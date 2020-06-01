using Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

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
    public async Task<ActionResult<Category>> Post ([FromBody]Category model)
    {
        return Ok(model);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Put(int id, [FromBody]Category model)
    {
        if(model.Id == id)
            return model;

        return NotFound();;
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> Delete(int id)
    {
        return Ok();;
    }
}