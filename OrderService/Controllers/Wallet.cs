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
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepo _repo;
        private readonly IMapper _mapper;

        public WalletController(IWalletRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("Sync")]
        public async Task<ActionResult> SyncWallet()
        {
            try
            {
                await _repo.CreateWallet();
                return Ok("Wallet Synced");
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not sync wallet: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadWalletDto>> GetWallet()
        {
            Console.WriteLine("--> Getting Platforms from ProductService");
            var walletItems = _repo.GetAllWallet();
            var walletReadDtoList = _mapper.Map<IEnumerable<ReadWalletDto>>(walletItems);
            return Ok(walletReadDtoList);
        }

    }
}