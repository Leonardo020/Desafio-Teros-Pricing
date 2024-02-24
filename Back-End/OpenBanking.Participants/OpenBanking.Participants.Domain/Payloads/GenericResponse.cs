namespace OpenBanking.Participants.Domain.Payloads
{
    public class GenericResponse<T>(bool success, string message)
    {
        public bool Success { get; set; } = success;
        public string Message { get; set; } = message;
        public T? Data { get; set; }

        public GenericResponse(bool success, string message, T? data) : this(success, message)
        {
            Data = data;
        }
    }
}
