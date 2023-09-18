using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Comescla;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combasnai
{
    public class EjercicioTiroArmaMenorCombasnaiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EjercicioTiroArmaMenorCombasnaiDTO> ObtenerLista()
        {
            List<EjercicioTiroArmaMenorCombasnaiDTO> lista = new List<EjercicioTiroArmaMenorCombasnaiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombasnaiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioTiroArmaMenorCombasnaiDTO()
                        {
                            EjercicioTiroArmaMenorId = Convert.ToInt32(dr["EjercicioTiroArmaMenorId"]),
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

        public string AgregarRegistro(EjercicioTiroArmaMenorCombasnaiDTO ejercicioTiroArmaMenorCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombasnaiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTiroArmaMenorCombasnaiDTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTiroArmaMenorCombasnaiDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTiroArmaMenorCombasnaiDTO.CantidadTiro;

                    cmd.Parameters.Add("@PorcentajeEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeEvaluacion"].Value = ejercicioTiroArmaMenorCombasnaiDTO.PorcentajeEvaluacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorCombasnaiDTO.UsuarioIngresoRegistro;

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

        public EjercicioTiroArmaMenorCombasnaiDTO BuscarFormato(int Codigo)
        {
            EjercicioTiroArmaMenorCombasnaiDTO ejercicioTiroArmaMenorCombasnaiDTO = new EjercicioTiroArmaMenorCombasnaiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombasnaiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ejercicioTiroArmaMenorCombasnaiDTO.EjercicioTiroArmaMenorId = Convert.ToInt32(dr["EjercicioTipoArmaMenorId"]);
                        ejercicioTiroArmaMenorCombasnaiDTO.TipoPersonalMilitarId = Convert.ToInt32(dr["TipoPersonalMilitarId"]);
                        ejercicioTiroArmaMenorCombasnaiDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        ejercicioTiroArmaMenorCombasnaiDTO.FechaEjercicio = Convert.ToDateTime(dr["FechaEjercicio"]).ToString("yyy-MM-dd");
                        ejercicioTiroArmaMenorCombasnaiDTO.TipoArmamentoId = Convert.ToInt32(dr["TipoArmamentoId"]);
                        ejercicioTiroArmaMenorCombasnaiDTO.PosicionTipoArmaId = Convert.ToInt32(dr["PosicionTipoArmaId"]);
                        ejercicioTiroArmaMenorCombasnaiDTO.DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]);
                        ejercicioTiroArmaMenorCombasnaiDTO.CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]);
                        ejercicioTiroArmaMenorCombasnaiDTO.PorcentajeEvaluacion = Convert.ToInt32(dr["PorcentajeEvaluacion"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioTiroArmaMenorCombasnaiDTO;
        }

        public string ActualizaFormato(EjercicioTiroArmaMenorCombasnaiDTO ejercicioTiroArmaMenorCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombasnaiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EjercicioTiroArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTiroArmaMenorId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.EjercicioTiroArmaMenorId;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTiroArmaMenorCombasnaiDTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTiroArmaMenorCombasnaiDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTiroArmaMenorCombasnaiDTO.CantidadTiro;

                    cmd.Parameters.Add("@PorcentajeEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeEvaluacion"].Value = ejercicioTiroArmaMenorCombasnaiDTO.PorcentajeEvaluacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorCombasnaiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EjercicioTiroArmaMenorCombasnaiDTO ejercicioTiroArmaMenorCombasnaiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombasnaiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTiroArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArEjercicioTiroArmaMenorIdmaMenorId"].Value = ejercicioTiroArmaMenorCombasnaiDTO.EjercicioTiroArmaMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorCombasnaiDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EjercicioTiroArmaMenorCombasnaiDTO> evaluacionAlistPersonalCombasnaiDTO)
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
                            foreach (var item in evaluacionAlistPersonalCombasnaiDTO)
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
