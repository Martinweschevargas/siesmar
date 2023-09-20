using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SubsistemaRepuestoCriticoDAO
    {

        SqlCommand cmd = new();

        public List<SubsistemaRepuestoCriticoDTO> ObtenerSubsistemaRepuestoCriticos()
        {
            List<SubsistemaRepuestoCriticoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SubsistemaRepuestoCriticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SubsistemaRepuestoCriticoDTO()
                        {
                            SubsistemaRepuestoCriticoId = Convert.ToInt32(dr["SubsistemaRepuestoCriticoId"]),
                            CodigoSubsistemaRepuestoCritico = dr["CodigoSubsistemaRepuestoCritico"].ToString(),
                            DescSubsistemaRepuestoCritico = dr["DescSubsistemaRepuestoCritico"].ToString(),
                            DescSistemaRepuestoCritico = dr["DescSistemaRepuestoCritico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO SubsistemaRepuestoCriticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaRepuestoCriticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoSubsistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaRepuestoCritico"].Value = SubsistemaRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico;

                    cmd.Parameters.Add("@DescSubsistemaRepuestoCritico", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSubsistemaRepuestoCritico"].Value = SubsistemaRepuestoCriticoDTO.DescSubsistemaRepuestoCritico;

                    cmd.Parameters.Add("@CodigoSistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaRepuestoCritico"].Value = SubsistemaRepuestoCriticoDTO.CodigoSistemaRepuestoCritico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaRepuestoCriticoDTO.UsuarioIngresoRegistro;

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

        public SubsistemaRepuestoCriticoDTO BuscarSubsistemaRepuestoCriticoID(int Codigo)
        {
            SubsistemaRepuestoCriticoDTO SubsistemaRepuestoCriticoDTO = new SubsistemaRepuestoCriticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaRepuestoCriticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaRepuestoCriticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        SubsistemaRepuestoCriticoDTO.SubsistemaRepuestoCriticoId = Convert.ToInt32(dr["SubsistemaRepuestoCriticoId"]);
                        SubsistemaRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = dr["CodigoSubsistemaRepuestoCritico"].ToString();
                        SubsistemaRepuestoCriticoDTO.DescSubsistemaRepuestoCritico = dr["DescSubsistemaRepuestoCritico"].ToString();
                        SubsistemaRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = dr["CodigoSistemaRepuestoCritico"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return SubsistemaRepuestoCriticoDTO;
        }

        public string ActualizarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO SubsistemaRepuestoCriticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaRepuestoCriticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaRepuestoCriticoId"].Value = SubsistemaRepuestoCriticoDTO.SubsistemaRepuestoCriticoId;

                    cmd.Parameters.Add("@CodigoSubsistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaRepuestoCritico"].Value = SubsistemaRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico;

                    cmd.Parameters.Add("@DescSubsistemaRepuestoCritico", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSubsistemaRepuestoCritico"].Value = SubsistemaRepuestoCriticoDTO.DescSubsistemaRepuestoCritico;
                    
                    cmd.Parameters.Add("@CodigoSistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaRepuestoCritico"].Value = SubsistemaRepuestoCriticoDTO.CodigoSistemaRepuestoCritico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaRepuestoCriticoDTO.UsuarioIngresoRegistro;

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

        public string EliminarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO SubsistemaRepuestoCriticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaRepuestoCriticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaRepuestoCriticoId"].Value = SubsistemaRepuestoCriticoDTO.SubsistemaRepuestoCriticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaRepuestoCriticoDTO.UsuarioIngresoRegistro;

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
