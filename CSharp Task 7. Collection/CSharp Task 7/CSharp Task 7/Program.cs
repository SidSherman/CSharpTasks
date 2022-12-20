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
                        MyIntList myList = new MyIntList(100, 0, 100);
                        Console.WriteLine(myList.ConvertToString());
                        myList.RemoveData(25, 50);
                        Console.WriteLine(myList.ConvertToString());
                        break;
                    }
                case 2:
                    {
                        TelephoneDictionary telephoneDictionary = new TelephoneDictionary();
                        string note = "";
                        while (true)
                        {
                            Console.WriteLine("Введите номер телефона без +7 и пробелов и ФИО через запятую, чтобы закончить ввод введите 0");

                            note = Console.ReadLine();

                            if (note == "0")
                                break;

                            telephoneDictionary.AddNote(note);

                        }

                        Console.WriteLine("Введите номер телефона без +7 и пробелов, чтобы найти владельца");
                            note = Console.ReadLine();


                        Console.WriteLine(telephoneDictionary.GetNameByNumber(note));
                        break;
                    }

                case 3:
                    {
                        HashSet<int> set = new HashSet<int>();
                        Console.WriteLine("Введите число");

                        int number;
                        if(int.TryParse(Console.ReadLine(), out number))
                        {
                            if(set.Contains(number))
                                {
                                Console.WriteLine("Число успешно добавлено");
                            }
                            else { Console.WriteLine("Число уже есть в мнодестве"); }
                        }
                        else { Console.WriteLine("Введено неправильное число"); }

                        break;
                    }
                case 4:
                    {
                       
                        break;
                    }

                default: break;
            }
        }

    }

    class MyIntList
    {
        private List<int> list = new List<int>();

        public List<int> List { get => list; set => list = value; }

        public MyIntList() {}

        public MyIntList(int lenght = 100)
        {
            Random rand = new Random();

            for (int i = 0; i < lenght; i++)
            {
                list.Add(rand.Next());
            }
        }

        public MyIntList(int lenght = 100, int min = 0, int max = 100)
        {
            Random rand = new Random();

            for(int i = 0; i < lenght; i++)
            {
                list.Add(rand.Next(min, max));
            }
        }

        public void AddData(params int[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                list.Add(parameters[i]);
            }     
        }

        public void RemoveData(int min, int max)
        {
            list.RemoveAll(item => item > min && item < max);
        }

        public void RemoveData()
        {
            list.Clear();
        }

        public string ConvertToString(string separator)
        {
            string str = "";
            
            foreach(int number in list)
            {
                str = str + separator +  number.ToString();
            }
            return str;
        }

        public string ConvertToString()
        {
            string str = "";

            foreach (int number in list)
            {
                str = str + " " + number.ToString();
            }
            return str;
        }
    }

    class TelephoneDictionary
    {
        private Dictionary<string, string> note = new Dictionary<string, string>();

        public Dictionary<string, string> Note { get => note; set => note = value; }

        public TelephoneDictionary()
        {

        }

        public void AddNote(string input)
        {
            string[] noteArray = input.Split(",");
            if (noteArray.Length != 2)
                return;
            if (!TryParseCustom.VerifyNumber(noteArray[0]))
                return;

            Note.Add(noteArray[0], noteArray[1]);

        }

        public void AddNote(string number, string name)
        {
            if (!TryParseCustom.VerifyNumber(number))
                return;
            Note.Add(number, name);
        }

        public string GetNameByNumber(string number)
        {
            note.TryGetValue(number, out string name);

            if(name == null)
            {
                name = "Такого номера в телефонной книге нет";
            }

            return name;

        }

    }

}