namespace Vending_Machine
{
    struct Response_Str
    {
        public bool IsSuccessful { get; set; }
        public string ResponseMsg { get; set; }
        public double Price { get; set; }
    }

    internal class ItemList
    {
        public List<Item> Items = new()
{
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("Coffee Latte",2,"Hot Drink",ItemType.HotDrink,0),
    new Item("Lays Chips",1,"Potato Chips",ItemType.Snack,9),
    new Item("Turkey Sandwich",3,"Sandwich",ItemType.Snack,2),
    new Item("Snicker",1,"Chocolate Bar",ItemType.Snack,4)
};
        public void AddItem()
        {
            Item newItem = new();
            while (true)
            {
                Console.Write("Item name: ");
                newItem.Name = Console.ReadLine();
                if (newItem.Name == "")
                {
                    Console.WriteLine("--------------------\nName cannot be empty\n--------------------");
                }
                else { break; }
            }

            while (true)
            {
                Console.Write("Item description: ");
                newItem.ItemDesc = Console.ReadLine();
                if (newItem.ItemDesc == "")
                {
                    Console.WriteLine("---------------------------\nDescription cannot be empty\n---------------------------");
                }
                else { break; }
            }

            while (true)
            {
                Console.Write("Item price: ");
                if (double.TryParse(Console.ReadLine(), out double Price))
                {
                    if (Price > 0)
                    {
                        newItem.Price = Price;
                        break;
                    }
                    else { Console.WriteLine("-------------------------------\nPrice must be a positive number\n-------------------------------"); }
                }
                else
                {
                    Console.WriteLine("-------------------------------------\nPlease enter a valid number for price\n-------------------------------------");
                }

            }

            while (true)
            {
                Console.Write("Item Type enter:\n1- Cold drink\n2- Hot drink\n3- Snack\n");
                if (int.TryParse(Console.ReadLine(), out int type))
                {
                    if (type == 1)
                    {
                        newItem.Type = ItemType.HotDrink;
                        break;
                    }
                    else if (type == 2)
                    {
                        newItem.Type = ItemType.ColdDrink;
                        break;
                    }
                    else if (type == 3)
                    {
                        newItem.Type = ItemType.Snack;
                        break;
                    }
                    else { Console.WriteLine("------------------------------------\nPlease enter a valid number for type\n------------------------------------"); }
                }
                else
                {
                    Console.WriteLine("------------------------------------\nPlease enter a valid number for type\n------------------------------------");
                }
            }

            while (true)
            {
                Console.Write("Item Quantity: ");
                if (int.TryParse(Console.ReadLine(), out int qty))
                {
                    if (qty > 0)
                    {
                        newItem.Qty = qty;
                        break;
                    }
                    else { Console.WriteLine("----------------------------------\nQuantity must be a positive number\n----------------------------------"); }
                }
                else
                {
                    Console.WriteLine("----------------------------------------\nPlease enter a valid number for Quantity\n----------------------------------------");
                }

            }
            Console.WriteLine("---------------------------------\n" + newItem.Name + " Created successfully!!" + "\n---------------------------------");
            Items.Add(newItem);
        }

        public string RemoveItem(int index)
        {
            string? Name = Items[index].Name;
            Items.RemoveAt(index);
            return Name + "";
        }

        public string ToString(bool IsAdmin)
        {
            string listOfItems = "";
            foreach (var (item, i) in Items.Select((item, i) => (item, i)))
            {
                if (!IsAdmin)
                {
                    if (i % 2 != 0) { listOfItems += i + " - " + item.ToString(IsAdmin) + "\n"; }
                    else { listOfItems += i + " - " + item.ToString(IsAdmin) + "\t"; }
                }
                else { listOfItems += i + " - " + item.ToString(IsAdmin) + "\n"; }

            }

            return "Here is the list of items:\n" + listOfItems;
        }

        public int ItemCount() { return Items.Count; }

        public void Restock()
        {
            string? Name;
            while (true)
            {
                Console.Write("Enter the number of item to restock: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < Items.Count)
                    while (true)
                    {
                        Console.Write("Item Quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int qty))
                        {
                            if (qty > 0)
                            {
                                Items[index].Qty += qty;
                                break;
                            }
                            else { Console.WriteLine("----------------------------------\nQuantity must be a positive number\n----------------------------------"); }
                        }
                        else
                        {
                            Console.WriteLine("----------------------------------------\nPlease enter a valid number for Quantity\n----------------------------------------");
                        }
                    }
                else
                {
                    Console.WriteLine("----------------------------------\nPlease enter a valid item number!!\n----------------------------------");
                }
                Name = Items[index].Name;
                Console.WriteLine("--------------------------------------\n" + Name + " restocked successfully!\n--------------------------------------");
                break;
            }

        }


        public Response_Str BuyItem(double Money, int index)
        {
            Response_Str Response = new();
            if (Items[index].Qty < 1)
            {
                Response.ResponseMsg = "------------------\nSorry out of stock\n------------------";
                Response.IsSuccessful = false;
            }
            else if (Money < Items[index].Price)
            {
                Response.ResponseMsg = "----------------\nNot enough money\n----------------";
                Response.IsSuccessful = false;
            }
            else
            {
                Response.ResponseMsg = "----------------------------\n" + Items[index].Name + " dropped\n----------------------------";
                Response.IsSuccessful = true;
                if (Items[index].Type == (int)ItemType.HotDrink)
                {
                    Response.Price = ++Items[index].Price;
                }
                else { Response.Price = Items[index].Price; }
                Items[index].Qty -= 1;
            }
            return Response;
        }
    }
}

