using CLIMFinders.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIMFinders.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(LoginResponseDto user);
    }
}
