using Microsoft.AspNetCore.Mvc;
using MyApi.Entities;
using MyApi.Models;

namespace bankapi.Repository
{
    public interface IAccountRepository
    {
        Task<ActionResult<ApiResponse<List<Account>>>> GetAll();
        Task<ActionResult<ApiResponse<Account>>> GetById(int id);
        Task<ActionResult<ApiResponse<string>>> CreateNewAccount(AccountDetail accountDetail);
        Task<ActionResult<ApiResponse<string>>> UpdateAccount(AccountDetail accountDetail);
        Task<ActionResult<ApiResponse<string>>> DeleteAccount(int id);
    }
}