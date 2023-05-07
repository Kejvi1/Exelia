namespace BeerAPI.Models
{
    /// <summary>
    /// Model which will be used for returning OK responses from the API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OkResponse<T> : BaseResponse<T>
    {
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
    }
}