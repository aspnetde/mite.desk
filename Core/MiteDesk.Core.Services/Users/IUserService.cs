/****************************************************************
 * Copyright (c) 2009 69° media solutions - All rights reserved *
 * 69 Grad OHG - Forsterstraße 100 - 90441 Nuernberg - Germany  *
 ***************************************************************/

using System.Collections.Generic;
using WinMite.Core.Model;

namespace WinMite.Core.Services
{
    public interface IUserService
    {
        User GetUser();
        Dictionary<string, string> UpdateUser(User user);
    }
}
