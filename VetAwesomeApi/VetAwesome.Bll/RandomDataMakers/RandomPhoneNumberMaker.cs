using VetAwesome.Bll.Interfaces.RandomDataMakers;

namespace VetAwesome.Bll.RandomDataMakers
{
    public class RandomPhoneNumberMaker : RandomDataMaker, IRandomPhoneNumberMaker
    {
        #region Phone Numbers
        private readonly List<string> phoneNumbers = new()
        {
            "(765) 672-5153",
            "(894) 665-9706",
            "(959) 884-5875",
            "(885) 627-2881",
            "(624) 362-5570",
            "(841) 575-2288",
            "(421) 299-2107",
            "(645) 278-4056",
            "(301) 243-1221",
            "(269) 265-6491",
            "(490) 616-2627",
            "(376) 203-1024",
            "(898) 549-8756",
            "(335) 822-3627",
            "(519) 505-2241",
            "(291) 854-4379",
            "(682) 235-8187",
            "(866) 800-9359",
            "(892) 314-8082",
            "(499) 884-0985",
            "(425) 396-0113",
            "(971) 564-0493",
            "(594) 908-7295",
            "(222) 268-1881",
            "(583) 533-4985"
        };
        #endregion

        public string MakePhoneNumber()
        {
            return GetRandomElement(phoneNumbers);
        }
    }
}
