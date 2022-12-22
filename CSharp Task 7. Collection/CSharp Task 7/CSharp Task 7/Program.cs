using System;
using System.Collections.Generic;
using System.Text;


namespace CSharpTask7
{
    class Program
    {
        static void Main()
        {
            GetUsersCommand();
        }

        static void GetUsersCommand()
        {
            while (true)
            {
                Console.WriteLine("Введите действие:\n" +
                    "1.Работа с листом\n" +
                    "2.Работа с телефонной книгой\n" +
                    "3.Проверка повторов\n" +
                    "4.Работа с адресной книгой\n" +
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
                        Task1();
                        break;
                    }
                case 2:
                    {
                        Task2();
                        break;
                    }

                case 3:
                    {

                        Task3();
                        break;
                    }
                case 4:
                    {
                        Task4();
                        break;
                    }

                default: break;
            }
        }

        static void Task1()
        {
            MyIntList myList = new MyIntList(100, 0, 100);
            Console.WriteLine("100 случайных чисел от 0 до 100:");
            Console.WriteLine(myList.ConvertToString());
            myList.RemoveData(25, 50);
            Console.WriteLine("Удалены числа от 25, до 50-ти:");
            Console.WriteLine(myList.ConvertToString());
        }

        static void Task2()
        {

            TelephoneDictionary telephoneDictionary = new TelephoneDictionary();
            string note = "";

            while (true)
            {

                Console.WriteLine("Введите действие:\n" +
                    "1.Ввести номер\n" +
                    "2.Найти владельца номера\n" +
                    "0.Выход в меню");

                int actionNumber = 0;
                actionNumber = TryParseCustom.TryReadLineInt(Console.ReadLine());

                if (actionNumber == 0)
                {
                    break;
                }

                switch (actionNumber)
                    {
                    case 1:
                        {

                            Console.WriteLine("Введите номер телефона без +7 и пробелов и ФИО через запятую.");

                            note = Console.ReadLine();

                            telephoneDictionary.AddNote(note);
                            break;
                        }
                    case 2:
                    {
                        Console.WriteLine("Введите номер телефона без +7 и пробелов, чтобы найти владельца");
                        note = Console.ReadLine();

                        Console.WriteLine(telephoneDictionary.GetNameByNumber(note));
                        break;
                    }
                }
            }
        }


        static void Task3()
        {
            HashSet<int> set = new HashSet<int>();
            while (true)
            {
                Console.WriteLine("Введите число, чтобы добавить число в множество. Введите -1, чтобы выйти в меню");

                int number;

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number == -1)
                        break;

                    if (set.Contains(number))
                    {
                        Console.WriteLine("Число уже есть в множестве");
                    }
                    else 
                    {
                        set.Add(number);
                        Console.WriteLine("Число успешно добавлено");
                    }
                }
                else 
                { 
                    if(number == -1) 
                        break;

                    Console.WriteLine("Введено неправильное число"); 
                }
            }
        }

        static void Task4()
        {

            TelephoneBook book = new TelephoneBook();

            book.AddContact(new TelephoneContact("Имя", "street", "house", "flatnum", "mobileP", "flatPhone"));
            book.AddContact(new TelephoneContact("Имя1", "street1", "house1", "flatnum1", "mobileP1", "flatPhone1"));
            book.AddContact(new TelephoneContact("Имя2", "street2", "house2", "flatnum2", "mobile2", "flatPhone2"));
            book.AddContact(new TelephoneContact("Имя3", "street3", "house3", "flatnum2", "mobileP3", "flatPhone3"));

            FileHandler.WriteLineInFile("_xmlTest.xml", book.SerializeAllDataToXML(), false);

            Console.WriteLine("Данные сохранены в bin\\Debug\\net6.0\\_xmlTest.xml");
            book.ClearData();

            /* ввод данных с клавиатуры
            while (true)
            {

                Console.WriteLine("Введите действие:\n" +
                    "1.Ввести данные\n" +
                    "2.Сохранить данные в XML\n" +
                    "0.Выход в меню");

                int actionNumber = 0;
                actionNumber = TryParseCustom.TryReadLineInt(Console.ReadLine());

                if (actionNumber == 0)
                {
                    break;
                }

                switch (actionNumber)
                {
                    case 1:
                    {

                        Console.WriteLine("Введите номер ФИО:");

                        string name = Console.ReadLine(); ;
                        Console.WriteLine("Введите название улицы:");
                        string street = Console.ReadLine();
                        Console.WriteLine("Введите номер дома:");
                        string houseNumber = Console.ReadLine();
                        Console.WriteLine("Введите номер квартиры:");
                        string flatNumber = Console.ReadLine();
                        Console.WriteLine("Введите номер мобильного телефона:");
                        string mobilePhone = Console.ReadLine();
                        Console.WriteLine("Введите номер домашнего телефона:");
                        string flatPhone = Console.ReadLine();
                        book.AddContact(new TelephoneContact(name,street,houseNumber,flatNumber,mobilePhone,flatPhone));
                        break;
                    }

                    case 2:
                    {
                        FileHandler.WriteLineInFile("_xmlTest.xml", book.SerializeAllDataToXML(), false);
                        Console.WriteLine("Данные сохранены в bin\\Debug\net6.0\\_xmlTest.xml");
                        break;
                    }
                }
            }
            */
        }
    }
}