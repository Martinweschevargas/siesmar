using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MedioComunicacionDAO
    {

        SqlCommand cmd = new();

        public List<MedioComunicacionDTO> ObtenerMedioComunicacions()
        {
            List<MedioComunicacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MedioComunicacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MedioComunicacionDTO()
                        {
                            MedioComunicacionId = Convert.ToInt32(dr["MedioComunicacionId"]),
                            DescMedioComunicacion = dr["DescMedioComunicacion"].ToString(),
                            CodigoMedioComunicacion = dr["CodigoMedioComunicacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMedioComunicacion(MedioComunicacionDTO MedioComunicacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioComunicacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMedioComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMedioComunicacion"].Value = MedioComunicacionDTO.DescMedioComunicacion;

                    cmd.Parameters.Add("@CodigoMedioComunicacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMedioComunicacion"].Value = MedioComunicacionDTO.CodigoMedioComunicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MedioComunicacionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public MedioComunicacionDTO BuscarMedioComunicacionID(int Codigo)
        {
            MedioComunicacionDTO MedioComunicacionDTO = new MedioComunicacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioComunicacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedioComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@MedioComunicacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        MedioComunicacionDTO.MedioComunicacionId = Convert.ToInt32(dr["MedioComunicacionId"]);
                        MedioComunicacionDTO.DescMedioComunicacion = dr["DescMedioComunicacion"].ToString();
                        MedioComunicacionDTO.CodigoMedioComunicacion = dr["CodigoMedioComunicacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return MedioComunicacionDTO;
        }

        public string ActualizarMedioComunicacion(MedioComunicacionDTO MedioComunicacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioComunicacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedioComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@MedioComunicacionId"].Value = MedioComunicacionDTO.MedioComunicacionId;

                    cmd.Parameters.Add("@DescMedioComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescMedioComunicacion"].Value = MedioComunicacionDTO.DescMedioComunicacion;

                    cmd.Parameters.Add("@CodigoMedioComunicacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMedioComunicacion"].Value = MedioComunicacionDTO.CodigoMedioComunicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MedioComunicacionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public string EliminarMedioComunicacion(MedioComunicacionDTO MedioComunicacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MedioComunicacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedioComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@MedioComunicacionId"].Value = MedioComunicacionDTO.MedioComunicacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MedioComunicacionDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

    }
}
