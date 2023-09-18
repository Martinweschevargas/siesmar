using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InspeccionConocimientoDAO
    {

        SqlCommand cmd = new();

        public List<InspeccionConocimientoDTO> ObtenerInspeccionConocimientos()
        {
            List<InspeccionConocimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InspeccionConocimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InspeccionConocimientoDTO()
                        {
                            InspeccionConocimientoId = Convert.ToInt32(dr["InspeccionConocimientoId"]),
                            DescInspeccionConocimiento = dr["DescInspeccionConocimiento"].ToString(),
                            CodigoInspeccionConocimiento = dr["CodigoInspeccionConocimiento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInspeccionConocimiento(InspeccionConocimientoDTO inspeccionConocimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionConocimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInspeccionConocimiento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescInspeccionConocimiento"].Value = inspeccionConocimientoDTO.DescInspeccionConocimiento;

                    cmd.Parameters.Add("@CodigoInspeccionConocimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInspeccionConocimiento"].Value = inspeccionConocimientoDTO.CodigoInspeccionConocimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionConocimientoDTO.UsuarioIngresoRegistro;

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

        public InspeccionConocimientoDTO BuscarInspeccionConocimientoID(int Codigo)
        {
            InspeccionConocimientoDTO inspeccionConocimientoDTO = new InspeccionConocimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionConocimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionConocimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        inspeccionConocimientoDTO.InspeccionConocimientoId = Convert.ToInt32(dr["InspeccionConocimientoId"]);
                        inspeccionConocimientoDTO.DescInspeccionConocimiento = dr["DescInspeccionConocimiento"].ToString();
                        inspeccionConocimientoDTO.CodigoInspeccionConocimiento = dr["CodigoInspeccionConocimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return inspeccionConocimientoDTO;
        }

        public string ActualizarInspeccionConocimiento(InspeccionConocimientoDTO inspeccionConocimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionConocimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionConocimientoId"].Value = inspeccionConocimientoDTO.InspeccionConocimientoId;

                    cmd.Parameters.Add("@DescInspeccionConocimiento", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescInspeccionConocimiento"].Value = inspeccionConocimientoDTO.DescInspeccionConocimiento;

                    cmd.Parameters.Add("@CodigoInspeccionConocimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInspeccionConocimiento"].Value = inspeccionConocimientoDTO.CodigoInspeccionConocimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionConocimientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarInspeccionConocimiento(InspeccionConocimientoDTO inspeccionConocimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionConocimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionConocimientoId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionConocimientoId"].Value = inspeccionConocimientoDTO.InspeccionConocimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionConocimientoDTO.UsuarioIngresoRegistro;

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
