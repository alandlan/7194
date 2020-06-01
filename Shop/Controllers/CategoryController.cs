using Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shop.Data;
using Microsoft.EntityFrameworkCore;
using System;

[Route("Categorias")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Category>>> Get([FromServices]DataContext context)
    {
        var categories = await context.Categories.AsNoTracking().ToListAsync();
        return Ok(categories);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById(
        int id,
        [FromServices]DataContext context)
    {
        var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return Ok(category);
    }


    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Post (
        [FromBody]Category model,
        [FromServices]DataContext context)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch(Exception)
        {
            
            return BadRequest(new { message = "Não foi possivel criar a categoria."});
        }
            
        
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Put(
        int id, 
        [FromBody]Category model,
        [FromServices]DataContext context)
    {
        if(id != model.Id)
            return NotFound(new {message = "Categoria não encontrada!"});

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Entry<Category>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Esse registro já foi atualizado"});
        }
        catch(Exception)
        {
            return BadRequest(new { message = "Não foi possivel atualizar a categoria."});
        }

    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Delete(
        int id,
        [FromServices]DataContext context)
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        if(category == null)
            return NotFound(new {message = "Categoria não localizada!"});

        try
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok(new { message = "Categoria removida com sucesso"});
        }
        catch (System.Exception)
        {
            return BadRequest(new { message = "Não possivel remover a categoria"});
        }
    }
}