using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class PresenteRecordatorioInstitucionalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PresenteRecordatorioInstitucionalDTO> ObtenerLista(int? CargaId = null)
        {
            List<PresenteRecordatorioInstitucionalDTO> lista = new List<PresenteRecordatorioInstitucionalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PresenteRecordatorioInstitucionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PresenteRecordatorioInstitucionalDTO()
                        {
                            PresenteRecordatorioInstitucionalId = Convert.ToInt32(dr["PresenteRecordatorioInstitucionalId"]),
                            FechaAdquisicion = (dr["FechaAdquisicion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoPresenteProtocolar = dr["TipoPresenteProtocolarId"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]),
                            DescFrecuenciaDifusion = dr["DescFrecuenciaDifusion"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PresenteRecordatorioInstitucionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@FechaAdquisicion"].Value = presenteRecordatorioInstitucionalDTO.FechaAdquisicion;

                    cmd.Parameters.Add("@CodigoTipoPresenteProtocolar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPresenteProtocolar "].Value = presenteRecordatorioInstitucionalDTO.CodigoTipoPresenteProtocolar;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = presenteRecordatorioInstitucionalDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = presenteRecordatorioInstitucionalDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
                    cmd.Parameters["@CostoUnitario"].Value = presenteRecordatorioInstitucionalDTO.CostoUnitario;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = presenteRecordatorioInstitucionalDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = presenteRecordatorioInstitucionalDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = presenteRecordatorioInstitucionalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = presenteRecordatorioInstitucionalDTO.UsuarioIngresoRegistro;

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

        public PresenteRecordatorioInstitucionalDTO BuscarFormato(int Codigo)
        {
            PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO = new PresenteRecordatorioInstitucionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PresenteRecordatorioInstitucionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresenteRecordatorioInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@PresenteRecordatorioInstitucionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        presenteRecordatorioInstitucionalDTO.PresenteRecordatorioInstitucionalId = Convert.ToInt32(dr["PresenteRecordatorioInstitucionalId"]);
                        presenteRecordatorioInstitucionalDTO.FechaAdquisicion = Convert.ToDateTime(dr["FechaAdquisicion"]).ToString("yyy-MM-dd");
                        presenteRecordatorioInstitucionalDTO.CodigoTipoPresenteProtocolar = dr["CodigoTipoPresenteProtocolar"].ToString();
                        presenteRecordatorioInstitucionalDTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        presenteRecordatorioInstitucionalDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        presenteRecordatorioInstitucionalDTO.CostoUnitario = Convert.ToDecimal(dr["CostoUnitario"]);
                        presenteRecordatorioInstitucionalDTO.CodigoFrecuenciaDifusion = dr["CodigoFrecuenciaDifusion"].ToString();
                        presenteRecordatorioInstitucionalDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return presenteRecordatorioInstitucionalDTO;
        }

        public string ActualizaFormato(PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PresenteRecordatorioInstitucionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresenteRecordatorioInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@PresenteRecordatorioInstitucionalId"].Value = presenteRecordatorioInstitucionalDTO.PresenteRecordatorioInstitucionalId;

                    cmd.Parameters.Add("@FechaAdquisicion", SqlDbType.Date);
                    cmd.Parameters["@FechaAdquisicion"].Value = presenteRecordatorioInstitucionalDTO.FechaAdquisicion;

                    cmd.Parameters.Add("@CodigoTipoPresenteProtocolar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPresenteProtocolar "].Value = presenteRecordatorioInstitucionalDTO.CodigoTipoPresenteProtocolar;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = presenteRecordatorioInstitucionalDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = presenteRecordatorioInstitucionalDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
                    cmd.Parameters["@CostoUnitario"].Value = presenteRecordatorioInstitucionalDTO.CostoUnitario;

                    cmd.Parameters.Add("@CodigoFrecuenciaDifusion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFrecuenciaDifusion "].Value = presenteRecordatorioInstitucionalDTO.CodigoFrecuenciaDifusion;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = presenteRecordatorioInstitucionalDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = presenteRecordatorioInstitucionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PresenteRecordatorioInstitucionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresenteRecordatorioInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@PresenteRecordatorioInstitucionalId"].Value = presenteRecordatorioInstitucionalDTO.PresenteRecordatorioInstitucionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = presenteRecordatorioInstitucionalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_PresenteRecordatorioInstitucionalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PresenteRecordatorioInstitucional", SqlDbType.Structured);
                    cmd.Parameters["@PresenteRecordatorioInstitucional"].TypeName = "Formato.PresenteRecordatorioInstitucional";
                    cmd.Parameters["@PresenteRecordatorioInstitucional"].Value = datos;

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



