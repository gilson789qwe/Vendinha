using Api.Data;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("/customers")]
[ApiController]
public class CustomerDebtController : Controller
{
    private readonly ICustomerDebtRepository _customerDebtRepository;

    public CustomerDebtController(ICustomerDebtRepository customerDebtRepository)
    {
        _customerDebtRepository = customerDebtRepository;
    }
    
    [EnableCors("AnotherPolicy")]
    [HttpGet]
    public async Task<ActionResult<List<CustomerDebtModel>>> FindAll(
        [FromServices] SystemTaskDBContex contex,
        [FromQuery]int page = 0,
        [FromQuery]int linesPerPage = 10
    )
    {
        if (page != 1)
        {
            page = (page-1) * 10;
        }
        else
        {
            page = 0;
        }

        List<CustomerDebtModel> customer;
        try
        {
            customer = await contex.CustomerDebts.AsNoTracking()
                .Skip(page)
                .Take(linesPerPage)
                .OrderByDescending(c => c.ValorTotal)
                .ToListAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        
        
        List<CustomerDebtModel> customerId = await _customerDebtRepository.FindAll();
        
        int totalElement;
        totalElement = customerId.Count();
        
        return Ok(Json(customer,totalElement));
    }
    
    [HttpPost]
    public async Task<ActionResult<CustomerDebtModel>> Created([FromBody] CustomerDebtModel customerDebtModel)
    {
        
        CustomerDebtModel customer = await _customerDebtRepository.Created(customerDebtModel);
        
        return Ok(customer);
    }
    
}