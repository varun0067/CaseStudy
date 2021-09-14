using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Service
{
    public interface ITokenGenerator
    {
        string GenerateToken(int userId,string userName);
    }
}
