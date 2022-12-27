using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SchoolQuestions;

public partial class CloseQuestion : UserControl, IQuestionable
{
    private string _answ;

    public CloseQuestion(JsonModels.Question cq)
    {
        InitializeComponent();

        HashSet<string> choices = new();

        while (choices.Count != 3)
            choices.Add(cq.Choices[Random.Shared.Next(3)]);

        Button[] b = new[] { q_1, q_2, q_3 };

        int index = 0;

        foreach (string item in choices)
            (b[index++].Content as TextBox).Text += item;

        question.Content = cq.Title;
    }

    public event IQuestionable.QuestionAnsweredType QuestionAnswered;

    private void Button_Click(object sender, RoutedEventArgs e) => QuestionAnswered?.Invoke(this, new QuestionInfo() { Answer = _answ });

    private void Button_Answ_Click(object sender, RoutedEventArgs e)
    {
        TextBox tb = (sender as Button).Content as TextBox;
        _answ = tb.Text.Remove(0, 3);

        (q_1.Content as TextBox).Foreground = (q_2.Content as TextBox).Foreground = (q_3.Content as TextBox).Foreground = Brushes.Black;
        tb.Foreground = Brushes.Red;
    }
}