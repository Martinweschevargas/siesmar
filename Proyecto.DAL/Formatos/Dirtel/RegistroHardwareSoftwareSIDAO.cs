using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroHardwareSoftwareSIDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroHardwareSoftwareSIDTO> ObtenerLista(int? CargaId = null)
        {
            List<RegistroHardwareSoftwareSIDTO> lista = new List<RegistroHardwareSoftwareSIDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroHardwareSoftwareSIListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroHardwareSoftwareSIDTO()
                        {
                            RegistroHardwareSoftwareSIId = Convert.ToInt32(dr["RegistroHardwareSoftwareSIId"]),
                            CodigoIBPHardwareSoftwareSI = dr["CodigoIBPHardwareSoftwareSI"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            AnioAdquisicionHardwareSoftwareSI = (dr["AnioAdquisicionHardwareSoftwareSI"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["DescDependencia"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroHardwareSoftwareSIRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPHardwareSoftwareSI", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPHardwareSoftwareSI"].Value = registroHardwareSoftwareSIDTO.CodigoIBPHardwareSoftwareSI;

                    cmd.Parameters.Add("@CodigoModeloBienServicioSubcampo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModeloBienServicioSubcampo "].Value = registroHardwareSoftwareSIDTO.CodigoModeloBienServicioSubcampo;

                    cmd.Parameters.Add("@CodigoModeloBienServicioDenominacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModeloBienServicioDenominacion "].Value = registroHardwareSoftwareSIDTO.CodigoModeloBienServicioDenominacion;

                    cmd.Parameters.Add("@CodigoMarca ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarca "].Value = registroHardwareSoftwareSIDTO.CodigoMarca;

                    cmd.Parameters.Add("@AnioAdquisicionHardwareSoftwareSI", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AnioAdquisicionHardwareSoftwareSI"].Value = registroHardwareSoftwareSIDTO.AnioAdquisicionHardwareSoftwareSI;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = registroHardwareSoftwareSIDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroHardwareSoftwareSIDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroHardwareSoftwareSIDTO.UsuarioIngresoRegistro;

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

        public RegistroHardwareSoftwareSIDTO BuscarFormato(int Codigo)
        {
            RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO = new RegistroHardwareSoftwareSIDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroHardwareSoftwareSIEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroHardwareSoftwareSIId", SqlDbType.Int);
                    cmd.Parameters["@RegistroHardwareSoftwareSIId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroHardwareSoftwareSIDTO.RegistroHardwareSoftwareSIId = Convert.ToInt32(dr["RegistroHardwareSoftwareSIId"]);
                        registroHardwareSoftwareSIDTO.CodigoIBPHardwareSoftwareSI = dr["CodigoIBPHardwareSoftwareSI"].ToString();
                        registroHardwareSoftwareSIDTO.CodigoModeloBienServicioSubcampo = dr["CodigoModeloBienServicioSubcampo "].ToString();
                        registroHardwareSoftwareSIDTO.CodigoModeloBienServicioDenominacion = dr["CodigoModeloBienServicioDenominacion "].ToString();
                        registroHardwareSoftwareSIDTO.CodigoMarca = dr["CodigoMarca "].ToString();
                        registroHardwareSoftwareSIDTO.AnioAdquisicionHardwareSoftwareSI = Convert.ToDateTime(dr["AnioAdquisicionHardwareSoftwareSI"]).ToString("yyy-MM-dd");
                        registroHardwareSoftwareSIDTO.CodigoDependencia = dr["CodigoDependencia "].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroHardwareSoftwareSIDTO;
        }

        public string ActualizaFormato(RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroHardwareSoftwareSIActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroHardwareSoftwareSIId", SqlDbType.Int);
                    cmd.Parameters["@RegistroHardwareSoftwareSIId"].Value = registroHardwareSoftwareSIDTO.RegistroHardwareSoftwareSIId;

                    cmd.Parameters.Add("@CodigoIBPHardwareSoftwareSI", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPHardwareSoftwareSI"].Value = registroHardwareSoftwareSIDTO.CodigoIBPHardwareSoftwareSI;

                    cmd.Parameters.Add("@CodigoModeloBienServicioSubcampo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModeloBienServicioSubcampo "].Value = registroHardwareSoftwareSIDTO.CodigoModeloBienServicioSubcampo;

                    cmd.Parameters.Add("@CodigoModeloBienServicioDenominacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModeloBienServicioDenominacion "].Value = registroHardwareSoftwareSIDTO.CodigoModeloBienServicioDenominacion;

                    cmd.Parameters.Add("@CodigoMarca ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMarca "].Value = registroHardwareSoftwareSIDTO.CodigoMarca;

                    cmd.Parameters.Add("@AnioAdquisicionHardwareSoftwareSI", SqlDbType.VarChar, 20);
                    cmd.Parameters["@AnioAdquisicionHardwareSoftwareSI"].Value = registroHardwareSoftwareSIDTO.AnioAdquisicionHardwareSoftwareSI;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = registroHardwareSoftwareSIDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroHardwareSoftwareSIDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroHardwareSoftwareSIEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroHardwareSoftwareSIId", SqlDbType.Int);
                    cmd.Parameters["@RegistroHardwareSoftwareSIId"].Value = registroHardwareSoftwareSIDTO.RegistroHardwareSoftwareSIId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroHardwareSoftwareSIDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.ExecuteNonQuery();

                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }
        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_RegistroHardwareSoftwareSIRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroHardwareSoftwareSI", SqlDbType.Structured);
                    cmd.Parameters["@RegistroHardwareSoftwareSI"].TypeName = "Formato.RegistroHardwareSoftwareSI";
                    cmd.Parameters["@RegistroHardwareSoftwareSI"].Value = datos;

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
