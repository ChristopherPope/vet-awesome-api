using VetAwesome.Bll.Enums;
using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.RandomDataMakers
{
    public class RandomUserMaker : RandomDataMaker, IRandomUserMaker
    {
        private readonly IRandomNameMaker nameMaker;

        public RandomUserMaker(IRandomNameMaker nameMaker)
        {
            this.nameMaker = nameMaker;
        }

        public UserEntity MakeUser(UserRoleType userRole)
        {
            return new UserEntity
            {
                Name = $"{nameMaker.MakeFirstName()} {nameMaker.MakeLastName()}",
                UserRoleId = (int)userRole
            };
        }
    }
}
