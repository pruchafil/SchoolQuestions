using System.IO;
using System.Text.Json;
using System.Windows;

namespace SchoolQuestions.SaveSystem;

public static class JSONHandler
{
    public static T GetObject<T>(string path) => (T)JsonSerializer.Deserialize(
            File.ReadAllText(path),
            typeof(T),
            new JsonSerializerOptions() { WriteIndented = true }
        );

    public static void WriteObject<T>(string path, T obj)
    {
        try
        {
            File.WriteAllText(
                path,
                JsonSerializer.Serialize(
                    obj,
                    typeof(T),
                    new JsonSerializerOptions() { WriteIndented = true }
                )
            );
        }
        catch
        {
            MessageBox.Show(
                $"Chyba při psaní do souboru {path}!",
                "Chyba",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}