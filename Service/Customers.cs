using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Customers : ICustomers
    {
        private string connection = ConfigurationManager.ConnectionStrings["BikeStoreDB"].ConnectionString;

        public List<Customer> GetAllCustomer()
        {
            List<Customer> customersList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("USPGetAllCustomer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            Id = Convert.ToInt32(reader["customer_id"]),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            Phone = reader["phone"].ToString(),
                            Email = reader["email"].ToString(),
                            Street = reader["street"].ToString(),
                            City = reader["city"].ToString(),
                            State = reader["state"].ToString(),
                            ZipCode = reader["zip_code"].ToString()
                        };

                        customersList.Add(customer);
                    }
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                }
            }
            return customersList;
        }

        public string InsertCustomer(Customer customer)
        {
            string message = string.Empty;
            using (SqlConnection conn = new SqlConnection(this.connection))
            {
                SqlCommand cmd = new SqlCommand("InsertCustomer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", customer.FirstName);
                cmd.Parameters.AddWithValue("@last_name", customer.LastName);
                cmd.Parameters.AddWithValue("@phone", customer.Phone);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@street", customer.Street);
                cmd.Parameters.AddWithValue("@city", customer.City);
                cmd.Parameters.AddWithValue("@state", customer.State);
                cmd.Parameters.AddWithValue("@zip_code", customer.ZipCode);
                SqlParameter data = new SqlParameter()
                {
                    ParameterName = "@message",
                    Size = 200,
                    Direction = System.Data.ParameterDirection.Output,
                    SqlDbType = System.Data.SqlDbType.VarChar
                };
                cmd.Parameters.Add(data);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    message = data.Value.ToString();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            return message;
        }
    }
}
