using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YaoGiAdmin.Lib
{
    public class LoggerHelper
    {
        private ILog logger;
        public LoggerHelper()
        {
            if (logger == null)
            {
                var repository = LogManager.CreateRepository("NETCoreRepository");
                //log4net从log4net.config文件中读取配置信息
                XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
                logger = LogManager.GetLogger(repository.Name, "InfoLogger");
            }
        }

        /// <summary>
        /// Debug日志
        /// </summary>
        /// <param name="data">调试数据</param>
        public void Debug(object data)
        {
            logger.Debug(data);
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="exception">catch异常信息</param>
        public void Info(string controller, Exception exception = null)
        {
            if (exception == null)
                logger.Info(controller);
            else
                logger.Info(controller, exception);
        }

        /// <summary>
        /// 告警日志
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="exception"></param>
        public void Warn(string controller, Exception exception = null)
        {
            if (exception == null)
                logger.Warn(controller);
            else
                logger.Warn(controller, exception);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="exception"></param>
        public void Error(string controller, Exception exception = null)
        {
            if (exception == null)
                logger.Error(controller);
            else
                logger.Error(controller, exception);
        }
    }
}
