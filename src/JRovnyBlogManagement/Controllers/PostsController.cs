﻿using AutoMapper;
using JRovny.BlogManagement.Data;
using JRovny.BlogManagement.Data.EntityFramework.Models;
using JRovny.BlogManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRovny.BlogManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostsDataProvider _dataProvider;
        private readonly IMapper _mapper;
        public PostsController(PostsDataProvider dataProvider, IMapper mapper)
        {
            _mapper = mapper;
            _dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.PostSummary>> GetAllPostsAsync()
        {
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