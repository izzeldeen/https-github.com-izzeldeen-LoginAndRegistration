using Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
