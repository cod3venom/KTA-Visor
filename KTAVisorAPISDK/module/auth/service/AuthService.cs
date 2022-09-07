﻿using KTAVisorAPISDK.module.auth.dto.request;
using KTAVisorAPISDK.module.auth.command;
using KTAVisorAPISDK.module.auth.entity;
using KTAVisorAPISDK.module.auth.repository;
using KTAVisorAPISDK.Shared.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.auth.service
{
    public class AuthService
    {
        private readonly AuthRepository authRepository;

        public AuthService()
        {
            this.authRepository = new AuthRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<bool> signUp(SignUpRequestTObject request) 
        {
            if (request.email == null)
            {
                throw new ArgumentNullException(nameof(request.email) + " can't be empty");
            }

            if (request.firstName == null)
            {
                throw new ArgumentNullException(nameof(request.firstName) + " can't be empty");
            }

            if (request.lastName == null)
            {
                throw new ArgumentNullException(nameof(request.lastName) + " can't be empty");
            }

            if (request.password == null)
            {
                throw new ArgumentNullException(nameof(request.password) + " can't be empty");
            }

            try
            {
                HttpResponseMessage result = await this.authRepository.signUp(request);
                string responseBody = await result.Content.ReadAsStringAsync();
                SignUpEntity signUp = JsonConvert.DeserializeObject<SignUpEntity>(responseBody);

                if (signUp == null || signUp.data.token == null)
                {
                    throw new Exception("Unable to sign up, please try later");
                }

                SaveSessionCommand.Execute(signUp.data.token);

                return (signUp.data.token != null);

            }
            catch(Exception)
            {
                throw new Exception("Something went wrong");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<SignInEntity> signIn(SignInRequestTObject request)
        {
            if (request.email == null)
            {
                throw new BadRequestException(nameof(request.email) + " can't be empty");
            }

            if (request.password == null)
            {
                throw new BadRequestException(nameof(request.password) + " can't be empty");
            }

            try
            {
                HttpResponseMessage result = await this.authRepository.signIn(request);
                string responseBody = await result.Content.ReadAsStringAsync();
                SignInEntity sisgnIn = JsonConvert.DeserializeObject<SignInEntity>(responseBody);

                if (sisgnIn == null || sisgnIn?.data?.jwt == null)
                {
                    throw new WrongCredentialsException("Unable to sign-in, please try later");
                }

                SaveSessionCommand.Execute(sisgnIn.data.jwt);

                return sisgnIn;

            }
            catch (Exception)
            {
                throw new Exception("Something went wrong");
            }

        }
    }
}