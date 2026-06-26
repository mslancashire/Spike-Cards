namespace Cards.API.Common.DTO.Search;

public record BetweenSettings(int Min, int Max);

public class SearchValidationSettings
{
    public SearchValidationSettings()
    {
        BetweenValidations = new Dictionary<string, BetweenSettings>();
    }

    public IDictionary<string, BetweenSettings> BetweenValidations { get; }
}
