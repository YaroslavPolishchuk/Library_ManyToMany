using LibraryApi.App_Start;
using System.Web.Http;

namespace LibraryApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Run();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Remove(
               GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
