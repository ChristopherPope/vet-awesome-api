using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.RandomDataMakers
{
    public class RandomCustomerMaker : RandomDataMaker, IRandomCustomerMaker
    {
        #region Names
        private readonly List<string> streetNames = new()
        {
            "Lincoln Avenue",
            "Fairway Drive",
            "Magnolia Avenue",
            "Cherry Street",
            "Union Street",
            "14th Street",
            "Railroad Street",
            "Cedar Court",
            "5th Street North",
            "Water Street",
            "Evergreen Drive",
            "Route 5",
            "Monroe Street",
            "Main Street",
            "Belmont Avenue",
            "Delaware Avenue",
            "Route 70",
            "Willow Drive",
            "Winding Way",
            "Main Street East",
            "Charles Street",
            "Linden Avenue",
            "Creekside Drive",
            "Aspen Drive",
            "Route 29"
        };
        private readonly List<string> cityNames = new()
        {
            "San Francisco",
            "Laredo",
            "San Antonio",
            "New York",
            "Columbus",
            "Chula Vista",
            "Sacramento",
            "Riverside",
            "Baton Rouge",
            "Seattle",
            "Tucson",
            "Henderson",
            "Oakland",
            "Norfolk",
            "St. Paul",
            "Albuquerque",
            "Omaha",
            "Garland",
            "Chesapeake",
            "Jersey City",
            "Milwaukee",
            "Chicago",
            "Boston",
            "Plano",
            "San Jose"
        };
        #endregion

        private readonly IRandomNameMaker nameMaker;
        private readonly IRandomPhoneNumberMaker phoneNumberMaker;
        private readonly List<StateEntity> stateEntities;

        public RandomCustomerMaker(IRandomNameMaker nameMaker,
            IRandomPhoneNumberMaker phoneNumberMaker,
            IUnitOfWork uow)
        {
            this.nameMaker = nameMaker;
            this.phoneNumberMaker = phoneNumberMaker;
            stateEntities = uow.States.ReadAll().ToList();
        }

        public CustomerEntity MakeCustomer()
        {
            var customer = new CustomerEntity
            {
                Name = $"{nameMaker.MakeFirstName()} {nameMaker.MakeLastName()}",
                StreetAddress1 = $"{GetRandomDigits(5)} {GetRandomElement(streetNames)}",
                City = GetRandomElement(cityNames),
                State = GetRandomElement(stateEntities),
                ZipCode = MakeZipCode(),
                CellPhone = phoneNumberMaker.MakePhoneNumber()
            };

            if (RandomBool)
            {
                customer.HomePhone = phoneNumberMaker.MakePhoneNumber();
            }
            if (RandomBool)
            {
                customer.WorkPhone = phoneNumberMaker.MakePhoneNumber();
            }

            return customer;
        }

        private string MakeZipCode()
        {
            var zipCode = GetRandomDigits(5);
            while (zipCode.Length < 5)
            {
                zipCode += GetRandomDigits(1);
            }

            if (!RandomBool)
            {
                return zipCode;
            }

            var extension = GetRandomDigits(4);
            while (extension.Length < 4)
            {
                extension += GetRandomDigits(1);
            }
            return $"{zipCode}-{extension}";
        }

    }
}
