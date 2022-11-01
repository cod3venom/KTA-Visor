using KTA_Visor.module.Managemnt.module.users.view;
using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.entity;
using KTAVisorAPISDK.module.user.service;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.users.handler
{
    public class UsersUIHandler
    {
        private readonly UsersView _usersView;
        private readonly UsersService _usersService;
        private readonly UserService _userService;
        public UsersUIHandler(UsersView usersView)
        {
            this._usersView = usersView;
            this._usersService = new UsersService();
            this._userService = new UserService();
            this.hookEvents();
        }

        private void hookEvents()
        {
        }

        public void Load()
        {
            Thread loadingThread = new Thread(async () =>
            {
                List<UserEntity.User> users = await this.allUsers();

                this.cleanTable();

                ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
                Parallel.ForEach(users, options, user =>
                {
                    this.addToTable(user);
                });

                if (users.Count > 0)
                {
                    this._usersView.UserInfoBoard.FromUser(users[0]);
                }
            });
            loadingThread.IsBackground = true;
            loadingThread.Start();
        }


        public void LoadSelectedUserById(int id)
        {
            Thread thr = new Thread(async () =>
            {
                UserEntity user = await this._userService.findUserById(id);
                this._usersView.UserInfoBoard.FromUser(user.data);
            });
            thr.IsBackground = true;
            thr.Start();
        }

        public void Create(CreateUserRequestTObject request)
        {
            Thread createThread = new Thread((ThreadStart) =>
            {
                this._usersView.Invoke((MethodInvoker)async delegate
                {
                    UserEntity newUser = await this._userService.create(request);
                    if (newUser.data == null)
                    {
                        MetroMessageBox.Show(this._usersView, "Nie udało się utworzyć nowego użytkownika, skontaktuj się z Administratorem", "Tworzenie użytkownika");
                    }
                    else
                    {
                        this.Load();
                    }
                });
            });

            createThread.IsBackground = true;
            createThread.Start();
        }

        public void Edit(int id, EditUserRequestTObject request)
        {
            Thread editThread = new Thread((ThreadStart) =>
            {
                this._usersView.Invoke((MethodInvoker) async delegate
                {
                    UserEntity editedUser = await this._userService.edit(id, request);
                    if (editedUser.data == null)
                    {
                        MetroMessageBox.Show(this._usersView, "Nie udało się edytować wybranego użytkownika, skontaktuj się z Administratorem", "Tworzenie użytkownika");
                    }
                    else
                    {
                        this.Load();
                        MetroMessageBox.Show(this._usersView, "Użytkownik został zmodyfikowany", "Edycja użytkownika");
                    }
                });
            });

            editThread.IsBackground = true;
            editThread.Start();
        }

        public void Delete(int id)
        {
            Thread editThread = new Thread((ThreadStart) =>
            {
                this._usersView.Invoke((MethodInvoker)async delegate
                {
                    DialogResult result = MetroMessageBox.Show(this._usersView, "Czy na pewno chcesz skasować wybranego użytkownika", "Skasowanie użytkownika", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No){
                        return;
                    }

                    _ = this._userService.delete(id);
                    this.Load();
                });
            });

            editThread.IsBackground = true;
            editThread.Start();
        }


        private async Task<List<UserEntity.User>> allUsers()
        {
            UserEntity users = await this._usersService.allUsers();
            if (users.datas == null)
            {
                return new List<UserEntity.User>();
            }

            return users.datas;
        }
 

        private void cleanTable()
        {
            if (!this._usersView.IsHandleCreated)
            {
                return;
            }
            this._usersView.Table.Invoke((MethodInvoker)delegate
            {
                this._usersView.Table.DataTable.Rows.Clear();
            });
        }

        private void addToTable(UserEntity.User user)
        {
            this._usersView.Table.Invoke((MethodInvoker)delegate
            {
                this._usersView.Table.Row.Add(
                    user.id,
                    user.firstName,
                    user.lastName,
                    user.email,
                    user.camCustomId,
                    user.badgeId,
                    user.createdAt

               );
            });
        }
    }
}
