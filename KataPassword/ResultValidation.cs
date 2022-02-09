namespace KataPassword
{
    public class ResultValidation
    {
        public bool IsValid { get => !ErrorDescription.Any(); }
        public List<string> ErrorDescription { get; set; }
    }
}
