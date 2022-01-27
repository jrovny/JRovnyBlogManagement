using AutoMapper;
using JRovnySiteManager.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRovnySiteManager.Controllers
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