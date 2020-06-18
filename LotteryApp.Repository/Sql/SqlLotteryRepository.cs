using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LotteryApp.Models;

namespace LotteryApp.Repository.Sql
{
    public class SqlLotteryRepository : ILotteryRepository
    {
          private DbContextOptions<LotteryContext> _dbOptions;

        public SqlLotteryRepository(DbContextOptionsBuilder<LotteryContext> dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new LotteryContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public ICustomerRepository Customers => new SqlCustomerRepository(new LotteryContext(_dbOptions));

        //  Add for each entity required to be interacting with database
    }
}
