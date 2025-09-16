using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

class Program {
    public interface ICoffee {
        string GetDescription();
        double GetCost();
    }

    public class SimpleCoffee : ICoffee {
        public string GetDescription() => "Чёрный кофе";
        public double GetCost() => 50.0;
    }

    public abstract class CoffeeDecorator : ICoffee {
        protected ICoffee coffee;
        public CoffeeDecorator(ICoffee coffee) {
            this.coffee = coffee;
        }
        public virtual string GetDescription() => coffee.GetDescription();
        public virtual double GetCost() => coffee.GetCost();
    }

    public class SugarDecorator : CoffeeDecorator {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", с сахаром";
        public override double GetCost() => coffee.GetCost() + 5.0;
    }

    public class MilkDecorator : CoffeeDecorator {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", с молоком";
        public override double GetCost() => coffee.GetCost() + 10.0;
    }

    static void Main() {
        ICoffee coffee = new SimpleCoffee();
        coffee = new SugarDecorator(coffee);
        coffee = new SugarDecorator(coffee);
        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine("Цена: " + coffee.GetCost() + " грн.");
    }
}