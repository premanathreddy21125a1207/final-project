using System;
using System.Collections.Generic;

namespace Recipe.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Quantity { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
