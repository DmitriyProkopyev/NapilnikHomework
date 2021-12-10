namespace Task2
{
    public class Good
    {
        public readonly string Name;

        public Good(string name) => Name = name;

        public override bool Equals(object obj)
        {
            if (obj is Good good)
                return good.Name == Name;

            return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
