using Core.Entites;
using Core.Helpers;
using DataAccess.Implementations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class GroupController
    {
        private GroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }



        #region    CreateGroup
        public void CreateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter group name");



            string name = Console.ReadLine();

        maxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter group max size");

            string size = Console.ReadLine();
            int maxSize;
            bool result = int.TryParse(size, out maxSize);




            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxSize,
                };


                var createdGroup = _groupRepository.Create(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} is succesfully created with max size - {createdGroup.MaxSize}");  
              }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max size");
                goto maxSize;

            }

          }
        #endregion

        #region UpdateGroup
        public void UpdateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name");
            string name = Console.ReadLine();



            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());

            if (group != null)
            {
                int oldSize = group.MaxSize;

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group name:");
                string newName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new group max size");
                string size = Console.ReadLine();

                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    var newGroup = new Group
                    {
                        Id = group.Id,
                        Name = newName,
                        MaxSize = maxSize
                    };
                    _groupRepository.Update(group);

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{name}, Max Size: {oldSize} is updated to Name:{newGroup.Name}, Max Size : {newGroup.MaxSize}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group size:");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct group name");
            }
        }


        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group name: ");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                _groupRepository.Delete(group);

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }
        }
        #endregion

        #region AllGroups

        public void AllGroups()
        {
            var groups = _groupRepository.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All groups");
            foreach (var group in groups)
            {
                Console.WriteLine($"Name:{group.Name}, Max Size:{group.MaxSize}");
            }
        }

        #endregion

        #region GetGroupByName
        public void GetGroupByName()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name:");
            string name = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{group.Name}, Max Size: {group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }
        }


        #endregion

        #region Exit
        public void Exit()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Thanks for using our application");
        }
        #endregion

        


    }
}




