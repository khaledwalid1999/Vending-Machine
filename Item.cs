using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    internal class Item
    {

        private string Name = "";
        private double Price;
        private string ItemDesc = "";
        private ItemType Type;
        private int Qty;

        public Item(string name, double price, string itemDesc, ItemType type, int qty)
        {
            Name = name;
            Price = price;
            ItemDesc = itemDesc;
            Type = type;
            Qty = qty;
        }
    }
    enum ItemType
    {
        HotDrink,
        ColdDrink,
        Snack
    }
}
