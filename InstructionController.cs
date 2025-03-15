//using Microsoft.AspNetCore.Mvc;

//namespace Recipe.Controllers
//{
//    public class InstructionController : Controller
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
using Recipe.Models;
using System;
using Recipe.Data;

namespace RecipeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly ProjectdbContext _context;

        public InstructionsController(ProjectdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instruction>>> GetInstructions()
        {
            return await _context.Instructions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instruction>> GetInstruction(int id)
        {
            var instruction = await _context.Instructions.FindAsync(id);
            if (instruction == null) return NotFound();
            return instruction;
        }

        [HttpPost]
        public async Task<ActionResult<Instruction>> CreateInstruction(Instruction instruction)
        {
            _context.Instructions.Add(instruction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInstruction), new { id = instruction.Id }, instruction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstruction(int id, Instruction instruction)
        {
            if (id != instruction.Id) return BadRequest();
            _context.Entry(instruction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstruction(int id)
        {
            var instruction = await _context.Instructions.FindAsync(id);
            if (instruction == null) return NotFound();
            _context.Instructions.Remove(instruction);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
