using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SalaryManagement.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace SalaryManagement.Utility.Validation
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }

    public class ValidationResultModel
    {
        private readonly List<ValidationError> Errors;

        public int StatusCode { get; }
        public string Status { get; }
        public string Message { get; }
        public JObject Data { get; set; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Data = new();
            StatusCode = StatusCodes.Status400BadRequest;
            Status = StatusResponse.Failed;
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key]
                    .Errors.Select(x => new ValidationError(JsonNamingPolicy.CamelCase.ConvertName(key), x.ErrorMessage)))
                    .ToList();

            foreach (var error in Errors)
            {
                if (error.Message.Contains("Could not convert"))
                {
                    error.Message = "The input data type is not correct.";
                }
            }

            Data.Add(new JProperty("errorCount", modelState.ErrorCount));
            Data.Add(new JProperty("errors", JToken.FromObject(Errors)));
        }
    }

    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }

    public class ValidationModel
    {
        public static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
