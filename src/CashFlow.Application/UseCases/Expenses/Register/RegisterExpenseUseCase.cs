using CashFlow.Communication.Enum;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

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
            var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);

            if (titleIsEmpty) 
                throw new ArgumentException("The title is required.");

            if (request.Amount <= 0)
                throw new ArgumentException("The Amount must to be greater than zero.");

            var paymentTypeIsValid = Enum.IsDefined(typeof(EPaymentType), request.PaymentType);

            if (paymentTypeIsValid == false)
                throw new ArgumentException("This payment type is invalid.");
        }
    }
}
