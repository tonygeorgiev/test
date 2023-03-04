using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ProjectManager.Core.Common.Contracts;
using ProjectManager.Core.Common.Exceptions;

namespace ProjectManager.Core.Common.Providers
{
    public class Validator : IValidator
    {
        public void Validate<T>(T obj) where T : class
        {
            var validationErrors = this.GetValidationErrors(obj);
            var valid = validationErrors.Count() == 0;

            if (!valid)
            {
                this.LogValidationErrors(validationErrors);
            }
        }

        public void LogValidationErrors(IEnumerable<string> validationErrors)
        {
            throw new UserValidationException(validationErrors.First());
        }

        private IEnumerable<string> GetValidationErrors(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Type attrType = typeof(ValidationAttribute);

            foreach (var propertyInfo in properties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);

                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;

                    bool valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}
