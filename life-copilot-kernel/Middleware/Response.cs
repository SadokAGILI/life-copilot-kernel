namespace life_copilot_kernel.Middleware
{
    public class Response
    {
        public Response()
        {
            Data = null;
        }
        public int Status { get; set; }
        public string Title { get; set; }
        public string ErrorStatus { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
