using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Seguridad;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Seguridad
{
    public class PermisoDAO
    {
        SqlCommand cmd = new SqlCommand();

        public List<PermisoDTO> ObtenerPermisos()
        {
            List<PermisoDTO> lista = new List<PermisoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Seguridad.usp_PermisosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new PermisoDTO()
                        {
                            PermisoId = Convert.ToInt32(dr["PermisoId"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public bool AgregarPermiso(PermisoDTO permisoDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PermisosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pPermiso = new SqlParameter();
                    pPermiso.ParameterName = "@Nombre";
                    pPermiso.SqlDbType = SqlDbType.VarChar;
                    pPermiso.Size = 80;
                    pPermiso.Value = permisoDTO.Nombre;

                    SqlParameter pUsuario = new SqlParameter();
                    pUsuario.ParameterName = "@IP";
                    pUsuario.SqlDbType = SqlDbType.VarChar;
                    pUsuario.Size = 80;
                    pUsuario.Value = "USER";

                    SqlParameter pIP = new SqlParameter();
                    pIP.ParameterName = "@Usuario";
                    pIP.SqlDbType = SqlDbType.VarChar;
                    pIP.Size = 80;
                    pIP.Value = "192.168.1.24";

                    SqlParameter pMAC = new SqlParameter();
                    pMAC.ParameterName = "@MAC";
                    pMAC.SqlDbType = SqlDbType.VarChar;
                    pMAC.Size = 50;
                    pMAC.Value = "2344GG6366";

                    SqlParameter pUsuarioDB = new SqlParameter();
                    pUsuarioDB.ParameterName = "@UsuarioDB";
                    pUsuarioDB.SqlDbType = SqlDbType.VarChar;
                    pUsuarioDB.Size = 50;
                    pUsuarioDB.Value = "SA";

                    cmd.Parameters.Add(pPermiso);
                    cmd.Parameters.Add(pUsuario);
                    cmd.Parameters.Add(pIP);
                    cmd.Parameters.Add(pMAC);
                    cmd.Parameters.Add(pUsuarioDB);

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

        public PermisoDTO BuscarPermisoID(int PermisoId)
        {
            PermisoDTO PermisoDTO = new PermisoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PermisosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIDPermiso = new SqlParameter();
                    pIDPermiso.ParameterName = "@PermisosId";
                    pIDPermiso.SqlDbType = SqlDbType.Int;
                    pIDPermiso.Value = PermisoId;

                    cmd.Parameters.Add(pIDPermiso);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        PermisoDTO.PermisoId = Convert.ToInt32(dr["PermisoId"]);
                        PermisoDTO.Nombre = dr["Nombre"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PermisoDTO;
        }

        public bool ActualizarPermiso(PermisoDTO PermisoDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PermisosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pPermisoId = new SqlParameter();
                    pPermisoId.ParameterName = "@PermisosId";
                    pPermisoId.SqlDbType = SqlDbType.Int;
                    pPermisoId.Value = PermisoDTO.PermisoId;

                    SqlParameter pPermiso = new SqlParameter();
                    pPermiso.ParameterName = "@Nombre";
                    pPermiso.SqlDbType = SqlDbType.VarChar;
                    pPermiso.Size = 80;
                    pPermiso.Value = PermisoDTO.Nombre;

                    SqlParameter pIP = new SqlParameter();
                    pIP.ParameterName = "@Usuario";
                    pIP.SqlDbType = SqlDbType.VarChar;
                    pIP.Size = 80;
                    pIP.Value = "192.168.1.24";

                    cmd.Parameters.Add(pPermisoId);
                    cmd.Parameters.Add(pPermiso);
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

        public bool EliminarPermiso(int PermisoId)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_PermisosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pPermisoId = new SqlParameter();
                    pPermisoId.ParameterName = "@PermisosId";
                    pPermisoId.SqlDbType = SqlDbType.Int;
                    pPermisoId.Value = PermisoId;

                    cmd.Parameters.Add(pPermisoId);
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
