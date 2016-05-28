using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FileObmen.Models;

namespace FileObmen.Tools
{
    public class LogonManager
    {
        public static void SetLoggedUserInfo(HttpContextBase httpContext)
        {
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                LoggedUserInfo info = GetUserInfoFromDB(httpContext.User.Identity.Name);
                if (info == null)
                {
                    SignOutUser(httpContext);
                }
                else
                {
                    httpContext.User = CreateUserPrincipal(info);
                }
            }
        }

        private static UserPrincipal CreateUserPrincipal(LoggedUserInfo user)
        {
            var identity = new UserIdentity("DB", true, user.Login);
            return new UserPrincipal(identity, user);
        }

        private static LoggedUserInfo GetUserInfoFromDB(string userName)
        {
            var unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            var user = unitOfWork.Users.GetUser(userName);
            return new LoggedUserInfo
            {
                Login = user.Login, 
                Roles = new[] {user.Role.Name}
            };
        }

        private static void SignOutUser(HttpContextBase httpContext)
        {
            FormsAuthentication.SignOut();
        }
    }
}