using System;
using System.Threading.Tasks;

namespace CSharp_Task_5
{
    struct Worker
    {
        private int id = 0;
        private DateTime creationTime;
        private string name;
        private int old;
        private float tall;
        private DateTime birthDate;
        private string birthLocation;
        
        public int Id { get => id; set => id = value; }
        public DateTime CreationTime { get => creationTime; set => creationTime = value; }
        public string Name { get => name; set => name = value; }
        public int Old { get => old; set => old = value; }
        public float Tall { get => tall; set => tall = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string BirthLocation { get => birthLocation; set => birthLocation = value; }

        public Worker(int id, DateTime creationTime, string name, int old, float tall,
            DateTime birthDate, string birthLocation)
        {
            this.id = id;
            this.creationTime = creationTime;
            this.name = name;
            this.old = old;
            this.tall = tall;
            this.birthDate = birthDate;
            this.birthLocation = birthLocation;
        }

        public string ReadValues(string splitter)
        {
            string str = "";

            str += id + splitter;
            str += creationTime + splitter;
            str += name + splitter;
            str += old + splitter ;
            str += tall + splitter ;
            str += birthDate + splitter ;
            str += birthLocation;

            return str;
        }
    }
}
