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
        public List<Item> Items = new List<Item>()
{
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("Coffee Latte",2,"Hot Drink",ItemType.HotDrink,0),
    new Item("Lays Chips",1,"Potato Chips",ItemType.Snack,9),
    new Item("Turkey Sandwich",3,"Sandwich",ItemType.Snack,2),
    new Item("Snicker",1,"Chocolate Bar",ItemType.Snack,4)
};
        public void AddItem(Item x)
        {
            Items.Add(x);
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

        public string Restock(int index, int qty)
        {
            string? Name = Items[index].Name;
            Items[index].Qty += qty;
            return Name + "";
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
