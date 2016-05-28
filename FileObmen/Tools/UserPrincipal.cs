using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace FileObmen.Tools
{
    public class UserPrincipal : GenericPrincipal
    {
        public LoggedUserInfo UserInfo { get; private set; }

        public UserPrincipal(IIdentity identity, LoggedUserInfo userInfo)
            : base(identity, userInfo.Roles)
        {
            UserInfo = userInfo;
        }
    }
}