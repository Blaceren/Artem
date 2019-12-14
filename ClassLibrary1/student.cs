using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary1
{
    [Serializable]
    public class student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Mark> marks { get; set; }
        public student()
        {
            marks = new List<Mark>();
        }
        public override string ToString()
        {
            string rating = "\n";
            foreach (var item in marks)
            {
                rating += item + "\n";
            }
            return $"{Name}  {LastName} {Age} " + rating;
        }
        public void AddMarks(string Sub, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                marks.Add(new Mark() { Rating = arr[i], Subject = Sub });
 
        }
    }
    [Serializable]
    public class Mark
    {
        public int Rating { get; set; }
        public string Subject { get; set; }
        public override string ToString()
        {
            return $"{Subject}------------{Rating}";
        }
    }


}
