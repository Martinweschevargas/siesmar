using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoArtefactoNavalDAO
    {

        SqlCommand cmd = new();

        public List<TipoArtefactoNavalDTO> ObtenerTipoArtefactoNavals()
        {
            List<TipoArtefactoNavalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoArtefactoNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoArtefactoNavalDTO()
                        {
                            TipoArtefactoNavalId = Convert.ToInt32(dr["TipoArtefactoNavalId"]),
                            DescTipoArtefactoNaval = dr["DescTipoArtefactoNaval"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoArtefactoNaval(TipoArtefactoNavalDTO tipoArtefactoNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoArtefactoNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoArtefactoNaval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoArtefactoNaval"].Value = tipoArtefactoNavalDTO.DescTipoArtefactoNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoArtefactoNavalDTO.UsuarioIngresoRegistro;

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

        public TipoArtefactoNavalDTO BuscarTipoArtefactoNavalID(int Codigo)
        {
            TipoArtefactoNavalDTO tipoArtefactoNavalDTO = new TipoArtefactoNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoArtefactoNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoArtefactoNavalId", SqlDbType.Int);
                    cmd.Parameters["@TipoArtefactoNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoArtefactoNavalDTO.TipoArtefactoNavalId = Convert.ToInt32(dr["TipoArtefactoNavalId"]);
                        tipoArtefactoNavalDTO.DescTipoArtefactoNaval = dr["DescTipoArtefactoNaval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoArtefactoNavalDTO;
        }

        public string ActualizarTipoArtefactoNaval(TipoArtefactoNavalDTO tipoArtefactoNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoArtefactoNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoArtefactoNavalId", SqlDbType.Int);
                    cmd.Parameters["@TipoArtefactoNavalId"].Value = tipoArtefactoNavalDTO.TipoArtefactoNavalId;

                    cmd.Parameters.Add("@DescTipoArtefactoNaval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoArtefactoNaval"].Value = tipoArtefactoNavalDTO.DescTipoArtefactoNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoArtefactoNavalDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoArtefactoNaval(TipoArtefactoNavalDTO tipoArtefactoNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoArtefactoNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoArtefactoNavalId", SqlDbType.Int);
                    cmd.Parameters["@TipoArtefactoNavalId"].Value = tipoArtefactoNavalDTO.TipoArtefactoNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoArtefactoNavalDTO.UsuarioIngresoRegistro;

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
