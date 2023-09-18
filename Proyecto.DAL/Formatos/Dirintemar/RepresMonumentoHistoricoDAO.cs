using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class RepresMonumentoHistoricoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RepresMonumentoHistoricoDTO> ObtenerLista()
        {
            List<RepresMonumentoHistoricoDTO> lista = new List<RepresMonumentoHistoricoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RepresMonumentoHistoricoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new RepresMonumentoHistoricoDTO()
                        {
                            RepresMonumentoHistoricoId = Convert.ToInt32(dr["RepresMonumentoHistoricoId"]),
                            DescTipoRepresentacionBienHistorico = dr["DescTipoRepresentacionBienHistorico"].ToString(),
                            DenominacionRepresMonumentoHistorico = dr["DenominacionRepresMonumentoHistorico"].ToString(),
                            DescTipoMaterialBienHistorico = dr["DescTipoMaterialBienHistorico"].ToString(),
                            EstadoConservacion = dr["EstadoConservacion"].ToString(),
                            NombreEscultor = dr["NombreEscultor"].ToString(),
                            FechaEntregaInaguracion = (dr["FechaEntregaInaguracion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            UbicacionRepresentacion = dr["UbicacionRepresentacion"].ToString(),
                            Distrito = dr["DescDistrito"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            Pais = dr["NombrePais"].ToString(),
                            CustorioMonumentoHistorico = dr["CustorioMonumentoHistorico"].ToString(),
                            ReferenciaMonumentoHistorico = dr["ReferenciaMonumentoHistorico"].ToString(),
                            InversionMonumentoHistorico = Convert.ToDecimal(dr["InversionMonumentoHistorico"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RepresMonumentoHistoricoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoRepresentacionBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoRepresentacionBienHistoricoId"].Value = represMonumentoHistoricoDTO.TipoRepresentacionBienHistoricoId;

                    cmd.Parameters.Add("@DenominacionRepresMonumentoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DenominacionRepresMonumentoHistorico"].Value = represMonumentoHistoricoDTO.DenominacionRepresMonumentoHistorico;

                    cmd.Parameters.Add("@TipoMaterialBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialBienHistoricoId"].Value = represMonumentoHistoricoDTO.TipoMaterialBienHistoricoId;

                    cmd.Parameters.Add("@EstadoConservacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@EstadoConservacion"].Value = represMonumentoHistoricoDTO.EstadoConservacion;

                    cmd.Parameters.Add("@NombreEscultor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreEscultor"].Value = represMonumentoHistoricoDTO.NombreEscultor;

                    cmd.Parameters.Add("@FechaEntregaInaguracion", SqlDbType.Date);
                    cmd.Parameters["@FechaEntregaInaguracion"].Value = represMonumentoHistoricoDTO.FechaEntregaInaguracion;

                    cmd.Parameters.Add("@UbicacionRepresentacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UbicacionRepresentacion"].Value = represMonumentoHistoricoDTO.UbicacionRepresentacion;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = represMonumentoHistoricoDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CustorioMonumentoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CustorioMonumentoHistorico"].Value = represMonumentoHistoricoDTO.CustorioMonumentoHistorico;

                    cmd.Parameters.Add("@ReferenciaMonumentoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ReferenciaMonumentoHistorico"].Value = represMonumentoHistoricoDTO.ReferenciaMonumentoHistorico;

                    cmd.Parameters.Add("@InversionMonumentoHistorico", SqlDbType.Decimal);
                    cmd.Parameters["@InversionMonumentoHistorico"].Value = represMonumentoHistoricoDTO.InversionMonumentoHistorico;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = represMonumentoHistoricoDTO.UsuarioIngresoRegistro;

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

        public RepresMonumentoHistoricoDTO BuscarFormato(int Codigo)
        {
            RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO = new RepresMonumentoHistoricoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RepresMonumentoHistoricoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepresMonumentoHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@RepresMonumentoHistoricoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        represMonumentoHistoricoDTO.RepresMonumentoHistoricoId = Convert.ToInt32(dr["RepresMonumentoHistoricoId"]);
                        represMonumentoHistoricoDTO.TipoRepresentacionBienHistoricoId = Convert.ToInt32(dr["TipoRepresentacionBienHistoricoId"]);
                        represMonumentoHistoricoDTO.DenominacionRepresMonumentoHistorico = dr["DenominacionRepresMonumentoHistorico"].ToString();
                        represMonumentoHistoricoDTO.TipoMaterialBienHistoricoId = Convert.ToInt32(dr["TipoMaterialBienHistoricoId"]);
                        represMonumentoHistoricoDTO.EstadoConservacion = dr["EstadoConservacion"].ToString();
                        represMonumentoHistoricoDTO.NombreEscultor = dr["NombreEscultor"].ToString();
                        represMonumentoHistoricoDTO.FechaEntregaInaguracion = Convert.ToDateTime(dr["FechaEntregaInaguracion"]).ToString("yyy-MM-dd");
                        represMonumentoHistoricoDTO.UbicacionRepresentacion = dr["UbicacionRepresentacion"].ToString();
                        represMonumentoHistoricoDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
    
                        represMonumentoHistoricoDTO.CustorioMonumentoHistorico = dr["CustorioMonumentoHistorico"].ToString();
                        represMonumentoHistoricoDTO.ReferenciaMonumentoHistorico = dr["ReferenciaMonumentoHistorico"].ToString();
                        represMonumentoHistoricoDTO.InversionMonumentoHistorico = Convert.ToDecimal(dr["InversionMonumentoHistorico"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return represMonumentoHistoricoDTO;
        }

        public string ActualizaFormato(RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RepresMonumentoHistoricoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepresMonumentoHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@RepresMonumentoHistoricoId"].Value = represMonumentoHistoricoDTO.RepresMonumentoHistoricoId;

                    cmd.Parameters.Add("@TipoRepresentacionBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoRepresentacionBienHistoricoId"].Value = represMonumentoHistoricoDTO.TipoRepresentacionBienHistoricoId;

                    cmd.Parameters.Add("@DenominacionRepresMonumentoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DenominacionRepresMonumentoHistorico"].Value = represMonumentoHistoricoDTO.DenominacionRepresMonumentoHistorico;

                    cmd.Parameters.Add("@TipoMaterialBienHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@TipoMaterialBienHistoricoId"].Value = represMonumentoHistoricoDTO.TipoMaterialBienHistoricoId;

                    cmd.Parameters.Add("@EstadoConservacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@EstadoConservacion"].Value = represMonumentoHistoricoDTO.EstadoConservacion;

                    cmd.Parameters.Add("@NombreEscultor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreEscultor"].Value = represMonumentoHistoricoDTO.NombreEscultor;

                    cmd.Parameters.Add("@FechaEntregaInaguracion", SqlDbType.Date);
                    cmd.Parameters["@FechaEntregaInaguracion"].Value = represMonumentoHistoricoDTO.FechaEntregaInaguracion;

                    cmd.Parameters.Add("@UbicacionRepresentacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UbicacionRepresentacion"].Value = represMonumentoHistoricoDTO.UbicacionRepresentacion;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = represMonumentoHistoricoDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CustorioMonumentoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CustorioMonumentoHistorico"].Value = represMonumentoHistoricoDTO.CustorioMonumentoHistorico;

                    cmd.Parameters.Add("@ReferenciaMonumentoHistorico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ReferenciaMonumentoHistorico"].Value = represMonumentoHistoricoDTO.ReferenciaMonumentoHistorico;

                    cmd.Parameters.Add("@InversionMonumentoHistorico", SqlDbType.Decimal);
                    cmd.Parameters["@InversionMonumentoHistorico"].Value = represMonumentoHistoricoDTO.InversionMonumentoHistorico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = represMonumentoHistoricoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RepresMonumentoHistoricoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepresMonumentoHistoricoId", SqlDbType.Int);
                    cmd.Parameters["@RepresMonumentoHistoricoId"].Value = represMonumentoHistoricoDTO.RepresMonumentoHistoricoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = represMonumentoHistoricoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RepresMonumentoHistoricoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RepresMonumentoHistorico", SqlDbType.Structured);
                    cmd.Parameters["@RepresMonumentoHistorico"].TypeName = "Formato.RepresMonumentoHistorico";
                    cmd.Parameters["@RepresMonumentoHistorico"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                    cmd.Parameters["@R_Mes"].Value = DateTime.Now.Month.ToString();

                    cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                    cmd.Parameters["@R_Anio"].Value = DateTime.Now.Year.ToString();

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
