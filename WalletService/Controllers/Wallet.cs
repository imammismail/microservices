using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletServices.Data;
using WalletServices.Dtos;
using WalletServices.Models;

namespace WalletServices.Controllers
{
    [Route("api/v1/wallet/[controller]")]
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

        [HttpGet]
        public ActionResult<IEnumerable<ReadWalletDto>> GetAllProduct()
        {
            var walletItem = _repo.GetAllWallet();
            var walletReadDtoList = _mapper.Map<IEnumerable<ReadWalletDto>>(walletItem);
            return Ok(walletReadDtoList);
        }

        [HttpGet("{name}", Name = "GetByWalletName")]
        public async Task<ActionResult> GetByProductId(string name)
        {
            var wallet = await _repo.GetByName(name);
            var readWallet = _mapper.Map<ReadWalletDto>(wallet);
            return Ok(readWallet);
        }

        [HttpPut]
        public async Task<ActionResult> TopupWallet(TopupWalletDto topupWalletDto)
        {
            try
            {
                var wallet = _mapper.Map<Wallet>(topupWalletDto);
                wallet.UserName = topupWalletDto.UserName;
                await _repo.TopupWallet(wallet);
                _repo.SaveChanges();
                var returnWallet = await _repo.GetByName(topupWalletDto.UserName);
                var readProductDto = _mapper.Map<ReadWalletDto>(returnWallet);
                return Ok(readProductDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{name}", Name = "OrderWithWallet")]
        public async Task<ActionResult> OrderWallet(string name, OrderWalletDto orderWalletDto)
        {
            try
            {
                var wallet = _mapper.Map<Wallet>(orderWalletDto);
                wallet.UserName = name;
                await _repo.OrderWallet(name, wallet);
                _repo.SaveChanges();
                var returnWallet = await _repo.GetByName(name);
                var readProductDto = _mapper.Map<ReadWalletDto>(returnWallet);
                return Ok(readProductDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}