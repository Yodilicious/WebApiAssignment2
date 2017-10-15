namespace Assignment2Music.Api.Controllers
{
    using System.Linq;
    using Database;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    [Produces("application/json")]
    [Route("api/v1/account")]
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromBody] LoginViewModel loginViewModel)
        {
            var artist = this.context.Artists.FirstOrDefault(a => a.Username.ToLower() == loginViewModel.Username.ToLower());

            if (artist == null)
            {
                return NotFound();
            }

            if (artist.Password == loginViewModel.Password)
            {
                return Ok("You are logged in.");
            }

            return NotFound();
        }

        [HttpPut]
        [Route("logout/{artistId}")]
        public IActionResult LoginUser(long artistId)
        {
            var artist = this.context.Artists.FirstOrDefault(a => a.RecordId == artistId);

            if (artist == null)
            {
                return NotFound();
            }
            
            return Ok("You are logged out!");
        }

        public AccountController(MusicDbContext context)
        {
            this.context = context;
        }

        private readonly MusicDbContext context;
    }
}