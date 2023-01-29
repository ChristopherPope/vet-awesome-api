using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.RandomDataMakers
{
    public class RandomCustomerMaker : RandomDataMaker, IRandomCustomerMaker
    {
        private readonly IRandomNameMaker nameMaker;
        private readonly IRandomPhoneNumberMaker phoneNumberMaker;

        public RandomCustomerMaker(IRandomNameMaker nameMaker, IRandomPhoneNumberMaker phoneNumberMaker)
        {
            this.nameMaker = nameMaker;
            this.phoneNumberMaker = phoneNumberMaker;
        }

        public IEnumerable<CustomerEntity> MakeCoupleOrSingle()
        {
            var lastName = nameMaker.MakeLastName();
            var customers = new List<CustomerEntity>
            {
                new CustomerEntity
                {
                    Name = $"{nameMaker.MakeFemaleName()} {lastName}",
                    PhoneNumber = phoneNumberMaker.MakePhoneNumber()
                }
            };

            if (RandomBool)
            {
                customers.Add(new CustomerEntity
                {
                    Name = $"{nameMaker.MakeMaleName()} {lastName}",
                    PhoneNumber = phoneNumberMaker.MakePhoneNumber()
                });
            }

            return customers;
        }
    }
}
