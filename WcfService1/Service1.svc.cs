using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WcfService1
{
    public class Service1 : IService1
    {
        
        readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["DBSIESMAR"].ConnectionString;

        public PerfilDTO GetPerfil(string DNI)

        {
            PerfilDTO perfilDTO = new PerfilDTO();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand cmd = new SqlCommand("Seguridad.usp_UsuariosPerfil", conn);

                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pDocumento = new SqlParameter();
                pDocumento.ParameterName = "@DOCUMENTO";
                pDocumento.SqlDbType = SqlDbType.VarChar;
                pDocumento.Value = pDocumento;

                cmd.Parameters.Add(pDocumento);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            perfilDTO.Id = Convert.ToInt32(dt.Rows[i]["UsuarioId"]);
                            perfilDTO.Documento = dt.Rows[i]["Documento"].ToString();                            
                            perfilDTO.Nombre1 = dt.Rows[i]["Nombre1"].ToString();
                            perfilDTO.Nombre2 = dt.Rows[i]["Nombre2"].ToString();
                            perfilDTO.Nombre3 = dt.Rows[i]["Nombre3"].ToString();
                            perfilDTO.ApellidoPaterno = dt.Rows[i]["ApellidoPaterno"].ToString();
                            perfilDTO.ApellidoMaterno = dt.Rows[i]["ApellidoMaterno"].ToString();
                            perfilDTO.NombreCompleto = dt.Rows[i]["GradoId"].ToString();
                            perfilDTO.CorreoInterno = dt.Rows[i]["CorreoInterno"].ToString();
                            perfilDTO.Foto = dt.Rows[i]["Foto"].ToString();
                            perfilDTO.Rol = Convert.ToInt32(dt.Rows[i]["Rol"]);
                        }
                    }
                    conn.Close();
                }
                return perfilDTO;
            }
        }

        public UserDTO LoginService(string username, string password)
        {
            UserDTO userDTO = new UserDTO();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                userDTO.Error = "Usuario o contraseña incorrectos";
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {

                    SqlCommand cmd = new SqlCommand("Seguridad.usp_UsuariosLogin", con);

                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@USER", SqlDbType.VarChar, 50);
                    cmd.Parameters["@USER"].Value = username;

                    cmd.Parameters.Add("@PASS", SqlDbType.VarChar, 50);
                    cmd.Parameters["@PASS"].Value = password;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                userDTO.CheckPassword = Convert.ToInt32(dt.Rows[i]["CHECK_CONTRASENA"].ToString());
                                if (userDTO.CheckPassword == 1)
                                {
                                    userDTO.Id = Convert.ToInt32(dt.Rows[i]["IdUsuario"].ToString());
                                    userDTO.Documento = dt.Rows[i]["Documento"].ToString();
                                    userDTO.Email = dt.Rows[i]["CorreoInterno"].ToString();
                                    userDTO.Rol = Convert.ToInt32(dt.Rows[i]["RolId"]);
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            return userDTO;
        }

    }
}
