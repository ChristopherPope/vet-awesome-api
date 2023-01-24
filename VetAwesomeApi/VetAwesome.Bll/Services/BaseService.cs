using AutoMapper;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;

        public BaseService(IUnitOfWork uow
            , IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
    }
}
