namespace ApiTemplate.Domain.Validation
{
    public class ValidationResult
    {
        public enum ValidationErrorCode
        {
            InvalidEntity,
            Conflict,
            NotAllowed,
            NotFound
        };

        public ValidationErrorCode? ErrorCode { get; set; }
        public bool IsValid { get { return !Errors.Any(); } }
        public List<ValidationError> Errors { get; private set; }

        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }

        public ValidationResult Add(string errorMessage)
        {
            Errors.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(string errorMessage, ValidationErrorCode errorCode)
        {
            ErrorCode = errorCode;
            Errors.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            Errors.Add(error);
            return this;
        }

        public ValidationResult Remove(ValidationError error)
        {
            if (Errors.Contains(error)) Errors.Remove(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                Errors.AddRange(result.Errors);

            return this;
        }
    }
}