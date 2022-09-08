using System;
using System.Runtime.CompilerServices;

namespace skillbox_homework
{
    class SkillboxTask2
    {
        static void Main()
        {

            while (true) {

                // Выбор задания

                Console.Clear();

                Console.WriteLine("Задание 1: определение четности числа \n");
                Console.WriteLine("Задание 2: подсчет суммы карт в игре '21' \n");
                Console.WriteLine("Задание 3: проверка числа на простоту \n");
                Console.WriteLine("Задание 4: наименьший элемент последвательности \n");
                Console.WriteLine("Задание 5: Угадай число \n");

                Console.WriteLine("Введите номер задания или 0, чтобы выйти: ");

                int taskNumber = -1;
                if(!int.TryParse(Console.ReadLine(), out taskNumber))
                {
                    Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                    Console.ReadLine();
                    continue;
                }
                
                switch (taskNumber)
                {
                    case 1:
                        IsNumberEven();
                        break;
                    case 2:
                        CardsSumCheck();
                        break;
                    case 3:
                        SimpleNumCheck();
                        break;
                    case 4:
                        GetMinValue();
                        break;
                    case 5:
                        GuessTheNumber();
                        break;
                    default:
                        break;
                }

                if (taskNumber == 0)
                {
                    break;
                }
            }
        }


        // Провнрка числа на четность
        static void IsNumberEven()
        {

            Console.WriteLine("Введите целое число: ");

            int value = 0;
            while(true)
            {
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Введено недопустимое значение, введите ещё раз: ");  
                    continue;
                }
                else break;
            }
           

            if (value % 2 == 0)
                Console.WriteLine($"Число {value} - четное");
            else
                Console.WriteLine($"Число {value} - нечетное");

            Console.WriteLine("Нажмите Enter, чтобы продолжить");
            Console.ReadLine();
        }


        //Подсчет суммы карт
        static void CardsSumCheck()
        {
            Console.WriteLine("Введите количество карт на руках: ");
            int count  = 0;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out count))
                {
                    Console.WriteLine("Введено недопустимое значение,попробуйте ещё раз: ");
                    continue;
                }
                else break;
            }

            Console.WriteLine("По очереди введите номинал карт. Для карт с картинками используйте следующие обозначения:\n" +
                    "Валет = J\n" +
                    "Дама = Q\n" +
                    "Король = K\n" +
                    "Туз = T");

            int sum = 0;

            for (int i = 0; i < count; i++)
            { 
                string value = Console.ReadLine();

                string pattern = "Текущая сумма: {0}";

                switch (value)
                {
                    case "1":
                        sum += 1;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "2":
                        sum += 2;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "3":
                        sum += 3;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "4":
                        sum += 4;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "5":
                        sum += 5;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "6":
                        sum += 6;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "7":
                        sum += 7;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "8":
                        sum += 8;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "9":
                        sum += 9;
                        Console.WriteLine(pattern, sum);
                        break;
                    case "10":
                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        sum += 10;
                        Console.WriteLine(pattern, sum);
                        break;
                    default:
                        Console.WriteLine("Введено недопустимое значение, попробуйте ещё раз: ");
                        i--;
                        break;
                }
                    
            }
            Console.WriteLine("Сумма всех карт: {0}", sum);

            Console.WriteLine("Нажмите Enter, чтобы продолжить");
            Console.ReadLine();
        }
    
        // проверка числа на простоту
        static void SimpleNumCheck()
        {
            Console.WriteLine("Введите целое число: ");
            int value = 0;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Введено недопустимое значение,попробуйте ещё раз: ");
                    continue;
                }
                else break;
            }

            int i = 3;
            bool isSimple = true;

            if (value % 2 != 0)
            {
                while (i < value - 1)
                {

                    if (value % i == 0)
                    {
                        Console.WriteLine(i);
                        isSimple = false;
                        break;
                    }
                    i += 2;

                }
            }
            else  isSimple = false;

            if (isSimple)
            {
                Console.WriteLine("Число простое");
            }
            else
            {
                Console.WriteLine("Число составное");
            }

            Console.WriteLine("Нажмите Enter, чтобы продолжить");
            Console.ReadLine();
       
        }

        // нахождение минимального значений
        static int GetMinValue()
        {
            Console.WriteLine("Введите дилну последовательности");
            int count = 0;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out count))
                {
                    Console.WriteLine("Введено недопустимое значение,попробуйте ещё раз: ");
                    continue;
                }
                else break;
            }

            int min = Int32.MaxValue;
            for (int i = 0; i< count; i++)
            {
                Console.WriteLine("Введите число: ");
                int value = min;

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("Введено недопустимое значение,попробуйте ещё раз: ");
                        continue;
                    }
                    else break;
                }


                if (min > value)
                {
                    min = value;
                }
            }

            Console.WriteLine("Минимальный элемент последовательности: " + min + "\n");

            Console.WriteLine("Нажмите Enter, чтобы продолжить");
            Console.ReadLine();
            return 0;


        }

        // Игра "Угадай число"
        static int GuessTheNumber()
        {

            Console.WriteLine("Введите максимальное число");
            int max = 0;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out max))
                {
                    Console.WriteLine("Введено недопустимое значение,попробуйте ещё раз: ");
                    continue;
                }
                else break;
            }


            Random randomize = new Random();
            int randomNumber = randomize.Next(1, max + 1);
            Console.WriteLine("Загадано число от 1, до {0}", max);
            

            while(true)
            {

                int value = 0;

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("Введено недопустимое значение,попробуйте ещё раз: ");
                        continue;
                    }
                    else break;
                }

                if (value == -1)
                    {
                    break;
                    }

                if (value == randomNumber)
                {
                    Console.WriteLine("Вы угадали!");
                    break;

                }
                else
                {
                    Console.WriteLine("Вы не угадали :(\nПопробуйте ещё раз. Если вы хотите узнать число, то введите -1");
                }
                
            }

            Console.WriteLine("Загаданное число: " + randomNumber);

            Console.WriteLine("Нажмите Enter, чтобы выйти");
            Console.ReadLine();
            return 0;

        }


    }
}