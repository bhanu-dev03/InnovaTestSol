using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaSolTest.Common
{
    public static class ApiEndPointConstants
    {
        public static readonly string SignUpApiUrl="api/user/signup";
        public static readonly string SignInApiUrl = "api/user/signin";
        public static readonly string UpdateApiUrl = "api/user/update";
        public static readonly string VerifyUserApiUrl = "api/user/verify";
        public static readonly string GetUserApiUrl = "api/user/details";

    }

    public static class WebEndPointConstants
    {
        public static readonly string VerifyUserUrl = "user/verify/";
    }
}
