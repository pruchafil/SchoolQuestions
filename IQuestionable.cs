namespace SchoolQuestions;

public interface IQuestionable
{
	delegate void QuestionAnsweredType(object sender, QuestionInfo e);
	public event QuestionAnsweredType QuestionAnswered;
}