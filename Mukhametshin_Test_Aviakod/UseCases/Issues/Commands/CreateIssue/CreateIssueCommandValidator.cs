using FluentValidation;

namespace Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.CreateIssue;

using static CreateIssue;

public class CreateIssueCommandValidator : AbstractValidator<Command>
{
    public CreateIssueCommandValidator()
    {
        RuleFor(c => c.Data.Title)
            .Must(title => title != "Ничего не делать")
            .WithMessage("Ничего не делать это очень плохо!")
            .OverridePropertyName(nameof(Command.Data.Title));

        RuleFor(c => c.Data.Description)
            .Must(d => d.Contains("ну", StringComparison.OrdinalIgnoreCase) == false)
            .WithMessage("Давай не будем употреблять слова паразиты в описании задачи.")
            .OverridePropertyName(nameof(Command.Data.Description));
    }
}