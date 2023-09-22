using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Domain.Interfaces;

namespace IonicAPIGamer.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        User IUserRepository.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.CreateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
