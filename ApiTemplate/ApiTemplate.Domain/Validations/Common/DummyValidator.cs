using FluentValidation;

namespace ApiTemplate.Domain.Validations.Common
{
    public class DummyValidator<TEntity> : AbstractValidator<TEntity>, IValidator<TEntity>
        where TEntity : class
    {
    }
}
