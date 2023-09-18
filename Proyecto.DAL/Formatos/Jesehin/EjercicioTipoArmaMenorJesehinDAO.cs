using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class EjercicioTipoArmaMenorJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EjercicioTipoArmaMenorJesehinDTO> ObtenerLista()
        {
            List<EjercicioTipoArmaMenorJesehinDTO> lista = new List<EjercicioTipoArmaMenorJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EjercicioTipoArmaMenorJesehinDTO()
                        {
                            EjercicioTipoArmaMenorJesehinId = Convert.ToInt32(dr["EjercicioTipoArmaMenorJesehinId"]),
                            DescTipoPersonalMilitar = dr["DescTipoPersonalMilitar"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            FechaEjercicioTipo = (dr["FechaEjercicioTipo"].ToString()).Split(" ", StringSplitOptions.None)[0],
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

        public string AgregarRegistro(EjercicioTipoArmaMenorJesehinDTO ejercicioTipoArmaMenorJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTipoArmaMenorJesehinDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTipoArmaMenorJesehinDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicioTipo", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicioTipo"].Value = ejercicioTipoArmaMenorJesehinDTO.FechaEjercicioTipo;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTipoArmaMenorJesehinDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTipoArmaMenorJesehinDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTipoArmaMenorJesehinDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTipoArmaMenorJesehinDTO.CantidadTiro;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorJesehinDTO.UsuarioIngresoRegistro;

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

        public EjercicioTipoArmaMenorJesehinDTO BuscarFormato(int Codigo)
        {
            EjercicioTipoArmaMenorJesehinDTO ejercicioTipoArmaMenorJesehinDTO = new EjercicioTipoArmaMenorJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorJesehinId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorJesehinId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ejercicioTipoArmaMenorJesehinDTO.EjercicioTipoArmaMenorJesehinId = Convert.ToInt32(dr["EjercicioTipoArmaMenorJesehinId"]);
                        ejercicioTipoArmaMenorJesehinDTO.TipoPersonalMilitarId = Convert.ToInt32(dr["TipoPersonalMilitarId"]);
                        ejercicioTipoArmaMenorJesehinDTO.GradoPersonalMilitarId = Convert.ToInt32(dr["GradoPersonalMilitarId"]);
                        ejercicioTipoArmaMenorJesehinDTO.FechaEjercicioTipo = Convert.ToDateTime(dr["FechaEjercicioTipo"]).ToString("yyy-MM-dd");
                        ejercicioTipoArmaMenorJesehinDTO.TipoArmamentoId = Convert.ToInt32(dr["TipoArmamentoId"]);
                        ejercicioTipoArmaMenorJesehinDTO.PosicionTipoArmaId = Convert.ToInt32(dr["PosicionTipoArmaId"]);
                        ejercicioTipoArmaMenorJesehinDTO.DistanciaMetros = Convert.ToDecimal(dr["DistanciaMetros"]);
                        ejercicioTipoArmaMenorJesehinDTO.CantidadTiro = Convert.ToInt32(dr["CantidadTiro"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ejercicioTipoArmaMenorJesehinDTO;
        }

        public string ActualizaFormato(EjercicioTipoArmaMenorJesehinDTO ejercicioTipoArmaMenorJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorJesehinId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorJesehinId"].Value = ejercicioTipoArmaMenorJesehinDTO.EjercicioTipoArmaMenorJesehinId;

                    cmd.Parameters.Add("@TipoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@TipoPersonalMilitarId"].Value = ejercicioTipoArmaMenorJesehinDTO.TipoPersonalMilitarId;

                    cmd.Parameters.Add("@GradoPersonalMilitarId", SqlDbType.Int);
                    cmd.Parameters["@GradoPersonalMilitarId"].Value = ejercicioTipoArmaMenorJesehinDTO.GradoPersonalMilitarId;

                    cmd.Parameters.Add("@FechaEjercicioTipo", SqlDbType.Date);
                    cmd.Parameters["@FechaEjercicioTipo"].Value = ejercicioTipoArmaMenorJesehinDTO.FechaEjercicioTipo;

                    cmd.Parameters.Add("@TipoArmamentoId", SqlDbType.Int);
                    cmd.Parameters["@TipoArmamentoId"].Value = ejercicioTipoArmaMenorJesehinDTO.TipoArmamentoId;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = ejercicioTipoArmaMenorJesehinDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DistanciaMetros", SqlDbType.Decimal);
                    cmd.Parameters["@DistanciaMetros"].Value = ejercicioTipoArmaMenorJesehinDTO.DistanciaMetros;

                    cmd.Parameters.Add("@CantidadTiro", SqlDbType.Int);
                    cmd.Parameters["@CantidadTiro"].Value = ejercicioTipoArmaMenorJesehinDTO.CantidadTiro;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EjercicioTipoArmaMenorJesehinDTO ejercicioTipoArmaMenorJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EjercicioTipoArmaMenorJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EjercicioTipoArmaMenorJesehinId", SqlDbType.Int);
                    cmd.Parameters["@EjercicioTipoArmaMenorJesehinId"].Value = ejercicioTipoArmaMenorJesehinDTO.EjercicioTipoArmaMenorJesehinId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ejercicioTipoArmaMenorJesehinDTO.UsuarioIngresoRegistro;

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


        public bool InsercionMasiva(IEnumerable<EjercicioTipoArmaMenorJesehinDTO> ejercicioTipoArmaMenorJesehinDTO)
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
                        cmd.CommandText = "insert into FIEstudiosInvestigacionHistoricaNaval " +
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
                            foreach (var item in ejercicioTipoArmaMenorJesehinDTO)
                            {
                                //cmd.Parameters["@NombreInvestigacion"].Value = item.NombreActividadCultural;
                                //cmd.Parameters["@TipoEstudioInvestigacionId"].Value = item.TipoActividadCulturalId;
                                //cmd.Parameters["@FechaInicioInvestigacion"].Value = Convert.ToDateTime(item.FechaInicioActCultural);
                                //cmd.Parameters["@FechaTerminoInvestigacion"].Value = Convert.ToDateTime(item.FechaTerminoActCultural);
                                //cmd.Parameters["@ResponsableInvestigacion"].Value = item.LugarActCultural;
                                //cmd.Parameters["@SolicitanteInvestigacion"].Value = item.AuspiciadoresActCultural;
                                //cmd.Parameters["@NParticipantesActCultural"].Value = item.NParticipantesActCultural;
                                //cmd.Parameters["@InversionActCultural"].Value = item.InversionActCultural;
                                //cmd.Parameters["@Usuario"].Value = item.UsuarioIngresoRegistro;
                                //cmd.Parameters["@IP"].Value = UtilitariosGlobales.obtenerDireccionIp();
                                //cmd.Parameters["@MAC"].Value = UtilitariosGlobales.obtenerDireccionMac();
                                //cmd.Parameters["@UsuarioDB"].Value = UtilitariosGlobales.obtenerUsuarioDB();
                                //cmd.Parameters["@Year"].Value = DateTime.Now.Year;
                                //cmd.Parameters["@Mes"].Value = DateTime.Now.Month;
                                //cmd.Parameters["@Dia"].Value = DateTime.Now.Day;
                                //cmd.ExecuteNonQuery();
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
