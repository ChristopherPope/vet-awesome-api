using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.Interfaces.RandomDataMakers
{
    public interface IRandomHouseholdMaker
    {
        HouseholdEntity MakeHousehold();
    }
}
