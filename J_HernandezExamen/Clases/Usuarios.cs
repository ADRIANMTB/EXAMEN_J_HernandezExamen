using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace J_HernandezExamen.Clases
{
    public class Usuario
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

        public static int Agregar(string nombre, string correoElectronico, string telefono)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES (@Nombre, @CorreoElectronico, @Telefono); SELECT SCOPE_IDENTITY();", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);

                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static int Borrar(int usuarioID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID", con))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ConsultarConFiltro(string filtroNombre)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Nombre LIKE '%' + @FiltroNombre + '%'", con))
                {
                    cmd.Parameters.AddWithValue("@FiltroNombre", filtroNombre);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int Modificar(int usuarioID, string nuevoNombre, string nuevoCorreoElectronico, string nuevoTelefono)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Nombre = @NuevoNombre, CorreoElectronico = @NuevoCorreoElectronico, Telefono = @NuevoTelefono WHERE UsuarioID = @UsuarioID", con))
                {
                    cmd.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@NuevoCorreoElectronico", nuevoCorreoElectronico);
                    cmd.Parameters.AddWithValue("@NuevoTelefono", nuevoTelefono);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}