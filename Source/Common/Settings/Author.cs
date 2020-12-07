namespace mbaaz.AdventOfCode2020.Common.Settings
{
    public class Author
    {
        public string Name { get; set; }
        public string NickName { get; set; }

        public Author()
        {
            
        }

        public Author(string name, string nickName)
        {
            Name = name;
            NickName = nickName;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(NickName))
                return "John Doe [@unknown]";

            if (string.IsNullOrEmpty(NickName))
                return Name;

            if (string.IsNullOrEmpty(Name))
                return $@"{NickName}";

            return $"{Name} [@{NickName}]";
        }
    }
}