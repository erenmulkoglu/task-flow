using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.DTOs.Auth;

namespace TaskFlow.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}
