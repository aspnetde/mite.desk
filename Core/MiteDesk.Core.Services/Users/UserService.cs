/****************************************************************
 * Copyright (c) 2009 69° media solutions - All rights reserved *
 * 69 Grad OHG - Forsterstraße 100 - 90441 Nuernberg - Germany  *
 ***************************************************************/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WinMite.Core.Data;
using WinMite.Core.Model;

namespace WinMite.Core.Services
{
    public class UserService : IUserService
    {

        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

        private readonly IUserRepository Repository;

        public User GetUser()
        {
            return Repository.GetUser();
        }

        public Dictionary<string, string> UpdateUser(User user)
        {

            Dictionary<string, string> errors = new Dictionary<string, string>();

            // Accountname angegeben?
            if(string.IsNullOrEmpty(user.AccountName) || user.AccountName.Trim().Length == 0)
                errors.Add("AccountName", "Bitte geben Sie den Account-Namen an.");

            // E-Mail-Adresse okay?
            if (string.IsNullOrEmpty(user.Email) || user.Email.Trim().Length == 0)
                errors.Add("Email", "Bitte geben Sie Ihre E-Mail-Adresse an.");
            else if (!new Regex(@"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,6}$").Match(user.Email).Success)
                errors.Add("Email", "Bitte geben Sie eine korrekte E-Mail-Adresse an.");

            // Passwort angegeben?
            if (string.IsNullOrEmpty(user.Password) || user.Password.Trim().Length == 0)
                errors.Add("Password", "Bitte geben Sie Ihr Passwort an.");

            if(errors.Count == 0)
            {
                Repository.UpdateUser(user);
            }

            return errors;

        }

    }
}
