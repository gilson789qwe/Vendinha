using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<List<UserModel>>> FindAll()
    {
        List<UserModel> users = await _userRepository.FindAll();
        return Ok(users);
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