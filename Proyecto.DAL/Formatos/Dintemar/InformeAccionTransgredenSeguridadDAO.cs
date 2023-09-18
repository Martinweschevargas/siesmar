using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class InformeAccionTransgredenSeguridadDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InformeAccionTransgredenSeguridadDTO> ObtenerLista()
        {
            List<InformeAccionTransgredenSeguridadDTO> lista = new List<InformeAccionTransgredenSeguridadDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InformeAccionTransgredenSeguridadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InformeAccionTransgredenSeguridadDTO()
                        {
                            InformeAccionTransgredenSeguridadId = Convert.ToInt32(dr["InformeAccionTransgredenSeguridadId"]),
                            InformeTransgresion = dr["InformeTransgresion"].ToString(),
                            FechaInforme = (dr["FechaInforme"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaSucesoTransgresion = (dr["FechaSucesoTransgresion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescZonaNaval = dr["DescZonaNaval"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescTipoTransgresion = dr["DescTipoTransgresion"].ToString(),
                            DetalleHecho = dr["DetalleHecho"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InformeAccionTransgredenSeguridadDTO informeAccionTransSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformeAccionTransgredenSeguridadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformeTransgresion", SqlDbType.VarChar,20);
                    cmd.Parameters["@InformeTransgresion"].Value = informeAccionTransSeguridadDTO.InformeTransgresion;

                    cmd.Parameters.Add("@FechaInforme", SqlDbType.Date);
                    cmd.Parameters["@FechaInforme"].Value = informeAccionTransSeguridadDTO.FechaInforme;

                    cmd.Parameters.Add("@FechaSucesoTransgresion", SqlDbType.Date);
                    cmd.Parameters["@FechaSucesoTransgresion"].Value = informeAccionTransSeguridadDTO.FechaSucesoTransgresion;

                    cmd.Parameters.Add("@DepartamentoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DepartamentoUbigeo"].Value = informeAccionTransSeguridadDTO.DepartamentoUbigeo;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = informeAccionTransSeguridadDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = informeAccionTransSeguridadDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@ZonaNavald", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavald"].Value = informeAccionTransSeguridadDTO.ZonaNavald;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = informeAccionTransSeguridadDTO.DependenciaId;

                    cmd.Parameters.Add("@TipoTransgresionId", SqlDbType.Int);
                    cmd.Parameters["@TipoTransgresionId"].Value = informeAccionTransSeguridadDTO.TipoTransgresionId;

                    cmd.Parameters.Add("@DetalleHecho", SqlDbType.VarChar,260);
                    cmd.Parameters["@DetalleHecho"].Value = informeAccionTransSeguridadDTO.DetalleHecho;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = informeAccionTransSeguridadDTO.CargaId;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informeAccionTransSeguridadDTO.UsuarioIngresoRegistro;

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

        public InformeAccionTransgredenSeguridadDTO BuscarFormato(int Codigo)
        {
            InformeAccionTransgredenSeguridadDTO informeAccionTransSeguridadDTO = new InformeAccionTransgredenSeguridadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformeAccionTransgredenSeguridadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformeAccionTransgredenSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@InformeAccionTransgredenSeguridadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        informeAccionTransSeguridadDTO.InformeAccionTransgredenSeguridadId = Convert.ToInt32(dr["InformeAccionTransgredenSeguridadId"]);
                        informeAccionTransSeguridadDTO.InformeTransgresion = dr["InformeTransgresion"].ToString();
                        informeAccionTransSeguridadDTO.FechaInforme = Convert.ToDateTime(dr["FechaInforme"]).ToString("yyy-MM-dd");
                        informeAccionTransSeguridadDTO.FechaSucesoTransgresion = Convert.ToDateTime(dr["FechaSucesoTransgresion"]).ToString("yyy-MM-dd");
                        informeAccionTransSeguridadDTO.DepartamentoUbigeo = dr["DepartamentoUbigeo"].ToString();
                        informeAccionTransSeguridadDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        informeAccionTransSeguridadDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        informeAccionTransSeguridadDTO.ZonaNavald = Convert.ToInt32(dr["ZonaNavald"]);
                        informeAccionTransSeguridadDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        informeAccionTransSeguridadDTO.TipoTransgresionId = Convert.ToInt32(dr["TipoTransgresionId"]);
                        informeAccionTransSeguridadDTO.DetalleHecho = dr["DetalleHecho"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return informeAccionTransSeguridadDTO;
        }

        public string ActualizaFormato(InformeAccionTransgredenSeguridadDTO informeAccionTransSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InformeAccionTransgredenSeguridadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformeAccionTransgredenSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@InformeAccionTransgredenSeguridadId"].Value = informeAccionTransSeguridadDTO.InformeAccionTransgredenSeguridadId;

                    cmd.Parameters.Add("@InformeTransgresion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@InformeTransgresion"].Value = informeAccionTransSeguridadDTO.InformeTransgresion;

                    cmd.Parameters.Add("@FechaInforme", SqlDbType.Date);
                    cmd.Parameters["@FechaInforme"].Value = informeAccionTransSeguridadDTO.FechaInforme;

                    cmd.Parameters.Add("@FechaSucesoTransgresion", SqlDbType.Date);
                    cmd.Parameters["@FechaSucesoTransgresion"].Value = informeAccionTransSeguridadDTO.FechaSucesoTransgresion;

                    cmd.Parameters.Add("@DepartamentoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DepartamentoUbigeo"].Value = informeAccionTransSeguridadDTO.DepartamentoUbigeo;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = informeAccionTransSeguridadDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = informeAccionTransSeguridadDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@ZonaNavald", SqlDbType.Int);
                    cmd.Parameters["@ZonaNavald"].Value = informeAccionTransSeguridadDTO.ZonaNavald;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = informeAccionTransSeguridadDTO.DependenciaId;

                    cmd.Parameters.Add("@TipoTransgresionId", SqlDbType.Int);
                    cmd.Parameters["@TipoTransgresionId"].Value = informeAccionTransSeguridadDTO.TipoTransgresionId;

                    cmd.Parameters.Add("@DetalleHecho", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DetalleHecho"].Value = informeAccionTransSeguridadDTO.DetalleHecho;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informeAccionTransSeguridadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InformeAccionTransgredenSeguridadDTO informeAccionTransSeguridadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InformeAccionTransgredenSeguridadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InformeAccionTransgredenSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@InformeAccionTransgredenSeguridadId"].Value = informeAccionTransSeguridadDTO.InformeAccionTransgredenSeguridadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = informeAccionTransSeguridadDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_LicenciaArmaMenorMilitarRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LicenciaArmaMenorMilitar", SqlDbType.Structured);
                    cmd.Parameters["@LicenciaArmaMenorMilitar"].TypeName = "Formato.LicenciaArmaMenorMilitar";
                    cmd.Parameters["@LicenciaArmaMenorMilitar"].Value = datos;

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
