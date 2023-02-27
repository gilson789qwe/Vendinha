using Api.Data;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("/users")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> FindAll(
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
        var users = await contex.Users.AsNoTracking()
            .Skip(page)
            .Take(linesPerPage)
            .ToListAsync();
        
        List<UserModel> usersId = await _userRepository.FindAll();
        
        int totalElement;
        totalElement = usersId.Count();
        
        return Ok(Json(users,totalElement));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> FindById(int id)
    {
        UserModel users = await _userRepository.FindAllBy(id);
        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> Created([FromBody] UserModel userModel)
    {
        UserModel user = await _userRepository.Created(userModel);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
    {
        userModel.Id = id;
        UserModel user = await _userRepository.Update(userModel, id);
        return Ok(user);

    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserModel>> Delete(int id)
    {
        bool user = await _userRepository.Delete(id);
        return Ok(user);

    }
}