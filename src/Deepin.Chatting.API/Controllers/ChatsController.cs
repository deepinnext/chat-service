using Deepin.Chatting.Application.Commands;
using Deepin.Chatting.Application.Queries;
using Deepin.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deepin.Chatting.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatsController(IMediator mediator, IChatQueries chatQueries, IUserContext userContext) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IChatQueries _chatQueries = chatQueries;
        private readonly IUserContext _userContext = userContext;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var chat = await _chatQueries.GetChatById(id);
            if (chat == null) return NotFound();
            return Ok(chat);
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var list = await _chatQueries.GetChats(_userContext.UserId);
            return Ok(list.OrderByDescending(x => x.UpdatedAt));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateChatCommand command)
        {
            var chat = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = chat.Id }, chat);
        }
        [HttpPost("direct")]
        public async Task<IActionResult> CreateDirectChat([FromBody] CreateDirectChatCommand command)
        {
            var chat = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = chat.Id }, chat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var chatMember = await _chatQueries.GetChatMember(chatId: id, _userContext.UserId);
            if (chatMember == null || !chatMember.IsOwner)
                return Forbid();
            await _mediator.Send(new DeleteChatCommand(id));
            return NoContent();
        }

        [HttpPost("{id}/join")]
        public async Task<IActionResult> JoinChat([FromBody] JoinChatCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("{id}/leave")]
        public async Task<IActionResult> LeaveChat([FromBody] LeaveChatCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
