using Microsoft.AspNetCore.Mvc;

namespace PrestigePathway.Api.Abstractions
{
    public interface IBaseController<TEntity>
        where TEntity : class
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAll();
        Task<ActionResult<TEntity>> GetById(int id);
        Task<ActionResult<TEntity>> Create(TEntity entity);
        Task<IActionResult> Update(int id, TEntity entity);
        Task<IActionResult> Delete(int id);
    }
}
