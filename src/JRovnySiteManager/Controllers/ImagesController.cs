using JRovnySiteManager.Data;
using JRovnySiteManager.Data.EntityFramework.Models;
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
        public ImagesController(ImagesDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _dataProvider.GetAllAsync();
        }
    }
}