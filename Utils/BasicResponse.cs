namespace APINETALL.Utils
{
    public class BasicResponse
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; } = false;
    }
    public class ModelResponse<T> : BasicResponse
    {
        /// <summary>
        ///     Modelo abstracto incluido en la respuesta
        /// </summary>
        public T Model { get; set; }
    }
    public class ListModelResponse<T> : BasicResponse
    {
        public List<T>? Model { get; set; }
    }

}