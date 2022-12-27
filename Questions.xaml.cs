using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SchoolQuestions;

public partial class Questions : Window
{
    private readonly JsonModels.Test _test;
    private int _questionsCount;
    private readonly List<JsonModels.Question> _answered;
    private readonly List<string> _answers;
    private int _seconds;

    private readonly DispatcherTimer _timer;

    public Questions(JsonModels.Test test)
    {
        InitializeComponent();
        _test = test;
        _questionsCount = test.Count;
        _answered = new();
        _answers = new();
        _timer = new() { Interval = new TimeSpan(0, 0, 1) };

        _seconds = test.Seconds;

        _timer.Tick += Tick;
        _timer.Start();

        Generate();
    }

    private void Generate()
    {
        int r;

        do
        {
            r = Random.Shared.Next(_test.Questions.Length);
        }
        while (_answered.Contains(_test.Questions[r]));

        _answered.Add(_test.Questions[r]);
        --_questionsCount;

        IQuestionable c =
            _test.Questions[r].Choices != null ?
            c = new CloseQuestion(_test.Questions[r])
            :
            c = new OpenQuestion(_test.Questions[r]);

        var ui = c as UIElement;

        gr.Children.Add(ui);
        Grid.SetRow(ui, 1);
        c.QuestionAnswered += QuestionAnswered;
    }

    private void QuestionAnswered(object sender, QuestionInfo e)
    {
        gr.Children.Remove(sender as UIElement);

        remaining.Content = $"Zbývá otázek: {_questionsCount}";
        _answers.Add(e.Answer);

        if (_questionsCount == 0)
        {
            ShowAnswers();
            return;
        }

        Generate();
    }

    private void Tick(object sender, EventArgs e)
    {
        if (--_seconds == 0)
        {
            ShowAnswers();
            return;
        }

        string m = (_seconds / 60).ToString().PadLeft(2, '0'),
               s = (_seconds % 60).ToString().PadLeft(2, '0');

        time.Content = $"{m}:{s}";

        if (_seconds <= 60)
            time.Foreground = Brushes.Red;
    }

    private void ShowAnswers()
    {
        Answers a = new(_answered.ToArray(), _answers.ToArray());
        a.Show();
        this.Close();
    }
}