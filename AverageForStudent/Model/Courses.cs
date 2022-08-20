using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageForStudent.Model
{
    public class Courses
    {

        public string name { get; set; }

        public int points { get; set; }

        public int grade { get; set; }

    

        public int getTotal()
        {
            return points * grade;
        }

      

    }
}
