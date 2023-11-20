using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace J_HernandezExamen.Clases
{
    public class Tecnico
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

        public static int Agregar(string nombre, string especialidad)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Tecnicos (Nombre, Especialidad) VALUES (@Nombre, @Especialidad); SELECT SCOPE_IDENTITY();", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Especialidad", especialidad);

                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static int Borrar(int tecnicoID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Tecnicos WHERE TecnicoID = @TecnicoID", con))
                {
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ConsultarTodos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}