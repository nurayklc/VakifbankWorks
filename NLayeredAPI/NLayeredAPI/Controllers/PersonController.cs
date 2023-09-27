using Microsoft.AspNetCore.Mvc;
using NLayeredAPI.Base.Response;
using NLayeredAPI.Dto.Dtos;
using NLayeredAPI.Service.Abstract;
using Serilog;

namespace NlayeredAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<PersonDto>>> Get()
        {
            Log.Debug("PersonContoller.Get");
            var persons = await _personService.GetAllAsync();
            return persons;
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<PersonDto>> GetById(int id)
        {
            Log.Debug("PersonContoller.GetById");
            var person = await _personService.GetByIdAsync(id);
            return person;
        }

        [HttpPost]
        public async Task<BaseResponse<PersonDto>> Post([FromBody] PersonDto dto)
        {
            Log.Debug("PersonContoller.Post");

            dto.CreatedAt = DateTime.Now;
            dto.CreatedBy = "SystemUser";

            var person = await _personService.AddAsync(dto);
            return person;
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<PersonDto>> Put(int id, [FromBody] PersonDto dto)
        {
            Log.Debug("PersonContoller.Put");
            var person = await _personService.UpdateAsync(id, dto);
            return person;
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<PersonDto>> Delete(int id)
        {
            Log.Debug("PersonContoller.Delete");
            var person = await _personService.RemoveAsync(id);
            return person;
        }


    }
}
