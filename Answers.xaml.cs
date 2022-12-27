using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SchoolQuestions;

public partial class Answers : Window
{
    private bool _opened;

    public Answers(JsonModels.Question[] list, string[] answers)
    {
        InitializeComponent();

        _opened = false;

        List<AnswersTemplate> l = new();

        for (int i = 0; i < list.Length; ++i)
            l.Add(new AnswersTemplate()
            {
                Question = list[i],
                Answer = answers[i],
                OK = list[i].Answers.Any(x => x == answers[i]) ? AnswersTemplate.Answered.Correct : AnswersTemplate.Answered.Wrong
            });

        lv.ItemsSource = l;
    }

    private void LV_Selected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (_opened)
            return;

        AnswersTemplate at = (AnswersTemplate)lv.SelectedItem;

        Reason r = new(at.Question, at.Answer);
        r.Show();
        r.Closed += (sender, e) => _opened = false;
    }

    private class AnswersTemplate
    {
        public enum Answered
        { Correct, Wrong }

        public JsonModels.Question Question { init; get; }
        public string Answer { init; get; }
        public Answered OK { init; get; }
    }
}