namespace SchoolQuestions.JsonModels;

public class Test
{
    public string Name { get; set; }
    public string Theme { get; set; }
    public int Count { get; set; }
    public Question[] Questions { get; set; }
    public int Seconds { get; set; }
}