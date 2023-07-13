using System.Linq.Expressions;
using ApiTemplate.Domain.Validation;

namespace ApiTemplate.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity>
        where TEntity : class
    {
        Task<ValidationResult> Add(TEntity entity);
        Task<ValidationResult> Add(ICollection<TEntity> entity);
        Task<ValidationResult> Update(TEntity entity);
        Task<ValidationResult> Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludeProperties);
        Task<ValidationResult> Delete(TEntity entity);
        Task<ValidationResult> Delete(ICollection<TEntity> entity);
    }
}