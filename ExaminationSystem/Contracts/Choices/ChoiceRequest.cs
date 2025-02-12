namespace ExaminationSystem.Contracts.Choices
{
    public record ChoiceRequest
    (
        string Content,
        bool IsCorrect
    );
}
