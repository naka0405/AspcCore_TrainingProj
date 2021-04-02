﻿using Banks.BusinessLogic.Interfaces;
using Banks.ViewModels.ViewModels;
using Banks.ViewModels.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Banks.API.Controllers
{
    /// <summary>
    /// The controller class to manage Account entity.
    /// Contains methods for performing accounts.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]  
    [Authorize(AuthenticationSchemes="Bearer")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        /// <summary>
        /// Creates an instance of AccountController.
        /// </summary>
        /// <param name="service">Instance of AccountService.</param>
        public AccountController(IAccountService service)
        {
            accountService = service;
        }


        /// <summary>       
        /// Get all accounts by identification code of client.
        /// </summary>
        /// <param name="bankId">A integer precision number.</param>
        /// <param name="clientCode">A string clientCode.</param>
        [HttpGet]
        public async Task<IActionResult> GetAllByCode([FromQuery] int bankId, string clientCode)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await accountService.GetClientAccountsByCode(bankId, clientCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }            
        }

        /// <summary>       
        /// Get all accounts by bankId, int currencyCode.
        /// </summary>
        /// <param name="currencyCode">Account currency code.</param>
        [HttpGet]
        public async Task<IActionResult> GetAllByCurrency([FromQuery] int bankId, int currencyCode)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input");
                }
                var result = await accountService.GetByCurrency(bankId, currencyCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Get account by Id.
        /// </summary>
        /// <param name="id">Identifier for the account.</param>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input");
                }
                var result = await accountService.GetById<GetByIdAccountViewModel>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Create new account for client.
        /// </summary>
        /// <param name="model">View model with parameters.</param>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input!");
                }
                var newId = await accountService.Create(model);
                if (newId > 0)
                {                   
                    return Ok(newId);
                }
                return BadRequest("Server Error!");
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Update number, currency for account.
        /// </summary>
        /// <param name="model">View model with parameters.</param>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input!");
                }
                 await accountService.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }

        /// <summary>       
        /// Delete some account.
        /// </summary>
        /// <param name="id">Identifier for the account.</param>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input!");
                }
                await accountService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequestViewModel(ex));
            }
        }
    }
}
