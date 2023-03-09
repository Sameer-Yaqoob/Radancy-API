using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Entities;
using MyApi.Models;

namespace bankapi.Repository
{
    public class AccountRepository:IAccountRepository
    {
        public BankContext _bankContext;
        public AccountRepository(BankContext bankContext)
        {
            _bankContext=bankContext;
        }
        
        public async Task<ActionResult<ApiResponse<List<Account>>>> GetAll()
        {
            var data=await _bankContext.Account.ToListAsync();

            if (data != null)
            {
                var result = new ApiResponse<List<Account>>(data)
                {
                    Success = true
                };
                return result;
            }
            else{
                var result = new ApiResponse<List<Account>>(data)
                {
                    Success = false,
                    ErrorMessage="Data Not Found"
                };
                return result;
            }
        }

        public async Task<ActionResult<ApiResponse<Account>>> GetById(int id)
        {
            var data=await _bankContext.Account.Where(i=>i.id==id).FirstOrDefaultAsync();
            if (data != null)
            {
                var result = new ApiResponse<Account>(data)
                {
                    Success = true
                };
                return result;
            }
            else{
                var result = new ApiResponse<Account>(data)
                {
                    Success = false,
                    ErrorMessage="Data Not Found"
                };
                return result;
            }
        }

        public async Task<ActionResult<ApiResponse<string>>> CreateNewAccount(AccountDetail accountDetail){
            var account = new Account
            {
                AccountHolderName=accountDetail.AccountHolderName,
                AccountNumber = accountDetail.AccountNumber,
                AccountType=accountDetail.AccountType,
                BranchName=accountDetail.BranchName,
                IfscCode=accountDetail.IfscCode,
                Balance = accountDetail.Balance
            };
        
            await _bankContext.Account.AddAsync(account);
            _bankContext.SaveChanges();
            var result = new ApiResponse<string>("Account Created")
            {
                Success = true
            };
            return result;
        }
        public async Task<ActionResult<ApiResponse<string>>> UpdateAccount(AccountDetail accountDetail)
        {
            var accountToUpdate =await _bankContext.Account
            .Where(a => a.id == accountDetail.Id)
            .FirstOrDefaultAsync();

            if (accountToUpdate != null)
            {
                accountToUpdate.Balance = accountDetail.Balance;
                _bankContext.SaveChanges();
                var result = new ApiResponse<string>("Account Updated")
                {
                    Success = true
                };
                return result;
            }
            else{
                var result = new ApiResponse<string>("")
                {
                    Success = false,
                    ErrorMessage="Data Not Found"
                };
                return result;
            }
        }
        public async Task<ActionResult<ApiResponse<string>>> DeleteAccount(int id)
        {
            var data=await _bankContext.Account.Where(i=>i.id==id).FirstOrDefaultAsync();
            if (data != null)
            {
                _bankContext.Account.Remove(data);
                _bankContext.SaveChanges();
                var result = new ApiResponse<string>("Account Deleted")
                {
                    Success = true
                };
                return result;
            }
            else{
                var result = new ApiResponse<string>("")
                {
                    Success = false,
                    ErrorMessage="Data Not Found"
                };
                return result;
            }
        }
    }
}