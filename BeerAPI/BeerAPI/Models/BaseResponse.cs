namespace BeerAPI.Models
{
    /// <summary>
    /// Base response model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}