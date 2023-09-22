using IonicApiGaner.Model.Models;

namespace IonicApiGamer.Model.ApiReturn;

public class UserListReturn : ResultReturn
{
    public List<UserModel> UserList { get; set; }
}
