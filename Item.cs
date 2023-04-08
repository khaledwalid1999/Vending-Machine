namespace Vending_Machine
{
    internal class Item
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? ItemDesc { get; set; }
        public ItemType Type { get; set; }
        public int Qty { get; set; }

        public Item() { }

        public Item(string name, double price, string itemDesc, ItemType type, int qty)
        {
            Name = name;
            Price = price;
            ItemDesc = itemDesc;
            Type = type;
            Qty = qty;
        }

        public string ToString(bool IsAdmin)
        {
            string ItemDetails;
            if (IsAdmin)
            {
                ItemDetails = "Name: " + Name + " Description: " + ItemDesc + " Type: " + Type.ToString() + " Price: " + Price + " JD's" + " (" + Qty + ") in stock";

            }
            else
            {
                ItemDetails = Name + " ";
                for (int i = Name.Length; i <= 20; i++)
                {
                    ItemDetails += ".";
                }
                if (Type == ItemType.HotDrink)
                {
                    ItemDetails +=
                    ++Price + " JD's";
                }
                else
                {
                    ItemDetails +=
                    Price + " JD's";
                }
            }
            return ItemDetails;
        }
    }
    enum ItemType
    {
        HotDrink,
        ColdDrink,
        Snack
    }
}
