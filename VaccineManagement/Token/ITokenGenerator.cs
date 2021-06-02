using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Token
{
    public interface ITokenGenerator
    {
        //baseada em login tenho que receber o email e a senha
        string GenerateToken();
    }
}
