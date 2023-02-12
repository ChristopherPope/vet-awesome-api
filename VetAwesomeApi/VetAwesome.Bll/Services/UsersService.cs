using AutoMapper;
using Microsoft.AspNetCore.Http;
using VetAwesome.Bll.Dtos;
using VetAwesome.Bll.Interfaces.Services;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.Services
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(IUnitOfWork uow,
            IMapper mapper,
            IHttpContextAccessor httpAccessor)
            : base(uow, mapper, httpAccessor)
        {
        }

        public void Authenticate(int userId)
        {
            httpAccessor.HttpContext.Session.SetInt32("UserId", userId);
        }

        public IEnumerable<User> GetUsers()
        {
            var query = uow.Users.ReadUsers();

            return mapper.ProjectTo<User>(query).ToList();
        }
    }
}
