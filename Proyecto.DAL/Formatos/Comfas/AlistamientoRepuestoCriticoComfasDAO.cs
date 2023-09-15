using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class AlistamientoRepuestoCriticoComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoRepuestoCriticoComfasDTO> ObtenerLista()
        {
            List<AlistamientoRepuestoCriticoComfasDTO> lista = new List<AlistamientoRepuestoCriticoComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoRepuestoCriticoComfasDTO()
                        {
                            AlistamientoRepuestoCriticoId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaRespuestoCritico = dr["DescSistemaRespuestoCritico"].ToString(),
                            DescSubsistemaRepuestoCritico = dr["DescSubsistemaRepuestoCritico"].ToString(),
                            EquipoRepuestoCritico = Convert.ToInt32(dr["EquipoRepuestoCritico"]),
                            Repuesto = Convert.ToInt32(dr["Repuesto"]),
                            RepuestoExistente = Convert.ToInt32(dr["RepuestoExistente"]),
                            RepuestoNecesario = Convert.ToInt32(dr["RepuestoNecesario"]),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfasDTO alistamientoRepuestoCriticoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoRepuestoCriticoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@SistemaRespuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SistemaRespuestoCriticoId"].Value = alistamientoRepuestoCriticoComfasDTO.SistemaRespuestoCriticoId;

                    cmd.Parameters.Add("@SubsistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaRepuestoCriticoId"].Value = alistamientoRepuestoCriticoComfasDTO.SubsistemaRepuestoCriticoId;

                    cmd.Parameters.Add("@EquipoRepuestoCritico", SqlDbType.Int);
                    cmd.Parameters["@EquipoRepuestoCritico"].Value = alistamientoRepuestoCriticoComfasDTO.EquipoRepuestoCritico;

                    cmd.Parameters.Add("@Repuesto", SqlDbType.Int);
                    cmd.Parameters["@Repuesto"].Value = alistamientoRepuestoCriticoComfasDTO.Repuesto;

                    cmd.Parameters.Add("@RepuestoExistente", SqlDbType.Int);
                    cmd.Parameters["@RepuestoExistente"].Value = alistamientoRepuestoCriticoComfasDTO.RepuestoExistente;

                    cmd.Parameters.Add("@RepuestoNecesario", SqlDbType.Int);
                    cmd.Parameters["@RepuestoNecesario"].Value = alistamientoRepuestoCriticoComfasDTO.RepuestoNecesario;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = alistamientoRepuestoCriticoComfasDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfasDTO.UsuarioIngresoRegistro;

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

        public AlistamientoRepuestoCriticoComfasDTO BuscarFormato(int Codigo)
        {
            AlistamientoRepuestoCriticoComfasDTO alistamientoRepuestoCriticoComfasDTO = new AlistamientoRepuestoCriticoComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoRepuestoCriticoComfasDTO.AlistamientoRepuestoCriticoId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoId"]);
                        alistamientoRepuestoCriticoComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistamientoRepuestoCriticoComfasDTO.SistemaRespuestoCriticoId = Convert.ToInt32(dr["SistemaRespuestoCriticoId"]);
                        alistamientoRepuestoCriticoComfasDTO.SubsistemaRepuestoCriticoId = Convert.ToInt32(dr["SubsistemaRepuestoCriticoId"]);
                        alistamientoRepuestoCriticoComfasDTO.EquipoRepuestoCritico = Convert.ToInt32(dr["EquipoRepuestoCritico"]);
                        alistamientoRepuestoCriticoComfasDTO.Repuesto = Convert.ToInt32(dr["Repuesto"]);
                        alistamientoRepuestoCriticoComfasDTO.RepuestoExistente = Convert.ToInt32(dr["RepuestoExistente"]);
                        alistamientoRepuestoCriticoComfasDTO.RepuestoNecesario = Convert.ToInt32(dr["RepuestoNecesario"]);
                        alistamientoRepuestoCriticoComfasDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoRepuestoCriticoComfasDTO;
        }

        public string ActualizaFormato(AlistamientoRepuestoCriticoComfasDTO alistamientoRepuestoCriticoComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = alistamientoRepuestoCriticoComfasDTO.AlistamientoRepuestoCriticoId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoRepuestoCriticoComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@SistemaRespuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SistemaRespuestoCriticoId"].Value = alistamientoRepuestoCriticoComfasDTO.SistemaRespuestoCriticoId;

                    cmd.Parameters.Add("@SubsistemaRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaRepuestoCriticoId"].Value = alistamientoRepuestoCriticoComfasDTO.SubsistemaRepuestoCriticoId;

                    cmd.Parameters.Add("@EquipoRepuestoCritico", SqlDbType.Int);
                    cmd.Parameters["@EquipoRepuestoCritico"].Value = alistamientoRepuestoCriticoComfasDTO.EquipoRepuestoCritico;

                    cmd.Parameters.Add("@Repuesto", SqlDbType.Int);
                    cmd.Parameters["@Repuesto"].Value = alistamientoRepuestoCriticoComfasDTO.Repuesto;

                    cmd.Parameters.Add("@RepuestoExistente", SqlDbType.Int);
                    cmd.Parameters["@RepuestoExistente"].Value = alistamientoRepuestoCriticoComfasDTO.RepuestoExistente;

                    cmd.Parameters.Add("@RepuestoNecesario", SqlDbType.Int);
                    cmd.Parameters["@RepuestoNecesario"].Value = alistamientoRepuestoCriticoComfasDTO.RepuestoNecesario;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = alistamientoRepuestoCriticoComfasDTO.CoeficientePonderacion;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfasDTO alistamientoRepuestoCriticoComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoRepuestoCriticoComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = alistamientoRepuestoCriticoComfasDTO.AlistamientoRepuestoCriticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoRepuestoCriticoComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AlistamientoRepuestoCriticoComfasDTO> alistamientoRepuestoCriticoComfasDTO)
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
                            foreach (var item in alistamientoRepuestoCriticoComfasDTO)
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
