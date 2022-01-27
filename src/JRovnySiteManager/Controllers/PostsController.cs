﻿using System.Collections.Generic;
using System.Threading.Tasks;
using JRovnySiteManager.Data;
using JRovnySiteManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace JRovnySiteManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostsDataProvider _dataProvider;
        public PostsController(PostsDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<List<PostSummary>> GetAllPostsAsync()
        {
            return await _dataProvider.GetAllPostsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var post = await _dataProvider.GetByIdAsync(id);

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
