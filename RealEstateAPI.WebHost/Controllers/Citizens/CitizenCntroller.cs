

using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Application.UseCase.Citizen.GetAllCitizen;
using RealEstateAPI.Domain.Exceptions;


namespace RealEstateAPI.WebHost.Controllers.Citizens;

[ApiController]
[Route("api/v{version:apiVersion}/citizens")]
[ApiVersion("1.0")]
public class CitizensController : ControllerBase
{
    private readonly ISender _sender;

    public CitizensController(ISender sender)
    {
        _sender = sender;
    }


    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CitizenListItemDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {

        //1.ساخت کوئری
       var query = new GetAllCitizenQuery();

        // 2. ارسال به لایه Application
        var result = await _sender.Send(query, cancellationToken);

        //3.بررسی نتیجه و برگرداندن پاسخ HTTP مناسب
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}