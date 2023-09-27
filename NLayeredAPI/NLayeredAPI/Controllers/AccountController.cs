using Microsoft.AspNetCore.Mvc;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.UOW.Abstract;

namespace NlayeredAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.AccountRepository.InsertAsync(account);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetById", new { account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            var item = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            item.Email = account.Email;
            item.UserName = account.UserName;
            item.Name = account.Name;
            item.LastActivity = DateTime.Now;

            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.CompleteAsync();
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var item = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            _unitOfWork.AccountRepository.RemoveAsync(item);
            await _unitOfWork.CompleteAsync();
            return Ok("Remove account successfully!");
        }
    }
}
