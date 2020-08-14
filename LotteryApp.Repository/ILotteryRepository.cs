using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp.Repository
{
    public interface ILotteryRepository
    {
        //ICustomerRepository customer { get; }
        ICustomerRepository Customers { get; }
        // Add for each of the entities to interact with the backend database.
    }
}
