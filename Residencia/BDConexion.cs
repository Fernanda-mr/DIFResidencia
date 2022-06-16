using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.SQLite;
using System.Configuration;

namespace Residencia
{
    public class BDConexion
    {
        public string connection = string.Empty;
        public SQLiteConnection connect;
        public SQLiteCommand command;
        public SQLiteDataAdapter da;
        public DataTable dt;
        public DataSet ds;

        public BDConexion()
        {
            connect = new SQLiteConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            }
            catch
            {
                connection = ConfigurationManager.AppSettings.Get("connection");
            }
        }
        public SQLiteConnection connecttodb()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.ConnectionString = connection;
                    connect.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return connect;
        }
        public void closeconnection()
        {
            if(connect.State != ConnectionState.Closed)
            {
                connect.Close();
            }
        }
        public string selectstring(string query)
        {
            string cadena="";
            try
            {
                connecttodb();
                command = new SQLiteCommand(query, connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
                closeconnection();
            }
            return cadena;
        }
        public bool excecutecommand(string query)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SQLiteCommand(query, connect);
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito= false;
            }
            finally
            {
                closeconnection();
            }
            return exito;
        }
        public bool ExecuteStoreProcedure(string namestoreprocedure)
        {
            try
            {
                connecttodb();
                command = new SQLiteCommand(namestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                closeconnection();
            }
        }
        public DataTable SelectDataTableFromStoreProcedure(string nomestoreprocedure)
        {
            dt = new DataTable();
            try
            {
                connecttodb();
                command=new SQLiteCommand(nomestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                da = new SQLiteDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeconnection();
            }
            return dt;
        }
        public DataTable SelectDataTable(string query)
        {
            dt = new DataTable();
            try
            {
                connecttodb();
                da = new SQLiteDataAdapter(query, connect);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connecttodb();
            }
            return dt;
        }
        public DataSet SelectDataSet(string query, string table)
        {
            ds = new DataSet();
            try
            {
                connecttodb();
                da = new SQLiteDataAdapter(query, connect);
                da.Fill(ds, table);
            }
            catch
            {

            }
            finally
            {
                closeconnection();
            }
            return ds;
        }

    }
}
