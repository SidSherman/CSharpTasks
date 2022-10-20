using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SkillboxHomework
{
    class SkillboxTask4
    { 

        static void Main()
        {

            while (true)
            {
                int taskNumber = 0;

                while (true)
                {
                    Console.WriteLine("Введите номер задачи:\n1.Разделение строки на слова\n2.Перестановка слов в обратном порядке\n0.Выход из программы");
                    if (!int.TryParse(Console.ReadLine(), out taskNumber))
                    {
                        Console.WriteLine("Введено недопустимое значение, нажмите Enter");
                        Console.ReadLine();
                        continue;
                    }
                    else break;
                }

                switch (taskNumber)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите строку:");
                            PrintArray(SplitString(Console.ReadLine()));
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите строку:");
                            PrintArray(ReverseWords(Console.ReadLine()));
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }
                if (taskNumber == 0)
                {
                    break;
                }
            }
        }
            

       
        static string[] SplitString(string str)
        {
            str = RemoveDoubleSpaces(str);

            string[] split = new string[str.Where(x => x == ' ').Count() + 1]; ;
            
            string temp = "";
            int j = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == Convert.ToChar(" "))
                {
                    split[j] = temp;
                    j++;
                    temp = "";
                }
                else
                {
                    temp = string.Join("", temp, str[i]);
                }
            }

            split[j] = temp;

            return split;     

        }

        static void PrintArray(string[] array)
        {
            foreach (string str in array)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
        }

        static string[] ReverseWords(string str)
        {
            string[] words = SplitString(str);
            return ReverseWords(words);

        }

        static string[] ReverseWords(string[] str)
        {
            string[] reversedSentences = new string[str.Length];

            int j = 0;
            for(int i = str.Length - 1; i >= 0; i--)
            {
                reversedSentences[j] = str[i];
                j++;
            }

            return reversedSentences;
        }

        static string RemoveDoubleSpaces(string str)
        {
            string strtemp = str;
            while (strtemp.Contains("  "))
            {
                strtemp = str.Replace("  ", " ");
            }

            return strtemp;
        }
    }
}
