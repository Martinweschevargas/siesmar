using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class InspeccionExtensionDAO
    {

        SqlCommand cmd = new();

        public List<InspeccionExtensionDTO> ObtenerInspeccionExtensions()
        {
            List<InspeccionExtensionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_InspeccionExtensionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InspeccionExtensionDTO()
                        {
                            InspeccionExtensionId = Convert.ToInt32(dr["InspeccionExtensionId"]),
                            DescInspeccionExtension = dr["DescInspeccionExtension"].ToString(),
                            CodigoInspeccionExtension = dr["CodigoInspeccionExtension"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarInspeccionExtension(InspeccionExtensionDTO inspeccionExtensionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionExtensionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescInspeccionExtension", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInspeccionExtension"].Value = inspeccionExtensionDTO.DescInspeccionExtension;

                    cmd.Parameters.Add("@CodigoInspeccionExtension", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInspeccionExtension"].Value = inspeccionExtensionDTO.CodigoInspeccionExtension;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionExtensionDTO.UsuarioIngresoRegistro;

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

        public InspeccionExtensionDTO BuscarInspeccionExtensionID(int Codigo)
        {
            InspeccionExtensionDTO inspeccionExtensionDTO = new InspeccionExtensionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionExtensionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionExtensionId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionExtensionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        inspeccionExtensionDTO.InspeccionExtensionId = Convert.ToInt32(dr["InspeccionExtensionId"]);
                        inspeccionExtensionDTO.DescInspeccionExtension = dr["DescInspeccionExtension"].ToString();
                        inspeccionExtensionDTO.CodigoInspeccionExtension = dr["CodigoInspeccionExtension"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return inspeccionExtensionDTO;
        }

        public string ActualizarInspeccionExtension(InspeccionExtensionDTO inspeccionExtensionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionExtensionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionExtensionId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionExtensionId"].Value = inspeccionExtensionDTO.InspeccionExtensionId;

                    cmd.Parameters.Add("@DescInspeccionExtension", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescInspeccionExtension"].Value = inspeccionExtensionDTO.DescInspeccionExtension;

                    cmd.Parameters.Add("@CodigoInspeccionExtension", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoInspeccionExtension"].Value = inspeccionExtensionDTO.CodigoInspeccionExtension;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionExtensionDTO.UsuarioIngresoRegistro;

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

        public string EliminarInspeccionExtension(InspeccionExtensionDTO inspeccionExtensionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_InspeccionExtensionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InspeccionExtensionId", SqlDbType.Int);
                    cmd.Parameters["@InspeccionExtensionId"].Value = inspeccionExtensionDTO.InspeccionExtensionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inspeccionExtensionDTO.UsuarioIngresoRegistro;

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
