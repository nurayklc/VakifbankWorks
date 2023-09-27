using NLayeredAPI.Base.Response;

namespace NLayeredAPI.Service.Abstract
{
    public interface IBaseService<Dto, TEntity>
    {
        Task<BaseResponse<Dto>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync();
        Task<BaseResponse<Dto>> AddAsync(Dto addResource);
        Task<BaseResponse<Dto>> UpdateAsync(int id, Dto updateResource);
        Task<BaseResponse<Dto>> RemoveAsync(int id);
    }
}
