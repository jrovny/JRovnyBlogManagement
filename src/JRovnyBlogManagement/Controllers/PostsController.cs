using AutoMapper;
using JRovny.BlogManagement.Data;
using JRovny.BlogManagement.Data.EntityFramework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRovny.BlogManagement.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostsDataProvider _dataProvider;
        private readonly IMapper _mapper;
        private readonly ILogger<PostsController> _logger;

        public PostsController(
            PostsDataProvider dataProvider,
            IMapper mapper,
            ILogger<PostsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.PostSummary>> GetAllPostsAsync()
        {
            _logger.LogInformation("Getting all blog posts");

            return _mapper.Map<IEnumerable<Models.PostSummary>>(await _dataProvider.GetAllPostsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var post = _mapper.Map<Models.PostDetailView>(await _dataProvider.GetByIdAsync(id));

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Post post)
        {
            await _dataProvider.UpdateAsync(post);

            return Ok();
        }
    }
}
