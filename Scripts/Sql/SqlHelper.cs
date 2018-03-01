using MySql.Data.MySqlClient;
using System.Data;


class SqlHelper
{
    MySqlConnection mySqlConn;
    MySqlCommand mySqlCmd;
    MySqlDataAdapter mySqlAdapter;
    const string sqlConnStr = "Server=localhost;Database=rts;Uid=root;Pwd=Lby1141200632;";

    public SqlHelper()
    {
        mySqlConn = new MySqlConnection(sqlConnStr);
        mySqlCmd = new MySqlCommand();
        mySqlCmd.Connection = mySqlConn;
    }



    public DataSet Select(string columnsName, string tableName, string condition)
    {
        mySqlConn.Open();
        DataSet ds = new DataSet();

        string sqlStr = string.Format("select {0} from {1} {2}", columnsName, tableName, condition);
        mySqlAdapter = new MySqlDataAdapter(sqlStr, mySqlConn);
        mySqlAdapter.Fill(ds);
        mySqlConn.Close();
        return ds;
    }

    public int Insert(string tableName, string columnsName, string values)
    {
        string sqlStr = string.Format("insert into {0} {1} values ({2})", tableName, columnsName, values);
        return ExecuteNoeQuery(sqlStr);
    }

    public int Delete(string tableName, string condition)
    {
        string sqlStr = string.Format("delete from {0} {1}", tableName, condition);
        return ExecuteNoeQuery(sqlStr);
    }

    public int Update(string tableName, string columnAndValue, string condition)
    {
        string sqlStr = string.Format("update {0} set {1} {2}", tableName, columnAndValue, condition);
        return ExecuteNoeQuery(sqlStr);
    }


    int ExecuteNoeQuery(string sqlStr)
    {
        int result = -1;
        mySqlConn.Open();
        mySqlCmd.CommandText = sqlStr;
        result = mySqlCmd.ExecuteNonQuery();
        mySqlConn.Close();
        return result;
    }
}
