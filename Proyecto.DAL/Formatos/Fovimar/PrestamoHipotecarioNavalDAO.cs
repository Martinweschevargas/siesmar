using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Fovimar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Fovimar
{
    public class PrestamoHipotecarioNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<PrestamoHipotecarioNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<PrestamoHipotecarioNavalDTO> lista = new List<PrestamoHipotecarioNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_PrestamoHipotecarioNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PrestamoHipotecarioNavalDTO()
                        {
                            PrestamoHipotecarioNavalId = Convert.ToInt32(dr["PrestamoHipotecarioNavalId"]),
                            DNIPersonalNaval = dr["DNIPersonalNaval"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescSituacionPersonalNaval = dr["DescSituacionPersonalNaval"].ToString(),
                            MontoPrestadoOtorgado = Convert.ToDecimal(dr["MontoPrestadoOtorgado"]),
                            DescMoneda = dr["DescMoneda"].ToString(),
                            NroCuota = Convert.ToInt32(dr["NroCuota"]),
                            DescModalidadPrestamo = dr["DescModalidadPrestamo"].ToString(),
                            DescFinalidadPrestamo = dr["DescFinalidadPrestamo"].ToString(),
                            DescEntidadFinanciera = dr["DescEntidadFinanciera"].ToString(),
                            RentabilidadFinanciera = Convert.ToDecimal(dr["RentabilidadFinanciera"]),
                            DescProyectoFovimar = dr["DescProyectoFovimar"].ToString(),
                            GarantiaConstituida = dr["GarantiaConstituida"].ToString(),
                            CuotaPagada = Convert.ToInt32(dr["CuotaPagada"]),
                            EstadoDeuda = dr["EstadoDeuda"].ToString(),
                            MontoMorosidad = Convert.ToDecimal(dr["MontoMorosidad"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PrestamoHipotecarioNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIPersonalNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@DNIPersonalNaval"].Value = prestamoHipotecarioNavalDTO.DNIPersonalNaval;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = prestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = prestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@MontoPrestadoOtorgado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoPrestadoOtorgado"].Value = prestamoHipotecarioNavalDTO.MontoPrestadoOtorgado;

                    cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMoneda"].Value = prestamoHipotecarioNavalDTO.CodigoMoneda;

                    cmd.Parameters.Add("@NroCuota", SqlDbType.Int);
                    cmd.Parameters["@NroCuota"].Value = prestamoHipotecarioNavalDTO.NroCuota;

                    cmd.Parameters.Add("@CodigoModalidadPrestamo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoModalidadPrestamo"].Value = prestamoHipotecarioNavalDTO.CodigoModalidadPrestamo;

                    cmd.Parameters.Add("@CodigoFinalidadPrestamo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoFinalidadPrestamo"].Value = prestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = prestamoHipotecarioNavalDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@RentabilidadFinanciera", SqlDbType.Decimal);
                    cmd.Parameters["@RentabilidadFinanciera"].Value = prestamoHipotecarioNavalDTO.RentabilidadFinanciera;

                    cmd.Parameters.Add("@CodigoProyectoFovimar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoProyectoFovimar"].Value = prestamoHipotecarioNavalDTO.CodigoProyectoFovimar;

                    cmd.Parameters.Add("@GarantiaConstituida", SqlDbType.VarChar,1);
                    cmd.Parameters["@GarantiaConstituida"].Value = prestamoHipotecarioNavalDTO.GarantiaConstituida;

                    cmd.Parameters.Add("@CuotaPagada", SqlDbType.Int);
                    cmd.Parameters["@CuotaPagada"].Value = prestamoHipotecarioNavalDTO.CuotaPagada;

                    cmd.Parameters.Add("@EstadoDeuda", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoDeuda"].Value = prestamoHipotecarioNavalDTO.EstadoDeuda;

                    cmd.Parameters.Add("@MontoMorosidad", SqlDbType.Decimal);
                    cmd.Parameters["@MontoMorosidad"].Value = prestamoHipotecarioNavalDTO.MontoMorosidad;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = prestamoHipotecarioNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public PrestamoHipotecarioNavalDTO BuscarFormato(int Codigo)
        {
            PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO = new PrestamoHipotecarioNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PrestamoHipotecarioNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PrestamoHipotecarioNavalId", SqlDbType.Int);
                    cmd.Parameters["@PrestamoHipotecarioNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        prestamoHipotecarioNavalDTO.PrestamoHipotecarioNavalId = Convert.ToInt32(dr["PrestamoHipotecarioNavalId"]);
                        prestamoHipotecarioNavalDTO.DNIPersonalNaval = dr["DNIPersonalNaval"].ToString();
                        prestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        prestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval = dr["CodigoSituacionPersonalNaval"].ToString();
                        prestamoHipotecarioNavalDTO.MontoPrestadoOtorgado = Convert.ToDecimal(dr["MontoPrestadoOtorgado"]);
                        prestamoHipotecarioNavalDTO.CodigoMoneda = dr["CodigoMoneda"].ToString();
                        prestamoHipotecarioNavalDTO.NroCuota = Convert.ToInt32(dr["NroCuota"]);
                        prestamoHipotecarioNavalDTO.CodigoModalidadPrestamo = dr["CodigoModalidadPrestamo"].ToString();
                        prestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo = dr["CodigoFinalidadPrestamo"].ToString();
                        prestamoHipotecarioNavalDTO.CodigoEntidadFinanciera = dr["CodigoEntidadFinanciera"].ToString();
                        prestamoHipotecarioNavalDTO.RentabilidadFinanciera = Convert.ToDecimal(dr["RentabilidadFinanciera"]);
                        prestamoHipotecarioNavalDTO.CodigoProyectoFovimar = dr["CodigoProyectoFovimar"].ToString();
                        prestamoHipotecarioNavalDTO.GarantiaConstituida = dr["GarantiaConstituida"].ToString();
                        prestamoHipotecarioNavalDTO.CuotaPagada = Convert.ToInt32(dr["CuotaPagada"]);
                        prestamoHipotecarioNavalDTO.EstadoDeuda = dr["EstadoDeuda"].ToString();
                        prestamoHipotecarioNavalDTO.MontoMorosidad = Convert.ToDecimal(dr["MontoMorosidad"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return prestamoHipotecarioNavalDTO;
        }

        public string ActualizaFormato(PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_PrestamoHipotecarioNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@PrestamoHipotecarioNavalId", SqlDbType.Int);
                    cmd.Parameters["@PrestamoHipotecarioNavalId"].Value = prestamoHipotecarioNavalDTO.PrestamoHipotecarioNavalId;

                    cmd.Parameters.Add("@DNIPersonalNaval", SqlDbType.VarChar,8);
                    cmd.Parameters["@DNIPersonalNaval"].Value = prestamoHipotecarioNavalDTO.DNIPersonalNaval;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = prestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoSituacionPersonalNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSituacionPersonalNaval"].Value = prestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval;

                    cmd.Parameters.Add("@MontoPrestadoOtorgado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoPrestadoOtorgado"].Value = prestamoHipotecarioNavalDTO.MontoPrestadoOtorgado;

                    cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoMoneda"].Value = prestamoHipotecarioNavalDTO.CodigoMoneda;

                    cmd.Parameters.Add("@NroCuota", SqlDbType.Int);
                    cmd.Parameters["@NroCuota"].Value = prestamoHipotecarioNavalDTO.NroCuota;

                    cmd.Parameters.Add("@CodigoModalidadPrestamo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoModalidadPrestamo"].Value = prestamoHipotecarioNavalDTO.CodigoModalidadPrestamo;

                    cmd.Parameters.Add("@CodigoFinalidadPrestamo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFinalidadPrestamo"].Value = prestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo;

                    cmd.Parameters.Add("@CodigoEntidadFinanciera", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEntidadFinanciera"].Value = prestamoHipotecarioNavalDTO.CodigoEntidadFinanciera;

                    cmd.Parameters.Add("@RentabilidadFinanciera", SqlDbType.Decimal);
                    cmd.Parameters["@RentabilidadFinanciera"].Value = prestamoHipotecarioNavalDTO.RentabilidadFinanciera;

                    cmd.Parameters.Add("@CodigoProyectoFovimar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProyectoFovimar"].Value = prestamoHipotecarioNavalDTO.CodigoProyectoFovimar;

                    cmd.Parameters.Add("@GarantiaConstituida", SqlDbType.VarChar,1);
                    cmd.Parameters["@GarantiaConstituida"].Value = prestamoHipotecarioNavalDTO.GarantiaConstituida;

                    cmd.Parameters.Add("@CuotaPagada", SqlDbType.Int);
                    cmd.Parameters["@CuotaPagada"].Value = prestamoHipotecarioNavalDTO.CuotaPagada;

                    cmd.Parameters.Add("@EstadoDeuda", SqlDbType.VarChar,20);
                    cmd.Parameters["@EstadoDeuda"].Value = prestamoHipotecarioNavalDTO.EstadoDeuda;

                    cmd.Parameters.Add("@MontoMorosidad", SqlDbType.Decimal);
                    cmd.Parameters["@MontoMorosidad"].Value = prestamoHipotecarioNavalDTO.MontoMorosidad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_PrestamoHipotecarioNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PrestamoHipotecarioNavalId", SqlDbType.Int);
                    cmd.Parameters["@PrestamoHipotecarioNavalId"].Value = prestamoHipotecarioNavalDTO.PrestamoHipotecarioNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "PrestamoHipotecarioNaval";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = prestamoHipotecarioNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_PrestamoHipotecarioNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PrestamoHipotecarioNaval", SqlDbType.Structured);
                    cmd.Parameters["@PrestamoHipotecarioNaval"].TypeName = "Formato.PrestamoHipotecarioNaval";
                    cmd.Parameters["@PrestamoHipotecarioNaval"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
