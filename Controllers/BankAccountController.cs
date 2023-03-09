using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankapi.Repository;
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using MyApi.Entities;
using MyApi.Models;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountsController : ControllerBase
    {
        public IAccountRepository _IAccountRepository;
        public BankAccountsController(IAccountRepository iAccountRepository){
            _IAccountRepository=iAccountRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> CreateNewAccount(AccountDetail accountDetail)
        {
            var data=await _IAccountRepository.CreateNewAccount(accountDetail);
            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Account>>>> GetAll()
        {
            var data=await _IAccountRepository.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Account>>> GetById(int id)
        {
            var data=await _IAccountRepository.GetById(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(AccountDetail accountDetail)
        {
            var data =await _IAccountRepository.UpdateAccount(accountDetail);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            var data=await _IAccountRepository.DeleteAccount(id);
            return Ok(data);
        }
    }
}