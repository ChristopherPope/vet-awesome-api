namespace VetAwesome.Bll.Interfaces.RandomDataMakers
{
    public interface IRandomNameMaker
    {
        public string FirstName { get; }
        public string MaleName { get; }
        public string FemaleName { get; }
        public string LastName { get; }
    }
}
