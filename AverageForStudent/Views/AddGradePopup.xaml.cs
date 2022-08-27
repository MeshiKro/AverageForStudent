using AverageForStudent.Controls;
using AverageForStudent.Model;

namespace AverageForStudent.Views;


public partial class PopupPage1 : BasePopupPage
{
    Database.Database database;
    private Courses courseDetail;

    public PopupPage1()
    {
        InitializeComponent();

        database = new Database.Database();
        this.courseDetail = null;
    }

    public PopupPage1(Courses courseDetail)
    {
        InitializeComponent();

        database = new Database.Database();

        this.courseDetail = courseDetail;

        title.Text = "Edit Grade";
        courseName.IsEnabled = false;
        courseName.Text = courseDetail.name;
        courseGrade.Text = courseDetail.grade.ToString();
        coursePoints.Text = courseDetail.points.ToString();
        addBtn.Text = "Update";
        clearBtn.IsVisible = false;
        deleteBtn.IsVisible = true;
    }

    private void AddButtonClicked(object sender, EventArgs e)
    {

        errorMsg.Text = ValidateFields();
        if (errorMsg.Text == "")
        {
            Courses c = getCourse();

            if (title.Text.Contains("Add"))
                database.Create(c);
            else
                database.Update(c);

            CloseButtonClicked(sender, e);

        }


    }

    private Courses getCourse()
    {
        Courses c = new Courses();
        if (title.Text.Contains("Edit")  && this.courseDetail != null)
            c.id = courseDetail.id;
        else
            c.id = database.GetNewId();

        c.name = courseName.Text;
        c.grade = Int32.Parse(courseGrade.Text);
        c.points = Int32.Parse(coursePoints.Text);
        return c;

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
    private async void DeleteButtonClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Delete", "Are you sure you want to delete this course?", "Yes", "No");
        if(answer)
        database.Delete(getCourse());
        CloseButtonClicked(sender, e);


    }
    private void CloseButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
