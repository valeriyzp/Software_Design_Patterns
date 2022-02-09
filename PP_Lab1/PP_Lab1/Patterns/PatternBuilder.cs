using System.Collections.Generic;

namespace PP_Lab1.Patterns
{
    public class Pizza
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public Pizza()
        {
            Ingredients = new List<string>();
        }
        public override string ToString()
        {
            string result = Name + ": ";
            foreach (string ingredient in Ingredients)
                result += (ingredient + ", ");
            return result.TrimEnd(new char[] { ',', ' '});
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public Recipe()
        {
            Ingredients = new List<string>();
        }
        public override string ToString()
        {
            string result = Name + ": ";
            foreach (string ingredient in Ingredients)
                result += (ingredient + ", ");
            return result.TrimEnd(new char[] { ',', ' ' });
        }
    }

    public interface IPizzaMaker
    {
        void reset();
        void SetName(string name);
        void SetDough(string dough);
        void SetCheese(string cheese);
        void SetSausage(string sausage);
    }

    public class RecipePizzaMaker : IPizzaMaker
    {
        public Recipe recipe { get; set; }
        public void reset()
        {
            recipe = new Recipe();
        }

        public void SetName(string name)
        {
            recipe.Name = name;
        }

        public void SetDough(string dough)
        {
            recipe.Ingredients.Add(dough);
        }
        public void SetCheese(string cheese)
        {
            recipe.Ingredients.Add(cheese);
        }
        public void SetSausage(string sausage)
        {
            recipe.Ingredients.Add(sausage);
        }
        public Recipe getRecipe()
        {
            return recipe;
        }
    }

    public class PizzaMaker : IPizzaMaker
    {
        public Pizza pizza { get; set;}
        public void reset()
        {
            pizza = new Pizza();
        }
        public void SetName(string name)
        {
            pizza.Name = name;
        }
        public void SetDough(string dough)
        {
            pizza.Ingredients.Add(dough);
        }
        public void SetCheese(string cheese)
        {
            pizza.Ingredients.Add(cheese);
        }
        public void SetSausage(string sausage)
        {
            pizza.Ingredients.Add(sausage);
        }
        public Pizza getPizza()
        {
            return pizza;
        }
    }

    public class Baker
    {
        public void MakePepperoni(IPizzaMaker pizzaMaker)
        {
            pizzaMaker.reset();
            pizzaMaker.SetName("Pepperoni");
            pizzaMaker.SetDough("Wheat bread");
            pizzaMaker.SetCheese("Mozzarella");
            pizzaMaker.SetSausage("Smoked sausage");
        }

        public void MakeMargarita(IPizzaMaker pizzaMaker)
        {
            pizzaMaker.reset();
            pizzaMaker.SetName("Margarita");
            pizzaMaker.SetDough("Wheat bread");
            pizzaMaker.SetCheese("Parmezan");
        }
    }
}
