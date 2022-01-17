using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectKomik
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source=LAPTOP-8MKEQ456;Initial Catalog=ProjectKomik;Persist Security Info=True;User ID=sa;Password=mentepermaib20";
        SqlConnection connection;
        SqlCommand com;
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string peminjaman(string IDPeminjaman, string TanggalPeminjaman, int Harga, string IDKomik)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Peminjaman values ('" + IDPeminjaman + "', '" + TanggalPeminjaman + "', " + Harga + " , '" + IDKomik + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string editPeminjaman(string IDPeminjaman, string TanggalPeminjaman, int Harga, string IDKomik)
        {
            string a = "gagal";
            try
            {
                string sql = "update into dbo.Peminjaman values ('" + IDPeminjaman + "', '" + TanggalPeminjaman + "', " + Harga + " , '" + IDKomik + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string deletePeminjaman(string IDPeminjaman)
        {
            string a = "gagal";
            try
            {
                string sql = "delete into dbo.Peminjaman where ID_Peminjaman = '" + IDPeminjaman + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string Login(string username, string password)
        {

            string kategori = "";
            string sql = "select Kategori from Login where Username='" + username + "' and Password='" + password + "'";
            connection = new SqlConnection(constring);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                kategori = reader.GetString(0);
            }
            return kategori;
        }


        public string Register( string username, string password, string kategori)
        {
            try
            {
                string sql = "insert into Login values('" + username + "', '" + password + "', '" + kategori + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "Sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public string UpdateRegister(string username, string password, string kategori, int id)
        {
            try
            {
                string sql2 = "update Login SET username='" + username + "', Password= '" + password + "', Kategori='" + kategori + "'where ID_Login = " + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "Sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public string DeleteRegister(string username)
        {
            try
            {
                int id = 0;
                string sql = "select ID_login from dbo.Login where Username = '" + username + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                connection.Close();
                string sql2 = "delete from Login where ID_Login=" + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteReader();
                connection.Close();

                return "Sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }


        public List<Peminjaman> Peminjaman()
        {
            List<Peminjaman> peminjamans = new List<Peminjaman>();
            try
            {
                string sql = "select ID_Peminjaman, Tgl_Peminjaman, " +
                    "Harga, JudulKomik from dbo.Peminjaman p join dbo.Komik l on p.ID_Komik = l.ID_Komik";
                connection = new SqlConnection(constring); 
                com = new SqlCommand(sql, connection); 
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Peminjaman data = new Peminjaman(); 
                    data.IDPeminjaman = reader.GetString(0); 
                    data.TanggalPeminjaman = reader.GetString(1);
                    data.Harga = reader.GetInt32(2);
                    data.JudulKomik = reader.GetString(4);
                    peminjamans.Add(data);

                }
                connection.Close(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return peminjamans;
        }

        public List<DataRegister> DataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select ID_Login , Username, Password, Kategori from Login";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.password = reader.GetString(2);
                    data.kategori = reader.GetString(3);
                    list.Add(data);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return list;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Komik(string IDKomik, string JudulKomik, string Pengarang, string Tahun)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Komik values ('" + IDKomik + "', '" + JudulKomik + "', '" + Pengarang + "' , '" + Tahun + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string editKomik(string IDKomik, string JudulKomik, string Pengarang, string Tahun)
        {
            string a = "gagal";
            try
            {
                string sql = "update into dbo.Komik values ('" + IDKomik + "', '" + JudulKomik + "', '" + Pengarang + "' , '" + Tahun + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string hapusKomik(string IDKomik)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.Komik where ID_Komik = '" + IDKomik + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<Komik> Komik()
        {
            List<Komik> komiks = new List<Komik>();
            try
            {
                string sql = "select ID_Komik, JudulKomik, " +
                    "Pengarang, Tahun from dbo.Komik";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Komik data = new Komik();
                    data.IDKomik = reader.GetString(0);
                    data.JudulKomik = reader.GetString(1);
                    data.Pengarang = reader.GetString(2);
                    data.Tahun = reader.GetString(4);
                    komiks.Add(data);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return komiks;
        }
    }
}
