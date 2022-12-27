using System.Windows;

namespace SchoolQuestions;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TestChoice tch = new();
        tch.Show();
        this.Close();
    }
}