using AutoMapper;
using NLayeredAPI.Base.Response;
using NLayeredAPI.Data.Repository.Abstract;
using NLayeredAPI.Data.UOW.Abstract;
using NLayeredAPI.Service.Abstract;
using Serilog;

namespace NLayeredAPI.Service.Concrete
{
    public abstract class BaseService<Dto, Entity> : IBaseService<Dto, Entity> where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseService(IGenericRepository<Entity> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Dto>> AddAsync(Dto addResource)
        {
            try
            {
                var entity = _mapper.Map<Dto, Entity>(addResource);
                await _genericRepository.InsertAsync(entity);
                await _unitOfWork.CompleteAsync();
                return new BaseResponse<Dto>(addResource);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Insert entity error!");
                return new BaseResponse<Dto>("Insert entity error!");
            }
        }

        public async Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAllAsync();
            var mapEntites = _mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(entities);
            return new BaseResponse<IEnumerable<Dto>>(mapEntites);
        }

        public async Task<BaseResponse<Dto>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            var mapEntity = _mapper.Map<Entity, Dto>(entity);
            return new BaseResponse<Dto>(mapEntity);
        }

        public async Task<BaseResponse<Dto>> RemoveAsync(int id)
        {
            try
            {
                var entityRemove = await _genericRepository.GetByIdAsync(id);
                if (entityRemove is null)
                    return new BaseResponse<Dto>("Id_NoData");

                _genericRepository.RemoveAsync(entityRemove);
                await _unitOfWork.CompleteAsync();
                return new BaseResponse<Dto>(_mapper.Map<Entity, Dto>(entityRemove));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Delete entity error!");
                return new BaseResponse<Dto>("Delete entity error!");
            }
        }

        public async Task<BaseResponse<Dto>> UpdateAsync(int id, Dto updateResource)
        {
            try
            {
                var entityUpdate = await _genericRepository.GetByIdAsync(id);
                if (entityUpdate is null)
                    return new BaseResponse<Dto>("Id_NoData");
                _genericRepository.Update(_mapper.Map<Dto, Entity>(updateResource));
                await _unitOfWork.CompleteAsync();
                return new BaseResponse<Dto>(updateResource);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Update entity error!");
                return new BaseResponse<Dto>("Update entity error!");
            }
        }
    }
}
