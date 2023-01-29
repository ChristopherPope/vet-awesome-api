namespace VetAwesome.Bll.RandomDataMakers
{
    public abstract class RandomDataMaker
    {
        protected readonly int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        protected readonly Random rand = new();

        protected bool RandomBool
        {
            get { return rand.Next(1, 101) > 50; }
        }

        public T GetRandomElement<T>(IEnumerable<T> elements)
        {
            return elements.ElementAt(rand.Next(0, elements.Count()));
        }

        public string GetRandomDigits(int maxDigits)
        {
            var digits = string.Empty;
            var numDigits = rand.Next(1, maxDigits + 1);
            while (digits.Length < numDigits)
            {
                digits += GetRandomElement(numbers).ToString();
            }

            return digits;
        }


    }
}
