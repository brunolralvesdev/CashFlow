using CashFlow.Communication.Enum;

namespace CashFlow.Communication.Requests
{
    public class RequestRegisterExpenseJson
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EPaymentType PaymentType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

    }
}
