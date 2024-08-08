using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);


            return new ResponseRegisteredExpenseJson
            {
                Id = Guid.NewGuid(),
                Title = request.Title
            };
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            var validator = new RegisterExpenseValidate();

            var result = validator.Validate(request);




            if (!result.IsValid)
            {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
