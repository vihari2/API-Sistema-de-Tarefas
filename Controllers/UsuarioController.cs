using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSystem.Models;
using WorkSystem.Repository.Interfaces;

namespace WorkSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchAllUsers()
        {

            List<UserModel> users = await _userRepository.SearchAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindById(int id)
        {

            UserModel user = await _userRepository.FindById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel userModel)
        {

            UserModel user = await _userRepository.Add(userModel);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool deleted = await _userRepository.Delete(id);
            return Ok(deleted);
        }
    }

}
