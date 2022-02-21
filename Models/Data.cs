using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Test.Models
{
    public class Data
    {
        static string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["Tarun"].ConnectionString;
        public List<Dress> GetAllDresses()
        {
            var list = new List<Dress>();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCmd = con.CreateCommand();
                    sqlCmd.CommandText = "SELECT * FROM TEST";
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var drs = new Dress();
                        drs.drsId = Convert.ToInt32(reader[0]);
                        drs.drsName = reader[1].ToString();
                        drs.drsDesign = reader[2].ToString();
                        drs.drsPrice = Convert.ToInt32(reader[3]);
                        list.Add(drs);
                    }
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }
        
        public Dress FindDress(int Id)
        {
            Dress drs = new Dress();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "Select * from TEST where Id =" +Id;
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        drs.drsId = Convert.ToInt32(reader[0]);
                        drs.drsName = reader[1].ToString();
                        drs.drsDesign = reader[2].ToString();
                        drs.drsPrice = Convert.ToInt32(reader[3]);

                    }
                    else
                    {
                        throw new Exception("No Dress Found");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            return drs;
        }

        public void UpdateDress(Dress drs)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = $"UPDATE TEST set DressName = '{drs.drsName}', Design = '{drs.drsDesign}', Amount ='{drs.drsPrice}' WHERE Id = {drs.drsId}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Dress Were Updated");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void AddNewDress(Dress drs)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = $"ADD TEST set DressName = '{drs.drsName}', Design = '{drs.drsDesign}', Amount ='{drs.drsPrice}' WHERE Id = {drs.drsId}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Dress Were Added");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}