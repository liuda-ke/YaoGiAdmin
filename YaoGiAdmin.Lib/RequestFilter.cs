using Microsoft.AspNetCore.Http;

namespace YaoGiAdmin.Lib
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
