namespace BeerAPI.Models
{
    /// <summary>
    /// Model which will be used for handling exceptions in web API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExceptionResponse<T> : BaseResponse<T>
    {
        /// <summary>
        /// Errors
        /// </summary>
        public T Errors { get; set; }
    }
}