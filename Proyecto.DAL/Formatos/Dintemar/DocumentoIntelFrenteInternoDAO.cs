using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class DocumentoIntelFrenteInternoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DocumentoIntelFrenteInternoDTO> ObtenerLista(int? CargaId = null)
        {
            List<DocumentoIntelFrenteInternoDTO> lista = new List<DocumentoIntelFrenteInternoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteInternoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DocumentoIntelFrenteInternoDTO()
                        {
                            DocumentoInteligenciaFrenteInternoId = Convert.ToInt32(dr["DocumentoInteligenciaFrenteInternoId"]),
                            DescMes = dr["DescMes"].ToString(),
                            AnioDocumentoFrenteInterno = Convert.ToInt32(dr["AnioDocumentoFrenteInterno"]),
                            DescDependencia = dr["NombreDependencia"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            NotaInformacionProducidoFI = Convert.ToInt32(dr["NotaInformacionProducidoFI"]),
                            NotaInteligenciaFI = Convert.ToInt32(dr["NotaInteligenciaFI"]),
                            ApreciacionInteligenciaFI = Convert.ToInt32(dr["ApreciacionInteligenciaFI"]),
                            ResumenMensualInteligenciaFI = Convert.ToInt32(dr["ResumenMensualInteligenciaFI"]),
                            EstudioInteligenciaFI = Convert.ToInt32(dr["EstudioInteligenciaFI"]),
                            BoletinInformacionFI = Convert.ToInt32(dr["BoletinInformacionFI"]),
                            OtrosEspecificarFI = Convert.ToInt32(dr["OtrosEspecificarFI"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteInternoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = documentoIntelFrenteInternoDTO.MesId;

                    cmd.Parameters.Add("@AnioDocumentoFrenteInterno", SqlDbType.Int);
                    cmd.Parameters["@AnioDocumentoFrenteInterno"].Value = documentoIntelFrenteInternoDTO.AnioDocumentoFrenteInterno;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = documentoIntelFrenteInternoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = documentoIntelFrenteInternoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@NotaInformacionProducidoFI", SqlDbType.Int);
                    cmd.Parameters["@NotaInformacionProducidoFI"].Value = documentoIntelFrenteInternoDTO.NotaInformacionProducidoFI;

                    cmd.Parameters.Add("@NotaInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@NotaInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.NotaInteligenciaFI;

                    cmd.Parameters.Add("@ApreciacionInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.ApreciacionInteligenciaFI;

                    cmd.Parameters.Add("@ResumenMensualInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@ResumenMensualInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.ResumenMensualInteligenciaFI;

                    cmd.Parameters.Add("@EstudioInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@EstudioInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.EstudioInteligenciaFI;

                    cmd.Parameters.Add("@BoletinInformacionFI", SqlDbType.Int);
                    cmd.Parameters["@BoletinInformacionFI"].Value = documentoIntelFrenteInternoDTO.BoletinInformacionFI;

                    cmd.Parameters.Add("@OtrosEspecificarFI", SqlDbType.Int);
                    cmd.Parameters["@OtrosEspecificarFI"].Value = documentoIntelFrenteInternoDTO.OtrosEspecificarFI;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = documentoIntelFrenteInternoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = documentoIntelFrenteInternoDTO.UsuarioIngresoRegistro;

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

        public DocumentoIntelFrenteInternoDTO BuscarFormato(int Codigo)
        {
            DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO = new DocumentoIntelFrenteInternoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteInternoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteInternoId", SqlDbType.Int);
                    cmd.Parameters["@DocumentoInteligenciaFrenteInternoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        documentoIntelFrenteInternoDTO.DocumentoInteligenciaFrenteInternoId = Convert.ToInt32(dr["DocumentoInteligenciaFrenteInternoId"]);
                        documentoIntelFrenteInternoDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        documentoIntelFrenteInternoDTO.AnioDocumentoFrenteInterno = Convert.ToInt32(dr["AnioDocumentoFrenteInterno"]);
                        documentoIntelFrenteInternoDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        documentoIntelFrenteInternoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        documentoIntelFrenteInternoDTO.NotaInformacionProducidoFI = Convert.ToInt32(dr["NotaInformacionProducidoFI"]);
                        documentoIntelFrenteInternoDTO.NotaInteligenciaFI = Convert.ToInt32(dr["NotaInteligenciaFI"]);
                        documentoIntelFrenteInternoDTO.ApreciacionInteligenciaFI = Convert.ToInt32(dr["ApreciacionInteligenciaFI"]);
                        documentoIntelFrenteInternoDTO.ResumenMensualInteligenciaFI = Convert.ToInt32(dr["ResumenMensualInteligenciaFI"]);
                        documentoIntelFrenteInternoDTO.EstudioInteligenciaFI = Convert.ToInt32(dr["EstudioInteligenciaFI"]);
                        documentoIntelFrenteInternoDTO.BoletinInformacionFI = Convert.ToInt32(dr["BoletinInformacionFI"]);
                        documentoIntelFrenteInternoDTO.OtrosEspecificarFI = Convert.ToInt32(dr["OtrosEspecificarFI"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return documentoIntelFrenteInternoDTO;
        }

        public string ActualizaFormato(DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteInternoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteInternoId", SqlDbType.Int);
                    cmd.Parameters["@DocumentoInteligenciaFrenteInternoId"].Value = documentoIntelFrenteInternoDTO.DocumentoInteligenciaFrenteInternoId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = documentoIntelFrenteInternoDTO.MesId;

                    cmd.Parameters.Add("@AnioDocumentoFrenteInterno", SqlDbType.Int);
                    cmd.Parameters["@AnioDocumentoFrenteInterno"].Value = documentoIntelFrenteInternoDTO.AnioDocumentoFrenteInterno;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = documentoIntelFrenteInternoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = documentoIntelFrenteInternoDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@NotaInformacionProducidoFI", SqlDbType.Int);
                    cmd.Parameters["@NotaInformacionProducidoFI"].Value = documentoIntelFrenteInternoDTO.NotaInformacionProducidoFI;

                    cmd.Parameters.Add("@NotaInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@NotaInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.NotaInteligenciaFI;

                    cmd.Parameters.Add("@ApreciacionInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@ApreciacionInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.ApreciacionInteligenciaFI;

                    cmd.Parameters.Add("@ResumenMensualInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@ResumenMensualInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.ResumenMensualInteligenciaFI;

                    cmd.Parameters.Add("@EstudioInteligenciaFI", SqlDbType.Int);
                    cmd.Parameters["@EstudioInteligenciaFI"].Value = documentoIntelFrenteInternoDTO.EstudioInteligenciaFI;

                    cmd.Parameters.Add("@BoletinInformacionFI", SqlDbType.Int);
                    cmd.Parameters["@BoletinInformacionFI"].Value = documentoIntelFrenteInternoDTO.BoletinInformacionFI;

                    cmd.Parameters.Add("@OtrosEspecificarFI", SqlDbType.Int);
                    cmd.Parameters["@OtrosEspecificarFI"].Value = documentoIntelFrenteInternoDTO.OtrosEspecificarFI;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = documentoIntelFrenteInternoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteInternoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteInternoId", SqlDbType.Int);
                    cmd.Parameters["@DocumentoInteligenciaFrenteInternoId"].Value = documentoIntelFrenteInternoDTO.DocumentoInteligenciaFrenteInternoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = documentoIntelFrenteInternoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DocumentoInteligenciaFrenteInternoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocumentoInteligenciaFrenteInterno", SqlDbType.Structured);
                    cmd.Parameters["@DocumentoInteligenciaFrenteInterno"].TypeName = "Formato.DocumentoInteligenciaFrenteInterno";
                    cmd.Parameters["@DocumentoInteligenciaFrenteInterno"].Value = datos;

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
