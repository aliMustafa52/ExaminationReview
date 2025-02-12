using ExaminationSystem.Contracts.Choices;

namespace ExaminationSystem.Contracts.Questions
{
    public record QuestionRequest
    (
        string Content,
        List<ChoiceRequest> ChoiceRequests
    );
}
