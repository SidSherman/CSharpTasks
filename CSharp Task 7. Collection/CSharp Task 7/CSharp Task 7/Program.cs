using System;
using System.Text;

namespace CSharpTask7
{
    class Program
    {
        static void Main()
        {

        }



        static void GetUsersCommand()
        {
            while (true)
            {
                Console.WriteLine("Введите действие:\n" +
                    "1.Добавить запись в репозиторий\n" +
                    "2.Удалить запись об указанном сотруднике\n" +
                    "3.Вывести данные об указанном сотруднике\n" +
                    "4.Вывести все данные\n" +
                    "5.Стереть все данные\n" +
                    "6.Вывести записи, созданные в пределах указанных дат\n" +
                    "7.Отсортировать данные по параметру\n" +
                    "0.Выход из программы");

                int taskNumber = 0;
                taskNumber = TryParseCustom.TryReadLineInt(Console.ReadLine());

                SelectTask(taskNumber);


                if (taskNumber == 0)
                {
                    break;
                }
            }
        }

        static void SelectTask(int taskNumber)
        {
            switch (taskNumber)
            {
                case 1:
                    {
                      
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите ID сотрудника");
                     
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Введите ID сотрудника");
                       
                        break;
                    }
                case 4:
                    {
                       
                        break;
                    }
                case 5:
                    
                    break;
                case 6:
                    {
                      
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Введите номер параметра:\n" +
                                           "1.ID (по-умолчанию)\n" +
                                           "2.Дата создания записи\n" +
                                           "3.ФИО\n" +
                                           "4.Рост\n" +
                                           "5.Дата рождения\n" +
                                           "6.Место рождения\n"); 
                        
                        
                        break;
                    }

                default: break;
            }
        }




















    }
}