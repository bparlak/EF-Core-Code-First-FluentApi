using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirstFluentApi.Models.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} boş bırakılamaz")
                .Length(2, 50).WithMessage("({TotalLength}) 2 karakterden az olamaz.")
                .Must(BeAValidName).WithMessage("{PropertyName} sadece harflerden oluşmalı.");

            RuleFor(c => c.SecondName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} boş bırakılamaz")
                .Length(2, 50).WithMessage("({TotalLength}) 2 karakterden az olamaz.")
                .Must(x=> x.Length <=15).WithMessage("{PropertyName} karakterden az olmalı.");

            RuleFor(c => c.UserName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz.")
                .Length(2, 50).WithMessage("({TotalLength}) 2 karakterden az olamaz.")
                .Must(BeAValidName).WithMessage("{PropertyName} sadece harflerden oluşmalı.");

            RuleFor(c => c.Email).NotNull()
                .NotEmpty().WithMessage("{PropertyName} alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir {PropertyName} giriniz.");
            RuleFor(a => a.Age)
                .LessThan(120).WithMessage("{PropertyName} {ComparisonValue} den küçük olmalı.")
                .GreaterThan(0).WithMessage("{PropertyName} {ComparisonValue} dan büyük olmalı.");
        }
        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(char.IsLetter);
        }
    }
}
