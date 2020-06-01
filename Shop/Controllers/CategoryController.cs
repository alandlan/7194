using Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shop.Data;

[Route("Categorias")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [Route("todas")]
    public async Task<ActionResult<List<Category>>> Get()
    {
        return new List<Category>();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        return new Category();
    }


    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Post (
        [FromBody]Category model,
        [FromServices]DataContext context)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
            
        context.Categories.Add(model);
        await context.SaveChangesAsync();
        return model;
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody]Category model)
    {
        if(id != model.Id)
            return NotFound(new {message = "Categoria não encontrada!"});

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(model);;
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Delete(int id)
    {
        return Ok();;
    }
}