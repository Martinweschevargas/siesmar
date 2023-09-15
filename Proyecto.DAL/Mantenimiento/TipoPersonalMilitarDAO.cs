using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoPersonalMilitarDAO
    {

        SqlCommand cmd = new();

        public List<TipoPersonalMilitarDTO> ObtenerTipoPersonalMilitars()
        {
            List<TipoPersonalMilitarDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalMilitarListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoPersonalMilitarDTO()
                        {
                            TipoPersonalMilitarId = Convert.ToInt32(dr["TipoPersonalMilitarId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoPersonalMilitar(TipoPersonalMilitarDTO tipoPersonalMilitarDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalMilitarRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoPersonalMilitar", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoPersonalMilitar"].Value = tipoPersonalMilitarDTO.DescTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = tipoPersonalMilitarDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPersonalMilitarDTO.UsuarioIngresoRegistro;

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

        public TipoPersonalMilitarDTO BuscarTipoPersonalMilitarID(int Codigo)
        {
            TipoPersonalMilitarDTO tipoPersonalMilitarDTO = new TipoPersonalMilitarDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalMilitarEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoPersonalMilitarDTO.TipoPersonalMilitarId = Convert.ToInt32(dr["TipoPersonalMilitarId"]);
                        tipoPersonalMilitarDTO.DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString();
                        tipoPersonalMilitarDTO.CodigoTipoPersonalMilitar = dr["CodigoTipoPersonalMilitar"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoPersonalMilitarDTO;
        }

        public string ActualizarTipoPersonalMilitar(TipoPersonalMilitarDTO tipoPersonalMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalMilitarActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = tipoPersonalMilitarDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@DescTipoPersonalMilitar", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoPersonalMilitar"].Value = tipoPersonalMilitarDTO.DescTipoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoTipoPersonalMilitar", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoPersonalMilitar"].Value = tipoPersonalMilitarDTO.CodigoTipoPersonalMilitar;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPersonalMilitarDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoPersonalMilitar(TipoPersonalMilitarDTO tipoPersonalMilitarDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoPersonalMilitarEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = tipoPersonalMilitarDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoPersonalMilitarDTO.UsuarioIngresoRegistro;

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
