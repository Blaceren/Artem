using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Newtonsoft.Json;

namespace StudentLibrary1
{
    
   public class StudentService
    {
        private string path = "Students.db";
       public IEnumerable<student> Students { get; set; }
        public StudentService()
        {
            if (File.Exists(path))
                Load();
          else
                Students = new List<student>();
        }
        public void Add(student Student)
        {
            (Students as List<student>).Add(Student);
        }
        public void Remove(string lastname)
        {
            List<student> temp = (Students as List<student>);
            student Del = temp.Find(st => st.LastName.Equals(lastname));
            if (Del != null)
                temp.Remove(Del);

        }
        public void Save()
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Students);
            }
        }
        public void Load()
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
               Students=( bf.Deserialize(fs) as List<student>);
            }
        }
        public void BestStudent()
        {
            List<student> temp = (Students as List<student>);

            double[] arr = new double[temp.Count];
            for (int i = 0; i < temp.Count; i++)
            {
                Console.Write(temp[i].Name + ":");
               arr[i]= (temp[i].marks.Average(x => x.Rating));
                Console.WriteLine(arr[i]);
            }
            double max = arr.Max();
            Console.WriteLine("BEST!!!!!!!!!!!: ");
            Console.WriteLine(temp.Find(x => x.marks.Average(y => y.Rating)==max));
                     
        }
        public void SaveJSON()
        {
            string json = JsonConvert.SerializeObject(Students, Formatting.Indented);
            File.WriteAllText("Stud.json", json);
        }
        
    }
}
