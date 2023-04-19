using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServices.Dtos;

namespace OrderServices.SyncDataServices
{
    public interface IProductDataClient
    {
        Task<IEnumerable<ReadProductDto>> ReturnAllProduct();
        Task<IEnumerable<ReadProductDto>> GetProductByname(string name);
    }

}