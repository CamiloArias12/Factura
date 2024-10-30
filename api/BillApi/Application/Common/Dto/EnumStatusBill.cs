namespace BillApi.Application.Common.Dto
{
    public enum EnumStatusBill
    {
        FirstReminder,
        SecondReminder,
        Disabled
    }

    public static class EnumStatusBillExtensions
    {
        private static readonly Dictionary<EnumStatusBill, string> _statusStrings = new()
        {
            { EnumStatusBill.FirstReminder, "primerRecordatorio" },
            { EnumStatusBill.SecondReminder, "segundoRecordatorio" },
            { EnumStatusBill.Disabled, "desactivado" }
        };

        public static string ToFriendlyString(this EnumStatusBill status)
        {
            return _statusStrings[status];
        }
    }
}
