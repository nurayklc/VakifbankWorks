namespace RestfulAPI.ResponseModel
{
    public class CommonResponse<TEntity>
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; }
        public TEntity Data { get; set; }

        public CommonResponse(TEntity data)
        {
            Data = data;
        }
        public CommonResponse(string error)
        {
            Error = error;
            Success = false;
        }
    }
}
