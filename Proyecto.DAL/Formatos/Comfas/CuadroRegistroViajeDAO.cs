using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class CuadroRegistroViajeDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CuadroRegistroViajeDTO> ObtenerLista()
        {
            List<CuadroRegistroViajeDTO> lista = new List<CuadroRegistroViajeDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CuadroRegistroViajeListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CuadroRegistroViajeDTO()
                        {
                            CuadroRegistroViajeId = Convert.ToInt32(dr["CuadroRegistroViajeId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            FechaRegistro = (dr["FechaRegistro"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            DescEspecialidadGenericaPersonal = dr["DescEspecialidadGenericaPersonal"].ToString(),
                            CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]),
                            UbigeoOrigen = Convert.ToInt32(dr["UbigeoOrigen"]),
                            UbigeoDestino = Convert.ToInt32(dr["UbigeoDestino"]),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TiempoDuracion = Convert.ToInt32(dr["TiempoDuracion"]),
                            MedioViaje = dr["MedioViaje"].ToString(),
                            DocumentoAutorizacion = dr["DocumentoAutorizacion"].ToString(),
                            MotivoViaje = dr["MotivoViaje"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CuadroRegistroViajeDTO cuadroRegistroViajeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroRegistroViajeRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = cuadroRegistroViajeDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = cuadroRegistroViajeDTO.FechaRegistro;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = cuadroRegistroViajeDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = cuadroRegistroViajeDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = cuadroRegistroViajeDTO.CIPPersonal;

                    cmd.Parameters.Add("@UbigeoOrigen", SqlDbType.Int);
                    cmd.Parameters["@UbigeoOrigen"].Value = cuadroRegistroViajeDTO.UbigeoOrigen;

                    cmd.Parameters.Add("@UbigeoDestino", SqlDbType.Int);
                    cmd.Parameters["@UbigeoDestino"].Value = cuadroRegistroViajeDTO.UbigeoDestino;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = cuadroRegistroViajeDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = cuadroRegistroViajeDTO.FechaTermino;

                    cmd.Parameters.Add("@TiempoDuracion", SqlDbType.Int);
                    cmd.Parameters["@TiempoDuracion"].Value = cuadroRegistroViajeDTO.TiempoDuracion;

                    cmd.Parameters.Add("@MedioViaje", SqlDbType.VarChar,10);
                    cmd.Parameters["@MedioViaje"].Value = cuadroRegistroViajeDTO.MedioViaje;

                    cmd.Parameters.Add("@DocumentoAutorizacion", SqlDbType.VarChar,20);
                    cmd.Parameters["@DocumentoAutorizacion"].Value = cuadroRegistroViajeDTO.DocumentoAutorizacion;

                    cmd.Parameters.Add("@MotivoViaje", SqlDbType.VarChar,100);
                    cmd.Parameters["@MotivoViaje"].Value = cuadroRegistroViajeDTO.MotivoViaje;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroRegistroViajeDTO.UsuarioIngresoRegistro;

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

        public CuadroRegistroViajeDTO BuscarFormato(int Codigo)
        {
            CuadroRegistroViajeDTO cuadroRegistroViajeDTO = new CuadroRegistroViajeDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroRegistroViajeEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroRegistroViajeId", SqlDbType.Int);
                    cmd.Parameters["@CuadroRegistroViajeId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        cuadroRegistroViajeDTO.CuadroRegistroViajeId = Convert.ToInt32(dr["CuadroRegistroViajeId"]);
                        cuadroRegistroViajeDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        cuadroRegistroViajeDTO.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("yyy-MM-dd");
                        cuadroRegistroViajeDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        cuadroRegistroViajeDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        cuadroRegistroViajeDTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        cuadroRegistroViajeDTO.UbigeoOrigen = Convert.ToInt32(dr["UbigeoOrigen"]);
                        cuadroRegistroViajeDTO.UbigeoDestino = Convert.ToInt32(dr["UbigeoDestino"]);
                        cuadroRegistroViajeDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        cuadroRegistroViajeDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        cuadroRegistroViajeDTO.TiempoDuracion = Convert.ToInt32(dr["TiempoDuracion"]);
                        cuadroRegistroViajeDTO.MedioViaje = dr["MedioViaje"].ToString();
                        cuadroRegistroViajeDTO.DocumentoAutorizacion = dr["DocumentoAutorizacion"].ToString();
                        cuadroRegistroViajeDTO.MotivoViaje = dr["MotivoViaje"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cuadroRegistroViajeDTO;
        }

        public string ActualizaFormato(CuadroRegistroViajeDTO cuadroRegistroViajeDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CuadroRegistroViajeActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CuadroRegistroViajeId", SqlDbType.Int);
                    cmd.Parameters["@CuadroRegistroViajeId"].Value = cuadroRegistroViajeDTO.CuadroRegistroViajeId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = cuadroRegistroViajeDTO.UnidadNavalId;

                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
                    cmd.Parameters["@FechaRegistro"].Value = cuadroRegistroViajeDTO.FechaRegistro;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = cuadroRegistroViajeDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = cuadroRegistroViajeDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = cuadroRegistroViajeDTO.CIPPersonal;

                    cmd.Parameters.Add("@UbigeoOrigen", SqlDbType.Int);
                    cmd.Parameters["@UbigeoOrigen"].Value = cuadroRegistroViajeDTO.UbigeoOrigen;

                    cmd.Parameters.Add("@UbigeoDestino", SqlDbType.Int);
                    cmd.Parameters["@UbigeoDestino"].Value = cuadroRegistroViajeDTO.UbigeoDestino;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = cuadroRegistroViajeDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = cuadroRegistroViajeDTO.FechaTermino;

                    cmd.Parameters.Add("@TiempoDuracion", SqlDbType.Int);
                    cmd.Parameters["@TiempoDuracion"].Value = cuadroRegistroViajeDTO.TiempoDuracion;

                    cmd.Parameters.Add("@MedioViaje", SqlDbType.VarChar, 10);
                    cmd.Parameters["@MedioViaje"].Value = cuadroRegistroViajeDTO.MedioViaje;

                    cmd.Parameters.Add("@DocumentoAutorizacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DocumentoAutorizacion"].Value = cuadroRegistroViajeDTO.DocumentoAutorizacion;

                    cmd.Parameters.Add("@MotivoViaje", SqlDbType.VarChar, 100);
                    cmd.Parameters["@MotivoViaje"].Value = cuadroRegistroViajeDTO.MotivoViaje;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroRegistroViajeDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CuadroRegistroViajeDTO cuadroRegistroViajeDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroRegistroViajeEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroRegistroViajeId", SqlDbType.Int);
                    cmd.Parameters["@CuadroRegistroViajeId"].Value = cuadroRegistroViajeDTO.CuadroRegistroViajeId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroRegistroViajeDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<CuadroRegistroViajeDTO> cuadroRegistroViajeDTO)
        {
            bool respuesta = false;
            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    using (var cmd = new SqlCommand())
                    {

                        cmd.Connection = conexion;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Formato.EstudiosInvestigacionHistoricaNaval " +
                            " (NombreInvestigacion, TipoEstudioInvestigacionId, FechaInicioInvestigacion, " +
                            "FechaTerminoInvestigacion, ResponsableInvestigacion, SolicitanteInvestigacion, " +
                            "UsuarioIngresoRegistro, FechaIngresoRegistro, NroIpRegistro, NroMacRegistro, " +
                            "UsuarioBaseDatos, CodigoIngreso, Año, Mes, Dia) values (@NombreInvestigacion, " +
                            "@TipoEstudioInvestigacionId, @FechaInicioInvestigacion, @FechaTerminoInvestigacion, " +
                            "@ResponsableInvestigacion, @SolicitanteInvestigacion, @Usuario, GETDATE(), @IP, @MAC, " +
                            "@UsuarioDB, 0, @YEAR, @MES, @DIA)";
                        cmd.Parameters.Add("@NombreInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@TipoEstudioInvestigacionId", SqlDbType.Int);
                        cmd.Parameters.Add("@FechaInicioInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@FechaTerminoInvestigacion", SqlDbType.Date);
                        cmd.Parameters.Add("@ResponsableInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@SolicitanteInvestigacion", SqlDbType.VarChar, 250);
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@MAC", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@UsuarioDB", SqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@YEAR", SqlDbType.Int);
                        cmd.Parameters.Add("@MES", SqlDbType.Int);
                        cmd.Parameters.Add("@DIA", SqlDbType.Int);
                        try
                        {
                            foreach (var item in cuadroRegistroViajeDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreTemaEstudioInvestigacion;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoEstudioInvestigacionIds;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicio);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTermino);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.Responsable;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.Solicitante;
                                cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();

                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            respuesta = true;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();                    
                            throw;
                        }
                        finally
                        {
                            conexion.Close();
                        }
                    }
                }
            }
            return respuesta;
        }
    }
}
