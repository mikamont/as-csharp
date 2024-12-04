using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FornecedoresController : ControllerBase
{
    private readonly IRepository<Fornecedor> _fornecedorRepository;

    public FornecedoresController(IRepository<Fornecedor> fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Fornecedor>> Get()
    {
        return Ok(_fornecedorRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Fornecedor> Get(int id)
    {
        var fornecedor = _fornecedorRepository.GetById(id);
        if (fornecedor == null) return NotFound();
        return Ok(fornecedor);
    }

    [HttpPost]
    public ActionResult<Fornecedor> Post([FromBody] Fornecedor fornecedor)
    {
        _fornecedorRepository.Add(fornecedor);
        return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Fornecedor fornecedor)
    {
        var existingFornecedor = _fornecedorRepository.GetById(id);
        if (existingFornecedor == null) return NotFound();

        _fornecedorRepository.Update(fornecedor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _fornecedorRepository.Delete(id);
        return NoContent();
    }
}
