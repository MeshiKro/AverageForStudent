using AverageForStudent.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageForStudent.Database
{
    public class Database
    {

        private readonly SQLiteConnection _database;

        public Database()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "entities.db");
            _database = new SQLiteConnection(dbPath);
            try
            {
                _database.CreateTable<Courses>(CreateFlags.ImplicitPK);
            }
            catch
            { }
        }

        public List<Courses> GetCoursesList()
        {
            return _database.Table<Courses>().ToList();
        }
        public void RemoveAllCourses()
        {
               _database.ExecuteScalar<Courses>("DELETE FROM Courses", new string[1] { "" });

        }
        public double GetAverage()
        {
            List<Courses> list = GetCoursesList();
            double totalPoint = 0;
         
            double totalSum = 0;
            foreach (Courses courses in list)
            {
                totalSum += courses.getTotal();
                totalPoint += courses.points;
            }

            return (totalSum / totalPoint);

        }
        public Int32 GetNewId()
        {
            int id = 0;
            List<Courses> courses = GetCoursesList();
            foreach(Courses c in courses)
            {
                if (c.id > id)
                    id = c.id;
            }
            return (id+1);
        }
        public int Create(Courses entity)
        {
            return _database.Insert(entity);
        }

        public int Update(Courses entity)
        {
            return _database.Update(entity);
        }

        public int Delete(Courses entity)
        {
            return _database.Delete(entity);
        }



    }

}
