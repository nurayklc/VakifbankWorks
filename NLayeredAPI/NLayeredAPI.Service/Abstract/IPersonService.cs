using NLayeredAPI.Data.Model;
using NLayeredAPI.Dto.Dtos;

namespace NLayeredAPI.Service.Abstract
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
    }
}
