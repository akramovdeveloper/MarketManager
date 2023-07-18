using FluentValidation.Results;
using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace MarketManager.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);

                ValidationResult[] validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

                List<ValidationFailure> failures = validationResults
                    .Where(v => v.Errors.Any())
                    .SelectMany(v => v.Errors)
                    .ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }

            return await next();
        }

    }
}
