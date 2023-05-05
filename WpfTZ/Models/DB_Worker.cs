using WpfTZ.ViewModels;
using System;
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
        static SQLiteConnection connection = (new SQLiteConnection("data source=DataBase/UserData.db;foreign keys=true;")).OpenAndReturn();
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
        private static Message InsertToTable(string tableName,List<string> columnNames, List<string> values)
        {
            if(columnNames.Count != values.Count)
            {
                return new Message("the count of column names does not match the count of values in InsertToTable()", MessageType.InternalError);
            }
            for (int i = 0;i< values.Count;i++)
            {
                values[i] = "'" + values[i] + "'";
            }
            SQLiteCommand command = new SQLiteCommand($"INSERT INTO user({string.Join(",", columnNames.ToArray())}) values ({string.Join(",", values.ToArray())})", connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                command.Dispose();
                if(e.ErrorCode == 19) // executes when you trying add copy of unique value 
                    return new Message("you trying add copy of unique value", MessageType.InputError);
                return new Message(e.Message, MessageType.InternalError);
            }
            command.Dispose();
            return new Message("success", MessageType.Success);
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
        #endregion
        public static Message AddUser(string name)
        {
            if(name.Trim(' ') == "")
            {
                return new Message("Name cannot be empty", MessageType.InputError);
            }
            return InsertToTable("users",ListBuilder<string>("name"),ListBuilder<string>(name));
        }

        public static List<User> GetAllUsers()
        {
            List<User> result = new List<User>();
            List<List<string>> data = GetAllDataFromTable("users");
            foreach(List<string> list in data)
            {
                result.Add(new User()
                {
                    Id = int.Parse(list[0]),
                    name = list[1]
                });
            }
            return (result);
        }
        public static List<Application> GetAllApps()
        {
            List<Application> result = new List<Application>();
            List<List<string>> data = GetAllDataFromTable("applications");
            foreach (List<string> list in data)
            {
                result.Add(new Application()
                {
                    Id = int.Parse(list[0]),
                    name = list[1]
                });
            }
            return (result);
        }
        public static List<Information> GetAllInfo()
        {
            List<Information> result = new List<Information>();
            List<List<string>> data = GetAllDataFromTable("information");
            foreach (List<string> list in data)
            {
                result.Add(new Information()
                {
                    Id = int.Parse(list[0]),
                    UserName = list[1],
                    AppName = list[2],
                    Comment = list[3],
                });
            }
            return (result);
        }
    }
}
