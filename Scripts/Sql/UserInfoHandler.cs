using UnityEngine;
using System.Collections;
using System.Data;

public class UserInfoHandler : Singleton< UserInfoHandler>{

    SqlHelper _sqlHelper;



    public UserInfoHandler()
    {
        _sqlHelper = new SqlHelper();
    }

    public bool Login(string userName, string pwd)
    {
        DataSet ds = _sqlHelper.Select("uid", "userinfo", string.Format("where username = '{0}' and userpwd = '{1}'", userName, pwd));
        return ds.Tables[0].Rows.Count > 0;
    }

    public bool Regist(string userName,string pwd)
    {
        if (Login(userName,pwd))
        {
            return false;
        }
        else
        {
            int result = _sqlHelper.Insert("userinfo", "(username,userpwd)", string.Format("'{0}','{1}'", userName, pwd));
            if (result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }


}
