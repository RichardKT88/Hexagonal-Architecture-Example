using Hex.Arc.API.Models;
using Hex.Arc.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hex.Arc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountsController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
    {
        try
        {
            await _accountService.TransferFundsAsync(
                request.FromAccountId,
                request.ToAccountId,
                request.Amount);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
