using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Data;
using OrderServices.Dtos;
using OrderServices.Models;

namespace OrderServices.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _repo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadOrderDto>> GetAllOrder()
        {
            var orderItem = _repo.GetAllOrder();
            var orderReadDtoList = _mapper.Map<IEnumerable<ReadOrderDto>>(orderItem);
            return Ok(orderReadDtoList);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                var orderModel = _mapper.Map<Order>(createOrderDto);

                await _repo.CreateOrder(orderModel);
                _repo.SaveChanges();
                return Ok("Order Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}