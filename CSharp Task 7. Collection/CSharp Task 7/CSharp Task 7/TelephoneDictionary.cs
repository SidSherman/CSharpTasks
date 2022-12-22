using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace CSharpTask7
{

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

            if (name == null)
            {
                name = "Такого номера в телефонной книге нет";
            }

            return name;
        }
    }
}
