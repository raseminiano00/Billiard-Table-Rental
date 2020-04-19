using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TableMonitoring
{
    public class DataAccessLayer
    {
        /*
       *  NOTE: to create a method definition on top of the method header, add a three slashes (///)
       *    A method definition is used to describe the method and its parameters.
       */

        // class declarations
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlParameter param;

        private MySqlDataReader reader;
        int counter = 0;
        private ArrayList paramList = new ArrayList();

        /// <summary>
        /// A method that will connect to a database using the connection string.
        /// Change connection string to connect to a different database.
        /// This will use a StoredProcedure CommandType  
        /// </summary>
        private void connectToDB()
        {
            this.conn = new MySqlConnection();
            this.cmd = new MySqlCommand();

            this.conn.ConnectionString =
                                        "Server=" + Properties.Settings.Default.ip + ";" +
                                         "Database=" + Properties.Settings.Default.Database + ";" +
                                         "User=" + Properties.Settings.Default.user + ";" +
                                         "Password=" + Properties.Settings.Default.pass + ";";
            this.conn.Open();
            this.cmd.Connection = conn;
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.setParameters();
        }

        /// <summary>
        /// Method to set the parameters in the parameter list to the Command Object
        /// </summary>
        public void setParameters()
        {
            foreach (MySqlParameter p in paramList)
            {
                this.cmd.Parameters.Add(p);
            }
        }

        /// <summary>
        /// This method will create a new parameter and add it to the parameter list.
        /// </summary>
        /// <param name="paramName">String name of the parameter</param>
        /// <param name="dbType">Database Type of the parameter</param>
        /// <param name="value">Value of the parameter to be passed</param>
        /// 

        public void addParameter(string paramName, DbType dbType, object value)
        {
            this.param = new MySqlParameter();
            this.param.ParameterName = paramName;
            this.param.DbType = dbType;
            this.param.Direction = ParameterDirection.Input;
            this.param.Value = (value == null) ? DBNull.Value : value;
            this.paramList.Add(param);
        }

        /// <summary>
        /// A method that will clear the parameters in the parameter list.
        /// Use this method before adding a new set of parameters.
        /// </summary>
        public void clearParameter()
        {
            this.paramList.Clear();
        }

        /// <summary>
        /// This method will execute any non-Select stored procedure
        /// </summary>
        /// <param name="sp">name of the Stored Procedure to be called.</param>
        public void executeQuery(string sp)
        {
            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                this.cmd.ExecuteNonQuery();
                this.conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This method will retrieve result set of a stored procedure
        /// </summary>
        /// <param name="sp">name of the Stored Procedure to be called</param>
        /// <returns></returns>
        public DataTable getDataTable(string sp)
        {
            this.da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                this.da.SelectCommand = cmd;
                this.da.Fill(dt);
                this.conn.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool checkExists(string sp)
        {
            this.da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                this.da.SelectCommand = cmd;
                this.da.Fill(dt);
                this.conn.Close();
                return (dt.Rows.Count > 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region
        public int readers(string sp)
        {


            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    counter++;


                }

                return counter;
            }
            catch (Exception)
            {

                throw;
            }

        }
        int id;
        public int idreader(string sp)
        {
            this.connectToDB();
            this.cmd.CommandText = sp;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }

            return id;
        }


        public Array stringreader(string sp)
        {
            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                reader = cmd.ExecuteReader();
                int fCount = reader.RecordsAffected;
                string[] das = new string[fCount];
                int b = 0;
                while (reader.Read())
                {
                    das[b] = reader.GetString(0);
                    b++;
                }
                return das;
            }
            catch (Exception)
            {

                throw;
            }
        }

        string stringreturn;
        public string singleReader(string sp)
        {
            this.connectToDB();
            this.cmd.CommandText = sp;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                stringreturn = reader.GetString(0);

            }
            return stringreturn;



        }
        int intreturner;

        public int singleReaderint(string sp)
        {
            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    intreturner = reader.GetInt32(0);

                }
                return intreturner;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public Array stringreaderByColumn(string sp)
        {
            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                reader = cmd.ExecuteReader();
                int fCount = reader.VisibleFieldCount;
                string[] das = new string[fCount];
                int b = fCount;
                while (reader.Read())
                {
                    for (int i = 0; i < fCount; i++)
                    {
                        das[i] = reader.GetString(i);
                    }

                }
                return das;



            }
            catch (Exception)
            {

                throw;
            }
        }
        public Array stringreader2Column(string sp)
        {
            try
            {
                this.connectToDB();
                this.cmd.CommandText = sp;
                reader = cmd.ExecuteReader();
                int fCount = reader.RecordsAffected;
                fCount = fCount * 2;
                string[] das = new string[fCount];
                int b = fCount;
                while (reader.Read())
                {
                    for (int i = 0; i < b; i++)
                    {
                        das[i] = reader.GetString(i);
                    }

                }
                return das;



            }
            catch (Exception)
            {

                throw;
            }
        }
        public int checkIfDuplicated(string sp)
        {
            this.connectToDB();
            this.cmd.CommandText = sp;
            reader = cmd.ExecuteReader();
            int duplicate = reader.RecordsAffected;
            return duplicate;
        }
        #endregion
    }
}