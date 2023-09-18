using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class CuadroDemostrativoPersonalComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CuadroDemostrativoPersonalComfasDTO> ObtenerLista()
        {
            List<CuadroDemostrativoPersonalComfasDTO> lista = new List<CuadroDemostrativoPersonalComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CuadroDemostrativoPersonalComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CuadroDemostrativoPersonalComfasDTO()
                        {
                            CuadroDemostrativoPersonalComfasId = Convert.ToInt32(dr["CuadroDemostrativoPersonalComfasId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Fecha = (dr["Fecha"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            DescEspecialidadGenericaPersonal = dr["DescEspecialidadGenericaPersonal"].ToString(),
                            CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]),
                            Condicion = dr["Condicion"].ToString(),
                            UbigeoOrigen = Convert.ToInt32(dr["UbigeoOrigen"]),
                            UbigeoDestino = Convert.ToInt32(dr["UbigeoDestino"]),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DuracionDias = Convert.ToInt32(dr["DuracionDias"]),
                            DocumentoReferencia = dr["DocumentoReferencia"].ToString(),
                            Motivo = dr["Motivo"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CuadroDemostrativoPersonalComfasDTO cuadroDemostrativoPersonalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroDemostrativoPersonalComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = cuadroDemostrativoPersonalComfasDTO.Fecha;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = cuadroDemostrativoPersonalComfasDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = cuadroDemostrativoPersonalComfasDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = cuadroDemostrativoPersonalComfasDTO.CIPPersonal;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar,20);
                    cmd.Parameters["@Condicion"].Value = cuadroDemostrativoPersonalComfasDTO.Condicion;

                    cmd.Parameters.Add("@UbigeoOrigen", SqlDbType.Int);
                    cmd.Parameters["@UbigeoOrigen"].Value = cuadroDemostrativoPersonalComfasDTO.UbigeoOrigen;

                    cmd.Parameters.Add("@UbigeoDestino", SqlDbType.Int);
                    cmd.Parameters["@UbigeoDestino"].Value = cuadroDemostrativoPersonalComfasDTO.UbigeoDestino;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = cuadroDemostrativoPersonalComfasDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = cuadroDemostrativoPersonalComfasDTO.FechaTermino;

                    cmd.Parameters.Add("@DuracionDias", SqlDbType.Int);
                    cmd.Parameters["@DuracionDias"].Value = cuadroDemostrativoPersonalComfasDTO.DuracionDias;

                    cmd.Parameters.Add("@DocumentoReferencia", SqlDbType.VarChar);
                    cmd.Parameters["@DocumentoReferencia"].Value = cuadroDemostrativoPersonalComfasDTO.DocumentoReferencia;

                    cmd.Parameters.Add("@Motivo", SqlDbType.VarChar);
                    cmd.Parameters["@Motivo"].Value = cuadroDemostrativoPersonalComfasDTO.Motivo;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroDemostrativoPersonalComfasDTO.UsuarioIngresoRegistro;

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

        public CuadroDemostrativoPersonalComfasDTO BuscarFormato(int Codigo)
        {
            CuadroDemostrativoPersonalComfasDTO cuadroDemostrativoPersonalComfasDTO = new CuadroDemostrativoPersonalComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroDemostrativoPersonalComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroDemostrativoPersonalComfasId", SqlDbType.Int);
                    cmd.Parameters["@CuadroDemostrativoPersonalComfasId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        cuadroDemostrativoPersonalComfasDTO.CuadroDemostrativoPersonalComfasId = Convert.ToInt32(dr["CuadroDemostrativoPersonalComfasId"]);
                        cuadroDemostrativoPersonalComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        cuadroDemostrativoPersonalComfasDTO.Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("yyy-MM-dd");
                        cuadroDemostrativoPersonalComfasDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        cuadroDemostrativoPersonalComfasDTO.EspecialidadGenericaPersonalId = Convert.ToInt32(dr["EspecialidadGenericaPersonalId"]);
                        cuadroDemostrativoPersonalComfasDTO.CIPPersonal = Convert.ToInt32(dr["CIPPersonal"]);
                        cuadroDemostrativoPersonalComfasDTO.Condicion = dr["Condicion"].ToString();
                        cuadroDemostrativoPersonalComfasDTO.UbigeoOrigen = Convert.ToInt32(dr["UbigeoOrigen"]);
                        cuadroDemostrativoPersonalComfasDTO.UbigeoDestino = Convert.ToInt32(dr["UbigeoDestino"]);
                        cuadroDemostrativoPersonalComfasDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        cuadroDemostrativoPersonalComfasDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        cuadroDemostrativoPersonalComfasDTO.DuracionDias = Convert.ToInt32(dr["DuracionDias"]);
                        cuadroDemostrativoPersonalComfasDTO.DocumentoReferencia = dr["DocumentoReferencia"].ToString();
                        cuadroDemostrativoPersonalComfasDTO.Motivo = dr["Motivo"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cuadroDemostrativoPersonalComfasDTO;
        }

        public string ActualizaFormato(CuadroDemostrativoPersonalComfasDTO cuadroDemostrativoPersonalComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CuadroDemostrativoPersonalComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CuadroDemostrativoPersonalComfasId", SqlDbType.Int);
                    cmd.Parameters["@CuadroDemostrativoPersonalComfasId"].Value = cuadroDemostrativoPersonalComfasDTO.CuadroDemostrativoPersonalComfasId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = cuadroDemostrativoPersonalComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = cuadroDemostrativoPersonalComfasDTO.Fecha;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = cuadroDemostrativoPersonalComfasDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@EspecialidadGenericaPersonalId", SqlDbType.Int);
                    cmd.Parameters["@EspecialidadGenericaPersonalId"].Value = cuadroDemostrativoPersonalComfasDTO.EspecialidadGenericaPersonalId;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.Int);
                    cmd.Parameters["@CIPPersonal"].Value = cuadroDemostrativoPersonalComfasDTO.CIPPersonal;

                    cmd.Parameters.Add("@Condicion", SqlDbType.VarChar,20);
                    cmd.Parameters["@Condicion"].Value = cuadroDemostrativoPersonalComfasDTO.Condicion;

                    cmd.Parameters.Add("@UbigeoOrigen", SqlDbType.Int);
                    cmd.Parameters["@UbigeoOrigen"].Value = cuadroDemostrativoPersonalComfasDTO.UbigeoOrigen;

                    cmd.Parameters.Add("@UbigeoDestino", SqlDbType.Int);
                    cmd.Parameters["@UbigeoDestino"].Value = cuadroDemostrativoPersonalComfasDTO.UbigeoDestino;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = cuadroDemostrativoPersonalComfasDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = cuadroDemostrativoPersonalComfasDTO.FechaTermino;

                    cmd.Parameters.Add("@DuracionDias", SqlDbType.Int);
                    cmd.Parameters["@DuracionDias"].Value = cuadroDemostrativoPersonalComfasDTO.DuracionDias;

                    cmd.Parameters.Add("@DocumentoReferencia", SqlDbType.VarChar);
                    cmd.Parameters["@DocumentoReferencia"].Value = cuadroDemostrativoPersonalComfasDTO.DocumentoReferencia;

                    cmd.Parameters.Add("@Motivo", SqlDbType.VarChar);
                    cmd.Parameters["@Motivo"].Value = cuadroDemostrativoPersonalComfasDTO.Motivo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroDemostrativoPersonalComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CuadroDemostrativoPersonalComfasDTO cuadroDemostrativoPersonalComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CuadroDemostrativoPersonalComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CuadroDemostrativoPersonalComfasId", SqlDbType.Int);
                    cmd.Parameters["@CuadroDemostrativoPersonalComfasId"].Value = cuadroDemostrativoPersonalComfasDTO.CuadroDemostrativoPersonalComfasId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cuadroDemostrativoPersonalComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<CuadroDemostrativoPersonalComfasDTO> cuadroDemostrativoPersonalComfasDTO)
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
                            foreach (var item in cuadroDemostrativoPersonalComfasDTO)
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
