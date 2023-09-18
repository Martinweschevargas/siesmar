using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoBienDenominacionSubcampoDAO
    {

        SqlCommand cmd = new();

        public List<TipoBienDenominacionSubcampoDTO> ObtenerTipoBienDenominacionSubcampos()
        {
            List<TipoBienDenominacionSubcampoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoBienDenominacionSubcampoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoBienDenominacionSubcampoDTO()
                        {
                            TipoBienDenominacionSubcampoId = Convert.ToInt32(dr["TipoBienDenominacionSubcampoId"]),
                            DescTipoBienDenominacionSubcampo = dr["DescTipoBienDenominacionSubcampo"].ToString(),
                            CodigoTipoBienDenominacionSubcampo = dr["CodigoTipoBienDenominacionSubcampo"].ToString(),
                            DescTipoBienSubcampo = dr["DescTipoBienSubcampo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoBienDenominacionSubcampo(TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienDenominacionSubcampoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoBienDenominacionSubcampo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoBienDenominacionSubcampo"].Value = tipoBienDenominacionSubcampoDTO.DescTipoBienDenominacionSubcampo;

                    cmd.Parameters.Add("@CodigoTipoBienDenominacionSubcampo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoBienDenominacionSubcampo"].Value = tipoBienDenominacionSubcampoDTO.CodigoTipoBienDenominacionSubcampo;

                    cmd.Parameters.Add("@TipoBienSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienSubcampoId"].Value = tipoBienDenominacionSubcampoDTO.TipoBienSubcampoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBienDenominacionSubcampoDTO.UsuarioIngresoRegistro;

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

        public TipoBienDenominacionSubcampoDTO BuscarTipoBienDenominacionSubcampoID(int Codigo)
        {
            TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDTO = new TipoBienDenominacionSubcampoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienDenominacionSubcampoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBienDenominacionSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienDenominacionSubcampoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoBienDenominacionSubcampoDTO.TipoBienDenominacionSubcampoId = Convert.ToInt32(dr["TipoBienDenominacionSubcampoId"]);
                        tipoBienDenominacionSubcampoDTO.DescTipoBienDenominacionSubcampo = dr["DescTipoBienDenominacionSubcampo"].ToString();
                        tipoBienDenominacionSubcampoDTO.CodigoTipoBienDenominacionSubcampo = dr["CodigoTipoBienDenominacionSubcampo"].ToString();
                        tipoBienDenominacionSubcampoDTO.TipoBienSubcampoId = Convert.ToInt32(dr["TipoBienSubcampoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoBienDenominacionSubcampoDTO;
        }

        public string ActualizarTipoBienDenominacionSubcampo(TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienDenominacionSubcampoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBienDenominacionSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienDenominacionSubcampoId"].Value = tipoBienDenominacionSubcampoDTO.TipoBienDenominacionSubcampoId;

                    cmd.Parameters.Add("@DescTipoBienDenominacionSubcampo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoBienDenominacionSubcampo"].Value = tipoBienDenominacionSubcampoDTO.DescTipoBienDenominacionSubcampo;

                    cmd.Parameters.Add("@CodigoTipoBienDenominacionSubcampo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoBienDenominacionSubcampo"].Value = tipoBienDenominacionSubcampoDTO.CodigoTipoBienDenominacionSubcampo;

                    cmd.Parameters.Add("@TipoBienSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienSubcampoId"].Value = tipoBienDenominacionSubcampoDTO.TipoBienSubcampoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBienDenominacionSubcampoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoBienDenominacionSubcampo(TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoBienDenominacionSubcampoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoBienDenominacionSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@TipoBienDenominacionSubcampoId"].Value = tipoBienDenominacionSubcampoDTO.TipoBienDenominacionSubcampoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoBienDenominacionSubcampoDTO.UsuarioIngresoRegistro;

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
