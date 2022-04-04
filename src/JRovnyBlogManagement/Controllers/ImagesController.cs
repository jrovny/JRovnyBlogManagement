using AutoMapper;
using JRovny.BlogManagement.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRovny.BlogManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ImagesDataProvider _dataProvider;
        private readonly IMapper _mapper;
        public ImagesController(ImagesDataProvider dataProvider, IMapper mapper)
        {
            _mapper = mapper;
            _dataProvider = dataProvider;
        }

        public async Task<IEnumerable<Models.Image>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Models.Image>>(await _dataProvider.GetAllAsync());
        }
    }
}