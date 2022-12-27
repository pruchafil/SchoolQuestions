using System.Windows;

namespace SchoolQuestions;

public partial class Reason : Window
{
    public Reason(JsonModels.Question question, string ans)
    {
        InitializeComponent();

        title.Text = question.Title;
        y_answ.Text = ans;
        r_answ.Text = string.Join("; ", question.Answers);
        reason.Text = question.Reason;
    }
}