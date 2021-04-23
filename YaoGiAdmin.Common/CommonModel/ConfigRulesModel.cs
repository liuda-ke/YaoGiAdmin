using System;
using System.Collections.Generic;
using System.Text;

namespace YaoGiAdmin.Common.CommonModel
{
    public class ConfigRulesModel
    {
        /// <summary>
        /// 主键 
        /// <summary>
        public long Id { get; set; }

        /// <summary>
        /// 规则名称 
        /// <summary>
        public string RuleName { get; set; }

        /// <summary>
        /// 规则拆分节点类型 
        /// <summary>
        public string RuleType { get; set; }

        /// <summary>
        /// 规则表达式类型 
        /// <summary>
        public string RuleExpressionType { get; set; }

        /// <summary>
        /// 浅层规则表达式 
        /// <summary>
        public string ShallowExpression { get; set; }

        /// <summary>
        /// 节点信息
        /// </summary>
        public string Node { get; set; }

        /// <summary>
        /// 数据源表
        /// </summary>
        public string OriginTable { get; set; }

        /// <summary>
        /// 目标表
        /// </summary>
        public string TargetTable { get; set; }

        /// <summary>
        /// 是否启用 
        /// <summary>
        public bool IsEnable { get; set; }
    }
}
