using UnityEngine;

public class Example:MonoBehaviour
{
    public DataBaseLoader DBLoader;

	public void Start()
	{
        DBLoader.OpenDB("DB.s3db");

        //read values
        var reader = DBLoader.RunQuery("SELECT * from Table1");
        reader.Read();
        var var1 = reader.GetInt32(1);
        reader.Read();
        var var2 = reader.GetInt32(1);

        Debug.Log(string.Format("Var 1 is {0} and Var 2 is {1}", var1, var2));

        reader.Dispose();
        reader = null;

        //write values
        ++var1;
        ++var2;

        DBLoader.RunNonQuery(string.Format("UPDATE Table1 set VALUE = {0} where ID = 'Var1'", var1));
        DBLoader.RunNonQuery(string.Format("UPDATE Table1 set VALUE = {0} where ID = 'Var2'", var2));

        Debug.Log("Updated Var 1 to " + var1 + " and Var 2 to " + var2);

        DBLoader.CloseDB();
    }
}