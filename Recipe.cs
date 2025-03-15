using System;
using System.Collections.Generic;

namespace Recipe.Models;

public partial class Recipe
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();

    public virtual User? User { get; set; }
}
