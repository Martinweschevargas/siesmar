using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TipoAdmisionIngresoDAO
    {

        SqlCommand cmd = new();

        public List<TipoAdmisionIngresoDTO> ObtenerTipoAdmisionIngresos()
        {
            List<TipoAdmisionIngresoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TipoAdmisionIngresoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TipoAdmisionIngresoDTO()
                        {
                            TipoAdmisionIngresoId = Convert.ToInt32(dr["TipoAdmisionIngresoId"]),
                            DescTipoAdmisionIngreso = dr["DescTipoAdmisionIngreso"].ToString(),
                            CodigoTipoAdmisionIngreso = dr["CodigoTipoAdmisionIngreso"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTipoAdmisionIngreso(TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAdmisionIngresoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTipoAdmisionIngreso", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTipoAdmisionIngreso"].Value = tipoAdmisionIngresoDTO.DescTipoAdmisionIngreso;

                    cmd.Parameters.Add("@CodigoTipoAdmisionIngreso", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTipoAdmisionIngreso"].Value = tipoAdmisionIngresoDTO.CodigoTipoAdmisionIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAdmisionIngresoDTO.UsuarioIngresoRegistro;

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

        public TipoAdmisionIngresoDTO BuscarTipoAdmisionIngresoID(int Codigo)
        {
            TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO = new TipoAdmisionIngresoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAdmisionIngresoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAdmisionIngresoId", SqlDbType.Int);
                    cmd.Parameters["@TipoAdmisionIngresoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        tipoAdmisionIngresoDTO.TipoAdmisionIngresoId = Convert.ToInt32(dr["TipoAdmisionIngresoId"]);
                        tipoAdmisionIngresoDTO.DescTipoAdmisionIngreso = dr["DescTipoAdmisionIngreso"].ToString();
                        tipoAdmisionIngresoDTO.CodigoTipoAdmisionIngreso = dr["CodigoTipoAdmisionIngreso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipoAdmisionIngresoDTO;
        }

        public string ActualizarTipoAdmisionIngreso(TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAdmisionIngresoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAdmisionIngresoId", SqlDbType.Int);
                    cmd.Parameters["@TipoAdmisionIngresoId"].Value = tipoAdmisionIngresoDTO.TipoAdmisionIngresoId;

                    cmd.Parameters.Add("@DescTipoAdmisionIngreso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTipoAdmisionIngreso"].Value = tipoAdmisionIngresoDTO.DescTipoAdmisionIngreso;

                    cmd.Parameters.Add("@CodigoTipoAdmisionIngreso", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTipoAdmisionIngreso"].Value = tipoAdmisionIngresoDTO.CodigoTipoAdmisionIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAdmisionIngresoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTipoAdmisionIngreso(TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TipoAdmisionIngresoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoAdmisionIngresoId", SqlDbType.Int);
                    cmd.Parameters["@TipoAdmisionIngresoId"].Value = tipoAdmisionIngresoDTO.TipoAdmisionIngresoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = tipoAdmisionIngresoDTO.UsuarioIngresoRegistro;

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
