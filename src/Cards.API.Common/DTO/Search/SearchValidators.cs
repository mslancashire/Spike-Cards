using FluentValidation;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Cards.API.Common.DTO.Search;

internal static class SearchErrorCodes
{
    internal const string NOT_SUPPLIED = "SRCH_1";
    internal const string EMPTY = "SRCH_2";
    internal const string INVALID = "SRCH_3";
    internal const string BETWEEN_VALUE = "SRCH_4";
}

internal class SearchByNameValidator : AbstractValidator<SearchByName>
{
    public SearchByNameValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .WithErrorCode(SearchErrorCodes.NOT_SUPPLIED)
            .WithMessage("Name must be supplied for search.");
        
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithErrorCode(SearchErrorCodes.EMPTY)
            .WithMessage("Name must be supplied for search.");

        RuleFor(r => r.Name)
            .Must(n => n.Contains('&') == false)
            .WithErrorCode(SearchErrorCodes.INVALID)
            .WithMessage("Name used in search must not have invalid characters.");
    }
}

internal abstract class BaseBetweenValidator<TSearchType> : AbstractValidator<TSearchType>
{
    internal BaseBetweenValidator(IOptions<SearchValidationSettings> settings, Expression<Func<TSearchType, int>> selector, string valueName)
    {
        var searchSettings = settings.Value;
        if (searchSettings.BetweenValidations.TryGetValue(typeof(TSearchType).Name, out var betweenSettings) == false)
        {
            return;
        }

        RuleFor(selector)
            .InclusiveBetween(betweenSettings.Min, betweenSettings.Max)
            .WithErrorCode(SearchErrorCodes.BETWEEN_VALUE)
            .WithMessage($"{valueName} search value must be between {betweenSettings.Min} and {betweenSettings.Max}.");
    }
}

internal class SearchByCostValidator(IOptions<SearchValidationSettings> settings) : BaseBetweenValidator<SearchByCost>(settings, r => r.Cost, "Cost");
internal class SearchByHealthValidator(IOptions<SearchValidationSettings> settings) : BaseBetweenValidator<SearchByHealth>(settings, r => r.Health, "Health");
internal class SearchByAttackValidator(IOptions<SearchValidationSettings> settings) : BaseBetweenValidator<SearchByAttack>(settings, r => r.Attack, "Attack");