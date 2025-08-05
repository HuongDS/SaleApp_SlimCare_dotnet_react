using Microsoft.AspNetCore.Mvc;
using SlimcareWeb.DataAccess.Entities;
using SlimcareWeb.Service.Dtos.Review;
using SlimcareWeb.Service.Interfaces;

namespace SlimcareApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this._reviewService = reviewService;
        }
        [HttpGet("/GetReview")]
        public async Task<ActionResult<IEnumerable<Review>>> GetAllAsync()
        {
            return Ok(await _reviewService.GetAllAsync());
        }
        [HttpGet("/GetReview/{id}")]
        public async Task<ActionResult<Review>> GetByIdAsync(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpGet("/GetReviewByProductId/{productId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetByProductIdAsync(int productId)
        {
            var reviews = await _reviewService.GetByProductIdAsync(productId);
            if (reviews == null || !reviews.Any())
            {
                return NotFound();
            }
            return Ok(reviews);
        }
        [HttpPost("/AddReview")]
        public async Task<ActionResult<ReviewViewDto>> AddAsync(CreateReviewDto data)
        {
            try
            {
                var review = await _reviewService.AddAsync(data);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/UpdateReview")]
        public async Task<ActionResult<ReviewViewDto>> UpdateAsync(ReviewUpdateDto data)
        {
            try
            {
                var review = await _reviewService.UpdateAsync(data);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/DeleteReview")]
        public async Task<ActionResult<Review>> SoftDeleteAsync(int id)
        {
            try
            {
                var review = await _reviewService.SoftDeleteAsync(id);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
