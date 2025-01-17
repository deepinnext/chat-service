using Deepin.Chatting.Application.Commands;
using FluentValidation;

namespace Deepin.Chatting.Application.Validations;

public class CreateDirectChatCommandValidator : AbstractValidator<CreateDirectChatCommand>
{
    public CreateDirectChatCommandValidator()
    {
        RuleFor(x => x.UserIds).NotEmpty().WithMessage("UserIds is required");
    }
}
