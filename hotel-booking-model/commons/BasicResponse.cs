namespace hotel_booking_model.commons
{
    public class BasicResponse<TRes>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public TRes Data { get; set; }
        public virtual string Errors { get; set; }
    }
}
