using System;
using System.Text;


namespace CSharp_Task_5
{
    class MainProgram
    {
         static void Main()
        {

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            while (true)
            {
                int taskNumber = 0;

                while (true)
                {
                    Console.WriteLine("Введите действие:\n" +
                        "1.Добавить запись в файл\n" +
                        "2.Вывести данные на экран\n" +
                        "3.Стереть данные\n" +
                        "0.Выход из программы");
                    if (!int.TryParse(Console.ReadLine(), out taskNumber))
                    {
                        Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                        Console.ReadLine();
                        continue;
                    }
                    else break;
                }
                switch(taskNumber)
                {
                    case 1:
                        {
                            WriteFile("workers.cvs", CreateWorker().ReadValues("#"));
                            break;
                        }
                    case 2:
                        {
                            ReadFile("workers.cvs");
                            break;
                        }
                    case 3:
                        File.Delete("workers.cvs");
                        break;

                        default: break;
                }
                if (taskNumber == 0)
                {
                    break;
                 }
            }
        }


        static Worker CreateWorker()
        {
            Worker worker = new Worker();

            Console.WriteLine("Введите ID сотрудника");
            worker.CreationTime = DateTime.Now;
            worker.Id = TryReadLineInt(Console.ReadLine());
            Console.WriteLine("Введите ФИО сотрудника");
            worker.Name = Console.ReadLine();
          
            Console.WriteLine("Введите рост сотрудника");
            worker.Tall = TryReadLineFloat(Console.ReadLine());
            Console.WriteLine("Введите дату рождения сотрудника в формате dd/mm/yyyy");
            worker.BirthDate = TryReadLineDataTime(Console.ReadLine()).Date;
            worker.Old = DateTime.Now.Year - worker.BirthDate.Year;
            Console.WriteLine("Введите место рождения сотрудника");
            worker.BirthLocation = Console.ReadLine();

            return worker;
        }

        #region TryReadLine
        static int TryReadLineInt(string str)
        {
            int value;
            while (true)
            {         
                if (!int.TryParse(str, out value))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter и попробуйте ещё раз");
                    str = Console.ReadLine();
                    continue;
                }
                else return value;
            }
        }
        static float TryReadLineFloat(string str)
        {
            float value;
            while (true)
            {
                if (!float.TryParse(str, out value))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter и попробуйте ещё раз");
                    str = Console.ReadLine();
                    continue;
                }
                else return value;
            }
        }
        static DateTime TryReadLineDataTime(string str)
        {
            DateTime value;
            while (true)
            {
                if (!DateTime.TryParse(str, out value))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter и попробуйте ещё раз");
                    Console.ReadLine();
                    str = Console.ReadLine();
                    continue;
                }
                else return value;
            }
        }
        #endregion
 

        static void ReadFile(string path)
        {
            if (!File.Exists(path))
                return;
            using (StreamReader stream = new StreamReader(path))
            {
                while (!stream.EndOfStream)
                {
                    string[] line = stream.ReadLine().Split("#");
                    
                    Console.WriteLine(String.Join(" ", line));
                }
            }
        }

        static void WriteFile(string path, string data)
        {
            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.WriteLine(data);
            }
        }

    }
}

