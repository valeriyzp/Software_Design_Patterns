using System;
using System.Collections.Generic;

namespace PP_Lab2.Patterns
{
    public interface IPackage
    {
        public void showInfo();
    }

    public class Package: IPackage
    {
        public string Name { get; set; }

        public Package(String name)
        {
            Name = name;
        }

        public void showInfo()
        {
            Console.WriteLine(Name);
        }
    }

    public class PackageBox : IPackage
    {
        string Name { get; set; }
        public List<IPackage> Packages { get; set; }

        public PackageBox(string name)
        {
            Packages = new List<IPackage>();
            Name = name;
        }

        public void showInfo()
        {
            Console.WriteLine(Name + '*');
            foreach (IPackage package in Packages)
            {
                package.showInfo();
            }
        }

        public void add(IPackage package)
        {
            Packages.Add(package);
        }

        public void remove(IPackage package)
        {
            Packages.Remove(package);
        }
    }
}
