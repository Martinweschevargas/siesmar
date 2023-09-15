using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combima1
{
    public class SituacionOperatividadEquipoCombima1DAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionOperatividadEquipoCombima1DTO> ObtenerLista()
        {
            List<SituacionOperatividadEquipoCombima1DTO> lista = new List<SituacionOperatividadEquipoCombima1DTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoCombima1Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadEquipoCombima1DTO()
                        {
                            SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]),
                            DescripcionMaterial = dr["DescripcionMaterial"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamenteo = dr["DescDepartamenteo"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observacion = dr["Observacion"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionOperatividadEquipoCombima1DTO situacionOperatividadEquipoCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoCombima1Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = situacionOperatividadEquipoCombima1DTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoCombima1DTO.Cantidad;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = situacionOperatividadEquipoCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,100);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoCombima1DTO.Ubicacion;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperatividadEquipoCombima1DTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionOperatividadEquipoCombima1DTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoCombima1DTO.Observacion;


                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoCombima1DTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadEquipoCombima1DTO BuscarFormato(int Codigo)
        {
            SituacionOperatividadEquipoCombima1DTO situacionOperatividadEquipoCombima1DTO = new SituacionOperatividadEquipoCombima1DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoCombima1Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionOperatividadEquipoCombima1DTO.SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]);
                        situacionOperatividadEquipoCombima1DTO.DescripcionMaterialId = Convert.ToInt32(dr["DescripcionMaterialId"]);
                        situacionOperatividadEquipoCombima1DTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        situacionOperatividadEquipoCombima1DTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        situacionOperatividadEquipoCombima1DTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionOperatividadEquipoCombima1DTO.DescDepartamenteo = dr["DescDepartamenteo"].ToString();
                        situacionOperatividadEquipoCombima1DTO.DescProvincia = dr["DescProvincia"].ToString();
                        situacionOperatividadEquipoCombima1DTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        situacionOperatividadEquipoCombima1DTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        situacionOperatividadEquipoCombima1DTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperatividadEquipoCombima1DTO;
        }

        public string ActualizaFormato(SituacionOperatividadEquipoCombima1DTO situacionOperatividadEquipoCombima1DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoCombima1Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoCombima1DTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@DescripcionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DescripcionMaterialId"].Value = situacionOperatividadEquipoCombima1DTO.DescripcionMaterialId;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoCombima1DTO.Cantidad;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = situacionOperatividadEquipoCombima1DTO.UnidadNavalId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,100);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoCombima1DTO.Ubicacion;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = situacionOperatividadEquipoCombima1DTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = situacionOperatividadEquipoCombima1DTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoCombima1DTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoCombima1DTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionOperatividadEquipoCombima1DTO situacionOperatividadEquipoCombima1DTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoCombima1Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoCombima1DTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoCombima1DTO.UsuarioIngresoRegistro;

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
        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoCombima1DTO> situacionOperatividadEquipoCombima1DTO)
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
                            foreach (var item in situacionOperatividadEquipoCombima1DTO)
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
