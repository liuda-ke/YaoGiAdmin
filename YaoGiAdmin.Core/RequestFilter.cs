using Microsoft.AspNetCore.Http;

namespace YaoGiAdmin.Core
{
    public class RequestFilter
    {
        public static IHttpContextAccessor httpContextAccessor;
        public static HttpContext GetContext()
        {
            HttpContext context=httpContextAccessor.HttpContext;

            return context;
        }   
    }

  
}
