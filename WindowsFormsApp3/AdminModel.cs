using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp3

{
    class AdminModel
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("server=DESKTOP-OBL2RND\\SQLEXPRESS;database=demodatabase;uid=sa;pwd=123456");
            return conn;
        }
        public Staff CheckLogin(string u, string p)
        {
            Staff staff = null;
            string sql = "SELECT * FROM tblStaff WHERE username=@u and password=@p";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@u", u);
            cmd.Parameters.AddWithValue("@p", p);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                staff = new Staff();
                staff.UserName = rd.GetString(0);
                staff.Role = rd.GetInt32(2);
            }
            cmd.Connection.Close();
            return staff;
        }
        public bool CheckExist(string id)
        {
            bool result = false;
            string sql = "SELECT * FROM tblQuestion WHERE _id=@id";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            result = rd.HasRows;
            cmd.Connection.Close();
            return !result;
        }
        public bool Addquestion(string id, string content, string a, string b, string c, string d, string correct, string type)
        {
            string sql = "insert into tblQuestion values(@i,@content,@a,@b,@c,@d,@correct,@type)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@i", id);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@correct", correct);
            cmd.Parameters.AddWithValue("@type", type);
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result > 0;
        }
        public DataTable GetQuestions()
        {
            string sql = "SELECT * FROM tblQuestion ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
            da.Fill(dt);
            return dt;
        }
        public bool DeleteQuestion(string id)
        {
            string sql = "DELETE FROM tblQuestion WHERE _id=@i";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = GetConnection();
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@i",id);
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result > 0;
        }
        public bool UpdateQuestion(string id,string subject,string content,string correct,string a,string b,string c, string d)
        {
            string sql = "UpDate tblQuestion SET _sid=@t,_content=@ct,_correct=@crr,_a=@a,_b=@b,_c=@c,_d=@d WHERE _id=@i";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = GetConnection();
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@i", id);
            cmd.Parameters.AddWithValue("@t", subject);
            cmd.Parameters.AddWithValue("@ct", content);
            cmd.Parameters.AddWithValue("@crr", correct);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result > 0;
        }
    }


}
