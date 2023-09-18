using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoCombustibleComoperguardDAO
    {

        SqlCommand cmd = new();

        public List<TipoCombustibleComoperguardDTO> ObtenerTipoCombustibleComoperguards()
        {
            List<TipoCombustibleComoperguardDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoCombustibleComoperguardListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoCombustibleComoperguardDTO()
                        {
                            TipoCombustibleComoperguardId = Convert.ToInt32(dr["TipoCombustibleComoperguardId"]),
                            DescTipoCombustibleComoperguard = dr["DescTipoCombustibleComoperguard"].ToString(),
                            CodigoTipoCombustibleComoperguard = dr["CodigoTipoCombustibleComoperguard"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO TipoCombustibleComoperguardDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCombustibleComoperguardRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;  

                    cmd.Parameters.Add("@DescTipoCombustibleComoperguard", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescTipoCombustibleComoperguard"].Value = TipoCombustibleComoperguardDTO.DescTipoCombustibleComoperguard;

                    cmd.Parameters.Add("@CodigoTipoCombustibleComoperguard", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCombustibleComoperguard"].Value = TipoCombustibleComoperguardDTO.CodigoTipoCombustibleComoperguard;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCombustibleComoperguardDTO.UsuarioIngresoRegistro;

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

        public TipoCombustibleComoperguardDTO BuscarTipoCombustibleComoperguardID(int Codigo)
        {
            TipoCombustibleComoperguardDTO TipoCombustibleComoperguardDTO = new TipoCombustibleComoperguardDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCombustibleComoperguardEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCombustibleComoperguardId", SqlDbType.Int);
                    cmd.Parameters["@TipoCombustibleComoperguardId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        TipoCombustibleComoperguardDTO.TipoCombustibleComoperguardId = Convert.ToInt32(dr["TipoCombustibleComoperguardId"]);
                        TipoCombustibleComoperguardDTO.DescTipoCombustibleComoperguard = dr["DescTipoCombustibleComoperguard"].ToString();
                        TipoCombustibleComoperguardDTO.CodigoTipoCombustibleComoperguard = dr["CodigoTipoCombustibleComoperguard"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return TipoCombustibleComoperguardDTO;
        }

        public string ActualizarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO TipoCombustibleComoperguardDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCombustibleComoperguardActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCombustibleComoperguardId", SqlDbType.Int);
                    cmd.Parameters["@TipoCombustibleComoperguardId"].Value = TipoCombustibleComoperguardDTO.TipoCombustibleComoperguardId;

                    cmd.Parameters.Add("@DescTipoCombustibleComoperguard", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescTipoCombustibleComoperguard"].Value = TipoCombustibleComoperguardDTO.DescTipoCombustibleComoperguard;

                    cmd.Parameters.Add("@CodigoTipoCombustibleComoperguard", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoCombustibleComoperguard"].Value = TipoCombustibleComoperguardDTO.CodigoTipoCombustibleComoperguard;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCombustibleComoperguardDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO TipoCombustibleComoperguardDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoCombustibleComoperguardEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoCombustibleComoperguardId", SqlDbType.Int);
                    cmd.Parameters["@TipoCombustibleComoperguardId"].Value = TipoCombustibleComoperguardDTO.TipoCombustibleComoperguardId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = TipoCombustibleComoperguardDTO.UsuarioIngresoRegistro;

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
