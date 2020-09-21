using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace YaoGiAdmin.CodeGenerate
{
    public  class GenerateTableService
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=YaoGiAdmin;Persist Security Info=True;User ID=sa;pwd=liuqi123");

        /// <summary>
        /// 生成表
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public  async Task<int> CreateTable(string TableName,string columns)
        {
            int res = 0;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                string sql = string.Format("CREATE TABLE {0}" + "({1})",TableName,columns);
                SqlCommand cmd = new SqlCommand(sql, connection);
                res = await cmd.ExecuteNonQueryAsync();
            }
            return res;
        }
    }
}
