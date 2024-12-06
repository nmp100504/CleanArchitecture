namespace KS.Common.Response;

public class TableResponse<T>
{
    public TableResponse()
        {
            Code = 200;
            Success = true;
            Message = "";
            DataError = "";
            RecordsTotal = RecordsFiltered = 0;
            Data = new List<T>();
        }

        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string DataError { get; set; }
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T> Data { get; set; }

        public void SetDraw(int draw)
        {
            Draw = draw;
        }

}
