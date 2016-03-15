using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;

/// <summary>
/// Based on: http://answers.unity3d.com/questions/743400/database-sqlite-setup-for-unity.html
/// </summary>
public class DataBaseLoader : MonoBehaviour 
{
    #region vars
    private SqliteConnection dbconn;
    #endregion
    #region init

    public void OpenDB (string name)
    {
        string conn = "URI=file:" + Application.streamingAssetsPath + "/"+name;
        dbconn = new SqliteConnection(conn);
        dbconn.Open();
    }

    public void CloseDB()
    {
        dbconn.Close();
        dbconn = null;
    }
    #endregion
    #region public interface
    public IDataReader RunQuery(string query)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();
        dbcmd.Dispose();
        dbcmd = null;
        return reader;
    }

    public void RunNonQuery(string nonQuery)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = nonQuery;
        int linesChanged = dbcmd.ExecuteNonQuery();
        if (linesChanged == 0) Debug.LogError("NonQuery: " + nonQuery + " changed no lines!");
        dbcmd.Dispose();
        dbcmd = null;
    }
    #endregion
}
