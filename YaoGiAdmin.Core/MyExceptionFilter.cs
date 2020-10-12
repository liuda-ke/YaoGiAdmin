using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace YaoGiAdmin.Core
{

    public class MyExceptionFilter : ExceptionFilterAttribute
    {

        LoggerHelper _loggerHelper;

        public MyExceptionFilter(LoggerHelper loggerHelper)
        {
            _loggerHelper = loggerHelper;
        }

        public override void OnException(ExceptionContext context)
        {
            // 如果异常没有被处理则进行处理
            if (context.ExceptionHandled == false)
            {
                //定义返回信息
                Response res = new Response();
                res.Code = 5001;
                res.Message = "发生错误,请联系管理员";

                //写入日志
                _loggerHelper.Error(context.HttpContext.Request.Path, context.Exception);

                context.Result = new ContentResult
                {
                    // 返回状态码设置为200，表示成功
                    StatusCode = StatusCodes.Status200OK,
                    // 设置返回格式
                    ContentType = "application/json;charset=utf-8",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
            // 设置为true，表示异常已经被处理了
            context.ExceptionHandled = true;
        }
    }
}
