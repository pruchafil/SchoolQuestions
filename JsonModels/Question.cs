namespace SchoolQuestions.JsonModels;


public class Question
{
    public string Title { get; set; }
    public string Reason { get; set; }
    public string[] Choices { get; set; }
    public string[] Answers { get; set; }
}