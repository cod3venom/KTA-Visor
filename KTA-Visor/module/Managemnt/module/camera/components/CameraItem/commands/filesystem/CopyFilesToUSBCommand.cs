using Ionic.Zip;
using KTA_Visor_UI.component.custom.MessageWindow;
using KTA_Visor_UI.component.custom.Security.FileEncryption;
using KTA_Visor_UI.component.custom.Security.FileEncryption.events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.camera.components.CameraItem.commands.filesystem
{
    public class CopyFilesToUSBCommand
    {
        public static void Execute(string destinationDrivePath, string[] files)
        {

            int totalCopiedFiles = 0;
            string destZipeFilePath = string.Format("{0}\\archiwum_{1}.zip", destinationDrivePath, DateTime.Now.ToString("yyyy_M_D_H_m_s"));

            if (!Directory.Exists(destinationDrivePath))
            {
                new AlertWindow("Nie udało się wykryć wybrany nośnik");
                return;
            }
            
            FileEncryptionWithPasswordWindow fileEncryptionWindow = new FileEncryptionWithPasswordWindow();
            fileEncryptionWindow.OnPasswordAndRepeatedPasswordDoesntMatch += (delegate (object sender, EventArgs e)
            {
                new AlertWindow("Wprowadzone hasła są różne, proszę sprobować jeszcze raz");
                return;
            });
            fileEncryptionWindow.OnPasswordLengthIsLessThanAllowed += (delegate (object sender, EventArgs e)
            {
                new AlertWindow("Minimum długość hasła to 8 znaków");
                return;
            });

            fileEncryptionWindow.OnSaveFileEncryptionPasswords += (delegate (object sender, OnSaveFileEncryptionPasswordsEvent e)
            {
               using (ZipFile zipFile = new ZipFile(destinationDrivePath))
                {

                    zipFile.Password = e.Password;

                    foreach (string f in files)
                    {
                        FileInfo file = new FileInfo(f);

                        if (!file.Exists)
                        {
                            new AlertWindow("error", "Błąd przy kopiowaniu", string.Format(
                               "{0} prawdopodobnie został usunięty lub zmieniono mu lokalizacje przed rozpoczęciem procesu zgrywania plików",
                               file
                            ));
                            continue;
                        }                       

                        zipFile.AddFile(file.FullName);
                        totalCopiedFiles++;
                    }

                    zipFile.Save(destZipeFilePath);
                }
            });

            fileEncryptionWindow.ShowDialog();
            if (totalCopiedFiles == 0) 
            {
                new AlertWindow("error", "Błąd przy kopiowaniu", "Nie udało się skopiować żadnych plików");
                return;
            }

            new AlertWindow("error", "Kopowianie plików", string.Format(
                "Skopiowano {0} plików",
                totalCopiedFiles.ToString()
            ));
        }
    }
}
