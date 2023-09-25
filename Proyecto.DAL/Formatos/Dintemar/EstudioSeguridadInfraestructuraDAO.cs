using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dintemar
{
    public class EstudioSeguridadInfraestructuraDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EstudioSeguridadInfraestructuraDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EstudioSeguridadInfraestructuraDTO> lista = new List<EstudioSeguridadInfraestructuraDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EstudioSeguridadInfraestructuraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstudioSeguridadInfraestructuraDTO()
                        {
                            EstudioSeguridadInfraestructuraId = Convert.ToInt32(dr["EstudioSeguridadInfraestructuraId"]),
                            DescMes =  dr["DescMes"].ToString(),
                            AnioEstudio = Convert.ToInt32(dr["AnioEstudio"]),
                            DescZonaNaval =  dr["DescZonaNaval"].ToString(),
                            EstudioSeguridadInfraestructura = Convert.ToInt32(dr["EstudioSeguridadInfraestructura"]),
                            PorcentajeAvanceEstudio = Convert.ToInt32(dr["PorcentajeAvanceEstudio"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioSeguridadInfraestructuraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = estudioSeguridadInfraestructuraDTO.NumeroMes;

                    cmd.Parameters.Add("@AnioEstudio", SqlDbType.Int);
                    cmd.Parameters["@AnioEstudio"].Value = estudioSeguridadInfraestructuraDTO.AnioEstudio;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = estudioSeguridadInfraestructuraDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstudioSeguridadInfraestructura", SqlDbType.Int);
                    cmd.Parameters["@EstudioSeguridadInfraestructura"].Value = estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructura;

                    cmd.Parameters.Add("@PorcentajeAvanceEstudio", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceEstudio"].Value = estudioSeguridadInfraestructuraDTO.PorcentajeAvanceEstudio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = estudioSeguridadInfraestructuraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioSeguridadInfraestructuraDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = estudioSeguridadInfraestructuraDTO.Fecha;


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

        public EstudioSeguridadInfraestructuraDTO BuscarFormato(int Codigo)
        {
            EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO = new EstudioSeguridadInfraestructuraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioSeguridadInfraestructuraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioSeguridadInfraestructuraId", SqlDbType.Int);
                    cmd.Parameters["@EstudioSeguridadInfraestructuraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructuraId = Convert.ToInt32(dr["EstudioSeguridadInfraestructuraId"]);
                        estudioSeguridadInfraestructuraDTO.NumeroMes = dr["NumeroMes"].ToString();
                        estudioSeguridadInfraestructuraDTO.AnioEstudio = Convert.ToInt32(dr["AnioEstudio"]);
                        estudioSeguridadInfraestructuraDTO.CodigoZonaNaval = dr["CodigoZonaNaval"].ToString();
                        estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructura = Convert.ToInt32(dr["EstudioSeguridadInfraestructura"]);
                        estudioSeguridadInfraestructuraDTO.PorcentajeAvanceEstudio = Convert.ToInt32(dr["PorcentajeAvanceEstudio"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return estudioSeguridadInfraestructuraDTO;
        }

        public string ActualizaFormato(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EstudioSeguridadInfraestructuraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioSeguridadInfraestructuraId", SqlDbType.Int);
                    cmd.Parameters["@EstudioSeguridadInfraestructuraId"].Value = estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructuraId;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = estudioSeguridadInfraestructuraDTO.NumeroMes;

                    cmd.Parameters.Add("@AnioEstudio", SqlDbType.Int);
                    cmd.Parameters["@AnioEstudio"].Value = estudioSeguridadInfraestructuraDTO.AnioEstudio;

                    cmd.Parameters.Add("@CodigoZonaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNaval"].Value = estudioSeguridadInfraestructuraDTO.CodigoZonaNaval;

                    cmd.Parameters.Add("@EstudioSeguridadInfraestructura", SqlDbType.Int);
                    cmd.Parameters["@EstudioSeguridadInfraestructura"].Value = estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructura;

                    cmd.Parameters.Add("@PorcentajeAvanceEstudio", SqlDbType.Int);
                    cmd.Parameters["@PorcentajeAvanceEstudio"].Value = estudioSeguridadInfraestructuraDTO.PorcentajeAvanceEstudio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioSeguridadInfraestructuraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EstudioSeguridadInfraestructuraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioSeguridadInfraestructuraId", SqlDbType.Int);
                    cmd.Parameters["@EstudioSeguridadInfraestructuraId"].Value = estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructuraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioSeguridadInfraestructuraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "EstudioSeguridadInfraestructura";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = estudioSeguridadInfraestructuraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = estudioSeguridadInfraestructuraDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_EstudioSeguridadInfraestructuraRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstudioSeguridadInfraestructura", SqlDbType.Structured);
                    cmd.Parameters["@EstudioSeguridadInfraestructura"].TypeName = "Formato.EstudioSeguridadInfraestructura";
                    cmd.Parameters["@EstudioSeguridadInfraestructura"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
