using System;
using System.Collections.Generic;

namespace CSharp_Task_5
{
    internal class TryParseCustom
    {

        #region TryReadLine

        static public int TryReadLineInt(string str)
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

        static public float TryReadLineFloat(string str)
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

        static public DateTime TryReadLineDataTime(string str)
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


    }
}
