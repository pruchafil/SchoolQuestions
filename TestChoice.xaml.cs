using System.Windows;

namespace SchoolQuestions;

public partial class TestChoice : Window
{
    public TestChoice()
    {
        InitializeComponent();

        lv.ItemsSource = SaveSystem.JSONHandler.GetObject<JsonModels.Test[]>(@"tests.json");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (lv.SelectedIndex == -1)
        {
            MessageBox.Show("Zvolte prosím platnou možnost", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        Questions q = new((JsonModels.Test)lv.SelectedItem);
        q.Show();
        this.Close();
    }
}