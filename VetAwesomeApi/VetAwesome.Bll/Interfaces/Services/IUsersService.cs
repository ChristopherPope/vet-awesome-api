using VetAwesome.Bll.Dtos;

namespace VetAwesome.Bll.Interfaces.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetUsers();
        void Authenticate(int userId);
    }
}
