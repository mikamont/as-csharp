using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly IRepository<Pedido> _pedidoRepository;

    public PedidosController(IRepository<Pedido> pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pedido>> Get()
    {
        return Ok(_pedidoRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Pedido> Get(int id)
    {
        var pedido = _pedidoRepository.GetById(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public ActionResult<Pedido> Post([FromBody] Pedido pedido)
    {
        _pedidoRepository.Add(pedido);
        return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Pedido pedido)
    {
        var existingPedido = _pedidoRepository.GetById(id);
        if (existingPedido == null) return NotFound();

        _pedidoRepository.Update(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _pedidoRepository.Delete(id);
        return NoContent();
    }
}
