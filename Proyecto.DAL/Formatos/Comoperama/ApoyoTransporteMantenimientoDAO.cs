using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperama
{
    public class ApoyoTransporteMantenimientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ApoyoTransporteMantenimientoDTO> ObtenerLista(int? CargaId=null)
        {
            List<ApoyoTransporteMantenimientoDTO> lista = new List<ApoyoTransporteMantenimientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ApoyoTransporteMantenimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargoId", SqlDbType.Int);
                cmd.Parameters["@CargoId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ApoyoTransporteMantenimientoDTO()
                        {
                            ApoyoTransporteMantenimientoId = Convert.ToInt32(dr["ApoyoTransporteMantenimientoId"]),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DistritoUbigeo = dr["DistritoUbigeo"].ToString(),
                            DescTipoActividadDenominacion = dr["DescTipoActividadDenominacion"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroBeneficiados = Convert.ToInt32(dr["NumeroBeneficiados"]),
                            Valor = Convert.ToDecimal(dr["Valor"]),
                            DescTipoAccionCivica = dr["DescTipoAccionCivica"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoTransporteMantenimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = apoyoTransporteMantenimientoDTO.CodigoZonaNaval;


                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = apoyoTransporteMantenimientoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoTipoActividadDenominacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoActividadDenominacion"].Value = apoyoTransporteMantenimientoDTO.CodigoTipoActividadDenominacion;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = apoyoTransporteMantenimientoDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = apoyoTransporteMantenimientoDTO.FechaTermino;

                    cmd.Parameters.Add("@NumeroBeneficiados", SqlDbType.Int);
                    cmd.Parameters["@NumeroBeneficiados"].Value = apoyoTransporteMantenimientoDTO.NumeroBeneficiados;       
                    
                    cmd.Parameters.Add("@Valor", SqlDbType.Decimal);
                    cmd.Parameters["@Valor"].Value = apoyoTransporteMantenimientoDTO.Valor;

                    cmd.Parameters.Add("@CodigoTipoAccionCivica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoAccionCivica"].Value = apoyoTransporteMantenimientoDTO.CodigoTipoAccionCivica;


                    cmd.Parameters.Add("@CargoId", SqlDbType.Int);
                    cmd.Parameters["@CargoId"].Value = apoyoTransporteMantenimientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoTransporteMantenimientoDTO.UsuarioIngresoRegistro;

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

        public ApoyoTransporteMantenimientoDTO BuscarFormato(int Codigo)
        {
            ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO = new ApoyoTransporteMantenimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoTransporteMantenimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoTransporteMantenimientoId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoTransporteMantenimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        apoyoTransporteMantenimientoDTO.ApoyoTransporteMantenimientoId = Convert.ToInt32(dr["ApoyoTransporteMantenimientoId"]);
                        apoyoTransporteMantenimientoDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        apoyoTransporteMantenimientoDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        apoyoTransporteMantenimientoDTO.CodigoTipoActividadDenominacion = dr["CodigoTipoActividadDenominacion"].ToString();
                        apoyoTransporteMantenimientoDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        apoyoTransporteMantenimientoDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        apoyoTransporteMantenimientoDTO.NumeroBeneficiados = Convert.ToInt32(dr["NumeroBeneficiados"]);
                        apoyoTransporteMantenimientoDTO.Valor = Convert.ToDecimal(dr["Valor"]);
                        apoyoTransporteMantenimientoDTO.CodigoTipoAccionCivica = dr["CodigoTipoAccionCivica"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return apoyoTransporteMantenimientoDTO;
        }

        public string ActualizaFormato(ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ApoyoTransporteMantenimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ApoyoTransporteMantenimientoId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoTransporteMantenimientoId"].Value = apoyoTransporteMantenimientoDTO.ApoyoTransporteMantenimientoId;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = apoyoTransporteMantenimientoDTO.CodigoZonaNaval;


                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = apoyoTransporteMantenimientoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoTipoActividadDenominacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoActividadDenominacion"].Value = apoyoTransporteMantenimientoDTO.CodigoTipoActividadDenominacion;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = apoyoTransporteMantenimientoDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = apoyoTransporteMantenimientoDTO.FechaTermino;

                    cmd.Parameters.Add("@NumeroBeneficiados", SqlDbType.Int);
                    cmd.Parameters["@NumeroBeneficiados"].Value = apoyoTransporteMantenimientoDTO.NumeroBeneficiados;

                    cmd.Parameters.Add("@Valor", SqlDbType.Decimal);
                    cmd.Parameters["@Valor"].Value = apoyoTransporteMantenimientoDTO.Valor;

                    cmd.Parameters.Add("@CodigoTipoAccionCivica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoAccionCivica"].Value = apoyoTransporteMantenimientoDTO.CodigoTipoAccionCivica;



                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoTransporteMantenimientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ApoyoTransporteMantenimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoTransporteMantenimientoId", SqlDbType.Int);
                    cmd.Parameters["@ApoyoTransporteMantenimientoId"].Value = apoyoTransporteMantenimientoDTO.ApoyoTransporteMantenimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = apoyoTransporteMantenimientoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ApoyoTransporteMantenimientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApoyoTransporteMantenimiento", SqlDbType.Structured);
                    cmd.Parameters["@ApoyoTransporteMantenimiento"].TypeName = "Formato.ApoyoTransporteMantenimiento";
                    cmd.Parameters["@ApoyoTransporteMantenimiento"].Value = datos;

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
