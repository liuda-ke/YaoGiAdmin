using System;

namespace YaoGiAdmin.Lib
{
    [Serializable]
    public class Response
    {
        public Response()
        {

        }
        /// <summary>
        /// 1成功  2错误  3失败(参考提示)
        /// </summary>
        public int Code { get; set; } = 1;

        public string Message { get; set; } = "成功";

        public object Data { get; set; } = null;
    }
}
