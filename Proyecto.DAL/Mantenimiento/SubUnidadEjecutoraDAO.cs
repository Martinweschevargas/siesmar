using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SubUnidadEjecutoraDAO
    {

        SqlCommand cmd = new();

        public List<SubUnidadEjecutoraDTO> ObtenerSubUnidadEjecutoras()
        {
            List<SubUnidadEjecutoraDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SubUnidadEjecutoraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SubUnidadEjecutoraDTO()
                        {
                            SubUnidadEjecutoraId = Convert.ToInt32(dr["SubUnidadEjecutoraId"]),
                            DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString(),
                            CodigoSubUnidadEjecutora = dr["CodigoSubUnidadEjecutora"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSubUnidadEjecutora(SubUnidadEjecutoraDTO subUnidadEjecutoraDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubUnidadEjecutoraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSubUnidadEjecutora", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@DescSubUnidadEjecutora"].Value = subUnidadEjecutoraDTO.DescSubUnidadEjecutora;

                    cmd.Parameters.Add("@CodigoSubUnidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubUnidadEjecutora"].Value = subUnidadEjecutoraDTO.CodigoSubUnidadEjecutora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = subUnidadEjecutoraDTO.UsuarioIngresoRegistro;

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

        public SubUnidadEjecutoraDTO BuscarSubUnidadEjecutoraID(int Codigo)
        {
            SubUnidadEjecutoraDTO subUnidadEjecutoraDTO = new SubUnidadEjecutoraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubUnidadEjecutoraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubUnidadEjecutoraId", SqlDbType.Int);
                    cmd.Parameters["@SubUnidadEjecutoraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        subUnidadEjecutoraDTO.SubUnidadEjecutoraId = Convert.ToInt32(dr["SubUnidadEjecutoraId"]);
                        subUnidadEjecutoraDTO.DescSubUnidadEjecutora = dr["DescSubUnidadEjecutora"].ToString();
                        subUnidadEjecutoraDTO.CodigoSubUnidadEjecutora = dr["CodigoSubUnidadEjecutora"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return subUnidadEjecutoraDTO;
        }

        public string ActualizarSubUnidadEjecutora(SubUnidadEjecutoraDTO subUnidadEjecutoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SubUnidadEjecutoraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubUnidadEjecutoraId", SqlDbType.Int);
                    cmd.Parameters["@SubUnidadEjecutoraId"].Value = subUnidadEjecutoraDTO.SubUnidadEjecutoraId;

                    cmd.Parameters.Add("@DescSubUnidadEjecutora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSubUnidadEjecutora"].Value = subUnidadEjecutoraDTO.DescSubUnidadEjecutora;

                    cmd.Parameters.Add("@CodigoSubUnidadEjecutora", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubUnidadEjecutora"].Value = subUnidadEjecutoraDTO.CodigoSubUnidadEjecutora;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = subUnidadEjecutoraDTO.UsuarioIngresoRegistro;

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
                                                   
        public string EliminarSubUnidadEjecutora(SubUnidadEjecutoraDTO subUnidadEjecutoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubUnidadEjecutoraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubUnidadEjecutoraId", SqlDbType.Int);
                    cmd.Parameters["@SubUnidadEjecutoraId"].Value = subUnidadEjecutoraDTO.SubUnidadEjecutoraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = subUnidadEjecutoraDTO.UsuarioIngresoRegistro;

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
