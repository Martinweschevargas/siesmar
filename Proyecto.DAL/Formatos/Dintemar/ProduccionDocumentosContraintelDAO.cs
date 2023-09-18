using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class ProduccionDocumentosContraintelDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ProduccionDocumentosContraintelDTO> ObtenerLista(int? CargaId = null)
        {
            List<ProduccionDocumentosContraintelDTO> lista = new List<ProduccionDocumentosContraintelDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ProduccionDocumentosContrainteligenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProduccionDocumentosContraintelDTO()
                        {
                            ProduccionDocumentosContrainteligenciaId = Convert.ToInt32(dr["ProduccionDocumentosContrainteligenciaId"]),
                            DescMes =  dr["DescMes"].ToString(),
                            AnioProduccionDocumento = Convert.ToInt32(dr["AnioProduccionDocumento"]),
                            DescDependencia =  dr["DescDependencia"].ToString(),
                            DescComandanciaDependencia =  dr["DescComandanciaDependencia"].ToString(),
                            DescZonaNaval =  dr["DescZonaNaval"].ToString(),
                            NotasInformacionContrainteligencia = Convert.ToInt32(dr["NotasInformacionContrainteligencia"]),
                            NotasContrainteligenciaProducidas = Convert.ToInt32(dr["NotasContrainteligenciaProducidas"]),
                            ApreciacionesContrainteligenciaProducida = Convert.ToInt32(dr["ApreciacionesContrainteligenciaProducida"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProduccionDocumentosContrainteligenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = produccionDocumentosContraintelDTO.MesId;

                    cmd.Parameters.Add("@AnioProduccionDocumento", SqlDbType.Int);
                    cmd.Parameters["@AnioProduccionDocumento"].Value = produccionDocumentosContraintelDTO.AnioProduccionDocumento;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = produccionDocumentosContraintelDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia  ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia "].Value = produccionDocumentosContraintelDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval "].Value = produccionDocumentosContraintelDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@NotasInformacionContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@NotasInformacionContrainteligencia"].Value = produccionDocumentosContraintelDTO.NotasInformacionContrainteligencia;

                    cmd.Parameters.Add("@NotasContrainteligenciaProducidas", SqlDbType.Int);
                    cmd.Parameters["@NotasContrainteligenciaProducidas"].Value = produccionDocumentosContraintelDTO.NotasContrainteligenciaProducidas;

                    cmd.Parameters.Add("@ApreciacionesContrainteligenciaProducida", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionesContrainteligenciaProducida"].Value = produccionDocumentosContraintelDTO.ApreciacionesContrainteligenciaProducida;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = produccionDocumentosContraintelDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = produccionDocumentosContraintelDTO.UsuarioIngresoRegistro;

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

        public ProduccionDocumentosContraintelDTO BuscarFormato(int Codigo)
        {
            ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO = new ProduccionDocumentosContraintelDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProduccionDocumentosContrainteligenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProduccionDocumentosContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@ProduccionDocumentosContrainteligenciaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        produccionDocumentosContraintelDTO.ProduccionDocumentosContrainteligenciaId = Convert.ToInt32(dr["ProduccionDocumentosContrainteligenciaId"]);
                        produccionDocumentosContraintelDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        produccionDocumentosContraintelDTO.AnioProduccionDocumento = Convert.ToInt32(dr["AnioProduccionDocumento"]);
                        produccionDocumentosContraintelDTO.CodigoDependencia = dr["CodigoDependencia "].ToString();
                        produccionDocumentosContraintelDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia "].ToString();
                        produccionDocumentosContraintelDTO.CodigoZonaNaval = dr["CodigoZonaNaval "].ToString();
                        produccionDocumentosContraintelDTO.NotasInformacionContrainteligencia = Convert.ToInt32(dr["NotasInformacionContrainteligencia"]);
                        produccionDocumentosContraintelDTO.NotasContrainteligenciaProducidas = Convert.ToInt32(dr["NotasContrainteligenciaProducidas"]);
                        produccionDocumentosContraintelDTO.ApreciacionesContrainteligenciaProducida = Convert.ToInt32(dr["ApreciacionesContrainteligenciaProducida"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return produccionDocumentosContraintelDTO;
        }

        public string ActualizaFormato(ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProduccionDocumentosContrainteligenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProduccionDocumentosContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@ProduccionDocumentosContrainteligenciaId"].Value = produccionDocumentosContraintelDTO.ProduccionDocumentosContrainteligenciaId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = produccionDocumentosContraintelDTO.MesId;

                    cmd.Parameters.Add("@AnioProduccionDocumento", SqlDbType.Int);
                    cmd.Parameters["@AnioProduccionDocumento"].Value = produccionDocumentosContraintelDTO.AnioProduccionDocumento;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = produccionDocumentosContraintelDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia  ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia "].Value = produccionDocumentosContraintelDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval "].Value = produccionDocumentosContraintelDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@NotasInformacionContrainteligencia", SqlDbType.Int);
                    cmd.Parameters["@NotasInformacionContrainteligencia"].Value = produccionDocumentosContraintelDTO.NotasInformacionContrainteligencia;

                    cmd.Parameters.Add("@NotasContrainteligenciaProducidas", SqlDbType.Int);
                    cmd.Parameters["@NotasContrainteligenciaProducidas"].Value = produccionDocumentosContraintelDTO.NotasContrainteligenciaProducidas;

                    cmd.Parameters.Add("@ApreciacionesContrainteligenciaProducida", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionesContrainteligenciaProducida"].Value = produccionDocumentosContraintelDTO.ApreciacionesContrainteligenciaProducida;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = produccionDocumentosContraintelDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProduccionDocumentosContrainteligenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProduccionDocumentosContrainteligenciaId", SqlDbType.Int);
                    cmd.Parameters["@ProduccionDocumentosContrainteligenciaId"].Value = produccionDocumentosContraintelDTO.ProduccionDocumentosContrainteligenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = produccionDocumentosContraintelDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ProduccionDocumentosContrainteligenciaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProduccionDocumentosContrainteligencia", SqlDbType.Structured);
                    cmd.Parameters["@ProduccionDocumentosContrainteligencia"].TypeName = "Formato.ProduccionDocumentosContrainteligencia";
                    cmd.Parameters["@ProduccionDocumentosContrainteligencia"].Value = datos;

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