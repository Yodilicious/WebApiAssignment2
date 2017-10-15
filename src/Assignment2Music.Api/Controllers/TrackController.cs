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
    [Route("api/v1/track")]
    public class TrackController : Controller
    {
        [HttpGet]
        [Route("~/api/v1/tracks")]
        public IEnumerable<TrackViewModel> GetTracks()
        {
            var tracks =  this.context.Tracks.Include(t => t.Artist).Include(t => t.Genre);

            return Mapper.Map<IEnumerable<TrackViewModel>>(tracks);
        }

        [HttpGet("{trackId}")]
        public async Task<IActionResult> GetTrack([FromRoute] long trackId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var track = await this.context.Tracks.Include(t => t.Artist).Include(t => t.Genre).SingleOrDefaultAsync(m => m.RecordId == trackId);

            if (track == null)
            {
                return NotFound();
            }
            
            return Ok(Mapper.Map<TrackViewModel>(track));
        }

        [HttpPut("{trackId}")]
        public async Task<IActionResult> PutTrack([FromRoute] long trackId, [FromBody] TrackViewModel trackViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (trackId != trackViewModel.RecordId)
            {
                return BadRequest();
            }

            var track = Mapper.Map<Track>(trackViewModel);

            this.context.Entry(track).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(trackId))
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
        public async Task<IActionResult> PostTrack([FromBody] TrackViewModel trackViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var track = Mapper.Map<Track>(trackViewModel);

            this.context.Tracks.Add(track);
            await this.context.SaveChangesAsync();

            return Ok(new { trackId = track.RecordId });
        }

        [HttpDelete("{trackId}")]
        public async Task<IActionResult> DeleteTrack([FromRoute] long trackId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var track = await this.context.Tracks.Include(t => t.Artist).Include(t => t.Genre).SingleOrDefaultAsync(m => m.RecordId == trackId);
            if (track == null)
            {
                return NotFound();
            }

            track.IsDeleted = true;
            await this.context.SaveChangesAsync();

            return Ok(Mapper.Map<TrackViewModel>(track));
        }

        private bool TrackExists(long trackId)
        {
            return this.context.Tracks.Any(e => e.RecordId == trackId);
        }

        public TrackController(MusicDbContext context)
        {
            this.context = context;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Track, TrackViewModel>()
                    .ForMember(t => t.ArtistName, opt => opt.MapFrom(a => a.Artist.ArtistName))
                    .ForMember(t => t.GenreName, opt => opt.MapFrom(g => g.Genre.Name));
                cfg.CreateMap<TrackViewModel, Track>();
            });
        }

        private readonly MusicDbContext context;
    }
}