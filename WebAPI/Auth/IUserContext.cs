namespace WebAPI.Auth
{
    public interface IUserContext
    {
        /// <summary>
        /// ИД текущего пользователя
        /// </summary>
        string? CurrentUserId { get; }
    }
}
