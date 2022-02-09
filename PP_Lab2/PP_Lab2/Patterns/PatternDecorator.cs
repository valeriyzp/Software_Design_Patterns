namespace PP_Lab2.Patterns
{
    public interface IHuman
    {
        public string showName();
        public string showСlothes();
    }

    public class Human : IHuman
    {
        string Name { get; set; }

        public Human(string name)
        {
            Name = name;
        }

        public string showName()
        {
            return Name;
        }

        public string showСlothes()
        {
            return Name + " wearing:";
        }
    }

    public class HumanDecorator : IHuman
    {
        private IHuman _Wrapee {get; set;}
    
        public HumanDecorator(IHuman wrapee)
        {
            _Wrapee = wrapee;
        }

        public string showName()
        {
            return _Wrapee.showName();
        }

        public string showСlothes()
        {
            return _Wrapee.showСlothes();
        }
    }

    public class FootDecorator : HumanDecorator, IHuman
    {
        public string FootClothes { get; set; }

        public FootDecorator(IHuman wrapee, string footClothes) : base(wrapee)
        {
            FootClothes = footClothes;
        }

        new public string showСlothes()
        {
            string res = base.showСlothes() + "\nOn foot " + FootClothes; 
            return res;
        }
    }

    public class BodyDecorator : HumanDecorator, IHuman
    {
        public BodyDecorator(IHuman wrapee) : base(wrapee) { ;}

        new public string showСlothes()
        {
            string res = base.showСlothes() + "\nOn body Jacket";
            return res;
        }
    }
}
