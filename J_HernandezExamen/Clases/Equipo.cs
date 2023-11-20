using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace J_HernandezExamen.Clases
{
    public class Equipo
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

        public static int Agregar(string tipoEquipo, string modelo, int usuarioID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES (@TipoEquipo, @Modelo, @UsuarioID); SELECT SCOPE_IDENTITY();", con))
                {
                    cmd.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static int Borrar(int equipoID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Equipos WHERE EquipoID = @EquipoID", con))
                {
                    cmd.Parameters.AddWithValue("@EquipoID", equipoID);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ConsultarTodos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos", con))
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

        public static DataTable ConsultarConFiltro(string filtroTipoEquipo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE TipoEquipo LIKE '%' + @FiltroTipoEquipo + '%'", con))
                {
                    cmd.Parameters.AddWithValue("@FiltroTipoEquipo", filtroTipoEquipo);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int Modificar(int equipoID, string nuevoTipoEquipo, string nuevoModelo, int nuevoUsuarioID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Equipos SET TipoEquipo = @NuevoTipoEquipo, Modelo = @NuevoModelo, UsuarioID = @NuevoUsuarioID WHERE EquipoID = @EquipoID", con))
                {
                    cmd.Parameters.AddWithValue("@NuevoTipoEquipo", nuevoTipoEquipo);
                    cmd.Parameters.AddWithValue("@NuevoModelo", nuevoModelo);
                    cmd.Parameters.AddWithValue("@NuevoUsuarioID", nuevoUsuarioID);
                    cmd.Parameters.AddWithValue("@EquipoID", equipoID);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        internal static int Agregar(string text)
        {
            throw new NotImplementedException();
        }
    }
}