//using Microsoft.AspNetCore.Mvc;

//namespace Recipe.Controllers
//{
//    public class RecipeController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using RecipeApp.Data;
using Recipe.Models;
using System;
using Recipe.Data;

namespace RecipeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ProjectdbContext _context;

        public RecipesController(ProjectdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe.Models.Recipe>>> GetRecipes()
        {
            return await _context.Recipes.Include(r => r.Ingredients).Include(r => r.Instructions).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe.Models.Recipe>> GetRecipe(int id)
        {
            var recipe = await _context.Recipes.Include(r => r.Ingredients).Include(r => r.Instructions).FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null) return NotFound();
            return recipe;
        }

        [HttpPost]
        public async Task<ActionResult<Recipe.Models.Recipe>> CreateRecipe(Recipe.Models.Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, Recipe.Models.Recipe recipe)
        {
            if (id != recipe.Id) return BadRequest();
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return NotFound();
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
