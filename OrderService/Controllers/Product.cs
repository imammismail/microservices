using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Data;
using OrderServices.Dtos;
using OrderServices.Models;

namespace ProductServices.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("Sync")]
        public async Task<ActionResult> SyncProduct()
        {
            try
            {
                await _repo.CreateProduct();
                return Ok("Product Synced");
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not sync product: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadProductDto>> GetProduct()
        {
            Console.WriteLine("--> Getting Platforms from ProductService");
            var productItems = _repo.GetAllProduct();
            var productReadDtoList = _mapper.Map<IEnumerable<ReadProductDto>>(productItems);
            return Ok(productReadDtoList);
        }

    }
}