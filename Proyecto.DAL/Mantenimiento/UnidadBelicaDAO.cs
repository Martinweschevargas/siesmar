using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UnidadBelicaDAO
    {

        SqlCommand cmd = new();

        public List<UnidadBelicaDTO> ObtenerUnidadBelicas()
        {
            List<UnidadBelicaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UnidadBelicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UnidadBelicaDTO()
                        {
                            UnidadBelicaId = Convert.ToInt32(dr["UnidadBelicaId"]),
                            DescUnidadBelica = dr["DescUnidadBelica"].ToString(),
                            CodigoUnidadBelica = dr["CodigoUnidadBelica"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUnidadBelica(UnidadBelicaDTO unidadBelicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadBelicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUnidadBelica", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescUnidadBelica"].Value = unidadBelicaDTO.DescUnidadBelica;

                    cmd.Parameters.Add("@CodigoUnidadBelica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadBelica"].Value = unidadBelicaDTO.CodigoUnidadBelica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadBelicaDTO.UsuarioIngresoRegistro;

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

        public UnidadBelicaDTO BuscarUnidadBelicaID(int Codigo)
        {
            UnidadBelicaDTO unidadBelicaDTO = new UnidadBelicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadBelicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadBelicaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadBelicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        unidadBelicaDTO.UnidadBelicaId = Convert.ToInt32(dr["UnidadBelicaId"]);
                        unidadBelicaDTO.DescUnidadBelica = dr["DescUnidadBelica"].ToString();
                        unidadBelicaDTO.CodigoUnidadBelica = dr["CodigoUnidadBelica"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadBelicaDTO;
        }

        public string ActualizarUnidadBelica(UnidadBelicaDTO unidadBelicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadBelicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadBelicaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadBelicaId"].Value = unidadBelicaDTO.UnidadBelicaId;

                    cmd.Parameters.Add("@DescUnidadBelica", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescUnidadBelica"].Value = unidadBelicaDTO.DescUnidadBelica;

                    cmd.Parameters.Add("@CodigoUnidadBelica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadBelica"].Value = unidadBelicaDTO.CodigoUnidadBelica;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadBelicaDTO.UsuarioIngresoRegistro;

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

        public string EliminarUnidadBelica(UnidadBelicaDTO unidadBelicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UnidadBelicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadBelicaId", SqlDbType.Int);
                    cmd.Parameters["@UnidadBelicaId"].Value = unidadBelicaDTO.UnidadBelicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = unidadBelicaDTO.UsuarioIngresoRegistro;

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
