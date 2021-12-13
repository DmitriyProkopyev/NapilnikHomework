using System;
using System.Linq;

namespace Model
{
    public delegate ValidationResult ValidationRule(string text);

    public class Validator
    {
        private readonly ValidationRule[] _rules;

        public Validator(params ValidationRule[] rules)
        {
            if (_rules.Any(rule => rule is null))
                throw new ArgumentException(nameof(rules));

            _rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }

        public ValidationResult Validate(string text)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Invoke(text);
                if (result.Success == false)
                    return result;
            }
                
            return new ValidationResult(true);
        }
    }
}
