using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Common.DTO.Search;

/// <summary>
/// A request to carry out a search to find all cards with the provided name.
/// </summary>
/// <remarks>For full comments, these records would need to be broken out.</remarks>
/// <param name="Name">Name of card/s to find.</param>
public record SearchByName([FromRoute] string Name);

public record SearchByDescription([FromRoute] string Description);

public record SearchByCost([FromRoute] int Cost);

public record SearchByHealth([FromRoute] int Health);

public record SearchByAttack([FromRoute] int Attack);

