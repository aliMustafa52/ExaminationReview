using ExaminationSystem.Contracts.Choices;
using ExaminationSystem.Contracts.Questions;
using ExaminationSystem.Entities;
using ExaminationSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using ExaminationSystem.Abstractions;
using SurveyBasketV5.Errors;
using System.Linq;
using ExaminationSystem.Errors;

namespace ExaminationSystem.Services.Questions
{
    public class QuestionService(ApplicationDbContext dbContext) : IQuestionService
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<QuestionResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var questionResponses = await _dbContext.Questions
                        .Where(q => q.IsActive)
                        .Select(q => new QuestionResponse(
                            q.Id,
                            q.Content,
                            q.Course.Name,
                            q.Choices
                                .Select(c => new ChoiceResponse(
                                    c.Id,
                                    c.Content,
                                    c.IsCorrect
                                )).ToList()
                        )).ToListAsync(cancellationToken);

            return questionResponses;
        }

        public async Task<Result<QuestionResponse>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var question = await _dbContext.Questions
                                .SingleOrDefaultAsync(q => q.Id == id && q.IsActive, cancellationToken);

            if(question is null) 
                return Result.Failure<QuestionResponse>(QuestionErrors.QuestionNotFound);

            var questionResponse = new QuestionResponse(
                            question.Id,
                            question.Content,
                            question.Course.Name,
                            question.Choices
                                .Select(c => new ChoiceResponse(
                                    c.Id,
                                    c.Content,
                                    c.IsCorrect
                                )).ToList()
            );

            return Result.Success(questionResponse);
        }
        public async Task<Result<QuestionResponse>> AddAsync(int courseId,QuestionRequest request, CancellationToken cancellationToken = default)
        {
            var course = await _dbContext.Courses
                            .Include(c => c.Questions.Where(q => q.IsActive))
                            .ThenInclude(q => q.Choices.Where(c => c.IsActive))
                            .FirstOrDefaultAsync(c => c.Id == courseId && c.IsActive, cancellationToken);

            if(course is null)
                return Result.Failure<QuestionResponse>(CourseErrors.CourseNotFound);

            var isExistingTitle = course.Questions
                                    .Any(q => q.Content == request.Content);
            if (isExistingTitle)
                return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestionTitle);

            var question = new Question
            {
                Content = request.Content,
                CourseId = courseId,
                Choices = request.ChoiceRequests
                            .Select(c => new Choice
                            {
                                Content = c.Content,
                                IsActive = c.IsCorrect
                            }).ToList()

            };

            await _dbContext.Questions.AddAsync(question, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var questionResponse = new QuestionResponse(
                            question.Id,
                            question.Content,
                            course.Name,
                            question.Choices
                                .Select(c => new ChoiceResponse(
                                    c.Id,
                                    c.Content,
                                    c.IsCorrect
                                )).ToList()
            );

            return Result.Success(questionResponse);
        }
        public Task<Result> UpdateAsync(int id, QuestionRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
