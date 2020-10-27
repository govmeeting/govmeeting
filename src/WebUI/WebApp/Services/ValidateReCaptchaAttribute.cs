using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GM.WebApp.Services
{
    public class ValidateReCaptchaAttribute : ActionFilterAttribute
    {
        public const string ReCaptchaModelErrorKey = "ReCaptcha";
        private const string RecaptchaResponseTokenKey = "g-recaptcha-response";
        private const string ApiVerificationEndpoint = "https://www.google.com/recaptcha/api/siteverify";
        private readonly IConfiguration m_configuration;
        private readonly Lazy<string> m_reCaptchaSecret;
        public ValidateReCaptchaAttribute(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }
            this.m_configuration = configuration;
            this.m_reCaptchaSecret = new Lazy<string>(() => m_configuration["ReCaptcha:Secret"]);
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await DoReCaptchaValidation(context);
            await base.OnActionExecutionAsync(context, next);
        }
        private async Task DoReCaptchaValidation(ActionExecutingContext context)
        {
            // We use "false" as a string because in the Razor page for Login, etc, there is an error if the check is for a boolean.
            if (m_configuration["IncludeReCaptcha"] == "false")
            {
                return;
            }

            if (!context.HttpContext.Request.HasFormContentType)
            {
                // Get request? 
                AddModelError(context, "No reCaptcha Token Found");
                return;
            }
            string token = context.HttpContext.Request.Form[RecaptchaResponseTokenKey];
            if (string.IsNullOrWhiteSpace(token))
            {
                AddModelError(context, "No reCaptcha Token Found");
            }
            else
            {
                await ValidateRecaptcha(context, token);
            }
        }
        private static void AddModelError(ActionExecutingContext context, string error)
        {
            context.ModelState.AddModelError(ReCaptchaModelErrorKey, error.ToString());
        }
        private async Task ValidateRecaptcha(ActionExecutingContext context, string token)
        {
            using (var webClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("secret", this.m_reCaptchaSecret.Value),
                    new KeyValuePair<string, string>("response", token)
                });
                HttpResponseMessage response = await webClient.PostAsync(ApiVerificationEndpoint, content);
                string json = await response.Content.ReadAsStringAsync();
                var reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(json);
                if (reCaptchaResponse == null)
                {
                    AddModelError(context, "Unable To Read Response From Server");
                }
                else if (!reCaptchaResponse.success)
                {
                    AddModelError(context, "Invalid reCaptcha");
                }
            }
        }
    }
    public class ReCaptchaResponse
    {
        public bool success { get; set; }
        public string challenge_ts { get; set; }
        public string hostname { get; set; }
        public string[] errorcodes { get; set; }
    }
}