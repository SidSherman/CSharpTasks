using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace CSharpTask7
{

    class MyIntList
    {
        private List<int> list = new List<int>();
        public List<int> List { get => list; set => list = value; }

        public MyIntList() { }

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

            for (int i = 0; i < lenght; i++)
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

            foreach (int number in list)
            {
                str = str + separator + number.ToString();
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
}
