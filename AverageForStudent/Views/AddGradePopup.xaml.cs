using AverageForStudent.Controls;
using AverageForStudent.Model;

namespace AverageForStudent.Views;


public partial class PopupPage1 : BasePopupPage
{
    Database.Database database;
    public PopupPage1()
    {
        InitializeComponent();

        database = new Database.Database();
    }
  

   
    private void AddButtonClicked(object sender, EventArgs e)
    {
       
        errorMsg.Text = ValidateFields();
        if (errorMsg.Text == "")
        {

            Courses c = new Courses();
            c.name = courseName.Text;
            c.grade = Int32.Parse(courseGrade.Text);
            c.points = Int32.Parse(coursePoints.Text);

            database.Create(c);

            CloseButtonClicked(sender, e);


        }

    }

    private string ValidateFields()
    {
        if (courseName.Text == "")
            return "Course Name Is Missing";
        if (courseGrade.Text == "")
            return "Grade Is Missing";
        if (coursePoints.Text == "")
            return "Points Is Missing";
        try
        {
            int grade = Int32.Parse(courseGrade.Text);
            if (grade < 0 || grade > 100)
                return "Grade is Invalid";

        }
        catch (Exception e)
        {
            return "Grade is Invalid";

        }

        try
        {
            Int32.Parse(coursePoints.Text);
        }
        catch (Exception e)
        {
            return "Points are Invalid";

        }

        return "";
    }

    private void ClearButtonClicked(object sender, EventArgs e)
    {
        errorMsg.Text = courseGrade.Text = coursePoints.Text = courseName.Text = "";

    }
    private void CloseButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
