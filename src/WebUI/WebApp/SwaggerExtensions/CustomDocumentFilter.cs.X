//using Swashbuckle.AspNetCore.SwaggerGen;
//using Swashbuckle.Swagger;

namespace GM.WebUI.WebApp.SwaggerExtensions
{
    /* This code is from: https://freecodecamp.github.io/wiki/en/swashbuckle-swagger-operation-alphabetical-order/
     * It's an example of customizing how the swagger.json file is built. I wanted to change this to arrange the
     * model definitions in alphabetical order. Part of the instructions are to make the following change to a
     * swagger-config.yaml file in the root of the project:
     
          .EnableSwagger(c =>
                {
                    c.DocumentFilter<GM.WebUI.WebApp.SwaggerExtensions.CustomDocumentFilter>();
                }
            );

     *  However, I could not figure out how to create and then modify such a file.
     *  I could not find any documentation on this file's format.
     */


    /* swaggerdocument & idocumentfilter are not found. I was able to resolve them by installing
     * Swagger.Core, but I got a warning that this package was compatable with .Net 4 but not .Net Core/
     * Therefore I commented out this class.
     */

    //public class CustomDocumentFilter : IDocumentFilter
    //{
    //    public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, System.Web.Http.Description.IApiExplorer apiExplorer)
    //    {
    //        //make operations alphabetic
    //        var paths = swaggerDoc.paths.OrderBy(e => e.Key).ToList();
    //        swaggerDoc.paths = paths.ToDictionary(e => e.Key, e => e.Value);

    //        ////controller comments do not get added to swagger docs. This is how to add them.
    //        //AddControllerDescriptions(swaggerDoc, apiExplorer);

    //    }

    //    //private static void AddControllerDescriptions(SwaggerDocument swaggerDoc, System.Web.Http.Description.IApiExplorer apiExplorer)
    //    //{
    //    //    var doc = new YourPortal.Areas.HelpPage.XmlDocumentationProvider(GetXmlCommentsPath());

    //    //    List<Tag> lst = new List<Tag>();
    //    //    var desc = apiExplorer.ApiDescriptions;
    //    //    ILookup<HttpControllerDescriptor, ApiDescription> apiGroups = desc.ToLookup(api => api.ActionDescriptor.ControllerDescriptor);
    //    //    foreach (var apiGroup in apiGroups)
    //    //    {
    //    //        string tagName = apiGroup.Key.ControllerName;
    //    //        var tag = new Tag { name = tagName };
    //    //        var apiDoc = doc.GetDocumentation(apiGroup.Key);
    //    //        if (!String.IsNullOrWhiteSpace(apiDoc))
    //    //            tag.description = apiDoc;
    //    //        lst.Add(tag);

    //    //    }
    //    //    if (lst.Count() > 0)
    //    //        swaggerDoc.tags = lst.ToList();
    //    //}
    //    //private static string GetXmlCommentsPath()
    //    //{
    //    //    return System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/YourPortal.xml");
    //    //}
    //}
}

