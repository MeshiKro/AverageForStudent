using AverageForStudent.Controls;

namespace AverageForStudent.Views;


public partial class PopupPage1 : BasePopupPage
{
    public PopupPage1()
    {
        InitializeComponent();
    }

    private async void TapGestureRecognizer_Tapped_NavigateToPoupPage1(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushModalAsync(new PopupPage2());
    }

    private async void TapGestureRecognizer_Tapped_NavigateToNormalPage(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PopModalAsync();
      //  await App.Current.MainPage.Navigation.PushAsync(new NewPage1());
    }

}
