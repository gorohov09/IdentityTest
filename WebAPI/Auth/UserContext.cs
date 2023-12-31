﻿using System.Security.Claims;

namespace WebAPI.Auth
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="httpContextAccessor">Адаптер Http-context'а</param>
        public UserContext(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        /// <inheritdoc/>
        public string? CurrentUserId => User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
    }
}
