namespace Pri.PE_Milan_Cheraft.Core.Models.Results
{
    public class AuthenticateResultModel
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Messages { get; set; } = new List<string>();
    }
}
