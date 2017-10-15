namespace Assignment2Music.Api.Controllers
{
    using System;
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
    [Route("api/v1/genre")]
    public class GenreController : Controller
    {
        [HttpGet]
        [Route("~/api/v1/genres")]
        public IEnumerable<GenreViewModel> GetGenres()
        {
            var genres = this.context.Genres;

            return Mapper.Map<IEnumerable<GenreViewModel>>(genres);
        }

        [HttpGet("{genreId}")]
        public async Task<IActionResult> GetGenre([FromRoute] long genreId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var genre = await this.context.Genres.SingleOrDefaultAsync(m => m.RecordId == genreId);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<GenreViewModel>(genre));
        }

        [HttpPut("{genreId}")]
        public async Task<IActionResult> PutGenre([FromRoute] long genreId, [FromBody] GenreViewModel genreViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (genreId != genreViewModel.RecordId)
            {
                return BadRequest();
            }

            var genre = Mapper.Map<Genre>(genreViewModel);

            this.context.Entry(genre).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(genreId))
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
        public IActionResult PostGenre([FromBody] GenreViewModel genreViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var genre = Mapper.Map<Genre>(genreViewModel);

            genre.IsDeleted = false;
            
            this.context.Genres.Add(genre);
            this.context.SaveChanges();
            
            return Ok(new { genreId = genre.RecordId });
        }

        [HttpDelete("{genreId}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] long genreId)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var genre = await this.context.Genres.SingleOrDefaultAsync(m => m.RecordId == genreId);
            if (genre == null)
            {
                return NotFound();
            }

            genre.IsDeleted = true;
            await this.context.SaveChangesAsync();

            return Ok(genre);
        }

        private bool GenreExists(long genreId)
        {
            return this.context.Genres.Any(e => e.RecordId == genreId);
        }
        
        public GenreController(MusicDbContext context)
        {
            this.context = context;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Genre, GenreViewModel>();
                cfg.CreateMap<GenreViewModel, Genre>();
            });
        }

        private readonly MusicDbContext context;
    }
}