using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case.Service
{
    using d = Framework.Data;
    using c = Framework.Command;
    using s = Properties.Settings;
    using da = Framework.Datas.Class1;
    using Framework;
    using System.Data;
    using System.Xml;
    using System.Data.SqlClient;
    using System.IO;
    partial class Service1
    {
        public Service1()
        {
            this.InitialUserCom();
        }
        #region IServer 成员
        object for_general = null;
        public object general(string summary, object p)
        {
            this._general(summary, p);
            return for_general;
        }

        public DataTable get(string cmd, object[] ps)
        {
            DataTable dt = default(DataTable);
            var cmds = cmd.Split(new string[] { " ", "=", ">", "<", "!=", "+", "-", "*", "/", ">=", "<=", "|", "^", ",", "(", ")", ".", "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> pl = new List<string>();
            if (ps != null)
                foreach (var item in cmds)
                {
                    if (item[0] == '@' && item[1] != '_')
                    {
                        foreach (var item2 in pl)
                            if (item == item2)
                                goto next;
                        pl.Add(item);
                    }
                next: ;
                }
            SqlCommand sc = default(SqlCommand);
            try
            {
                if (pl.Count < 1)
                {
                    dt = new DataTable("dt");
                    sc = new SqlCommand();
                    sc.Connection = new SqlConnection(Properties.Settings.Default.ConString);
                    sc.CommandText = cmd;
                    sc.Connection.Open();
                    var reader = sc.ExecuteReader();
                    var pllen = reader.FieldCount;
                    for (int i = 0; i < pllen; i++)
                        dt.Columns.Add("col" + i.ToString());

                    object[] ov = new object[pllen];
                    while (reader.Read())
                    {
                        for (int i = 0; i < pllen; i++)
                        {
                            ov[i] = reader.GetValue(i);
                        }
                        dt.Rows.Add(ov);
                    }
                }
                else if (pl.Count == ps.Length)
                {
                    dt = new DataTable("dt");
                    sc = new SqlCommand();
                    var pllen = pl.Count;
                    for (int i = 0; i < pllen; i++)
                        sc.Parameters.AddWithValue(pl[i], ps[i]);

                    sc.Connection = new SqlConnection(Properties.Settings.Default.ConString);
                    sc.CommandText = cmd;
                    sc.Connection.Open();
                    var reader = sc.ExecuteReader();
                    var len = reader.FieldCount;
                    for (int i = 0; i < len; i++)
                    {
                        dt.Columns.Add("col" + i.ToString());
                    }
                    object[] ov = new object[len];
                    while (reader.Read())
                    {
                        for (int i = 0; i < len; i++)
                        {
                            ov[i] = reader.GetValue(i);
                        }
                        dt.Rows.Add(ov);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (sc != null)
                    sc.Connection.Close();
            }
            return dt;
        }

        public XmlDocument getfromxml(string xmlFileName)
        {
            XmlDocument xd = new XmlDocument();
            if (File.Exists(xmlFileName))
                xd.Load(xmlFileName);
            return xd;
        }


        public DataTable procedure(string proc, string procps, object[] ps)
        {
            DataTable dt = default(DataTable);
            var cmds = procps.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            List<string> pl = new List<string>();
            if (ps != null)
                foreach (var item in cmds)
                {
                    if (item[0] == '@' && item[1] != '_')
                    {
                        pl.Add(item);
                    }
                }
            SqlCommand sc = default(SqlCommand);
            try
            {
                if (pl.Count < 1)
                {
                    dt = new DataTable("dt");
                    sc = new SqlCommand();
                    sc.Connection = new SqlConnection(Properties.Settings.Default.ConString);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.CommandText = proc;
                    sc.Connection.Open();
                    var reader = sc.ExecuteReader();
                    var len = reader.FieldCount;
                    for (int i = 0; i < len; i++)
                        dt.Columns.Add("col" + i.ToString());
                    object[] ov = new object[len];
                    while (reader.Read())
                    {
                        for (int i = 0; i < len; i++)
                        {
                            ov[i] = reader.GetValue(i);
                        }
                        dt.Rows.Add(ov);
                    }
                }
                else if (pl.Count == ps.Length)
                {
                    dt = new DataTable("dt");
                    sc = new SqlCommand();
                    sc.Connection = new SqlConnection(Properties.Settings.Default.ConString);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.CommandText = proc;
                    var pllen = pl.Count;
                    for (int i = 0; i < pllen; i++)
                    {
                        sc.Parameters.AddWithValue(pl[i], ps[i]);
                    }
                    sc.Connection.Open();
                    var reader = sc.ExecuteReader();
                    var len = reader.FieldCount;
                    for (int i = 0; i < len; i++)
                        dt.Columns.Add("col" + i.ToString());
                    object[] ov = new object[len];
                    while (reader.Read())
                    {
                        for (int i = 0; i < len; i++)
                        {
                            ov[i] = reader.GetValue(i);
                        }
                        dt.Rows.Add(ov);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (sc != null)
                    sc.Connection.Close();
            }
            return dt;
        }

        public bool savetoxml(string xmlFileName, XmlDocument xe)
        {
            bool b = false;
            if (File.Exists(xmlFileName))
            {
                xe.Save(xmlFileName);
                b = true;
            }
            return b;
        }

        public bool set(string cmd, object[] ps)
        {
            bool b = false;
            var cmds = cmd.Split(new string[] { " ", "=", ">", "<", "!=", "+", "-", "*", "/", ">=", "<=", "|", "^", ",", "(", ")", ".", "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> pl = new List<string>();
            if (ps != null)
                foreach (var item in cmds)
                {
                    if (item[0] == '@' && item[1] != '_')
                    {
                        foreach (var item2 in pl)
                            if (item == item2)
                                goto next;
                        pl.Add(item);
                    }
                next: ;
                }
            SqlCommand sc = default(SqlCommand);
            try
            {
                if (pl.Count < 1)
                {
                    sc = new SqlCommand();
                    sc.Connection = new SqlConnection(Properties.Settings.Default.ConString);
                    sc.CommandText = cmd;
                    sc.Connection.Open();
                    sc.ExecuteNonQuery();
                    b = true;
                }
                else if (pl.Count == ps.Length)
                {
                    sc = new SqlCommand();
                    sc.Connection = new SqlConnection(Properties.Settings.Default.ConString);
                    sc.CommandText = cmd;
                    for (int i = 0; i < pl.Count; i++)
                        sc.Parameters.AddWithValue(pl[i], ps[i]);

                    sc.Connection.Open();
                    sc.ExecuteNonQuery();
                    b = true;
                }
            }
            catch (Exception)
            {
                b = false;
            }
            finally
            {
                if (sc != null)
                    sc.Connection.Close();
            }
            return b;
        }

        #endregion
        #region extend methods
        /// <summary>
        /// 初始化服务端实例
        /// </summary>
        partial void InitialUserCom();
        /// <summary>
        /// 服务内容范式
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="p"></param>
        partial void _general(string summary, object p);
        #endregion
    }
}
