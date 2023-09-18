using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class EstudioContraintelPersonalExternoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EstudioContraintelPersonalExternoDTO> ObtenerLista(int? CargaId = null)
        {
            List<EstudioContraintelPersonalExternoDTO> lista = new List<EstudioContraintelPersonalExternoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonalExternoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstudioContraintelPersonalExternoDTO()
                        {
                            EstudioContrainteligenciaPersonalExternoId = Convert.ToInt32(dr["EstudioContrainteligenciaPersonalExternoId"]),
                            NombrePais = dr["NombrePais"].ToString(),
                            DescTipoVinculo = dr["DescTipoVinculo"].ToString(),
                            DescDependencia = dr["NombreDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            InvestigacionContrainteligenciaProducida = Convert.ToInt32(dr["InvestigacionContrainteligenciaProducida"]),
                            DescTipoEstudioContrainteligencia = dr["NombreDependencia"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonalExternoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumericoPais ", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumericoPais "].Value = estudioContraintelPersonalExternoDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoTipoVinculo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoVinculo "].Value = estudioContraintelPersonalExternoDTO.CodigoTipoVinculo;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = estudioContraintelPersonalExternoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval "].Value = estudioContraintelPersonalExternoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia "].Value = estudioContraintelPersonalExternoDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@InvestigacionContrainteligenciaProducida", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionContrainteligenciaProducida"].Value = estudioContraintelPersonalExternoDTO.InvestigacionContrainteligenciaProducida;

                    cmd.Parameters.Add("@CodigoTipoEstudioContrainteligencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEstudioContrainteligencia "].Value = estudioContraintelPersonalExternoDTO.CodigoTipoEstudioContrainteligencia;
                    
                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = estudioContraintelPersonalExternoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioContraintelPersonalExternoDTO.UsuarioIngresoRegistro;

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

        public EstudioContraintelPersonalExternoDTO BuscarFormato(int Codigo)
        {
            EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO = new EstudioContraintelPersonalExternoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonalExternoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonalExternoId", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaPersonalExternoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        estudioContraintelPersonalExternoDTO.EstudioContrainteligenciaPersonalExternoId = Convert.ToInt32(dr["EstudioContrainteligenciaPersonalExternoId"]);
                        estudioContraintelPersonalExternoDTO.NumericoPais = dr["NumericoPais"].ToString();
                        estudioContraintelPersonalExternoDTO.CodigoTipoVinculo = dr["CodigoTipoVinculo"].ToString();
                        estudioContraintelPersonalExternoDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        estudioContraintelPersonalExternoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        estudioContraintelPersonalExternoDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        estudioContraintelPersonalExternoDTO.InvestigacionContrainteligenciaProducida = Convert.ToInt32(dr["InvestigacionContrainteligenciaProducida"]);
                        estudioContraintelPersonalExternoDTO.CodigoTipoEstudioContrainteligencia = dr["CodigoTipoEstudioContrainteligencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estudioContraintelPersonalExternoDTO;
        }

        public string ActualizaFormato(EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonalExternoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonalExternoId", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaPersonalExternoId"].Value = estudioContraintelPersonalExternoDTO.EstudioContrainteligenciaPersonalExternoId;
                   
                    cmd.Parameters.Add("@NumericoPais ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais "].Value = estudioContraintelPersonalExternoDTO.NumericoPais;

                    cmd.Parameters.Add("@CodigoTipoVinculo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoVinculo "].Value = estudioContraintelPersonalExternoDTO.CodigoTipoVinculo;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = estudioContraintelPersonalExternoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval "].Value = estudioContraintelPersonalExternoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia "].Value = estudioContraintelPersonalExternoDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@InvestigacionContrainteligenciaProducida", SqlDbType.Int);
                    cmd.Parameters["@InvestigacionContrainteligenciaProducida"].Value = estudioContraintelPersonalExternoDTO.InvestigacionContrainteligenciaProducida;

                    cmd.Parameters.Add("@CodigoTipoEstudioContrainteligencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoEstudioContrainteligencia "].Value = estudioContraintelPersonalExternoDTO.CodigoTipoEstudioContrainteligencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioContraintelPersonalExternoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonalExternoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonalExternoId", SqlDbType.Int);
                    cmd.Parameters["@EstudioContrainteligenciaPersonalExternoId"].Value = estudioContraintelPersonalExternoDTO.EstudioContrainteligenciaPersonalExternoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioContraintelPersonalExternoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EstudioContrainteligenciaPersonalExternoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioContrainteligenciaPersonalExterno", SqlDbType.Structured);
                    cmd.Parameters["@EstudioContrainteligenciaPersonalExterno"].TypeName = "Formato.EstudioContrainteligenciaPersonalExterno";
                    cmd.Parameters["@EstudioContrainteligenciaPersonalExterno"].Value = datos;

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

