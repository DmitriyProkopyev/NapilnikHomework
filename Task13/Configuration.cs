namespace Model
{
    public class Configuration
    {
        private readonly Validator _validator;
        private readonly Database _database;
        
        public Configuration()
        {
            var notEmpty = new ValidationRule(text => 
            new ValidationResult(text != string.Empty && text != null));

            var containsOnlyDigits = new ValidationRule(text => 
            new ValidationResult(ulong.TryParse(text, out ulong _)));

            var hasCorrectLength = new ValidationRule(text => 
            new ValidationResult(text.Length == 10));

            _validator = new Validator(notEmpty, containsOnlyDigits, hasCorrectLength);
            _database = new Database();
        }

        public Result Execute(string passport)
        {
            var validationResult = _validator.Validate(passport);

            if (validationResult.Success == false)
                return validationResult;

            return _database.MakeRequest(passport);
        }
    }
}
