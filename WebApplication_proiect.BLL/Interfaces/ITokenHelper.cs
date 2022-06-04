using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;

namespace WebApplication_proiect.BLL.Helpers
{
    public interface ITokenHelper
    {
       
            Task<string> CreateAccessToken(User _User);
            string CreateRefreshToken();
            ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
        
    }
}
