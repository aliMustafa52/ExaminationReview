using ExaminationSystem.Contracts.Choices;

namespace ExaminationSystem.Contracts.Questions
{
    public record QuestionResponse
    (
        int Id,
        string Content,
        string Quiz,
        List<ChoiceResponse> Choices
    );
}
