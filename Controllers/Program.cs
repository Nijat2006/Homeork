using Core.Constant;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupController _groupController = new GroupController();

            Console.WriteLine("-----------------------------");

            while (true)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "1 - Create Group");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "2 - Update Group");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "3 - delete Group");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "4 - GetGroup by name");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "5 - All Group ");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "6 - Create Student ");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "7-  Update Student ");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "8 - Delete Student ");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "9 - All Student by Group ");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "10 - GetStudent by Group");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "0 - Exit");

                Console.WriteLine("----");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select option");

                string number = Console.ReadLine();


                int selectedNumber;


                bool result = int.TryParse(number, out selectedNumber);


                if (result)
                {
                    if (selectedNumber >= 0 && selectedNumber <= 5)

                    {
                        switch (selectedNumber)
                        {
                            case (int)Options.CreateGroup:
                                _groupController.CreateGroup();
                                break;

                            case (int)Options.UpdateGroup:
                                _groupController.UpdateGroup();
                                break;

                            case (int)Options.DeleteGroup:
                                _groupController.DeleteGroup();
                                break;

                            case (int)Options.AllGroups:
                                _groupController.AllGroup();
                                break;

                            case (int)Options.GetGroupByName:
                                _groupController.GetGroupByName();
                                break;

                            case (int)Options.Exit:
                                _groupController.Exit();
                                return;

                            case (int)Options.CreateStudent:
                                _studentController.CreateStudent();
                                break;

                        }
                    }
                }



            }

        }
    }
}
