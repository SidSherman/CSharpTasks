using System;
using System.Collections;

namespace CSharp_Task_5
{
    class WorkersRepository
    {
        private List<Worker> workers;
        private string savePath = "workers.cvs";

        public List<Worker> Workers { get => workers; set => workers = value; }
        public string SavePath { get => savePath; set => savePath = value; }

        public WorkersRepository(List<Worker> Args)
        {
            workers = Args;
        }

        public WorkersRepository()
        {
            workers = new List<Worker>();
        }

        public Worker this[int index]
        {
            get { return Workers[index]; }
            set { Workers[index] = value; }
        }

        public void AddWorker(int id, DateTime creationTime, string name, int old, float tall,
            DateTime birthDate, string birthLocation)
        {
            if(GetWorkerByID(id).Id == 0)
            {
                workers.Add(new Worker(id, creationTime, name, old, tall, birthDate, birthLocation));
            }
            else
            {
                Console.WriteLine("Работник с таким ID уже существует");
            }
        }

        public void AddWorker(Worker worker)
        {
            if (GetWorkerByID(worker.Id).Id == 0)
            {
                workers.Add(worker);
            }
            else
            {
                Console.WriteLine("Работник с таким ID уже существует");
            }
        }

        public Worker GetWorkerByID(int id)
        {
           foreach (Worker worker in workers)
            {
                if(worker.Id == id)
                {
                    return worker;
                }
            }
            return new Worker();
        }

        public void DeleteWorkerByID(int id)
        {
            Worker worker = GetWorkerByID(id);
            if (worker.Id != 0)
            {
                workers.Remove(worker);
            }
        }

        public void DeleteData()
        {
            workers.Clear();
            FileHandler.FileDelete(SavePath);
        }

        public void ReadDataFromFile()
        {
            workers.Clear();
            ArrayList lines = FileHandler.ReadFile(savePath);

            foreach(string line in lines)
            {
                string[] words = line.Split("#");

                AddWorker(int.Parse(words[0]), DateTime.Parse(words[1]), words[2], int.Parse(words[3]), float.Parse(words[4]), DateTime.Parse(words[5]), words[6]);

            }
        }

        public void SaveData()
        {
            FileHandler.FileDelete(SavePath);
            foreach (Worker worker in workers)
            {
                FileHandler.WriteLineInFile(SavePath, worker.ReadValues("#"));
            }
        }

        public void SortData(int sortParam)
        {
            switch (sortParam){
                case 1:
                    {
                        workers = workers.OrderBy(x => x.Id).ToList();
                        break;
                    }
                case 2:
                    {
                        workers = workers.OrderBy(x => x.CreationTime).ToList();
                        break;
                    }
                case 3:
                    {
                        workers = workers.OrderBy(x => x.Name).ToList();
                        break;
                    }
                case 4:
                    {
                        workers = workers.OrderBy(x => x.Tall).ToList();
                        break;
                    }
                case 5:
                    {
                        workers = workers.OrderBy(x => x.BirthDate).ToList();
                        break;
                    }
                case 6:
                    {
                        workers = workers.OrderBy(x => x.BirthLocation).ToList();
                        break;
                    }
                default:
                    {
                        workers = workers.OrderBy(x => x.Id).ToList();
                        break;
                    }
                   
            }
        }

        public string OutputData(DateTime firstDate, DateTime secondTime)
        {
            if (RepositoryIsEmpty())
            {
                return "";
            }

            string output = "";

            foreach (Worker worker in workers)
            {
                if (worker.CreationTime > firstDate && worker.CreationTime  < secondTime)
                {
                    output += worker.ReadValues(" ");
                    //Console.WriteLine(worker.ReadValues(" "));
                }
            }
            return output;
        }

        public string OutputData(int id)
        {
            if (RepositoryIsEmpty())
            {
                return "";
            }
            string output = "";

            Worker worker = GetWorkerByID(id);
            if (worker.Id != 0)
            {
                output += worker.ReadValues(" ");
                //Console.WriteLine(worker.ReadValues(" "));
                return output;
            }
            else
            {
                return "Работник с таким ID не существует";
                //Console.WriteLine("Работник с таким ID не существует");
            }

        }

        public string OutputData()
        {
            if (RepositoryIsEmpty())
            { 
                return "";
            }

            string output = "";

            foreach (Worker worker in workers)
            {
                output += worker.ReadValues(" ");
                //Console.WriteLine(worker.ReadValues(" "));
            }
            return output;


        }

        public bool RepositoryIsEmpty()
        {
            if (workers.Count < 1)
            {
                Console.WriteLine("Репозиторий пуст");
                return true;
            }

            return false;
        }

    }
}
