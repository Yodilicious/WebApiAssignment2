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
    [Route("api/v1/review")]
    public class ReviewController : Controller
    {
        [HttpGet]
        [Route("~/api/v1/reviews/track/{trackId}")]
        public IEnumerable<ReviewViewModel> GetReviews(long trackId)
        {
            var reviews = this.context.Reviews.Include(r => r.Artist).Include(r => r.Track).Where(r => r.TrackId == trackId);

            return Mapper.Map<IEnumerable<ReviewViewModel>>(reviews);
        }

        [HttpGet]
        [Route("~/api/v1/reviews")]
        public IEnumerable<ReviewViewModel> GetReviews()
        {
            var reviews = this.context.Reviews.Include(r => r.Artist).Include(r => r.Track);

            return Mapper.Map<IEnumerable<ReviewViewModel>>(reviews);
        }

        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReview([FromRoute] long reviewId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var review = await this.context.Reviews.Include(r => r.Artist).Include(r => r.Track).SingleOrDefaultAsync(m => m.RecordId == reviewId);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ReviewViewModel>(review));
        }

        [HttpPut("{reviewId}")]
        public async Task<IActionResult> PutReview([FromRoute] long reviewId, [FromBody] ReviewViewModel reviewViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (reviewId != reviewViewModel.RecordId)
            {
                return BadRequest();
            }

            var review = Mapper.Map<Review>(reviewViewModel);

            this.context.Entry(review).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(reviewId))
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
        public async Task<IActionResult> PostReview([FromBody] ReviewViewModel reviewViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var review = Mapper.Map<Review>(reviewViewModel);

            this.context.Reviews.Add(review);
            await this.context.SaveChangesAsync();

            return Ok(new { reviewId = review.RecordId });
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview([FromRoute] long reviewId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var review = await this.context.Reviews.Include(r => r.Artist).Include(r => r.Track).SingleOrDefaultAsync(m => m.RecordId == reviewId);
            if (review == null)
            {
                return NotFound();
            }

            review.IsDeleted = true;
            await this.context.SaveChangesAsync();

            return Ok(Mapper.Map<ReviewViewModel>(review));
        }

        private bool ReviewExists(long reviewId)
        {
            return this.context.Reviews.Any(e => e.RecordId == reviewId);
        }

        public ReviewController(MusicDbContext context)
        {
            this.context = context;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Review, ReviewViewModel>()
                    .ForMember(t => t.ArtistName, opt => opt.MapFrom(a => a.Artist.ArtistName))
                    .ForMember(t => t.TrackName, opt => opt.MapFrom(g => g.Track.TrackName));
                cfg.CreateMap<ReviewViewModel, Review>();
            });
        }

        private readonly MusicDbContext context;
    }
}