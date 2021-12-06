﻿using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> foods = new List<IBakedFood>();
        private List<IDrink> drinks = new List<IDrink>();
        private List<ITable> tables = new List<ITable>();
        private decimal totalIncome = 0;

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            foods.Add(food);
            return $"Added {food.Name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);
            return $"Added table number {table.TableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal bill = table.GetBill() + table.Price;
            totalIncome += bill;
            table.Clear();

            return $"Table: {table.TableNumber}\r\nBill: {bill}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var food = foods.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {table.TableNumber} ordered {food.Name}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var availableTable = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity > numberOfPeople);

            if (availableTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                availableTable.Reserve(numberOfPeople);
                return $"Table {availableTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
