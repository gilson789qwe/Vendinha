using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("/debts")]
[ApiController]
public class DebtController : Controller
{

    private readonly IDebtRepository _debtRepository;

    public DebtController(IDebtRepository debtRepository)
    {
        _debtRepository = debtRepository;
    }
    
    [EnableCors("AnotherPolicy")]
    [HttpGet]
    public async Task<ActionResult<List<DebtModel>>> FindAll()
    {
        List<DebtModel> debts = await _debtRepository.FindAll();
        return Ok(debts);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DebtModel>> FindById(int id)
    {
        DebtModel debts = await _debtRepository.FindAllBy(id);
        return Ok(debts);
    }

    [HttpPost]
    public async Task<ActionResult<DebtModel>> Created([FromBody] DebtModel debtModel)
    {
        
        DebtModel user = await _debtRepository.Created(debtModel);
        
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DebtModel>> Update([FromBody] DebtModel debtModel, int id)
    {
        debtModel.Id = id;
        DebtModel user = await _debtRepository.Update(debtModel, id);
        return Ok(user);

    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<DebtModel>> Delete(int id)
    {
        bool user = await _debtRepository.Delete(id);
        return Ok(user);

    }
}