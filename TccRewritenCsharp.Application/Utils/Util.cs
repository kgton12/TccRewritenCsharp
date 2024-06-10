namespace TccRewritenCsharp.Application.Utils
{
    public class Util
    {
        public static void Validate(Object request)
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
                throw new Exception($"The following fields are missing or empty: {missingFieldsString}");
            }
        }
    }
}
