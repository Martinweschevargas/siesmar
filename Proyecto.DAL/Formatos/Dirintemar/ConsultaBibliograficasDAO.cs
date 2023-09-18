using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirintemar
{
    public class ConsultaBibliograficasDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ConsultaBibliograficasDTO> ObtenerLista()
        {
            List<ConsultaBibliograficasDTO> lista = new List<ConsultaBibliograficasDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ConsultaBibliofraficasListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ConsultaBibliograficasDTO()
                        {
                            ConsultaBibliograficaId = Convert.ToInt32(dr["ConsultaBibliograficaId"]),
                            FechaConsultaBibliografica = (dr["FechaConsultaBibliografica"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LibroPrestadoConsultaB = Convert.ToInt32(dr["LibroPrestadoConsultaB"]),
                            PublicacionePrestadaConsultaB = Convert.ToInt32(dr["PublicacionPrestadaConsultaB"]),
                            RevistaPrestada = Convert.ToInt32(dr["RevistaPrestada"]),
                            FolletoPrestado = Convert.ToInt32(dr["FolletoPrestado"]),
                            LecturaInterna = Convert.ToInt32(dr["LecturaInterna"]),
                            ReferenciaBibliografica = Convert.ToInt32(dr["ReferenciaBibliografica"]),
                            BusquedaEnSistema = Convert.ToInt32(dr["BusquedaEnSistema"]),
                            TotalConsultaBibliografica = Convert.ToInt32(dr["TotalConsultaBibliografica"]),
                            UsuariosLectoresConsultasB = Convert.ToInt32(dr["UsuariosLectoresConsultasB"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(ConsultaBibliograficasDTO consultaBibliograficasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsultaBibliofraficasRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaConsultaBibliografica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FechaConsultaBibliografica"].Value = consultaBibliograficasDTO.FechaConsultaBibliografica;

                    cmd.Parameters.Add("@LibroPrestadoConsultaB", SqlDbType.Int);
                    cmd.Parameters["@LibroPrestadoConsultaB"].Value = consultaBibliograficasDTO.LibroPrestadoConsultaB;

                    cmd.Parameters.Add("@PublicacionPrestadaConsultaB", SqlDbType.Int);
                    cmd.Parameters["@PublicacionPrestadaConsultaB"].Value = consultaBibliograficasDTO.PublicacionePrestadaConsultaB;

                    cmd.Parameters.Add("@RevistaPrestada", SqlDbType.Int);
                    cmd.Parameters["@RevistaPrestada"].Value = consultaBibliograficasDTO.RevistaPrestada;

                    cmd.Parameters.Add("@FolletoPrestado", SqlDbType.Int);
                    cmd.Parameters["@FolletoPrestado"].Value = consultaBibliograficasDTO.FolletoPrestado;

                    cmd.Parameters.Add("@LecturaInterna", SqlDbType.Int);
                    cmd.Parameters["@LecturaInterna"].Value = consultaBibliograficasDTO.LecturaInterna;

                    cmd.Parameters.Add("@ReferenciaBibliografica", SqlDbType.Int);
                    cmd.Parameters["@ReferenciaBibliografica"].Value = consultaBibliograficasDTO.ReferenciaBibliografica;

                    cmd.Parameters.Add("@BusquedaEnSistema", SqlDbType.Int);
                    cmd.Parameters["@BusquedaEnSistema"].Value = consultaBibliograficasDTO.BusquedaEnSistema;

                    cmd.Parameters.Add("@TotalConsultaBibliografica", SqlDbType.Int);
                    cmd.Parameters["@TotalConsultaBibliografica"].Value = consultaBibliograficasDTO.TotalConsultaBibliografica;

                    cmd.Parameters.Add("@UsuariosLectoresConsultasB", SqlDbType.Int);
                    cmd.Parameters["@UsuariosLectoresConsultasB"].Value = consultaBibliograficasDTO.UsuariosLectoresConsultasB;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consultaBibliograficasDTO.UsuarioIngresoRegistro;

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

        public ConsultaBibliograficasDTO BuscarFormato(int Codigo)
        {
            ConsultaBibliograficasDTO consultaBibliograficasDTO = new ConsultaBibliograficasDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsultaBibliofraficasEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsultaBibliograficaId", SqlDbType.Int);
                    cmd.Parameters["@ConsultaBibliograficaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        consultaBibliograficasDTO.ConsultaBibliograficaId = Convert.ToInt32(dr["ConsultaBibliograficaId"]);
                        consultaBibliograficasDTO.FechaConsultaBibliografica = Convert.ToDateTime(dr["FechaConsultaBibliografica"]).ToString("yyy-MM-dd");
                        consultaBibliograficasDTO.LibroPrestadoConsultaB = Convert.ToInt32(dr["LibroPrestadoConsultaB"]);
                        consultaBibliograficasDTO.PublicacionePrestadaConsultaB = Convert.ToInt32(dr["PublicacionPrestadaConsultaB"]);
                        consultaBibliograficasDTO.RevistaPrestada = Convert.ToInt32(dr["RevistaPrestada"]);
                        consultaBibliograficasDTO.FolletoPrestado = Convert.ToInt32(dr["FolletoPrestado"]);
                        consultaBibliograficasDTO.LecturaInterna = Convert.ToInt32(dr["LecturaInterna"]);
                        consultaBibliograficasDTO.ReferenciaBibliografica = Convert.ToInt32(dr["ReferenciaBibliografica"]);
                        consultaBibliograficasDTO.BusquedaEnSistema = Convert.ToInt32(dr["BusquedaEnSistema"]);
                        consultaBibliograficasDTO.TotalConsultaBibliografica = Convert.ToInt32(dr["TotalConsultaBibliografica"]);
                        consultaBibliograficasDTO.UsuariosLectoresConsultasB = Convert.ToInt32(dr["UsuariosLectoresConsultasB"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return consultaBibliograficasDTO;
        }

        public string ActualizaFormato(ConsultaBibliograficasDTO consultaBibliograficasDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ConsultaBibliofraficasActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsultaBibliograficaId", SqlDbType.Int);
                    cmd.Parameters["@ConsultaBibliograficaId"].Value = consultaBibliograficasDTO.ConsultaBibliograficaId;

                    cmd.Parameters.Add("@FechaConsultaBibliografica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@FechaConsultaBibliografica"].Value = consultaBibliograficasDTO.FechaConsultaBibliografica;

                    cmd.Parameters.Add("@LibroPrestadoConsultaB", SqlDbType.Int);
                    cmd.Parameters["@LibroPrestadoConsultaB"].Value = consultaBibliograficasDTO.LibroPrestadoConsultaB;

                    cmd.Parameters.Add("@PublicacionPrestadaConsultaB", SqlDbType.Int);
                    cmd.Parameters["@PublicacionPrestadaConsultaB"].Value = consultaBibliograficasDTO.PublicacionePrestadaConsultaB;

                    cmd.Parameters.Add("@RevistaPrestada", SqlDbType.Int);
                    cmd.Parameters["@RevistaPrestada"].Value = consultaBibliograficasDTO.RevistaPrestada;

                    cmd.Parameters.Add("@FolletoPrestado", SqlDbType.Int);
                    cmd.Parameters["@FolletoPrestado"].Value = consultaBibliograficasDTO.FolletoPrestado;

                    cmd.Parameters.Add("@LecturaInterna", SqlDbType.Int);
                    cmd.Parameters["@LecturaInterna"].Value = consultaBibliograficasDTO.LecturaInterna;

                    cmd.Parameters.Add("@ReferenciaBibliografica", SqlDbType.Int);
                    cmd.Parameters["@ReferenciaBibliografica"].Value = consultaBibliograficasDTO.ReferenciaBibliografica;

                    cmd.Parameters.Add("@BusquedaEnSistema", SqlDbType.Int);
                    cmd.Parameters["@BusquedaEnSistema"].Value = consultaBibliograficasDTO.BusquedaEnSistema;

                    cmd.Parameters.Add("@TotalConsultaBibliografica", SqlDbType.Int);
                    cmd.Parameters["@TotalConsultaBibliografica"].Value = consultaBibliograficasDTO.TotalConsultaBibliografica;

                    cmd.Parameters.Add("@UsuariosLectoresConsultasB", SqlDbType.Int);
                    cmd.Parameters["@UsuariosLectoresConsultasB"].Value = consultaBibliograficasDTO.UsuariosLectoresConsultasB;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consultaBibliograficasDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ConsultaBibliograficasDTO consultaBibliograficasDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ConsultaBibliofraficasEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsultaBibliograficaId", SqlDbType.Int);
                    cmd.Parameters["@ConsultaBibliograficaId"].Value = consultaBibliograficasDTO.ConsultaBibliograficaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = consultaBibliograficasDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ConsultaBibliofraficaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ConsultaBibliofrafica", SqlDbType.Structured);
                    cmd.Parameters["@ConsultaBibliofrafica"].TypeName = "Formato.ConsultaBibliofrafica";
                    cmd.Parameters["@ConsultaBibliofrafica"].Value = datos;

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
