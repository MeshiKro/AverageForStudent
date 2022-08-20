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
        await App.Current.MainPage.Navigation.PushModalAsync(new PopupPage1());

    }
}