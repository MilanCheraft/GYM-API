namespace Pri.PE_Milan_Cheraft.Core.Models.Results
{
    public class ResultModel<T>
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Value { get; set; }
    }
}
