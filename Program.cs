// See https://aka.ms/new-console-template for more information
using Vending_Machine;

int CurrentUserType;
User CurrentUser = new();
ItemList ItemList = new();
int index;

while (true)
{
    Console.WriteLine("");
    Console.WriteLine("Hello enter \n1- for customer\n2- for admin\n9- to quit");
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out CurrentUserType))
        {
            if (CurrentUserType == 1 || CurrentUserType == 2 || CurrentUserType == 9)
            {
                if (CurrentUserType == (int)UserType.Admin)
                {
                    CurrentUser.UserType = UserType.Admin;
                    Console.WriteLine("-------------------\nWelcome Admin,\n");
                    Console.WriteLine(ItemList.ToString(CurrentUserType == (int)UserType.Admin));
                    while (true)
                    {
                        Console.WriteLine("\nChoose one of the following options:\n1- Add item\n2- Restock item\n3- Remove item\n4- Show items\n9- Quit");

                        if (int.TryParse(Console.ReadLine(), out index))
                        {


                            switch (index)
                            {
                                case 1:
                                    ItemList.AddItem();
                                    break;

                                case 2:
                                    ItemList.Restock();
                                    break;
                                case 3:
                                    while (true)
                                    {
                                        Console.Write("Enter the number of item to remove: ");
                                        if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < ItemList.ItemCount())
                                        {
                                            Console.WriteLine(ItemList.RemoveItem(index) + " removed successfully!");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("----------------------------------\nPlease enter a valid item number!!\n----------------------------------");
                                        }
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine(ItemList.ToString(CurrentUserType == (int)UserType.Admin));
                                    break;
                                case 9:
                                    break;
                                default:
                                    Console.WriteLine("----------------------------\nPlease choose a valid option\n----------------------------");
                                    break;
                            }
                        }
                        else { Console.WriteLine("----------------------------\nPlease choose a valid option\n----------------------------"); }
                        if (index == 9) { break; }

                    }


                }
                else if (CurrentUserType == (int)UserType.Customer)
                {
                    CurrentUser.UserType = UserType.Customer;
                    Console.WriteLine("-------------------\nWelcome Customer\n");
                    Console.WriteLine(ItemList.ToString(CurrentUserType == (int)UserType.Admin));
                    while (true)
                    {
                        Console.WriteLine("\nChoose one of the following options:\n1- Add money\n2- Buy item\n3- Get credit\n4- Show items\n5- Return change\n9- Quit");
                        if (int.TryParse(Console.ReadLine(), out index))
                        {


                            switch (index)
                            {
                                case 1:
                                    while (true)
                                    {
                                        Console.Write("Insert money: ");
                                        if (double.TryParse(Console.ReadLine(), out double money))
                                        {
                                            if (money > 0)
                                            {
                                                Console.WriteLine("------------------------------\n" + money + " added successfully,\ncurrent balance: " + CurrentUser.AddMoney(money) + "\n------------------------------");
                                                break;
                                            }
                                            else { Console.WriteLine("-------------------------------\nMoney must be a positive number\n-------------------------------"); }
                                        }
                                        else
                                        {
                                            Console.WriteLine("------------------------------\nEnter a valid number for Money\n------------------------------");
                                        }

                                    }
                                    break;

                                case 2:
                                    while (true)
                                    {
                                        Console.Write("Enter the number of item to buy: ");
                                        if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < ItemList.ItemCount())
                                        {
                                            Response_Str Response = ItemList.BuyItem(CurrentUser.GetCredit(), index);
                                            Console.WriteLine(Response.ResponseMsg);
                                            if (Response.IsSuccessful)
                                            {
                                                CurrentUser.Money -= Response.Price;
                                            }
                                            break;

                                        }
                                        else { Console.WriteLine("----------------------------------\nPlease enter a valid item number!!\n----------------------------------"); }
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("----------------------------------\nCurrent balance: " + CurrentUser.GetCredit() + " JD's\n----------------------------------");
                                    break;
                                case 4:
                                    Console.WriteLine(ItemList.ToString(CurrentUserType == (int)UserType.Admin));
                                    break;
                                case 5:
                                    Console.WriteLine("------------------------------\n" + CurrentUser.ReturnChange() + "\tJD's returned\n------------------------------");
                                    break;
                                case 9:
                                    break;
                                default:
                                    Console.WriteLine("----------------------------\nPlease choose a valid option\n----------------------------");
                                    break;
                            }
                        }
                        else { Console.WriteLine("----------------------------\nPlease choose a valid option\n----------------------------"); }
                        if (index == 9 || index == 5) { break; }
                    }
                }
                break;
            }
        }
        Console.WriteLine("----------------------------\nPlease choose a valid option\n----------------------------");
    }
    if (CurrentUserType == 9) { break; }

}
