using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0 || this.Components == null)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + (this.Components.Sum(x => x.OverallPerformance) / this.Components.Count);
            }
        }

        public override decimal Price
        {
            get
            {
                return base.Price + this.Components.Sum(x => x.Price) + this.Peripherals.Sum(x => x.Price);
            }
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();


        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(
                    $"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(
                    $"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}."
                );
            }

            components.Remove(component);
            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}."
                );
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}."
                );
            }

            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            if (this.Peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance (0.00):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Average(x => x.OverallPerformance)}):");

                foreach (var peripheral in this.Peripherals)
                {
                    sb.AppendLine($"  {peripheral.ToString()}");
                }
            }
            

            return sb.ToString().TrimEnd();
        }
    }
}
