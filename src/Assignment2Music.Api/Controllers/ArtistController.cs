namespace Assignment2Music.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Database;
    using Models;
    using ViewModels;

    [Produces("application/json")]
    [Route("api/v1/artist")]
    public class ArtistController : Controller
    {
        [HttpGet]
        [Route("~/api/v1/artists")]
        public IEnumerable<ArtistViewModel> RetrieveArtists()
        {
            var artists = this.context.Artists;

            return Mapper.Map<IEnumerable<ArtistViewModel>>(artists);
        }

        [HttpGet("{artistId}")]
        public async Task<IActionResult> RetrieveArtist([FromRoute] long artistId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artist = await this.context.Artists.SingleOrDefaultAsync(m => m.RecordId == artistId);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ArtistViewModel>(artist));
        }

        [HttpPut("{artistId}")]
        public async Task<IActionResult> UpdateArtist([FromRoute] long artistId, [FromBody] ArtistViewModel artistViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (artistId != artistViewModel.RecordId)
            {
                return BadRequest();
            }

            var artist = Mapper.Map<Artist>(artistViewModel);

            this.context.Entry(artist).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(artistId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistViewModel artistViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artist = Mapper.Map<Artist>(artistViewModel);

            artist.IsDeleted = false;

            this.context.Artists.Add(artist);
            await this.context.SaveChangesAsync();

            return Ok(new { artistId = artist.RecordId });
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> RemoveArtist([FromRoute] long artistId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artist = await this.context.Artists.SingleOrDefaultAsync(m => m.RecordId == artistId);
            if (artist == null)
            {
                return NotFound();
            }

            artist.IsDeleted = true;
            await this.context.SaveChangesAsync();

            return Ok(artist);
        }

        private bool ArtistExists(long artistId)
        {
            return this.context.Artists.Any(e => e.RecordId == artistId);
        }

        public ArtistController(MusicDbContext context)
        {
            this.context = context;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Artist, ArtistViewModel>();
                cfg.CreateMap<ArtistViewModel, Artist>();
            });
        }

        private readonly MusicDbContext context;
    }
}