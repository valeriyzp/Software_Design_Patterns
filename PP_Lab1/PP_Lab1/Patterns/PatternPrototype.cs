namespace PP_Lab1.Patterns
{
    public interface IComputer
    {
        string ToString();
        IComputer clone();
    }

    public abstract class Computer : IComputer
    {
        public string Model { get; set; }
        public abstract IComputer clone();
        public override string ToString()
        {
            return Model;
        }
        public Computer(Computer source)
        {
            this.Model = source.Model;
        }
        public Computer()
        {
            ;
        }
    }

    class DesktopComputer : Computer
    {
        public string EthernetAdapter { get; set; }
        public DesktopComputer(DesktopComputer source) : base(source) 
        {
            this.EthernetAdapter = source.EthernetAdapter;
        }
        public DesktopComputer()
        {
            ;
        }
        public override IComputer clone()
        {
            return new DesktopComputer(this);
        }
    }

    class Notebook : Computer
    {
        public string WiFiAdapter { get; set; }
        public Notebook(Notebook source) : base(source)
        {
            this.WiFiAdapter = source.WiFiAdapter;
        }
        public Notebook()
        {
            ;
        }
        public override IComputer clone()
        {
            return new Notebook(this);
        }
    }
}
