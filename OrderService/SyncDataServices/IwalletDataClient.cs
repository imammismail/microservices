using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServices.Dtos;

namespace OrderServices.SyncDataServices
{
    public interface IWalletDataClient
    {
        Task<IEnumerable<ReadWalletDto>> ReturnAllWallet();
        Task<IEnumerable<ReadWalletDto>> GetWalletByname(string name);
    }
}