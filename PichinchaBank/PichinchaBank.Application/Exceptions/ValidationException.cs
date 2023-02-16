﻿using FluentValidation.Results;

namespace PichinchaBank.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException() : base("We have an issue on validation process")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                             .ToDictionary(fg => fg.Key, fg => fg.ToArray());
        }
    }
}
