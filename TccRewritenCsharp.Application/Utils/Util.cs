using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.Utils
{
    public class Util
    {
        public static ValidationValue Validate(Object request)
        {
            var properties = request.GetType().GetProperties();

            var missingFields = new List<string>();

            foreach (var property in properties)
            {
                var value = property.GetValue(request);

                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    missingFields.Add(property.Name);
                }
            }

            if (missingFields.Count != 0)
            {
                var missingFieldsString = string.Join(", ", missingFields);
                return new ValidationValue { IsValid = false, Message = $"The following fields are missing or empty: {missingFieldsString}" };
            }
            return new ValidationValue { IsValid = true, Message = string.Empty };
        }

        public static ValidationValue ValidateId(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out Guid result))
                return new ValidationValue { IsValid = false, Message = "ID invalid" };

            return new ValidationValue { IsValid = true, Message = string.Empty };
        }
    }
    public class ValidationValue()
    {
        public bool IsValid { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
