namespace hotel_booking_model.commons
{
    public class BasicResponse<TRes> where TRes : class
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public TRes Data { get; set; }
    }
}
