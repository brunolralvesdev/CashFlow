using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidate : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidate() 
        {
            RuleFor(expense => expense.Title).Empty().WithMessage("The title is required.");
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The Amount must to be greater than zero.");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("This payment type is invalid.");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses cannot be for the future.");
        }
    }
}
