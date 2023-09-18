using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperpac
{
    public class NumeroUnidadFuerzaNavalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<NumeroUnidadFuerzaNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<NumeroUnidadFuerzaNavalDTO> lista = new List<NumeroUnidadFuerzaNavalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_NumeroUnidadFuerzaNavalListar", conexion);
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
                        lista.Add(new NumeroUnidadFuerzaNavalDTO()
                        {
                            NumeroUnidadFuerzaNavalId = Convert.ToInt32(dr["NumeroUnidadFuerzaNavalId"]),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            DescUnidadBelica = dr["DescUnidadBelica"].ToString(),
                            DescEstadoOperativo = dr["DescEstadoOperativo"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NumeroUnidadFuerzaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = numeroUnidadFuerzaNavalDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoUnidadBelica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadBelica"].Value = numeroUnidadFuerzaNavalDTO.CodigoUnidadBelica;

                    cmd.Parameters.Add("@CodigoEstadoOperativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoOperativo"].Value = numeroUnidadFuerzaNavalDTO.CodigoEstadoOperativo;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = numeroUnidadFuerzaNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro;

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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public NumeroUnidadFuerzaNavalDTO BuscarFormato(int Codigo)
        {
            NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO = new NumeroUnidadFuerzaNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NumeroUnidadFuerzaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroUnidadFuerzaNavalId", SqlDbType.Int);
                    cmd.Parameters["@NumeroUnidadFuerzaNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        numeroUnidadFuerzaNavalDTO.NumeroUnidadFuerzaNavalId = Convert.ToInt32(dr["NumeroUnidadFuerzaNavalId"]);
                        numeroUnidadFuerzaNavalDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        numeroUnidadFuerzaNavalDTO.CodigoUnidadBelica = dr["CodigoUnidadBelica"].ToString();
                        numeroUnidadFuerzaNavalDTO.CodigoEstadoOperativo = dr["CodigoEstadoOperativo"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return numeroUnidadFuerzaNavalDTO;
        }

        public string ActualizaFormato(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_NumeroUnidadFuerzaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@NumeroUnidadFuerzaNavalId", SqlDbType.Int);
                    cmd.Parameters["@NumeroUnidadFuerzaNavalId"].Value = numeroUnidadFuerzaNavalDTO.NumeroUnidadFuerzaNavalId;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = numeroUnidadFuerzaNavalDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoUnidadBelica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadBelica"].Value = numeroUnidadFuerzaNavalDTO.CodigoUnidadBelica;

                    cmd.Parameters.Add("@CodigoEstadoOperativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstadoOperativo"].Value = numeroUnidadFuerzaNavalDTO.CodigoEstadoOperativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NumeroUnidadFuerzaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroUnidadFuerzaNavalId", SqlDbType.Int);
                    cmd.Parameters["@NumeroUnidadFuerzaNavalId"].Value = numeroUnidadFuerzaNavalDTO.NumeroUnidadFuerzaNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO)
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
                    cmd.Parameters["@Formato"].Value = "NumeroUnidadFuerzaNaval";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = numeroUnidadFuerzaNavalDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_NumeroUnidadFuerzaNavalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroUnidadFuerzaNaval", SqlDbType.Structured);
                    cmd.Parameters["@NumeroUnidadFuerzaNaval"].TypeName = "Formato.NumeroUnidadFuerzaNaval";
                    cmd.Parameters["@NumeroUnidadFuerzaNaval"].Value = datos;

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
