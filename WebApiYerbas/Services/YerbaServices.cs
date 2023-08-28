using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using WebApiYerbas.Models;

namespace WebApiYerbas.Services
{
    public class YerbaServices
    {
        private static string connectionString = "Server=.; Database=YerbasApiRest; Trusted_Connection=True; TrustServerCertificate=True;";


        public static List<Yerba> Get()
        {
            List<Yerba> lst = new List<Yerba>();
            string query = "Select * from yerbas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(query, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lst.Add(new Yerba()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            Cantidad = int.Parse(reader["Cantidad"].ToString())
                        });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    return lst;
                }
                finally
                {
                    connection.Close();
                }
            }
            return lst;
        }

        public static Yerba GetById(int id)
        {
            Yerba oYerba = null;

            string query = "SELECT * FROM yerbas" +
                           " WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id); // Agregar parámetro Id
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        oYerba = new Yerba()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            Cantidad = int.Parse(reader["Cantidad"].ToString())
                        };
                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    return oYerba;
                }
                finally
                {
                    connection.Close();
                }
            }
            return oYerba;
        }


        public static bool Add(Yerba oYerba)
        {
            bool result = false;

            string query = "INSERT INTO yerbas (Nombre, Cantidad) " +
                           "VALUES ( @Nombre, @Cantidad )";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Nombre", oYerba.Nombre);
                    command.Parameters.AddWithValue("@Cantidad", oYerba.Cantidad);

                    connection.Open();

                    command.ExecuteNonQuery(); 

                    result = true;

                }
                catch(Exception)
                {
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public static bool Update (Yerba oYerba)
        {
            bool result = false;

            string query = "UPDATE yerbas SET Nombre=@Nombre, Cantidad=@Cantidad " +
                                "WHERE id=@id";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Id", oYerba.Id);
                    command.Parameters.AddWithValue("@Nombre", oYerba.Nombre);
                    command.Parameters.AddWithValue("@Cantidad", oYerba.Cantidad);

                    connection.Open();

                    command.ExecuteNonQuery();

                    result = true;

                }
                catch (Exception)
                {
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }



        public static bool Delete(int id)
        {
            bool result = false;

            string query = "DELETE FROM yerbas " +
                           "WHERE id=@id";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                    result = true;
                }
                catch (Exception)
                {
                    return result;
                }
                finally
                {
                    connection.Close();
                }

            }

            return result;
        }
    }
}
