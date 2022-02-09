using PP_Lab5.Tasks;
using System;

namespace PP_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            showTask1();
            showTask2();
        }

        static void showTask1()
        {
            Console.WriteLine("Task1: ");

            Baker ExperiencedBaker = new Baker("Experienced baker");
            Shoemaker ExperiencedShoemaker = new Shoemaker("Experienced shoemaker");
            Barkeeper ExperiencedBarkeeper = new Barkeeper("Experienced barkeeper");

            Clock BigBen = Clock.GetInstance();

            BigBen.Subscribe(ExperiencedBaker);
            BigBen.Subscribe(ExperiencedShoemaker);
            BigBen.Subscribe(ExperiencedBarkeeper);

            BigBen.SimulateAllDay();

            Console.WriteLine();
        }

        static void showTask2()
        {
            Console.WriteLine("Task2: ");

            Nicholas SaintNicholas = Nicholas.GetInstance();

            Child Valeriy = new Child("Valeriy");
            Child Maria = new Child("Maria");
            Child Ilon = new Child("Ilon");

            Valeriy.SendLetter(SaintNicholas, 10, 1);
            Maria.SendLetter(SaintNicholas, 10, 5);
            Ilon.SendLetter(SaintNicholas, 1, 10);

            SaintNicholas.CelebrateSaintNicholasDay();

            Console.WriteLine();
        }
    }
}
