using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.Interfaces.RandomDataMakers
{
    public interface IRandomDataMaker
    {
        CustomerEntity MakeCustomer(bool isMale, string? lastName = null);
    }
}
