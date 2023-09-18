using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class AlistamientoMaterialComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMaterialComfasDTO> ObtenerLista()
        {
            List<AlistamientoMaterialComfasDTO> lista = new List<AlistamientoMaterialComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialComfasDTO()
                        {
                            AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescCapacidadOperativa = dr["DescCapacidadOperativa"].ToString(),
                            CapacidadIntrinseca1 = Convert.ToInt32(dr["CapacidadIntrinseca1"]),
                            PonderacionCapacidad1 = Convert.ToInt32(dr["PonderacionCapacidad1"]),
                            Subclasificacion2 = Convert.ToInt32(dr["Subclasificacion2"]),
                            PonderacionCapacidad2 = Convert.ToInt32(dr["PonderacionCapacidad2"]),
                            Subclasificacion3 = Convert.ToInt32(dr["Subclasificacion3"]),
                            PonderacionCapacidad3 = Convert.ToInt32(dr["PonderacionCapacidad3"]),
                            Requerido = Convert.ToInt32(dr["Requerido"]),
                            Operativo = Convert.ToInt32(dr["Operativo"]),
                            NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMaterialComfasDTO alistamientoMaterialComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMaterialComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = alistamientoMaterialComfasDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@CapacidadIntrinseca1", SqlDbType.Int);
                    cmd.Parameters["@CapacidadIntrinseca1"].Value = alistamientoMaterialComfasDTO.CapacidadIntrinseca1;

                    cmd.Parameters.Add("@PonderacionCapacidad1", SqlDbType.Int);
                    cmd.Parameters["@PonderacionCapacidad1"].Value = alistamientoMaterialComfasDTO.PonderacionCapacidad1;

                    cmd.Parameters.Add("@Subclasificacion2", SqlDbType.Int);
                    cmd.Parameters["@Subclasificacion2"].Value = alistamientoMaterialComfasDTO.Subclasificacion2;

                    cmd.Parameters.Add("@PonderacionCapacidad2", SqlDbType.Int);
                    cmd.Parameters["@PonderacionCapacidad2"].Value = alistamientoMaterialComfasDTO.PonderacionCapacidad2;

                    cmd.Parameters.Add("@Subclasificacion3", SqlDbType.Int);
                    cmd.Parameters["@Subclasificacion3"].Value = alistamientoMaterialComfasDTO.Subclasificacion3;

                    cmd.Parameters.Add("@PonderacionCapacidad3", SqlDbType.Int);
                    cmd.Parameters["@PonderacionCapacidad3"].Value = alistamientoMaterialComfasDTO.PonderacionCapacidad3;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialComfasDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialComfasDTO.Operativo;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialComfasDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComfasDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialComfasDTO BuscarFormato(int Codigo)
        {
            AlistamientoMaterialComfasDTO alistamientoMaterialComfasDTO = new AlistamientoMaterialComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoMaterialComfasDTO.AlistamientoMaterialId = Convert.ToInt32(dr["AlistamientoMaterialId"]);
                        alistamientoMaterialComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistamientoMaterialComfasDTO.CapacidadOperativaId = Convert.ToInt32(dr["CapacidadOperativaId"]);
                        alistamientoMaterialComfasDTO.CapacidadIntrinseca1 = Convert.ToInt32(dr["CapacidadIntrinseca1"]);
                        alistamientoMaterialComfasDTO.PonderacionCapacidad1 = Convert.ToInt32(dr["PonderacionCapacidad1"]);
                        alistamientoMaterialComfasDTO.Subclasificacion2 = Convert.ToInt32(dr["Subclasificacion2"]);
                        alistamientoMaterialComfasDTO.PonderacionCapacidad2 = Convert.ToInt32(dr["PonderacionCapacidad2"]);
                        alistamientoMaterialComfasDTO.Subclasificacion3 = Convert.ToInt32(dr["Subclasificacion3"]);
                        alistamientoMaterialComfasDTO.PonderacionCapacidad3 = Convert.ToInt32(dr["PonderacionCapacidad3"]);
                        alistamientoMaterialComfasDTO.Requerido = Convert.ToInt32(dr["Requerido"]);
                        alistamientoMaterialComfasDTO.Operativo = Convert.ToInt32(dr["Operativo"]);
                        alistamientoMaterialComfasDTO.NivelAlistamientoParcial = Convert.ToDecimal(dr["NivelAlistamientoParcial"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialComfasDTO;
        }

        public string ActualizaFormato(AlistamientoMaterialComfasDTO alistamientoMaterialComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialComfasDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMaterialComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@CapacidadOperativaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaId"].Value = alistamientoMaterialComfasDTO.CapacidadOperativaId;

                    cmd.Parameters.Add("@CapacidadIntrinseca1", SqlDbType.Int);
                    cmd.Parameters["@CapacidadIntrinseca1"].Value = alistamientoMaterialComfasDTO.CapacidadIntrinseca1;

                    cmd.Parameters.Add("@PonderacionCapacidad1", SqlDbType.Int);
                    cmd.Parameters["@PonderacionCapacidad1"].Value = alistamientoMaterialComfasDTO.PonderacionCapacidad1;

                    cmd.Parameters.Add("@Subclasificacion2", SqlDbType.Int);
                    cmd.Parameters["@Subclasificacion2"].Value = alistamientoMaterialComfasDTO.Subclasificacion2;

                    cmd.Parameters.Add("@PonderacionCapacidad2", SqlDbType.Int);
                    cmd.Parameters["@PonderacionCapacidad2"].Value = alistamientoMaterialComfasDTO.PonderacionCapacidad2;

                    cmd.Parameters.Add("@Subclasificacion3", SqlDbType.Int);
                    cmd.Parameters["@Subclasificacion3"].Value = alistamientoMaterialComfasDTO.Subclasificacion3;

                    cmd.Parameters.Add("@PonderacionCapacidad3", SqlDbType.Int);
                    cmd.Parameters["@PonderacionCapacidad3"].Value = alistamientoMaterialComfasDTO.PonderacionCapacidad3;

                    cmd.Parameters.Add("@Requerido", SqlDbType.Int);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialComfasDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.Int);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialComfasDTO.Operativo;

                    cmd.Parameters.Add("@NivelAlistamientoParcial", SqlDbType.Decimal);
                    cmd.Parameters["@NivelAlistamientoParcial"].Value = alistamientoMaterialComfasDTO.NivelAlistamientoParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMaterialComfasDTO alistamientoMaterialComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMaterialComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialId"].Value = alistamientoMaterialComfasDTO.AlistamientoMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialComfasDTO> alistamientoMaterialComfasDTO)
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
                            foreach (var item in alistamientoMaterialComfasDTO)
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
