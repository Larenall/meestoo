using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meestoo.Infrastructure.Helper
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(int id,string email, List<User> list);
    }
}
