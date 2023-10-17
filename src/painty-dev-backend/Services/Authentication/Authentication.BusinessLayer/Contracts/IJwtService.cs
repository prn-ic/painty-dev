using Authentication.BusinessLayer.Models;
using Authentication.DomainLayer.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authentication.BusinessLayer.Contracts
{
    public interface IJwtService
    {
        public TokenModel CreateTokenPair(User user);
        public List<Claim> GenerateRefreshTokenClaims(User user);
        public List<Claim> GenerateAccessTokenClaims(User user);
        public JwtSecurityToken CreateToken(List<Claim> claims, DateTime expires);
        public ClaimsPrincipal GetClaimsPrincipal(string token);
        public string WriteToken(JwtSecurityToken token);
    }
}
