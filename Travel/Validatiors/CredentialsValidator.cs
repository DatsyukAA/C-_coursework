using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Travel.Models.ViewModels;

namespace Travel.Validatiors
{
    public class CredentialsValidator : AbstractValidator<CredentialsVM>
    {
        public CredentialsValidator()
        {
            RuleFor(credential => credential.Email).NotEmpty().WithMessage("E-mail cannot be empty!");
            RuleFor(credential => credential.Password).NotEmpty().WithMessage("Passwrod cannot be empty!");
        }
    }
}
