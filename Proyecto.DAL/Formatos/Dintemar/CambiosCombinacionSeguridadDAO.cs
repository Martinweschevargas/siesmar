using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class CambiosCombinacionSeguridadDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CambiosCombinacionSeguridadDTO> ObtenerLista(int? CargaId = null)
        {
            List<CambiosCombinacionSeguridadDTO> lista = new List<CambiosCombinacionSeguridadDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CambiosCombinacionSeguridadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CambiosCombinacionSeguridadDTO()
                        {
                            CambiosCombinacionSeguridadId = Convert.ToInt32(dr["CambiosCombinacionSeguridadId"]),
                            DescMes =  dr["DescMes"].ToString(),
                            AnioCambioCombinacion = Convert.ToInt32(dr["AnioCambioCombinacion"]),
                            DescZonaNaval =  dr["DescZonaNaval"].ToString(),
                            CambiosCombinacionSeguridad = Convert.ToInt32(dr["CambiosCombinacionSeguridad"]),
                            PorcentajeAvanceCambio = Convert.ToInt32(dr["PorcentajeAvanceCambio"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CambiosCombinacionSeguridadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = cambiosCombinacionSeguridadDTO.MesId;

                    cmd.Parameters.Add("@AnioCambioCombinacion", SqlDbType.Int);
                    cmd.Parameters["@AnioCambioCombinacion"].Value = cambiosCombinacionSeguridadDTO.AnioCambioCombinacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = cambiosCombinacionSeguridadDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CambiosCombinacionSeguridad", SqlDbType.Int);
                    cmd.Parameters["@CambiosCombinacionSeguridad"].Value = cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridad;

                    cmd.Parameters.Add("@PorcentajeAvanceCambio", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceCambio"].Value = cambiosCombinacionSeguridadDTO.PorcentajeAvanceCambio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = cambiosCombinacionSeguridadDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cambiosCombinacionSeguridadDTO.UsuarioIngresoRegistro;

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

        public CambiosCombinacionSeguridadDTO BuscarFormato(int Codigo)
        {
            CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO = new CambiosCombinacionSeguridadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CambiosCombinacionSeguridadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CambiosCombinacionSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@CambiosCombinacionSeguridadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridadId = Convert.ToInt32(dr["CambiosCombinacionSeguridadId"]);
                        cambiosCombinacionSeguridadDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        cambiosCombinacionSeguridadDTO.AnioCambioCombinacion = Convert.ToInt32(dr["AnioCambioCombinacion"]);
                        cambiosCombinacionSeguridadDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridad = Convert.ToInt32(dr["CambiosCombinacionSeguridad"]);
                        cambiosCombinacionSeguridadDTO.PorcentajeAvanceCambio = Convert.ToInt32(dr["PorcentajeAvanceCambio"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cambiosCombinacionSeguridadDTO;
        }

        public string ActualizaFormato(CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CambiosCombinacionSeguridadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CambiosCombinacionSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@CambiosCombinacionSeguridadId"].Value = cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridadId;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = cambiosCombinacionSeguridadDTO.MesId;

                    cmd.Parameters.Add("@AnioCambioCombinacion", SqlDbType.Int);
                    cmd.Parameters["@AnioCambioCombinacion"].Value = cambiosCombinacionSeguridadDTO.AnioCambioCombinacion;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = cambiosCombinacionSeguridadDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@CambiosCombinacionSeguridad", SqlDbType.Int);
                    cmd.Parameters["@CambiosCombinacionSeguridad"].Value = cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridad;

                    cmd.Parameters.Add("@PorcentajeAvanceCambio", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceCambio"].Value = cambiosCombinacionSeguridadDTO.PorcentajeAvanceCambio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cambiosCombinacionSeguridadDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CambiosCombinacionSeguridadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CambiosCombinacionSeguridadId", SqlDbType.Int);
                    cmd.Parameters["@CambiosCombinacionSeguridadId"].Value = cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cambiosCombinacionSeguridadDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CambiosCombinacionSeguridadRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CambiosCombinacionSeguridad", SqlDbType.Structured);
                    cmd.Parameters["@CambiosCombinacionSeguridad"].TypeName = "Formato.CambiosCombinacionSeguridad";
                    cmd.Parameters["@CambiosCombinacionSeguridad"].Value = datos;

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
