using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EntidadFinancieraDAO
    {

        SqlCommand cmd = new();

        public List<EntidadFinancieraDTO> ObtenerEntidadFinancieras()
        {
            List<EntidadFinancieraDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EntidadFinancieraDTO()
                        {
                            EntidadFinancieraId = Convert.ToInt32(dr["EntidadFinancieraId"]),
                            DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString(),
                            CodigoEntidadFinanciera = dr["CodigoEntidadFinanciera"].ToString(),
                            DescEntidadFinancieraGrupo = dr["DescEntidadFinancieraGrupo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEntidadFinanciera(EntidadFinancieraDTO EntidadFinancieraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEntidadFinanciera", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEntidadFinanciera"].Value = EntidadFinancieraDTO.DescEntidadFinanciera;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = EntidadFinancieraDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@EntidadFinancieraGrupoId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraGrupoId"].Value = EntidadFinancieraDTO.EntidadFinancieraGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EntidadFinancieraDTO.UsuarioIngresoRegistro;

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

        public EntidadFinancieraDTO BuscarEntidadFinancieraID(int Codigo)
        {
            EntidadFinancieraDTO EntidadFinancieraDTO = new EntidadFinancieraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadFinancieraId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        EntidadFinancieraDTO.EntidadFinancieraId = Convert.ToInt32(dr["EntidadFinancieraId"]);
                        EntidadFinancieraDTO.DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString();
                        EntidadFinancieraDTO.CodigoEntidadFinanciera = dr["CodigoEntidadFinanciera"].ToString();
                        EntidadFinancieraDTO.EntidadFinancieraGrupoId = Convert.ToInt32(dr["EntidadFinancieraGrupoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return EntidadFinancieraDTO;
        }

        public string ActualizarEntidadFinanciera(EntidadFinancieraDTO EntidadFinancieraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadFinancieraId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraId"].Value = EntidadFinancieraDTO.EntidadFinancieraId;

                    cmd.Parameters.Add("@DescEntidadFinanciera", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEntidadFinanciera"].Value = EntidadFinancieraDTO.DescEntidadFinanciera;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = EntidadFinancieraDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@EntidadFinancieraGrupoId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraGrupoId"].Value = EntidadFinancieraDTO.EntidadFinancieraGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EntidadFinancieraDTO.UsuarioIngresoRegistro;

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

        public string EliminarEntidadFinanciera(EntidadFinancieraDTO EntidadFinancieraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadFinancieraId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraId"].Value = EntidadFinancieraDTO.EntidadFinancieraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = EntidadFinancieraDTO.UsuarioIngresoRegistro;

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
