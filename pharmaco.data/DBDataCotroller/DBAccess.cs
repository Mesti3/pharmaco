using System.Collections.Generic;
using System.Data.SqlClient;

namespace pharmaco.data.DBDataCotroller
{
    public class DBAccess
    {
        public static SqlConnection CreateConnection()
        {
            SqlConnection result = new SqlConnection();
            result.ConnectionString = "Data Source=" + System.Configuration.ConfigurationManager.AppSettings["DBserver"] + ";Initial Catalog=" + System.Configuration.ConfigurationManager.AppSettings["DBname"] + ";Connection Timeout=60;Trusted_Connection=False;Integrated Security=False;User Id=" + System.Configuration.ConfigurationManager.AppSettings["Username"] + ";Password=" + System.Configuration.ConfigurationManager.AppSettings["Password"]; 

            result.Open();
            return result;
        }
        /// <summary>
        /// Function to create connection and get result of sql select 
        /// </summary>
        /// <param name="sqlSelect">select sql query</param>
        /// <returns>opened reader</returns>
        /// <remarks>Do not use in transactions</remarks>
        public static SqlDataReader GetReader(string sqlSelect, List<SqlParameter> parameters = null)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (var command = new SqlCommand(sqlSelect, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        return reader;
                    }
                }
            }
        }
        public static string ReadFirstResult(string sqlSelect)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (var command = new SqlCommand(sqlSelect, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return reader[0].ToString();
                        else
                            return string.Empty;
                    }
                }
            }
        }
    }
}
