using System;
using System.Data.SqlClient;
using Dapper;

namespace ASP_TEST.Models
{
    public class Timer_Repository
    {
        string connectionString = "Data Source=SQL5080.site4now.net;Initial Catalog=db_a79439_regdb;User Id=db_a79439_regdb_admin;Password=qwerty009";
        public string Create(Time time)
        {
            string result = string.Empty;
            using (SqlConnection connection = new SqlConnection("connectionString"))
            {
                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "INSERT INTO [Time]([Date], [Time]) VALUES @date, @time";
                        var values = new
                        {
                            Time = time.time,
                            Date = time.date,
                        };
                        connection.Query(query, values, trans);
                        trans.Commit();
                        result = "Done!";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
