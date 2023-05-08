using WpfTZ.ViewModels;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace WpfTZ.Models
{
    public enum MessageType
    {
        Success,
        InputError,
        InternalError
    }



    public struct Message
    {
        public string messageText;
        public MessageType type;
        public Message(string messageText, MessageType type)
        {
            this.messageText = messageText;
            this.type = type;
        }
    }
    public static class DB_Worker
    {
        //static SQLiteConnection connection = (new SQLiteConnection("Data Source=/DataBase/UserData.db;foreign keys=true;")).OpenAndReturn();
        static SQLiteConnection connection = (new SQLiteConnection("Data Source=UserData.db;foreign keys=true;")).OpenAndReturn();
        private static List<T> ListBuilder<T>(params T[] listElements)
        {
            
            List<T> result = new List<T>();
            foreach (T elem in listElements)
            {
                result.Add(elem);
            }
            return result;
        }

        #region TABLE MANIPULATIONS

        private static bool ChangeRowValuesById(string tableName, List<string> columnNames, List<string> values, int id)
        {
            if (columnNames.Count != values.Count)
            {
                MessageSend(new Message("the count of column names does not match the count of values in InsertToTable()", MessageType.InternalError));
                return false;
            }
            SQLiteCommand command = new SQLiteCommand(connection);
            List<string> columnNames_values = new List<string>();
            for (int i = 0; i < values.Count; i++)
            {
                command.Parameters.AddWithValue("$i" + i, values[i]);
                values[i] = "$i" + i;
                columnNames_values.Add(columnNames[i]+" = "+values[i]);
            }
            command.CommandText = $"UPDATE {tableName} SET {string.Join(",", columnNames_values.ToArray())} WHERE id = $id ;";
            command.Parameters.AddWithValue("$id", id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                command.Dispose();
                MessageSend(new Message(e.Message, MessageType.InternalError));
                return false;
            }
            command.Dispose();
            MessageSend(new Message("success", MessageType.Success));
            return true;
        }

        private static bool GetRowFromTableIfExists(string tableName, string columnName, string value, out List<string> result)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            result = new List<string>();
            command.CommandText = $"SELECT * From {tableName} WHERE {columnName} = $value;";
            command.Parameters.AddWithValue("$value", value);
          
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return false;
            }
            for (int i = 0; i< reader.FieldCount; i++){
                result.Add(reader.GetValue(i).ToString());
            }
                
            
            
            return true;
        }
        private static bool InsertToTable(string tableName,List<string> columnNames, List<string> values)
        {
            if(columnNames.Count != values.Count)
            {
                MessageSend(new Message("the count of column names does not match the count of values in InsertToTable()", MessageType.InternalError));
                return false;
            }
            SQLiteCommand command = new SQLiteCommand(connection);
            for (int i = 0;i< values.Count;i++)
            {
                command.Parameters.AddWithValue("$i" + i,values[i]);
                values[i] = "$i" + i;
                
            }
            command.CommandText = $"INSERT INTO {tableName}({string.Join(",", columnNames.ToArray())}) values ({string.Join(",", values.ToArray())})";
            
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                command.Dispose();
                if (e.ErrorCode == 19)
                { // executes when you trying add copy of unique value 
                    MessageSend(new Message("you trying add copy of unique value", MessageType.InputError));
                    return false;
                }
                MessageSend(new Message(e.Message, MessageType.InternalError));
                return false;
            }
            command.Dispose();
            MessageSend(new Message("success", MessageType.Success));
            return true;
        }
        private static bool RemoveFromTableBy(string tableName,string columnName, string value)
        {
            //SQLiteCommand command = new SQLiteCommand($"DELETE FROM {tableName} WHERE({columnName} = '{value}')", connection);
            SQLiteCommand command = new SQLiteCommand($"DELETE FROM {tableName} WHERE({columnName} = $i)", connection);
            command.Parameters.AddWithValue("$i",value);
            try
            {
                if (command.ExecuteNonQuery() == 0)
                {
                    MessageSend(new Message($"{tableName} with {columnName} is {value} doesn't exists", MessageType.InputError));
                    command.Dispose();
                    return false;
                }
            }
            catch (SQLiteException e)
            {
                command.Dispose();
                MessageSend(new Message(e.Message, MessageType.InternalError));
                return false;
            }
            command.Dispose();
            MessageSend(new Message("success", MessageType.Success));
            return true;
        }
        private static List<List<string>> GetAllDataFromTable(string tableName)
        {
            List<List<string>> result = new List<List<string>>();
            using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {tableName};", connection))
            {
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new List<string>());
                    for (int i = 0; i < reader.FieldCount; i++)
                        result[result.Count - 1].Add(reader.GetValue(i).ToString());
                }
            }
            return result;
        }

        private static List<string> GetColumnFromTable(string tableName, string columnName)
        {
            List<string> result = new List<string>();
            using (SQLiteCommand command = new SQLiteCommand($"SELECT {columnName} FROM {tableName};", connection))
            {
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
                }
            }
            return result;
        }

        #endregion
        private static void MessageSend(Message message)
        {
            ManagerVM.Instance.ReceiveMessage(message);
        }
        #region USERS
        public static bool AddUser(string name)
        {
            if(name.Trim(' ') == "")
            {
                MessageSend(new Message("Name cannot be empty", MessageType.InputError));
                return false;
            }

            return InsertToTable("users",ListBuilder<string>("name"),ListBuilder<string>(name));
        }
        public static bool RemoveUser(string name)
        {
            if (name.Trim(' ') == "")
            {
                MessageSend(new Message("Name cannot be empty", MessageType.InputError));
                return false;
            }
            
            return RemoveFromTableBy("users", "name", name);
        }

        public static List<UserData> GetAllUsers()
        {
            List<UserData> result = new List<UserData>();
            List<List<string>> data = GetAllDataFromTable("users");
            foreach(List<string> list in data)
            {
                result.Add(new UserData()
                {
                    Id = int.Parse(list[0]),
                    name = list[1]
                });
            }
            return (result);
        }
        #endregion

        #region APPLiCATIONS 
        public static bool AddApp(string name)
        {
            if (name.Trim(' ') == "")
            {
                MessageSend(new Message("Name cannot be empty", MessageType.InputError));
                return false;
            }

            return InsertToTable("applications", ListBuilder<string>("name"), ListBuilder<string>(name));
        }
        public static bool RemoveApp(string name)
        {
            if (name.Trim(' ') == "")
            {
                MessageSend(new Message("Name cannot be empty", MessageType.InputError));
                return false;
            }

            return RemoveFromTableBy("applications", "name", name);
        }
        public static List<AppData> GetAllApps()
        {
            List<AppData> result = new List<AppData>();
            List<List<string>> data = GetAllDataFromTable("applications");
            foreach (List<string> list in data)
            {
                result.Add(new AppData()
                {
                    Id = int.Parse(list[0]),
                    name = list[1]
                });
            }
            return (result);
        }
        #endregion

        #region INFORMATION


        public static bool GetInfoRowByIdIfExists(int id, out List<string> result) => GetRowFromTableIfExists("information", "id", id.ToString(), out result);

        public static bool EditInformation(int id, string newUserName, string newAppName, string newComment)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM information WHERE (userName = $userName AND appName = $appName AND NOT(id = $id))";
            command.Parameters.AddWithValue("$userName",newUserName);
            command.Parameters.AddWithValue("$appName", newAppName);
            command.Parameters.AddWithValue("$id", id);
            if (command.ExecuteReader().HasRows)
            {
                MessageSend(new Message("Information with this parameters already exists", MessageType.InputError));
                return false;
            }
            return ChangeRowValuesById("information", ListBuilder<string>("userName", "appName", "comment"), ListBuilder<string>(newUserName, newAppName, newComment), id);
        }
        public static bool AddInformation(string userName, string appName, string comment)
        {
            bool isUnique;
            using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM information WHERE userName = $i1 AND appName = $i2;", connection))
            {
                command.Parameters.AddWithValue("$i1",userName);
                command.Parameters.AddWithValue("$i2", appName);
                isUnique = !command.ExecuteReader().HasRows;
            }
            if (!isUnique)
            {
                MessageSend(new Message("Information with this parameters already exists", MessageType.InputError));
                return false;
            }
            if (userName.Trim(' ') == ""|| appName.Trim(' ') == "")
            {
                MessageSend(new Message("Name cannot be empty", MessageType.InputError));
                return false;
            }

            return InsertToTable("information", ListBuilder<string>("userName","appName","comment"), ListBuilder<string>(userName,appName,comment));
        }
        public static List<string> GetAppNamesInfo() => GetColumnFromTable("applications", "name");
        public static List<string> GetUserNamesInfo() => GetColumnFromTable("users", "name");
        public static bool RemoveInformation(int id) => RemoveFromTableBy("information", "id", id.ToString());
        public static List<InfoData> GetAllInfo()
        {
            List<InfoData> result = new List<InfoData>();
            List<List<string>> data = GetAllDataFromTable("information");
            foreach (List<string> list in data)
            {
                result.Add(new InfoData()
                {
                    Id = int.Parse(list[0]),
                    UserName = list[1],
                    AppName = list[2],
                    Comment = list[3],
                });
            }
            return (result);
        }
        #endregion
    }
}
