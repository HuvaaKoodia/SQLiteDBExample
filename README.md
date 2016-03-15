### SQLiteDBExample

Allows reading and writing to an SQLite database from Unity.
Works in the Unity Editor and as a 64-bit Windows build.

Project based on http://answers.unity3d.com/questions/743400/database-sqlite-setup-for-unity.html

## Step by step instructions for any DIY programmers:

# Getting hold of required DLLs:

- Download 64-bit sqlite Precompiled Binaries for Windows DLL from http://www.sqlite.org/download.html
- Copy Mono.Data.Sqlite.dll & System.Data.dll from Unity folder (for example: "C:\Program Files\Unity\Editor\Data\Mono\lib\mono\2.0")
- Add all three dlls to the "Assets/Plugins" folder in the Unity project.

# Creating a database:

- Create a sqlite database your program of choice (for instance: http://sqliteadmin.orbmu2k.de/)
- Add database to the "Assets/StreamingAssets" folder

## Working with the database (example code):

# Opening a database:

		string conn = "URI=file:" + Application.streamingAssetsPath + "/"+name; //Path to database.
		dbconn = new SqliteConnection(conn);
		dbconn.Open();
	
# Running a query:

		IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "SELECT * FROM Table";
        IDataReader reader = dbcmd.ExecuteReader();
        dbcmd.Dispose();
        dbcmd = null;
        
# Iterating a query (depends on your database, of course):

		while (reader.Read())
		{
			var id = reader.GetInt32(0);
			var value = reader.GetInt32(1);

			Debug.Log("ID = " + id + "  VALUE = " + value);
		}
		
# Closing a database:

		dbconn.Close();
        dbconn = null;
		
The DataBaseLoader class has a simple public interface for this functionality.

## Making a build:

- Set the "API compatibility level" in Unity Player Settings to ".NET 2.0"
- Set the Windows Build Architecture to "x86-64"
- Build