using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class AlistamientoMaterialJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMaterialJesehinDTO> ObtenerLista()
        {
            List<AlistamientoMaterialJesehinDTO> lista = new List<AlistamientoMaterialJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMaterialJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialJesehinDTO()
                        {
                            AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString(),
                            Ponderado1N = dr["Ponderado1N"].ToString(),
                            Subclasificacion2 = dr["Subclasificacion2"].ToString(),
                            Ponderado2Nivel = dr["Ponderado2Nivel"].ToString(),
                            Subclasificacion3 = dr["Subclasificacion3"].ToString(),
                            Ponderado3Nivel = dr["Ponderado3Nivel"].ToString(),
                            Requerido = Convert.ToInt32(dr["Requerido"]),
                            Operativo = Convert.ToInt32(dr["Operativo"]),
                            PorcentajeOperatividad = Convert.ToDecimal(dr["Operativo"]),
                            PonderadoFuncional = Convert.ToDecimal(dr["PonderadoFuncional"]),
                            NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMaterialJesehinDTO alistamientoMaterialJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMaterialJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido3NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido3NId"].Value = alistamientoMaterialJesehinDTO.AlistamientoMaterialRequerido3NId;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialJesehinDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialJesehinDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialJesehinDTO.PorcentajeOperatividad;

                    cmd.Parameters.Add("@PonderadoFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PonderadoFuncional"].Value = alistamientoMaterialJesehinDTO.PonderadoFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialJesehinDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialJesehinDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialJesehinDTO BuscarFormato(int Codigo)
        {
            AlistamientoMaterialJesehinDTO alistamientoMaterialJesehinDTO = new AlistamientoMaterialJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoMaterialJesehinDTO.AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]);
                        alistamientoMaterialJesehinDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistamientoMaterialJesehinDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        alistamientoMaterialJesehinDTO.AlistamientoMaterialRequerido3NId = Convert.ToInt32(dr["AlistamientoMaterialRequerido3NId"]);
                        alistamientoMaterialJesehinDTO.CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString();
                        alistamientoMaterialJesehinDTO.Ponderado1N = dr["Ponderado1N"].ToString();
                        alistamientoMaterialJesehinDTO.Subclasificacion2 = dr["Subclasificacion2"].ToString();
                        alistamientoMaterialJesehinDTO.Ponderado2Nivel = dr["Ponderado2Nivel"].ToString();
                        alistamientoMaterialJesehinDTO.Subclasificacion3 = dr["Subclasificacion3"].ToString();
                        alistamientoMaterialJesehinDTO.Ponderado3Nivel = dr["Ponderado3Nivel"].ToString();
                        alistamientoMaterialJesehinDTO.Requerido = Convert.ToInt32(dr["Requerido"]);
                        alistamientoMaterialJesehinDTO.Operativo = Convert.ToInt32(dr["Operativo"]);
                        alistamientoMaterialJesehinDTO.PorcentajeOperatividad = Convert.ToDecimal(dr["PorcentajeOperatividad"]);
                        alistamientoMaterialJesehinDTO.PonderadoFuncional = Convert.ToDecimal(dr["PonderadoFuncional"]);
                        alistamientoMaterialJesehinDTO.NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialJesehinDTO;
        }

        public string ActualizaFormato(AlistamientoMaterialJesehinDTO alistamientoMaterialJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialJesehinDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMaterialJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoMaterialRequerido3NId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequerido3NId"].Value = alistamientoMaterialJesehinDTO.AlistamientoMaterialRequerido3NId;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialJesehinDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialJesehinDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.Decimal);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialJesehinDTO.PorcentajeOperatividad;

                    cmd.Parameters.Add("@PonderadoFuncional", SqlDbType.Decimal);
                    cmd.Parameters["@PonderadoFuncional"].Value = alistamientoMaterialJesehinDTO.PonderadoFuncional;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialJesehinDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMaterialJesehinDTO alistamientoMaterialJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialJesehinDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialJesehinDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialJesehinDTO> emisionNotaPrensaDTO)
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
                            foreach (var item in emisionNotaPrensaDTO)
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
