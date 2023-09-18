using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfas
{
    public class AlistamientoMunicionComfasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoMunicionComfasDTO> ObtenerLista()
        {
            List<AlistamientoMunicionComfasDTO> lista = new List<AlistamientoMunicionComfasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMunicionComfasDTO()
                        {
                            AlistamientoMunicionComfasId = Convert.ToInt32(dr["AlistamientoMunicionComfasId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaMunicion = dr["DescSistemaMunicion"].ToString(),
                            DescSubsistemaMunicion = dr["DescSubsistemaMunicion"].ToString(),
                            Equipo = Convert.ToInt32(dr["Equipo"]),
                            Municion = Convert.ToInt32(dr["Municion"]),
                            Existente = Convert.ToInt32(dr["Existente"]),
                            Necesaria = Convert.ToInt32(dr["Necesaria"]),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoMunicionComfasDTO alistamientoMunicionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMunicionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@SistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaMunicionId"].Value = alistamientoMunicionComfasDTO.SistemaMunicionId;

                    cmd.Parameters.Add("@SubsistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaMunicionId"].Value = alistamientoMunicionComfasDTO.SubsistemaMunicionId;

                    cmd.Parameters.Add("@Equipo", SqlDbType.Int);
                    cmd.Parameters["@Equipo"].Value = alistamientoMunicionComfasDTO.Equipo;

                    cmd.Parameters.Add("@Municion", SqlDbType.Int);
                    cmd.Parameters["@Municion"].Value = alistamientoMunicionComfasDTO.Municion;

                    cmd.Parameters.Add("@Existente", SqlDbType.Int);
                    cmd.Parameters["@Existente"].Value = alistamientoMunicionComfasDTO.Existente;

                    cmd.Parameters.Add("@Necesaria", SqlDbType.Int);
                    cmd.Parameters["@Necesaria"].Value = alistamientoMunicionComfasDTO.Necesaria;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = alistamientoMunicionComfasDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfasDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMunicionComfasDTO BuscarFormato(int Codigo)
        {
            AlistamientoMunicionComfasDTO alistamientoMunicionComfasDTO = new AlistamientoMunicionComfasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfasId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfasId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoMunicionComfasDTO.AlistamientoMunicionComfasId = Convert.ToInt32(dr["AlistamientoMunicionComfasId"]);
                        alistamientoMunicionComfasDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistamientoMunicionComfasDTO.SistemaMunicionId = Convert.ToInt32(dr["SistemaMunicionId"]);
                        alistamientoMunicionComfasDTO.SubsistemaMunicionId = Convert.ToInt32(dr["SubsistemaMunicionId"]);
                        alistamientoMunicionComfasDTO.Equipo = Convert.ToInt32(dr["Equipo"]);
                        alistamientoMunicionComfasDTO.Municion = Convert.ToInt32(dr["Municion"]);
                        alistamientoMunicionComfasDTO.Existente = Convert.ToInt32(dr["Existente"]);
                        alistamientoMunicionComfasDTO.Necesaria = Convert.ToInt32(dr["Necesaria"]);
                        alistamientoMunicionComfasDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMunicionComfasDTO;
        }

        public string ActualizaFormato(AlistamientoMunicionComfasDTO alistamientoMunicionComfasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoMunicionComfasId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfasId"].Value = alistamientoMunicionComfasDTO.AlistamientoMunicionComfasId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoMunicionComfasDTO.UnidadNavalId;

                    cmd.Parameters.Add("@SistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaMunicionId"].Value = alistamientoMunicionComfasDTO.SistemaMunicionId;

                    cmd.Parameters.Add("@SubsistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaMunicionId"].Value = alistamientoMunicionComfasDTO.SubsistemaMunicionId;

                    cmd.Parameters.Add("@Equipo", SqlDbType.Int);
                    cmd.Parameters["@Equipo"].Value = alistamientoMunicionComfasDTO.Equipo;

                    cmd.Parameters.Add("@Municion", SqlDbType.Int);
                    cmd.Parameters["@Municion"].Value = alistamientoMunicionComfasDTO.Municion;

                    cmd.Parameters.Add("@Existente", SqlDbType.Int);
                    cmd.Parameters["@Existente"].Value = alistamientoMunicionComfasDTO.Existente;

                    cmd.Parameters.Add("@Necesaria", SqlDbType.Int);
                    cmd.Parameters["@Necesaria"].Value = alistamientoMunicionComfasDTO.Necesaria;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = alistamientoMunicionComfasDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoMunicionComfasDTO alistamientoMunicionComfasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoMunicionComfasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionComfasId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionComfasId"].Value = alistamientoMunicionComfasDTO.AlistamientoMunicionComfasId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMunicionComfasDTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<AlistamientoMunicionComfasDTO> alistamientoMunicionComfasDTO)
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
                            foreach (var item in alistamientoMunicionComfasDTO)
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
