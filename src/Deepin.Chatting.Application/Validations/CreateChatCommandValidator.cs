using Deepin.Chatting.Application.Commands;
using FluentValidation;

namespace Deepin.Chatting.Application.Validations;

public class CreateChatCommandValidator : AbstractValidator<CreateChatCommand>
{
    public CreateChatCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}
