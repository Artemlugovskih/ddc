using Building_Materials.Entity;
using Building_Materials.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Materials.Core
{
    public class AuthHelper
    {
        private TradeEntities _db;

        public AuthHelper()
        {
            _db = new TradeEntities();
        }

        public async Task<bool> AuthHelp(string login, string password)
        {
            var user = await _db.User.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);

            if (user == null)
                return false;

            UserSingletone.User = user;
            return true;
        }
    }
}
