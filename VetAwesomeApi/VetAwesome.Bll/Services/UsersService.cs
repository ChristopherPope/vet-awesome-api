using AutoMapper;
using VetAwesome.Bll.Dtos;
using VetAwesome.Bll.Interfaces.Services;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.Services
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public IEnumerable<User> GetUsers()
        {
            var query = uow.Users.ReadUsers();

            return mapper.ProjectTo<User>(query).ToList();
        }
    }
}
