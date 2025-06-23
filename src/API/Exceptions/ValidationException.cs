﻿using System;
using System.Collections.Generic;

namespace API.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(IEnumerable<string> errors)
            : base("Erro(s) de validação.")
        {
            Errors = errors;
        }
    }
}