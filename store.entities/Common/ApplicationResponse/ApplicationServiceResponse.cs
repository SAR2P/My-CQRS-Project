

namespace Store.Entities.Common.ApplicationResponse
{
    public class ApplicationServiceResponse
    {
        private readonly List<string> _Errors = new();

        public bool IsSucces => !IsFailed;
        public bool IsFailed => _Errors.Any();


        public void AddError(string error)
        {
            _Errors.Add(error);
        }
        
        public IReadOnlyList<string> Errors => _Errors;


    }

    public class ApplicationServiceResponse<TResult> : ApplicationServiceResponse
    {
        public TResult? Result { get; set; }
        public string? StatusMessage { get; set; }

    }
}
