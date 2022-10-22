using System;
using System.Text;


namespace CSharp_Task_5
{
    class MainProgram
    {
        static WorkersRepository repository;

        static void Main()
        {
            
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            // Read data and update repository
            repository = new WorkersRepository();
            repository.SavePath = "workers.cvs";
            repository.ReadDataFromFile();

            GetUsersCommand();
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
                        repository.AddWorker(GetWorkersDataFromConsole());
                        repository.SaveData();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите ID сотрудника");
                        repository.DeleteWorkerByID(TryParseCustom.TryReadLineInt(Console.ReadLine()));
                        repository.SaveData();
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Введите ID сотрудника");
                        Console.WriteLine(repository.OutputData(TryParseCustom.TryReadLineInt(Console.ReadLine())));
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine(repository.OutputData());
                        break;
                    }
                case 5:
                    repository.DeleteData();
                    break;
                case 6:
                    {
                        Console.WriteLine("Введите первую дату в формате dd/mm/yyyy");
                        DateTime firstDate = TryParseCustom.TryReadLineDataTime(Console.ReadLine());

                        Console.WriteLine("Введите вторую дату в формате dd/mm/yyyy");
                        DateTime secondDate = TryParseCustom.TryReadLineDataTime(Console.ReadLine());

                        Console.WriteLine(repository.OutputData(firstDate, secondDate));
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

                        repository.SortData(TryParseCustom.TryReadLineInt(Console.ReadLine()));
                        repository.SaveData();
                        break;
                    }

                default: break;
            }
        }


        static Worker GetWorkersDataFromConsole()
        {
            Worker worker = new Worker();

            Console.WriteLine("Введите ID сотрудника");
            worker.Id = TryParseCustom.TryReadLineInt(Console.ReadLine());

            Console.WriteLine("Введите ФИО сотрудника");
            worker.Name = Console.ReadLine();
          
            Console.WriteLine("Введите рост сотрудника");
            worker.Tall = TryParseCustom.TryReadLineFloat(Console.ReadLine());

            Console.WriteLine("Введите дату рождения сотрудника в формате dd/mm/yyyy");
            worker.BirthDate = TryParseCustom.TryReadLineDataTime(Console.ReadLine()).Date;
            worker.Old = DateTime.Now.Year - worker.BirthDate.Year;

            Console.WriteLine("Введите место рождения сотрудника");
            worker.BirthLocation = Console.ReadLine();

            worker.CreationTime = DateTime.Now;
            return worker;
        }
    }
}

