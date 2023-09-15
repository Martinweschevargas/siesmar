using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesehin
{
    public class AlistamientoCombustibleLubricanteJesehinDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoCombustibleLubricanteJesehinDTO> ObtenerLista()
        {
            List<AlistamientoCombustibleLubricanteJesehinDTO> lista = new List<AlistamientoCombustibleLubricanteJesehinDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteJesehinListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoCombustibleLubricanteJesehinDTO()
                        {
                            AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Articulo = dr["Articulo"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            UnidadMedida = dr["UnidadMedida"].ToString(),
                            Cargo = dr["Cargo"].ToString(),
                            Aumento = dr["Aumento"].ToString(),
                            Consumo = dr["Consumo"].ToString(),
                            Existencia = dr["Existencia"].ToString(),
                            PromedioPonderado = Convert.ToDecimal(dr["PromedioPonderado"]),
                            SubPromedioParcial = Convert.ToDecimal(dr["SubPromedioParcial"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteJesehinDTO alistamientoCombustibleLubricanteJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteJesehinRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoCombustibleLubricanteJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = alistamientoCombustibleLubricanteJesehinDTO.AlistamientoCombustibleLubricante2Id;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistamientoCombustibleLubricanteJesehinDTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@SubPromedioParcial"].Value = alistamientoCombustibleLubricanteJesehinDTO.SubPromedioParcial;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteJesehinDTO.UsuarioIngresoRegistro;

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

        public AlistamientoCombustibleLubricanteJesehinDTO BuscarFormato(int Codigo)
        {
            AlistamientoCombustibleLubricanteJesehinDTO alistamientoCombustibleLubricanteJesehinDTO = new AlistamientoCombustibleLubricanteJesehinDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteJesehinEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoCombustibleLubricanteJesehinDTO.AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]);
                        alistamientoCombustibleLubricanteJesehinDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistamientoCombustibleLubricanteJesehinDTO.DescUnidadNaval = dr["DescUnidadNaval"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.AlistamientoCombustibleLubricante2Id = Convert.ToInt32(dr["AlistamientoCombustibleLubricante2Id"]);
                        alistamientoCombustibleLubricanteJesehinDTO.Articulo = dr["Articulo"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.Equipo = dr["Equipo"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.UnidadMedida = dr["UnidadMedida"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.Cargo = dr["Cargo"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.Aumento = dr["Aumento"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.Consumo = dr["Consumo"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.Existencia = dr["Existencia"].ToString();
                        alistamientoCombustibleLubricanteJesehinDTO.PromedioPonderado = Convert.ToDecimal(dr["PromedioPonderado"]);
                        alistamientoCombustibleLubricanteJesehinDTO.SubPromedioParcial = Convert.ToDecimal(dr["SubPromedioParcial"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoCombustibleLubricanteJesehinDTO;
        }

        public string ActualizaFormato(AlistamientoCombustibleLubricanteJesehinDTO alistamientoCombustibleLubricanteJesehinDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteJesehinActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteJesehinDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistamientoCombustibleLubricanteJesehinDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = alistamientoCombustibleLubricanteJesehinDTO.AlistamientoCombustibleLubricante2Id;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistamientoCombustibleLubricanteJesehinDTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@SubPromedioParcial"].Value = alistamientoCombustibleLubricanteJesehinDTO.SubPromedioParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteJesehinDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoCombustibleLubricanteJesehinDTO alistamientoCombustibleLubricanteJesehinDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoCombustibleLubricanteJesehinEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistamientoCombustibleLubricanteJesehinDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoCombustibleLubricanteJesehinDTO.UsuarioIngresoRegistro;

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

        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteJesehinDTO> emisionNotaPrensaDTO)
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
