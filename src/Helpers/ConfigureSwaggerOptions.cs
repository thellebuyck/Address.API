using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Addresses.API.Helpers
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider) => this.apiVersionDescriptionProvider = apiVersionDescriptionProvider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoApiVersion(description));
            }
        }


        private static OpenApiInfo CreateInfoApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Signs365 Address API",
                Version = description.ApiVersion.ToString(),
                Description = "REST Service for the Signs365 Address API",
                Contact = new OpenApiContact
                {
                    Name = "Address.API",
                    Email = "info@signs365.com",
                    Url = new Uri("https://signs365.com")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "<strong> This API Version of Signs365 AddressAPI  has been deprecated. </strong>";
            }
            return info;
        }
    }
}
