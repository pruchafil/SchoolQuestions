using System.Windows;
using System.Windows.Controls;

namespace SchoolQuestions;

/// <summary>
/// Interakční logika pro OpenQuestion.xaml
/// </summary>
public partial class OpenQuestion : UserControl, IQuestionable
{
    public OpenQuestion(JsonModels.Question oq)
    {
        InitializeComponent();
        question.Text = oq.Title;
    }

    public event IQuestionable.QuestionAnsweredType QuestionAnswered;

    private void Button_Click(object sender, RoutedEventArgs e) => QuestionAnswered?.Invoke(this, new() { Answer = answer.Text });
}