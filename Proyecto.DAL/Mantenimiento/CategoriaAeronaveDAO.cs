using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CategoriaAeronaveDAO
    {

        SqlCommand cmd = new();

        public List<CategoriaAeronaveDTO> ObtenerCategoriaAeronaves()
        {
            List<CategoriaAeronaveDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CategoriaAeronaveListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CategoriaAeronaveDTO()
                        {
                            CategoriaAeronaveId = Convert.ToInt32(dr["CategoriaAeronaveId"]),
                            DescCategoriaAeronave = dr["DescCategoriaAeronave"].ToString(),
                            CodigoCategoriaAeronave = dr["CodigoCategoriaAeronave"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCategoriaAeronave(CategoriaAeronaveDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaAeronaveRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCategoriaAeronave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescCategoriaAeronave"].Value = capitaniaDTO.DescCategoriaAeronave;

                    cmd.Parameters.Add("@CodigoCategoriaAeronave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCategoriaAeronave"].Value = capitaniaDTO.CodigoCategoriaAeronave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public CategoriaAeronaveDTO BuscarCategoriaAeronaveID(int Codigo)
        {
            CategoriaAeronaveDTO capitaniaDTO = new CategoriaAeronaveDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaAeronaveEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaAeronaveId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        capitaniaDTO.CategoriaAeronaveId = Convert.ToInt32(dr["CategoriaAeronaveId"]);
                        capitaniaDTO.DescCategoriaAeronave = dr["DescCategoriaAeronave"].ToString();
                        capitaniaDTO.CodigoCategoriaAeronave = dr["CodigoCategoriaAeronave"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capitaniaDTO;
        }

        public string ActualizarCategoriaAeronave(CategoriaAeronaveDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaAeronaveActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaAeronaveId"].Value = capitaniaDTO.CategoriaAeronaveId;

                    cmd.Parameters.Add("@DescCategoriaAeronave", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescCategoriaAeronave"].Value = capitaniaDTO.DescCategoriaAeronave;

                    cmd.Parameters.Add("@CodigoCategoriaAeronave", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCategoriaAeronave"].Value = capitaniaDTO.CodigoCategoriaAeronave;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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

        public string EliminarCategoriaAeronave(CategoriaAeronaveDTO capitaniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaAeronaveEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaAeronaveId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaAeronaveId"].Value = capitaniaDTO.CategoriaAeronaveId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capitaniaDTO.UsuarioIngresoRegistro;

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
