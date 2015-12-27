using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TitanEditor
{
    public class DBLite
    {
        public OdbcConnection OdbcCon;
        private OdbcDataReader Odbcdr;

        public  SqlConnection SqlCon;
        private SqlDataReader Sqldr;

        //public OleDbConnection OleDbCon;
        //private OleDbDataReader OleDbdr;
        public Exception ExError;
        private byte ConType;
        private string Path;
        private string Password;
        private string ConFormat;


        public static DBLite dbMu;
        public static DBLite dbMe;
        public static DBLite mdb;

        public DBLite(byte ConnectionType)
        {
            if (ConnectionType == 1)
            {
                OdbcCon = new OdbcConnection();
                ConType = 1;
            }
            else if (ConnectionType == 3)
            {
                SqlCon = new SqlConnection();
                ConType = 3;
            }
        }

        public DBLite(string path, string password)
        {
            Path = path;
            OdbcCon = new OdbcConnection();
            Password = password;
            ConType = 2;
        }

        public bool Connect()
        {
            try
            {
                ExError = new Exception();
                if (Password == "")
                {
                    ConFormat = @"Driver={Microsoft Access Driver (*.mdb)};DBQ=" + Path + ";";
                }
                else
                {
                    ConFormat = String.Format(@"Provider=MSDASQL;Driver={Microsoft Access Driver (*.mdb)};Dbq={0};Jet OLEDB:Database Password={1}", Path, Password);
                }
                OdbcCon.ConnectionString = ConFormat;
                OdbcCon.Open();
                OdbcCon.Close();
            }
            catch (Exception x)
            {
                ExError = x;
                return false;
            }
            finally
            {
                if (OdbcCon.State != ConnectionState.Closed)
                    OdbcCon.Close();
            }
            return true;
        }

        public bool Connect(string Server, string DataBase, string User, string Password)
        {
            try
            {
                ExError = new Exception();
                string ConFormat = "Data Source=" + Server + ";Initial Catalog=" + DataBase + ";User Id=" + User + ";Password=" + Password + ";";
                SqlCon.ConnectionString = ConFormat;
                SqlCon.Open();
                SqlCon.Close();
                return true;
            }
            catch (Exception x)
            {
                ExError = x;
                return false;
            }
            finally
            {
                if (SqlCon.State != ConnectionState.Closed)
                    SqlCon.Close();
            }
        }

        public bool Connect(string DNS, string Login, string Password) //If is MySql DNS = DataBase
        {
            try
            {
                ExError = new Exception();
                string ConFormat = "DSN=" + DNS + ";UID=" + Login + ";PWD=" + Password + ";";
                OdbcCon.ConnectionString = ConFormat;
                OdbcCon.Open();
                OdbcCon.Close();
                return true;
            }
            catch (Exception x)
            {
                ExError = x;
                return false;
            }
            finally
            {
                if (OdbcCon.State != ConnectionState.Closed)
                    OdbcCon.Close();
            }
        }

        public void Close()
        {
            switch (ConType)
            {
                case 1:
                    {
                        if (OdbcCon.State != ConnectionState.Closed)
                            OdbcCon.Close();
                        if(Odbcdr != null)
                            if (!Odbcdr.IsClosed)
                                Odbcdr.Close();
                    } break;
                case 2:
                    {
                        if (OdbcCon.State != ConnectionState.Closed)
                            OdbcCon.Close();

                        if (OdbcCon != null)
                            if (!Odbcdr.IsClosed)
                                Odbcdr.Close();
                    } break;
                case 3:
                    {
                        if (SqlCon.State != ConnectionState.Closed)
                            SqlCon.Close();

                        if (Sqldr != null)
                            if (!Sqldr.IsClosed)
                                Sqldr.Close();
                    } break;
            }
        }

        public bool Exec(string Query)
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            OdbcCon.Open();
                            OdbcCommand cmd = new OdbcCommand(Query, OdbcCon);
                            cmd.ExecuteNonQuery();
                        } break;
                    case 2:
                        {
                            OdbcCon.Open();
                            OdbcCommand cmd = new OdbcCommand(Query, OdbcCon);
                            cmd.ExecuteNonQuery();
                        } break;
                    case 3:
                        {
                            SqlCon.Open();
                            SqlCommand cmd = new SqlCommand(Query, SqlCon);
                            cmd.ExecuteNonQuery();
                        } break;
                }
                return true;
            }
            catch (Exception x)
            {
                ExError = x;
                return false;
            }
        }

        public bool Read(string Query)
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            Odbcdr = default(OdbcDataReader);
                            OdbcCommand GetData = default(OdbcCommand);
                            GetData = new OdbcCommand(Query, OdbcCon);

                            OdbcCon.Open();
                            Odbcdr = GetData.ExecuteReader();
                        } break;
                    case 2:
                        {
                            Odbcdr = default(OdbcDataReader);
                            OdbcCommand GetData = default(OdbcCommand);
                            GetData = new OdbcCommand(Query, OdbcCon);

                            OdbcCon.Open();
                            Odbcdr = GetData.ExecuteReader();
                        } break;
                    case 3:
                        {
                            Sqldr = default(SqlDataReader);
                            SqlCommand GetData = default(SqlCommand);
                            GetData = new SqlCommand(Query, SqlCon);

                            SqlCon.Open();
                            Sqldr = GetData.ExecuteReader();
                        } break;
                }
                return true;
            }
            catch (Exception x)
            {
                ExError = x;
                return false;
            }
        }

        public bool Fetch()
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            if (Odbcdr != null)
                            {
                                return Odbcdr.Read();
                            }
                        } break;
                    case 2:
                        {
                            if (Odbcdr != null)
                            {
                                return Odbcdr.Read();
                            }
                        } break;
                    case 3:
                        {
                            if (Sqldr != null)
                            {
                                return Sqldr.Read();
                            }
                        } break;
                }
                return false;
            }
            catch (Exception x)
            {
                ExError = x;
                return false;
            }
        }


        public string GetAsString(string Row)
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Odbcdr[i].ToString();
                                    }
                                }
                            }
                        } break;
                    case 2:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Odbcdr[i].ToString();
                                    }
                                }
                            }
                        } break;
                    case 3:
                        {
                            if (!Sqldr.IsClosed)
                            {
                                for (int i = 0; i < Sqldr.FieldCount; i++)
                                {
                                    if (Sqldr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Sqldr[i].ToString();
                                    }
                                }
                            }
                        } break;
                }
                return null;
            }
            catch (Exception x)
            {
                ExError = x;
                return null;
            }
        }


        public int GetAsInteger(string Row)
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Convert.ToInt32(Odbcdr[i]);
                                    }
                                }
                            }
                        } break;
                    case 2:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Convert.ToInt32(Odbcdr[i]);
                                    }
                                }
                            }
                        } break;
                    case 3:
                        {
                            if (!Sqldr.IsClosed)
                            {
                                for (int i = 0; i < Sqldr.FieldCount; i++)
                                {
                                    if (Sqldr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Convert.ToInt32(Sqldr[i]);
                                    }
                                }
                            }
                        } break;
                }
                return 0;
            }
            catch (Exception x)
            {
                ExError = x;
                return 0;
            }
        }

        public Int64 GetAsInteger64(string Row)
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Convert.ToInt64(Odbcdr[i]);
                                    }
                                }
                            }
                        } break;
                    case 2:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Convert.ToInt64(Odbcdr[i]);
                                    }
                                }
                            }
                        } break;
                    case 3:
                        {
                            if (!Sqldr.IsClosed)
                            {
                                for (int i = 0; i < Sqldr.FieldCount; i++)
                                {
                                    if (Sqldr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return Convert.ToInt64(Sqldr[i]);
                                    }
                                }
                            }
                        } break;
                }
                return 0;
            }
            catch (Exception x)
            {
                ExError = x;
                return 0;
            }
        }

        public float GetAsFloat(string Row)
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return float.Parse(Odbcdr[i].ToString());
                                    }
                                }
                            }
                        } break;
                    case 2:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return float.Parse(Odbcdr[i].ToString());
                                    }
                                }
                            }
                        } break;
                    case 3:
                        {
                            if (!Sqldr.IsClosed)
                            {
                                for (int i = 0; i < Sqldr.FieldCount; i++)
                                {
                                    if (Sqldr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return float.Parse(Sqldr[i].ToString());
                                    }
                                }
                            }
                        } break;
                }
                return 0;
            }
            catch (Exception x)
            {
                ExError = x;
                return 0;
            }
        }

        public byte[] GetAsBinary(string Row)
        {
            try
            {
                ExError = new Exception();
                switch (ConType)
                {
                    case 1:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return (byte[])(Odbcdr[i]);
                                    }
                                }
                            }
                        } break;
                    case 2:
                        {
                            if (!Odbcdr.IsClosed)
                            {
                                for (int i = 0; i < Odbcdr.FieldCount; i++)
                                {
                                    if (Odbcdr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return (byte[])(Odbcdr[i]);
                                    }
                                }
                            }
                        } break;
                    case 3:
                        {
                            if (!Sqldr.IsClosed)
                            {
                                for (int i = 0; i < Sqldr.FieldCount; i++)
                                {
                                    if (Sqldr.GetName(i).ToUpper() == Row.ToUpper())
                                    {
                                        return (byte[])(Sqldr[i]);
                                    }
                                }
                            }
                        } break;
                }
                return null;
            }
            catch (Exception x)
            {
                ExError = x;
                return null;
            }
        }
    }
}
