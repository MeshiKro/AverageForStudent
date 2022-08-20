using AverageForStudent.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AverageForStudent.ViewModel
{


    public class CoursesListViewModel : BaseViewModel
    {
        #region Properites
        public ObservableCollection<Courses> CoursesList { get; set; } = new ObservableCollection<Courses>();

        private readonly Database.Database database;


        #endregion


        public CoursesListViewModel()
        {
            database = new Database.Database();


            AddCoursesList();
        }

        private void AddCoursesList()
        {
            IsBusy = true;
            Avg = "AVG: " +database.GetAverage();

            Task.Run(async () =>
              {
                  // await api call;
                  await Task.Delay(1000);

                  Application.Current.Dispatcher.Dispatch(() =>
                  {
                      //database.Create(new Courses { name = "Math", points = 3, grade = 100 });
                      //database.Create(new Courses { name = "Java", points = 3, grade = 90 });
                      List<Courses> cList = database.GetCoursesList();
                      CoursesList.Clear();
                      foreach (Courses c in cList)
                      {

                          CoursesList.Add(c);
                      }

                  });
              });


            IsBusy = false;

        }

        #region Commands
        public ICommand RefreshCommand => new Command(async () =>
        {
            IsRefreshing = false;

            AddCoursesList();
        });

        public ICommand SelectedItemCommand => new Command<Courses>(async (courseDetail) =>
        {
            await Application.Current.MainPage.DisplayAlert("Selected Student", "Selected STudent Name is " + courseDetail.name, "OK");
        });
        #endregion
    }
}
