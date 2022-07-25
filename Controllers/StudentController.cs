using Core.Entites;
using Core.Helpers;
using DataAccess.Implementations.Repositories;
using DataAccess.Implementations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Controller
{
    public class StudentController
    {
        public class StudentController
        {
            private StudentRepository _studentRepository;

            private GroupRepository _groupRepository;

            private Student student;

            public IEnumerable<object> Groups { get; private set; }

            public StudentController()
            {
                _studentRepository = new StudentRepository();

                _studentRepository = new StudentRepository();
            }
            #region CreateStudent
            public void CreateStudent()
            {
                var groups = _groupRepository.GetAll();

                if (groups.Count != 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student name:");

                    string name = Console.ReadLine();

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student surname:");

                    string surname = Console.ReadLine();

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All groups");

                    foreach (var group in Groups)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
                    }
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name:");
                    string groupName = Console.ReadLine();


                    var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());

                    if (dbGroup != null)
                    {
                        if (dbGroup.MaxSize > dbGroup.CurrentSize)
                        {
                            var student = new Student
                            {
                                Name = name,
                                Surname = surname,
                                Group = dbGroup,
                            };
                            dbGroup.CurrentSize++;

                            _studentRepository.Create(student);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, text: $"Name:{student.Name}, Surname:{student.Surname}, Age:{student.Age}, Group:{student.Group}");
                        }
                        else
                        {
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Group is full, max size of group {dbGroup.MaxSize}");
                            }
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Including group doesn't exist");
                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Including group doesn't exist");
                }





            }
            #endregion

            #region GetAllStudentsByGroup

            public void GetAllStudentsByGroup()
            {

                var groups = _groupRepository.GetAll();


            GroupAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");

                foreach (var group in Groups)

                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
                }




                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name:");

                string groupName = Console.ReadLine();

                var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
                if (dbGroup != null)
                {
                    var groupStudents = _studentRepository.GetAll(s => s.Group.Id == dbGroup.Id);

                    if (groupStudents.Count != 0)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All students of the group");


                        foreach (var groupStudent in groupStudents)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{groupStudent.Name} {groupStudent.Surname} {groupStudent.Age}");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no student in this group - {dbGroup.Name}");
                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Including group doesn't exist");
                }
                goto GroupAllList;

            }

            #endregion

            #region DeleteStudent
            public void DeleteStudent()
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter student name: ");
                string name = Console.ReadLine();
                var student = _studentRepository.Get(s => s.Name.ToLower() == s.Name.ToLower());
                if (student != null)
                {
                    _studentRepository.Delete(student);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This student doesn't exist");
                }
            }
            #endregion

            #region

            public void UpdateStudent()
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter student name");
                string name = Console.ReadLine();

                var group = _groupRepository.Get(s => s.Name.ToLower() == name.ToLower());

                if (group != null)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new student name:");
                    string newName = Console.ReadLine();

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student surname:");
                    string surname = Console.ReadLine();

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student age:");
                    string age = Console.ReadLine();

                    byte studentAge;
                    bool result = byte.TryParse(age, out studentAge);
                    if (result)
                    {
                        var newStudent = new Student
                        {
                            Name = name,
                            Surname = surname,
                            Age = studentAge,
                        };
                        _studentRepository.Update(student);

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{name}, Surname: {surname}, Age: {age}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct student name:");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct student surname:");
                }
            }

            #endregion
            #region DeleteStudent
            public void DeleteStudent()
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter student name: ");
                string name = Console.ReadLine();
                var student = _studentRepository.Get(s => s.Name.ToLower() == s.Name.ToLower());
                if (student != null)
                {
                    _studentRepository.Delete(student);


                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This student doesn't exist");
                }
            }
            #endregion

            #region

            public void UpdateStudent()
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter student name");
                string name = Console.ReadLine();

                var group = _groupRepository.Get(s => s.Name.ToLower() == name.ToLower());

                if (group != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter new student name:");
                    string newName = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student surname:");
                    string surname = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student age:");
                    string age = Console.ReadLine();

                    byte studentAge;
                    bool result = byte.TryParse(age, out studentAge);
                    if (result)
                    {
                        var newStudent = new Student
                        {
                            Name = name,
                            Surname = surname,
                            Age = studentAge,
                        };
                        _studentRepository.Update(student);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{name}, Surname: {surname}, Age: {age}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct student name:");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct student surname:");
                }
            }

            #endregion

        }
    }
}
    

           