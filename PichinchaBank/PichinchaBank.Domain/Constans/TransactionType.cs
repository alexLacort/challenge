using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PichinchaBank.Domain.Constans
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionType
    {
        Withdrawals,
        Deposit
    }
}
