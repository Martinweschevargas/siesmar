using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CapacidadOperativaRequeridaDAO
    {

        SqlCommand cmd = new();

        public List<CapacidadOperativaRequeridaDTO> ObtenerCapacidadOperativaRequeridas()
        {
            List<CapacidadOperativaRequeridaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaRequeridaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapacidadOperativaRequeridaDTO()
                        {
                            CapacidadOperativaRequeridaId = Convert.ToInt32(dr["CapacidadOperativaRequeridaId"]),
                            DescCapacidadOperativaRequerida = dr["DescCapacidadOperativaRequerida"].ToString(),
                            CodigoCapacidadOperativaRequerida = dr["CodigoCapacidadOperativaRequerida"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCapacidadOperativaRequerida(CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaRequeridaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCapacidadOperativaRequerida", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescCapacidadOperativaRequerida"].Value = capacidadOperativaRequeridaDTO.DescCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@CodigoCapacidadOperativaRequerida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativaRequerida"].Value = capacidadOperativaRequeridaDTO.CodigoCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacidadOperativaRequeridaDTO.UsuarioIngresoRegistro;

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

        public CapacidadOperativaRequeridaDTO BuscarCapacidadOperativaRequeridaID(int Codigo)
        {
            CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDTO = new CapacidadOperativaRequeridaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaRequeridaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        capacidadOperativaRequeridaDTO.CapacidadOperativaRequeridaId = Convert.ToInt32(dr["CapacidadOperativaRequeridaId"]);
                        capacidadOperativaRequeridaDTO.DescCapacidadOperativaRequerida = dr["DescCapacidadOperativaRequerida"].ToString();
                        capacidadOperativaRequeridaDTO.CodigoCapacidadOperativaRequerida = dr["CodigoCapacidadOperativaRequerida"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capacidadOperativaRequeridaDTO;
        }

        public string ActualizarCapacidadOperativaRequerida(CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaRequeridaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = capacidadOperativaRequeridaDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@DescCapacidadOperativaRequerida", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescCapacidadOperativaRequerida"].Value = capacidadOperativaRequeridaDTO.DescCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@CodigoCapacidadOperativaRequerida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCapacidadOperativaRequerida"].Value = capacidadOperativaRequeridaDTO.CodigoCapacidadOperativaRequerida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacidadOperativaRequeridaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCapacidadOperativaRequerida(CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CapacidadOperativaRequeridaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = capacidadOperativaRequeridaDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacidadOperativaRequeridaDTO.UsuarioIngresoRegistro;

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
