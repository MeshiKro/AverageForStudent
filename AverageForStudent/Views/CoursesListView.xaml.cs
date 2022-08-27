using AverageForStudent.Database;
using AverageForStudent.ViewModel;
using AverageForStudent.Views;

namespace AverageForStudent;

public partial class CoursesListView : ContentPage
{

    public CoursesListView()
	{
		InitializeComponent();
        this.BindingContext = new CoursesListViewModel();

    }

    private async void AddGradeClicked(object sender, EventArgs e)
    {

        var modalPage = new PopupPage1();
        modalPage.Disappearing += (sender2, e2) =>
        {
          ((CoursesListViewModel)  this.BindingContext).RefreshCommand.Execute(null);
        };
        await App.Current.MainPage.Navigation.PushModalAsync(modalPage);


    }
   



}