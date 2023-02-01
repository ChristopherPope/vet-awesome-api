//using VetAwesome.Bll.Interfaces.RandomDataMakers;
//using VetAwesome.Bll.Interfaces.RandomEntityMaker;
//using VetAwesome.Dal.Entities;
//using VetAwesome.Dal.Interfaces;

//namespace VetAwesome.Bll.RandomDataMakers
//{
//    public class RandomHouseholdMaker : RandomDataMaker, IRandomHouseholdMaker
//    {
//        #region Names
//        private readonly List<string> streetNames = new()
//        {
//            "Lincoln Avenue",
//            "Fairway Drive",
//            "Magnolia Avenue",
//            "Cherry Street",
//            "Union Street",
//            "14th Street",
//            "Railroad Street",
//            "Cedar Court",
//            "5th Street North",
//            "Water Street",
//            "Evergreen Drive",
//            "Route 5",
//            "Monroe Street",
//            "Main Street",
//            "Belmont Avenue",
//            "Delaware Avenue",
//            "Route 70",
//            "Willow Drive",
//            "Winding Way",
//            "Main Street East",
//            "Charles Street",
//            "Linden Avenue",
//            "Creekside Drive",
//            "Aspen Drive",
//            "Route 29"
//        };
//        private readonly List<string> cityNames = new()
//        {
//            "San Francisco",
//            "Laredo",
//            "San Antonio",
//            "New York",
//            "Columbus",
//            "Chula Vista",
//            "Sacramento",
//            "Riverside",
//            "Baton Rouge",
//            "Seattle",
//            "Tucson",
//            "Henderson",
//            "Oakland",
//            "Norfolk",
//            "St. Paul",
//            "Albuquerque",
//            "Omaha",
//            "Garland",
//            "Chesapeake",
//            "Jersey City",
//            "Milwaukee",
//            "Chicago",
//            "Boston",
//            "Plano",
//            "San Jose"
//        };
//        #endregion
//        private List<StateEntity> stateEntities = new();
//        private readonly IRandomCustomerMaker customerMaker;
//        private readonly IRandomPetMaker petMaker;
//        private readonly IRandomPhoneNumberMaker phoneNumberMaker;
//        private readonly IUnitOfWork uow;

//        public RandomHouseholdMaker(IRandomCustomerMaker customerMaker,
//            IRandomPetMaker petMaker,
//            IRandomPhoneNumberMaker phoneNumberMaker,
//            IUnitOfWork uow)
//        {
//            this.customerMaker = customerMaker;
//            this.petMaker = petMaker;
//            this.phoneNumberMaker = phoneNumberMaker;
//            this.uow = uow;
//        }

//        public HouseholdEntity MakeHousehold()
//        {
//            if (!stateEntities.Any())
//            {
//                LoadStateEntities();
//            }

//            var household = new HouseholdEntity
//            {
//                StreetAddress1 = $"{GetRandomDigits(5)} {GetRandomElement(streetNames)}",
//                City = GetRandomElement(cityNames),
//                State = GetRandomElement(stateEntities),
//                ZipCode = MakeZipCode(),
//                PhoneNumber = phoneNumberMaker.MakePhoneNumber()
//            };

//            foreach (var customer in customerMaker.MakeCoupleOrSingle())
//            {
//                household.Customers.Add(customer);
//            }

//            var petCount = rand.Next(1, 5);
//            for (var i = 0; i < petCount; i++)
//            {
//                household.Pets.Add(petMaker.MakePet());
//            }

//            return household;
//        }

//        private void LoadStateEntities()
//        {
//            stateEntities = uow.States.ReadAll().ToList();
//        }

//        private string MakeZipCode()
//        {
//            var zipCode = GetRandomDigits(5);
//            while (zipCode.Length < 5)
//            {
//                zipCode += GetRandomDigits(1);
//            }

//            if (!RandomBool)
//            {
//                return zipCode;
//            }

//            var extension = GetRandomDigits(4);
//            while (extension.Length < 4)
//            {
//                extension += GetRandomDigits(1);
//            }
//            return $"{zipCode}-{extension}";
//        }
//    }
//}
