using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class UsuarioDAO
    {

        SqlCommand cmd = new();

        public List<UsuarioDTO> ObtenerUsuarios(int? RolId = null)
        {
            List<UsuarioDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_UsuariosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@RolId", SqlDbType.Int);
                cmd.Parameters["@RolId"].Value = RolId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new UsuarioDTO()
                        {
                            Id = Convert.ToInt32(dr["UsuarioId"]),
                            TipoDocumento = Convert.ToInt32(dr["TipoDocumento"]),
                            TipoPersona = Convert.ToInt32(dr["TipoPersona"]),
                            EspecialidadId = Convert.ToInt32(dr["EspecialidadId"]),
                            CalificacionId = Convert.ToInt32(dr["Calificacion"]),
                            GradoInstruccionId = Convert.ToInt32(dr["GradoInstruccion"]),
                            RolId = Convert.ToInt32(dr["Rolid"]),
                            Documento = dr["Documento"].ToString(),
                            Nombre1 = dr["Nombre1"].ToString(),
                            Nombre2 = dr["Nombre2"].ToString(),
                            Nombre3 = dr["Nombre3"].ToString(),
                            ApellidoMaterno = dr["ApellidoMaterno"].ToString(),
                            ApellidoPaterno = dr["ApellidoPaterno"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Sexo = dr["Sexo"].ToString(),
                            Cip = dr["CIP"].ToString(),                           
                            FechaIngreso = dr["FechaIngreso"].ToString(),
                            UbigeoOldDomicilio = dr["UbigeoOldDomicilio"].ToString(),
                            UbigeoDomicilio = dr["UbigeoDomicilio"].ToString(),
                            CorreoInterno = dr["CorreoInterno"].ToString(),
                            CorreoExterno = dr["CorreoExterno"].ToString(),
                            TelefonoCelular = dr["TelefonoCelular"].ToString(),
                            TelefonoFijo = dr["TelefonoFijo"].ToString(),
                            DescDependencia = dr["Dependencia"].ToString(),                    
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUsuario(UsuarioDTO usuarioDTO)
        {
            string ID = "0";
            
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuariosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmailUsuario", SqlDbType.VarChar, 80);
                    cmd.Parameters["@EmailUsuario"].Value = usuarioDTO.CorreoExterno;

                    cmd.Parameters.Add("@PasswordUsuario", SqlDbType.VarChar, 80);
                    cmd.Parameters["@PasswordUsuario"].Value = usuarioDTO.Cip;

                    cmd.Parameters.Add("@DniUsuario", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DniUsuario"].Value = usuarioDTO.Cip;

                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Nombre"].Value = usuarioDTO.Nombres;

                    cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 100);
                    cmd.Parameters["@ApellidoPaterno"].Value = usuarioDTO.ApellidoPaterno;

                    cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 100);
                    cmd.Parameters["@ApellidoMaterno"].Value = usuarioDTO.ApellidoMaterno;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CIP"].Value = usuarioDTO.Cip;

                    cmd.Parameters.Add("@GradoId", SqlDbType.Int);
                    cmd.Parameters["@GradoId"].Value = usuarioDTO.Cip;

                    cmd.Parameters.Add("@EspecialidadId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadId"].Value = usuarioDTO.Cip;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = usuarioDTO.Cip;

                    cmd.Parameters.Add("@Foto", SqlDbType.VarChar, 250);
                    cmd.Parameters["@Foto"].Value = usuarioDTO.Cip;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usuarioDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            ID = dr["ID"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ID=ex.Message;
                }
            }
            return ID;
        }

        public UsuarioDAO()
        {
        }

        public UsuarioDTO BuscarUsuarioDNI(int UsuarioId)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            ConfiguracionConexion cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuariosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pDNI = new SqlParameter();
                    pDNI.ParameterName = "@UsuarioId";
                    pDNI.SqlDbType = SqlDbType.VarChar;
                    pDNI.Value = UsuarioId;
                    cmd.Parameters.Add(pDNI);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        usuarioDTO.Id = Convert.ToInt32(dr["UsuarioId"]);
                        usuarioDTO.TipoDocumento = Convert.ToInt32(dr["TipoDocumento"]);
                        usuarioDTO.Documento = dr["Documento"].ToString();
                        usuarioDTO.Nombre1 = dr["Nombre1"].ToString();
                        usuarioDTO.Nombre2 = dr["Nombre2"].ToString();
                        usuarioDTO.Nombre3 = dr["Nombre3"].ToString();
                        usuarioDTO.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                        usuarioDTO.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                        usuarioDTO.NombreCompleto = dr["NombreCompleto"].ToString();
                        usuarioDTO.Sexo = dr["Sexo"].ToString();
                        usuarioDTO.Cip = dr["CIP"].ToString();
                        usuarioDTO.TipoPersona = Convert.ToInt32(dr["TipoPersona"]);
                        //usuarioDTO.Grado = Convert.ToInt32(dr["Grado"]);
                        usuarioDTO.EspecialidadId = Convert.ToInt32(dr["Especialidad"]);
                        usuarioDTO.CalificacionId = Convert.ToInt32(dr["Calificacion"]);
                        usuarioDTO.FechaIngreso = UtilitariosGlobales.obtenerFecha(dr["FechaIngreso"].ToString());
                        usuarioDTO.UbigeoOldDomicilio = dr["UbigeoOldDomicilio"].ToString();
                        usuarioDTO.UbigeoDomicilio = dr["UbigeoDomicilio"].ToString();
                        usuarioDTO.CorreoInterno = dr["CorreoInterno"].ToString();
                        usuarioDTO.CorreoExterno = dr["CorreoExterno"].ToString();
                        usuarioDTO.TelefonoCelular = dr["TelefonoCelular"].ToString();
                        usuarioDTO.TelefonoFijo = dr["TelefonoFijo"].ToString();
                        usuarioDTO.DescDependencia = dr["Dependencia"].ToString();
                        usuarioDTO.GradoInstruccionId = Convert.ToInt32(dr["GradoInstruccion"]);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarioDTO;
        }

        public bool ActualizarUsuario(UsuarioDTO usuarioDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuariosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUsuarioId = new SqlParameter();
                    pUsuarioId.ParameterName = "@UsuarioId";
                    pUsuarioId.SqlDbType = SqlDbType.Int;
                    pUsuarioId.Value = usuarioDTO.Id;

                    SqlParameter pEmail = new SqlParameter();
                    pEmail.ParameterName = "@EmailUsuario";
                    pEmail.SqlDbType = SqlDbType.VarChar;
                    pEmail.Size = 80;
                    pEmail.Value = usuarioDTO.CorreoExterno;

                    SqlParameter pcontrasena = new SqlParameter();
                    pcontrasena.ParameterName = "@ContrasenaUsuario";
                    pcontrasena.SqlDbType = SqlDbType.VarChar;
                    pcontrasena.Size = 80;
                    pcontrasena.Value = usuarioDTO.CorreoExterno;

                    SqlParameter pDni = new SqlParameter();
                    pDni.ParameterName = "@DniUsuario";
                    pDni.SqlDbType = SqlDbType.VarChar;
                    pDni.Size = 80;
                    pDni.Value = usuarioDTO.Nombres;

                    SqlParameter pNombre = new SqlParameter();
                    pNombre.ParameterName = "@Nombre";
                    pNombre.SqlDbType = SqlDbType.VarChar;
                    pNombre.Size = 80;
                    pNombre.Value = usuarioDTO.Nombres;

                    SqlParameter pApellidoP = new SqlParameter();
                    pApellidoP.ParameterName = "@ApellidoPaterno";
                    pApellidoP.SqlDbType = SqlDbType.VarChar;
                    pApellidoP.Size = 80;
                    pApellidoP.Value = usuarioDTO.ApellidoPaterno;

                    SqlParameter pCIP = new SqlParameter();
                    pCIP.ParameterName = "@CIP";
                    pCIP.SqlDbType = SqlDbType.VarChar;
                    pCIP.Size = 80;
                    pCIP.Value = usuarioDTO.Cip;

                    SqlParameter pApellidoM = new SqlParameter();
                    pApellidoM.ParameterName = "@ApellidoMaterno";
                    pApellidoM.SqlDbType = SqlDbType.VarChar;
                    pApellidoM.Size = 80;
                    pApellidoM.Value = usuarioDTO.ApellidoMaterno;

                    SqlParameter pEspecialidadID = new SqlParameter();
                    pEspecialidadID.ParameterName = "@EspecialidadId";
                    pEspecialidadID.SqlDbType = SqlDbType.VarChar;
                    pEspecialidadID.Size = 80;
                    pEspecialidadID.Value = usuarioDTO.EspecialidadId;

                    SqlParameter pFoto = new SqlParameter();
                    pFoto.ParameterName = "@Foto";
                    pFoto.SqlDbType = SqlDbType.VarChar;
                    pFoto.Size = 80;
                    pFoto.Value = usuarioDTO.FechaIngreso;

                    SqlParameter pIP = new SqlParameter();
                    pIP.ParameterName = "@Usuario";
                    pIP.SqlDbType = SqlDbType.VarChar;
                    pIP.Size = 80;
                    pIP.Value = "192.168.1.24";

                    cmd.Parameters.Add(pUsuarioId);
                    cmd.Parameters.Add(pEmail);
                    cmd.Parameters.Add(pcontrasena);
                    cmd.Parameters.Add(pDni);
                    cmd.Parameters.Add(pNombre);
                    cmd.Parameters.Add(pApellidoP);
                    cmd.Parameters.Add(pCIP);
                    cmd.Parameters.Add(pApellidoM);
                    cmd.Parameters.Add(pEspecialidadID);
                    cmd.Parameters.Add(pFoto);
                    cmd.Parameters.Add(pIP);

                    cmd.ExecuteNonQuery();
                    respuesta = true;

                }
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        public bool EliminarUsuario(int UsuarioId)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_UsuariosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pUsuarioId = new SqlParameter();
                    pUsuarioId.ParameterName = "@UsuarioId";
                    pUsuarioId.SqlDbType = SqlDbType.Int;
                    pUsuarioId.Value = UsuarioId;

                    cmd.Parameters.Add(pUsuarioId);
                    cmd.ExecuteNonQuery();

                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }
    }
}
