using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.Interfaces.RandomDataMakers
{
    public interface IRandomCustomerMaker
    {
        CustomerEntity MakeCustomer();
    }
}
