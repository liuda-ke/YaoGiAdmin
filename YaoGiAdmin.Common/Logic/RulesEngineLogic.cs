using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YaoGiAdmin.Common.CommonModel;
using YaoGiAdmin.Core.Extensions;

namespace YaoGiAdmin.Common.Logic
{
    public class RulesEngineLogic
    {
        private static readonly Lazy<RulesEngineLogic> lazy = new Lazy<RulesEngineLogic>(() => new RulesEngineLogic());
        public static RulesEngineLogic Instance => lazy.Value;
        public static RulesEngine.RulesEngine GetRulesEngine(List<ConfigRulesModel> list)
        {
            var data = new
            {
                WorkflowName = "inputWorkflow",
                Rules = list.Select((t, i) => new
                {
                    RuleName = (t.RuleName + i.ToString()),
                    Expression = t.ShallowExpression,
                    SuccessEvent = (t.Node + $"_{t.RuleType}"),
                    RuleExpressionType = t.RuleExpressionType,
                })

            }.ToJson();
            var injectWorkflow = new WorkflowRules
            {
                WorkflowName = "inputWorkflowReference",
                WorkflowRulesToInject = new List<string> { "inputWorkflow" }
            };
            var injectWorkflowStr = JsonConvert.SerializeObject(injectWorkflow);
            var mockLogger = new Mock<ILogger>();
            return new RulesEngine.RulesEngine(new string[] { data, injectWorkflowStr }, mockLogger.Object);
        }
    }
}
