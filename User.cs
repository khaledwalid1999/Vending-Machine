using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    enum UserType
    {
        Customer,
        Admin
    }
    internal class User
    {
        private UserType UserType;

        List<Item> Items = new List<Item>() {
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5)
};
    }

}
