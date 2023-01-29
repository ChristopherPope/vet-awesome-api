using AutoMapper;
using Microsoft.AspNetCore.Http;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;
        protected readonly IHttpContextAccessor httpAccessor;

        public BaseService(IUnitOfWork uow
            , IMapper mapper
            , IHttpContextAccessor httpAccessor)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.httpAccessor = httpAccessor;
        }
    }
}
