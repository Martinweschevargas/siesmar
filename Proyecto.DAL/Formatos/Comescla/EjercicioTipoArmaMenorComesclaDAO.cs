using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comescla;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comescla
{
    public class EjercicioTipoArmaMenorComesclaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EjercicioTipoArmaMenorComesclaDTO> ObtenerLista()
        {
            List<EjercicioTipoArmaMenorComesclaDTO> lista = new List<EjercicioTipoArmaMenorComesclaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComesclaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioTipoArmaMenorComesclaDTO()
                        {
                            EjercicioTipoArmaMenorId = Convert.ToInt32(dr["EjercicioTipoArmaMenorId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            FechaEjercicio = (dr["FechaEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoArmamento = dr["DescTipoArmamento"].ToString(),
                            DescPosicionTipoArma = dr["DescPosicionTipoArma"].ToString(),
                            DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]),
                            CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]),
                            PorcentajeEvaluacion = Convert.ToInt32(dr["PorcentajeEvaluacion"]),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EjercicioTipoArmaMenorComesclaDTO ejercicioTipoArmaMenorComesclaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComesclaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTipoArmaMenorComesclaDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTipoArmaMenorComesclaDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTipoArmaMenorComesclaDTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTipoArmaMenorComesclaDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTipoArmaMenorComesclaDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTipoArmaMenorComesclaDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTipoArmaMenorComesclaDTO.CantidadTiro;

                    cmd.Parameters.Add("@PorcentajeEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeEvaluacion"].Value = ejercicioTipoArmaMenorComesclaDTO.PorcentajeEvaluacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComesclaDTO.UsuarioIngresoRegistro;

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

        public EjercicioTipoArmaMenorComesclaDTO BuscarFormato(int Codigo)
        {
            EjercicioTipoArmaMenorComesclaDTO ejercicioTipoArmaMenorComesclaDTO = new EjercicioTipoArmaMenorComesclaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComesclaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ejercicioTipoArmaMenorComesclaDTO.EjercicioTipoArmaMenorId = Convert.ToInt32(dr["EjercicioTipoArmaMenorId"]);
                        ejercicioTipoArmaMenorComesclaDTO.TipoPersonalMilitarId = Convert.ToInt32(dr["TipoPersonalMilitarId"]);
                        ejercicioTipoArmaMenorComesclaDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        ejercicioTipoArmaMenorComesclaDTO.FechaEjercicio = Convert.ToDateTime(dr["FechaEjercicio"]).ToString("yyy-MM-dd");
                        ejercicioTipoArmaMenorComesclaDTO.TipoArmamentoId = Convert.ToInt32(dr["TipoArmamentoId"]);
                        ejercicioTipoArmaMenorComesclaDTO.PosicionTipoArmaId = Convert.ToInt32(dr["PosicionTipoArmaId"]);
                        ejercicioTipoArmaMenorComesclaDTO.DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]);
                        ejercicioTipoArmaMenorComesclaDTO.CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]);
                        ejercicioTipoArmaMenorComesclaDTO.PorcentajeEvaluacion = Convert.ToInt32(dr["PorcentajeEvaluacion"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioTipoArmaMenorComesclaDTO;
        }

        public string ActualizaFormato(EjercicioTipoArmaMenorComesclaDTO ejercicioTipoArmaMenorComesclaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComesclaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EjercicioTipoArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorId"].Value = ejercicioTipoArmaMenorComesclaDTO.EjercicioTipoArmaMenorId;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTipoArmaMenorComesclaDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTipoArmaMenorComesclaDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTipoArmaMenorComesclaDTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTipoArmaMenorComesclaDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTipoArmaMenorComesclaDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTipoArmaMenorComesclaDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTipoArmaMenorComesclaDTO.CantidadTiro;

                    cmd.Parameters.Add("@PorcentajeEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeEvaluacion"].Value = ejercicioTipoArmaMenorComesclaDTO.PorcentajeEvaluacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComesclaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EjercicioTipoArmaMenorComesclaDTO ejercicioTipoArmaMenorComesclaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorComesclaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorId"].Value = ejercicioTipoArmaMenorComesclaDTO.EjercicioTipoArmaMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorComesclaDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EjercicioTipoArmaMenorComesclaDTO> ejercicioTipoArmaMenorComesclaDTO)
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
                            foreach (var item in ejercicioTipoArmaMenorComesclaDTO)
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
