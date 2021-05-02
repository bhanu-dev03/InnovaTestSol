
namespace InnovaSolTest.Common.Constants
{
    public static class RepositoryConstants
    {
        public static string GetAll = "select * from {0}";
        public static string Get = "select * from {0} where id ={1}";
        public static string sp_GetUser = "spGetUser";
        public static string sp_SaveUser = "spSaveUser";
        public static string sp_UpdateUser = "spUpdateUser";
        public static string sp_GetUsers = "spUsers";
        public static string sp_DeleteUser = "spDeleteUser";
        public static string sp_GetUserByEmailId = "spGetUserByEmailId";
    }
}
