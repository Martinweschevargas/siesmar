using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combima1
{
    public class EjercicioTiroArmaMenorCombima1DAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EjercicioTiroArmaMenorCombima1DTO> ObtenerLista()
        {
            List<EjercicioTiroArmaMenorCombima1DTO> lista = new List<EjercicioTiroArmaMenorCombima1DTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombima1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioTiroArmaMenorCombima1DTO()
                        {
                            EjercicioTiroArmaMenorId = Convert.ToInt32(dr["EjercicioTiroArmaMenorId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGradoPersonalMilitar = dr["DescGradoPersonalMilitar"].ToString(),
                            FechaEjercicio = (dr["FechaEjercicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoArmamento = dr["DescTipoArmamento"].ToString(),
                            DescPosicionTipoArma = dr["DescPosicionTipoArma"].ToString(),
                            DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]),
                            CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]),



                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EjercicioTiroArmaMenorCombima1DTO ejercicioTiroArmaMenorCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombima1Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombima1DTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombima1DTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTiroArmaMenorCombima1DTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTiroArmaMenorCombima1DTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTiroArmaMenorCombima1DTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTiroArmaMenorCombima1DTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTiroArmaMenorCombima1DTO.CantidadTiro;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorCombima1DTO.UsuarioIngresoRegistro;

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

        public EjercicioTiroArmaMenorCombima1DTO BuscarFormato(int Codigo)
        {
            EjercicioTiroArmaMenorCombima1DTO ejercicioTiroArmaMenorCombima1DTO = new EjercicioTiroArmaMenorCombima1DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombima1Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ejercicioTiroArmaMenorCombima1DTO.EjercicioTiroArmaMenorId = Convert.ToInt32(dr["EjercicioTipoArmaMenorId"]);
                        ejercicioTiroArmaMenorCombima1DTO.TipoPersonalMilitarId = Convert.ToInt32(dr["TipoPersonalMilitarId"]);
                        ejercicioTiroArmaMenorCombima1DTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        ejercicioTiroArmaMenorCombima1DTO.FechaEjercicio = Convert.ToDateTime(dr["FechaEjercicio"]).ToString("yyy-MM-dd");
                        ejercicioTiroArmaMenorCombima1DTO.TipoArmamentoId = Convert.ToInt32(dr["TipoArmamentoId"]);
                        ejercicioTiroArmaMenorCombima1DTO.PosicionTipoArmaId = Convert.ToInt32(dr["PosicionTipoArmaId"]);
                        ejercicioTiroArmaMenorCombima1DTO.DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]);
                        ejercicioTiroArmaMenorCombima1DTO.CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioTiroArmaMenorCombima1DTO;
        }

        public string ActualizaFormato(EjercicioTiroArmaMenorCombima1DTO ejercicioTiroArmaMenorCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombima1Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EjercicioTiroArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTiroArmaMenorId"].Value = ejercicioTiroArmaMenorCombima1DTO.EjercicioTiroArmaMenorId;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombima1DTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTiroArmaMenorCombima1DTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicio", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicio"].Value = ejercicioTiroArmaMenorCombima1DTO.FechaEjercicio;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTiroArmaMenorCombima1DTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTiroArmaMenorCombima1DTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTiroArmaMenorCombima1DTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTiroArmaMenorCombima1DTO.CantidadTiro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorCombima1DTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EjercicioTiroArmaMenorCombima1DTO ejercicioTiroArmaMenorCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTiroArmaMenorCombima1Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTiroArmaMenorId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArEjercicioTiroArmaMenorIdmaMenorId"].Value = ejercicioTiroArmaMenorCombima1DTO.EjercicioTiroArmaMenorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTiroArmaMenorCombima1DTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<EjercicioTiroArmaMenorCombima1DTO> evaluacionAlistPersonalCombima1DTO)
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
                            foreach (var item in evaluacionAlistPersonalCombima1DTO)
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
