using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mukhametshin_Test_Aviakod.Controllers.Base;
using Mukhametshin_Test_Aviakod.Dto.Common;
using Mukhametshin_Test_Aviakod.Dto.Issue;
using Mukhametshin_Test_Aviakod.Mappers.Issue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.CreateIssue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.DeleteIssue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.UpdateIssue;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Queries.FindIssues;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Queries.GetIssue;

namespace Mukhametshin_Test_Aviakod.Controllers;

[ApiController]
[Route("api/issues")]
public class IssueController : BaseController
{
    private readonly IMediator _mediator;

    public IssueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<IssueDto>> Find([FromQuery] IssueFindDto dto)
    {
        var response = await _mediator.Send(new FindIssues.Query(dto.ToData(), UserId));
        return response.Issues.Select(i => i.ToDto()).ToList();
    }

    [HttpGet("{issueId:guid}")]
    public async Task<ActionResult<IssueDto>> Get(Guid issueId)
    {
        var response = await _mediator.Send(new GetIssue.Query(issueId, UserId));
        if (response.Data is null)
        {
            return NotFound();
        }
        
        return Ok(response.Data!.ToDto());
    }

    [HttpPost]
    public async Task<SimpleDto<Guid>> Create([FromBody] IssueCreateDto dto)
    {
        var id = await _mediator.Send(new CreateIssue.Command(dto.ToData(), UserId));
        return new SimpleDto<Guid>(id);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(IssueUpdateDto dto)
    {
        await _mediator.Send(new UpdateIssue.Command(dto.ToData(), UserId));
        return NoContent();
    }

    [HttpDelete("{issueId:guid}")]
    public async Task<IActionResult> Delete(Guid issueId)
    {
        await _mediator.Send(new DeleteIssue.Command(issueId, UserId));
        return NoContent();
    }
}