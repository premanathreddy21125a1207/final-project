using System;
using System.Collections.Generic;

namespace Recipe.Models;

public partial class Instruction
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int StepNumber { get; set; }

    public string StepDescription { get; set; } = null!;

    public virtual Recipe? Recipe { get; set; }
}
