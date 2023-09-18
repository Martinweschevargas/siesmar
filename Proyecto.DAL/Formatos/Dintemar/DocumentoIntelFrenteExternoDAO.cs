using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class DocumentoIntelFrenteExternoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DocumentoIntelFrenteExternoDTO> ObtenerLista(int? CargaId = null)
        {
            List<DocumentoIntelFrenteExternoDTO> lista = new List<DocumentoIntelFrenteExternoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteExternoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DocumentoIntelFrenteExternoDTO()
                        {
                            DocumentoInteligenciaFrenteExternoId = Convert.ToInt32(dr["DocumentoInteligenciaFrenteExternoId"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioDocumentoFrenteExterno = Convert.ToInt32(dr["AnioDocumentoFrenteExterno"]),
                            DescDependencia = dr["NombreDependencia,"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            NotaInformacionProducidasFE = Convert.ToInt32(dr["NotaInformacionProducidasFE"]),
                            NotaInteligenciaFE = Convert.ToInt32(dr["NotaInteligenciaFE"]),
                            ApreciacionInteligenciaFE = Convert.ToInt32(dr["ApreciacionInteligenciaFE"]),
                            ResumenMensualInteligenciaFE = Convert.ToInt32(dr["ResumenMensualInteligenciaFE"]),
                            EstudioInteligenciaFE = Convert.ToInt32(dr["EstudioInteligenciaFE"]),
                            BoletinInformacionFE = Convert.ToInt32(dr["BoletinInformacionFE"]),
                            OtrosEspecificarFE = Convert.ToInt32(dr["OtrosEspecificarFE"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteExternoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = documentoIntelFrenteExternoDTO.MesId;

                    cmd.Parameters.Add("@AnioDocumentoFrenteExterno", SqlDbType.Int);
                    cmd.Parameters["@AnioDocumentoFrenteExterno"].Value = documentoIntelFrenteExternoDTO.AnioDocumentoFrenteExterno;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = documentoIntelFrenteExternoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = documentoIntelFrenteExternoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = documentoIntelFrenteExternoDTO.NumericoPais;

                    cmd.Parameters.Add("@NotaInformacionProducidasFE", SqlDbType.Int);
                    cmd.Parameters["@NotaInformacionProducidasFE"].Value = documentoIntelFrenteExternoDTO.NotaInformacionProducidasFE;

                    cmd.Parameters.Add("@NotaInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@NotaInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.NotaInteligenciaFE;

                    cmd.Parameters.Add("@ApreciacionInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.ApreciacionInteligenciaFE;

                    cmd.Parameters.Add("@ResumenMensualInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@ResumenMensualInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.ResumenMensualInteligenciaFE;

                    cmd.Parameters.Add("@EstudioInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@EstudioInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.EstudioInteligenciaFE;

                    cmd.Parameters.Add("@BoletinInformacionFE", SqlDbType.Int);
                    cmd.Parameters["@BoletinInformacionFE"].Value = documentoIntelFrenteExternoDTO.BoletinInformacionFE;

                    cmd.Parameters.Add("@OtrosEspecificarFE", SqlDbType.Int);
                    cmd.Parameters["@OtrosEspecificarFE"].Value = documentoIntelFrenteExternoDTO.OtrosEspecificarFE;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = documentoIntelFrenteExternoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = documentoIntelFrenteExternoDTO.UsuarioIngresoRegistro;

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

        public DocumentoIntelFrenteExternoDTO BuscarFormato(int Codigo)
        {
            DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO = new DocumentoIntelFrenteExternoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteExternoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteExternoId", SqlDbType.Int);
                    cmd.Parameters["@DocumentoInteligenciaFrenteExternoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        documentoIntelFrenteExternoDTO.DocumentoInteligenciaFrenteExternoId = Convert.ToInt32(dr["DocumentoInteligenciaFrenteExternoId"]);
                        documentoIntelFrenteExternoDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        documentoIntelFrenteExternoDTO.AnioDocumentoFrenteExterno = Convert.ToInt32(dr["AnioDocumentoFrenteExterno"]);
                        documentoIntelFrenteExternoDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        documentoIntelFrenteExternoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        documentoIntelFrenteExternoDTO.NumericoPais = dr["NumericoPais"].ToString();
                        documentoIntelFrenteExternoDTO.NotaInformacionProducidasFE = Convert.ToInt32(dr["NotaInformacionProducidasFE"]);
                        documentoIntelFrenteExternoDTO.NotaInteligenciaFE = Convert.ToInt32(dr["NotaInteligenciaFE"]);
                        documentoIntelFrenteExternoDTO.ApreciacionInteligenciaFE = Convert.ToInt32(dr["ApreciacionInteligenciaFE"]);
                        documentoIntelFrenteExternoDTO.ResumenMensualInteligenciaFE = Convert.ToInt32(dr["ResumenMensualInteligenciaFE"]);
                        documentoIntelFrenteExternoDTO.EstudioInteligenciaFE = Convert.ToInt32(dr["EstudioInteligenciaFE"]);
                        documentoIntelFrenteExternoDTO.BoletinInformacionFE = Convert.ToInt32(dr["BoletinInformacionFE"]);
                        documentoIntelFrenteExternoDTO.OtrosEspecificarFE = Convert.ToInt32(dr["OtrosEspecificarFE"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return documentoIntelFrenteExternoDTO;
        }

        public string ActualizaFormato(DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteExternoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteExternoId", SqlDbType.Int);
                    cmd.Parameters["@DocumentoInteligenciaFrenteExternoId"].Value = documentoIntelFrenteExternoDTO.DocumentoInteligenciaFrenteExternoId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = documentoIntelFrenteExternoDTO.MesId;

                    cmd.Parameters.Add("@AnioDocumentoFrenteExterno", SqlDbType.Int);
                    cmd.Parameters["@AnioDocumentoFrenteExterno"].Value = documentoIntelFrenteExternoDTO.AnioDocumentoFrenteExterno;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = documentoIntelFrenteExternoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = documentoIntelFrenteExternoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@NumericoPais", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumericoPais"].Value = documentoIntelFrenteExternoDTO.NumericoPais;

                    cmd.Parameters.Add("@NotaInformacionProducidasFE", SqlDbType.Int);
                    cmd.Parameters["@NotaInformacionProducidasFE"].Value = documentoIntelFrenteExternoDTO.NotaInformacionProducidasFE;

                    cmd.Parameters.Add("@NotaInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@NotaInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.NotaInteligenciaFE;

                    cmd.Parameters.Add("@ApreciacionInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.ApreciacionInteligenciaFE;

                    cmd.Parameters.Add("@ResumenMensualInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@ResumenMensualInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.ResumenMensualInteligenciaFE;

                    cmd.Parameters.Add("@EstudioInteligenciaFE", SqlDbType.Int);
                    cmd.Parameters["@EstudioInteligenciaFE"].Value = documentoIntelFrenteExternoDTO.EstudioInteligenciaFE;

                    cmd.Parameters.Add("@BoletinInformacionFE", SqlDbType.Int);
                    cmd.Parameters["@BoletinInformacionFE"].Value = documentoIntelFrenteExternoDTO.BoletinInformacionFE;

                    cmd.Parameters.Add("@OtrosEspecificarFE", SqlDbType.Int);
                    cmd.Parameters["@OtrosEspecificarFE"].Value = documentoIntelFrenteExternoDTO.OtrosEspecificarFE;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = documentoIntelFrenteExternoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteExternoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteExternoId", SqlDbType.Int);
                    cmd.Parameters["@DocumentoInteligenciaFrenteExternoId"].Value = documentoIntelFrenteExternoDTO.DocumentoInteligenciaFrenteExternoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = documentoIntelFrenteExternoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteExternoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteExterno", SqlDbType.Structured);
                    cmd.Parameters["@DocumentoInteligenciaFrenteExterno"].TypeName = "Formato.DocumentoInteligenciaFrenteExterno";
                    cmd.Parameters["@DocumentoInteligenciaFrenteExterno"].Value = datos;

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
