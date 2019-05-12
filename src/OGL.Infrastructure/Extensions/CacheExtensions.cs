using Microsoft.Extensions.Caching.Memory;
using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDto jwtDto)
            => cache.Set(GetJwtKey(tokenId), jwtDto, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDto>(GetJwtKey(tokenId));
        public static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}
