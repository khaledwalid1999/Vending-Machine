// See https://aka.ms/new-console-template for more information


using Vending_Machine;
int UserType;
List<Item> Items = new List<Item>()
{
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5),
    new Item("100 ml water bottle",1,"cold water bottle",ItemType.ColdDrink,5)
};
while (true)
{
    Console.WriteLine("");
    Console.WriteLine("Hello, \nenter 1 if you are a customer or 2 if you are an admin\nenter -1 to quit");
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out UserType))
        {
            if (UserType == 1 || UserType == 2 || UserType == -1)
            {
                break;
            }
        }
        Console.WriteLine("Please enter a valid number");
    }
    if (UserType == -1) { break; }

}
