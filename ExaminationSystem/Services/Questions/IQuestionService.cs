using ExaminationSystem.Contracts.Questions;
using SurveyBasket.Abstractions;

namespace ExaminationSystem.Services.Questions
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionResponse>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Result<QuestionResponse>> GetAsync(int id, CancellationToken cancellationToken = default);

        Task<Result<QuestionResponse>> AddAsync(QuestionRequest request, CancellationToken cancellationToken = default);

        Task<Result> UpdateAsync(int id, QuestionRequest request, CancellationToken cancellationToken = default);

        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
