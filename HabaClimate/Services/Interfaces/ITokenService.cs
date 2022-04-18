using HabaClimate.Data.Models;

namespace HabaClimate.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}