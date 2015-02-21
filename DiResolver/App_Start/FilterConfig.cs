using System.Web.Mvc;

namespace DiResolver
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(DependencyResolver.Current.GetService<DebugFilter>());
        }
    }
}
