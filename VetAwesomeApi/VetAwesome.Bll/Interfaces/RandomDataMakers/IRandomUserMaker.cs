using VetAwesome.Bll.Enums;
using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.Interfaces.RandomDataMakers
{
    public interface IRandomUserMaker
    {
        UserEntity MakeUser(RoleType userRole);
    }
}
