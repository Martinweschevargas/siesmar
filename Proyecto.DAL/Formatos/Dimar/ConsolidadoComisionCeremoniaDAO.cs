using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class ConsolidadoComisionCeremoniaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConsolidadoComisionCeremoniaDTO> ObtenerLista(int? CargaId = null)
        {
            List<ConsolidadoComisionCeremoniaDTO> lista = new List<ConsolidadoComisionCeremoniaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConsolidadoComisionCeremoniaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ConsolidadoComisionCeremoniaDTO()
                        {
                            ConsolidadoComisionCeremoniaId = Convert.ToInt32(dr["ConsolidadoComisionCeremoniaId"]),
                            FechaActividad = (dr["FechaActividad"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            Actividad = dr["Actividad"].ToString(),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            Costo = Convert.ToDecimal(dr["Costo"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsolidadoComisionCeremoniaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaActividad", SqlDbType.Date);
                    cmd.Parameters["@FechaActividad"].Value = consolidadoComisionCeremoniaDTO.FechaActividad;

                    cmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Actividad"].Value = consolidadoComisionCeremoniaDTO.Actividad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = consolidadoComisionCeremoniaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = consolidadoComisionCeremoniaDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Costo", SqlDbType.Decimal);
                    cmd.Parameters["@Costo"].Value = consolidadoComisionCeremoniaDTO.Costo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = consolidadoComisionCeremoniaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consolidadoComisionCeremoniaDTO.UsuarioIngresoRegistro;

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

        public ConsolidadoComisionCeremoniaDTO BuscarFormato(int Codigo)
        {
            ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO = new ConsolidadoComisionCeremoniaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsolidadoComisionCeremoniaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsolidadoComisionCeremoniaId", SqlDbType.Int);
                    cmd.Parameters["@ConsolidadoComisionCeremoniaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        consolidadoComisionCeremoniaDTO.ConsolidadoComisionCeremoniaId = Convert.ToInt32(dr["ConsolidadoComisionCeremoniaId"]);
                        consolidadoComisionCeremoniaDTO.FechaActividad = Convert.ToDateTime(dr["FechaActividad"]).ToString("yyy-MM-dd");
                        consolidadoComisionCeremoniaDTO.Actividad = dr["Actividad"].ToString();
                        consolidadoComisionCeremoniaDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        consolidadoComisionCeremoniaDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                        consolidadoComisionCeremoniaDTO.Costo = Convert.ToDecimal(dr["Costo"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return consolidadoComisionCeremoniaDTO;
        }

        public string ActualizaFormato(ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsolidadoComisionCeremoniaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ConsolidadoComisionCeremoniaId", SqlDbType.Int);
                    cmd.Parameters["@ConsolidadoComisionCeremoniaId"].Value = consolidadoComisionCeremoniaDTO.ConsolidadoComisionCeremoniaId;

                    cmd.Parameters.Add("@FechaActividad", SqlDbType.Date);
                    cmd.Parameters["@FechaActividad"].Value = consolidadoComisionCeremoniaDTO.FechaActividad;

                    cmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 200);
                    cmd.Parameters["@Actividad"].Value = consolidadoComisionCeremoniaDTO.Actividad;

                    cmd.Parameters.Add("@CodigoUnidadMedida ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida "].Value = consolidadoComisionCeremoniaDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = consolidadoComisionCeremoniaDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@Costo", SqlDbType.Decimal);
                    cmd.Parameters["@Costo"].Value = consolidadoComisionCeremoniaDTO.Costo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consolidadoComisionCeremoniaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsolidadoComisionCeremoniaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsolidadoComisionCeremoniaId", SqlDbType.Int);
                    cmd.Parameters["@ConsolidadoComisionCeremoniaId"].Value = consolidadoComisionCeremoniaDTO.ConsolidadoComisionCeremoniaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consolidadoComisionCeremoniaDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_ConsolidadoComisionCeremoniaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsolidadoComisionCeremonia", SqlDbType.Structured);
                    cmd.Parameters["@ConsolidadoComisionCeremonia"].TypeName = "Formato.ConsolidadoComisionCeremonia";
                    cmd.Parameters["@ConsolidadoComisionCeremonia"].Value = datos;

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
    }
}