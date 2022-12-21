using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
            Console.WriteLine(myList.ConvertToString());
            myList.RemoveData(25, 50);
            Console.WriteLine(myList.ConvertToString());
        }

        static void Task2()
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
        }


        static void Task3()
        {
            HashSet<int> set = new HashSet<int>();
            Console.WriteLine("Введите число");

            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (set.Contains(number))
                {
                    Console.WriteLine("Число успешно добавлено");
                }
                else { Console.WriteLine("Число уже есть в мнодестве"); }
            }
            else { Console.WriteLine("Введено неправильное число"); }

        }

        static void Task4()
        {
            TelephoneBook book = new TelephoneBook();
            FileHandler.WriteLineInFile("_xmlTest.xml", book.SerializeDataToXML(new TelephoneContact("Имя", "street", "house", "flatnum", "mobileP", "flatPhone")));

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

    class TelephoneContact
    {

        private string name;
        private string street;
        private string houseNumber;
        private string flatNumber;
        private string mobilePhone;
        private string flatPhone;

        public string Name { get => name; set => name = value; }
        public string Street { get => street; set => street = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }
        public string MobilePhone { get => mobilePhone; set => mobilePhone = value; }
        public string FlatPhone { get => flatPhone; set => flatPhone = value; }

        public TelephoneContact ()
        {

        }

        public TelephoneContact(string name, string street, string houseName, string flatNumber, string mobilePhone, string flatPhone)
        {
            Name = name;
            Street = street;
            HouseNumber= houseName;
            FlatNumber = flatNumber;
            MobilePhone = mobilePhone;
            FlatPhone = flatPhone;
        }

    }

    class TelephoneBook
    {
        private List<TelephoneContact> telephoneContacts= new List<TelephoneContact>();
        public List<TelephoneContact> TelephoneContacts { get => telephoneContacts; set => telephoneContacts = value; }

        public TelephoneBook()
        { }

        public TelephoneBook(TelephoneContact contact)
        {
            AddContact(contact);
        }

        TelephoneBook(List<TelephoneContact> telephoneContacts)
        {
            TelephoneContacts = telephoneContacts;
        }

        public void AddContact(TelephoneContact contact)
        {
            TelephoneContacts.Add(contact);
        }

        public void AddContact(string name, string street, string houseName, string flatNumber, string mobilePhone, string flatPhone)
        {
            TelephoneContacts.Add(new TelephoneContact(name, street, houseName, flatNumber, mobilePhone, flatPhone));
        }

        public string SerializeDataToXML(TelephoneContact contact)
        {
            XElement xmlPERSON = new XElement("PERSON");
            XElement xmlADDRESS = new XElement("ADDRESS");
            XElement xmlStreet = new XElement("Street");
            XElement xmlPHONES = new XElement("PHONES");
            XElement xmlHouseNumber = new XElement("HouseNumber");
            XElement xmlFlatNumber = new XElement("FlatNumber");
            XElement xmlMobilePhone = new XElement("MobilePhone");
            XElement xmlFlatPhone = new XElement("FlatPhone");

            XAttribute xmlNameAttr = new XAttribute("name", contact.Name);
            
            xmlPERSON.Add(xmlNameAttr);
            xmlStreet.Add(contact.Street);
            xmlFlatNumber.Add(contact.FlatNumber);
            xmlHouseNumber.Add(contact.HouseNumber);
            xmlMobilePhone.Add(contact.MobilePhone);
            xmlFlatPhone.Add(contact.FlatPhone);

            xmlADDRESS.Add(xmlStreet, xmlHouseNumber, xmlFlatNumber);
            xmlPHONES.Add(xmlMobilePhone, xmlFlatPhone);
            xmlPERSON.Add(xmlADDRESS, xmlPHONES);

            return xmlPERSON.ToString();
        }

    }
}