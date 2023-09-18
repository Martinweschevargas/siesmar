using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class EmisionFotografiaVideoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EmisionFotografiaVideoDTO> ObtenerLista(int? CargaId = null)
        {
            List<EmisionFotografiaVideoDTO> lista = new List<EmisionFotografiaVideoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EmisionFotografiaVideoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EmisionFotografiaVideoDTO()
                        {
                            EmisionFotografiaVideoId = Convert.ToInt32(dr["EmisionFotografiaVideoId"]),
                            FechaEmisionFotoVideo = (dr["FechaEmisionFotoVideo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            TipoCosto = dr["TipoCosto"].ToString(),
                            DescProductoDimar = dr["DescProductoDimar"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            MontoRecaudado = Convert.ToDecimal(dr["MontoRecaudado"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EmisionFotografiaVideoDTO emisionFotografiaVideoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EmisionFotografiaVideoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaEmisionFotoVideo", SqlDbType.Date);
                    cmd.Parameters["@FechaEmisionFotoVideo"].Value = emisionFotografiaVideoDTO.FechaEmisionFotoVideo;

                    cmd.Parameters.Add("@TipoCosto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoCosto"].Value = emisionFotografiaVideoDTO.TipoCosto;

                    cmd.Parameters.Add("@CodigoProductoDimar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoDimar "].Value = emisionFotografiaVideoDTO.CodigoProductoDimar;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = emisionFotografiaVideoDTO.Cantidad;

                    cmd.Parameters.Add("@MontoRecaudado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoRecaudado"].Value = emisionFotografiaVideoDTO.MontoRecaudado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = emisionFotografiaVideoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = emisionFotografiaVideoDTO.UsuarioIngresoRegistro;

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

        public EmisionFotografiaVideoDTO BuscarFormato(int Codigo)
        {
            EmisionFotografiaVideoDTO emisionFotografiaVideoDTO = new EmisionFotografiaVideoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EmisionFotografiaVideoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmisionFotografiaVideoId", SqlDbType.Int);
                    cmd.Parameters["@EmisionFotografiaVideoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        emisionFotografiaVideoDTO.EmisionFotografiaVideoId = Convert.ToInt32(dr["EmisionFotografiaVideoId"]);
                        emisionFotografiaVideoDTO.FechaEmisionFotoVideo = Convert.ToDateTime(dr["FechaEmisionFotoVideo"]).ToString("yyy-MM-dd");
                        emisionFotografiaVideoDTO.TipoCosto = dr["TipoCosto"].ToString();
                        emisionFotografiaVideoDTO.CodigoProductoDimar = dr["CodigoProductoDimar"].ToString();
                        emisionFotografiaVideoDTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        emisionFotografiaVideoDTO.MontoRecaudado = Convert.ToDecimal(dr["MontoRecaudado"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return emisionFotografiaVideoDTO;
        }

        public string ActualizaFormato(EmisionFotografiaVideoDTO emisionFotografiaVideoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EmisionFotografiaVideoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EmisionFotografiaVideoId", SqlDbType.Int);
                    cmd.Parameters["@EmisionFotografiaVideoId"].Value = emisionFotografiaVideoDTO.EmisionFotografiaVideoId;

                    cmd.Parameters.Add("@FechaEmisionFotoVideo", SqlDbType.Date);
                    cmd.Parameters["@FechaEmisionFotoVideo"].Value = emisionFotografiaVideoDTO.FechaEmisionFotoVideo;

                    cmd.Parameters.Add("@TipoCosto", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoCosto"].Value = emisionFotografiaVideoDTO.TipoCosto;

                    cmd.Parameters.Add("@CodigoProductoDimar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoDimar "].Value = emisionFotografiaVideoDTO.CodigoProductoDimar;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = emisionFotografiaVideoDTO.Cantidad;

                    cmd.Parameters.Add("@MontoRecaudado", SqlDbType.Decimal);
                    cmd.Parameters["@MontoRecaudado"].Value = emisionFotografiaVideoDTO.MontoRecaudado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = emisionFotografiaVideoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EmisionFotografiaVideoDTO emisionFotografiaVideoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EmisionFotografiaVideoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmisionFotografiaVideoId", SqlDbType.Int);
                    cmd.Parameters["@EmisionFotografiaVideoId"].Value = emisionFotografiaVideoDTO.EmisionFotografiaVideoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = emisionFotografiaVideoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EmisionFotografiaVideoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EmisionFotografiaVideo", SqlDbType.Structured);
                    cmd.Parameters["@EmisionFotografiaVideo"].TypeName = "Formato.EmisionFotografiaVideo";
                    cmd.Parameters["@EmisionFotografiaVideo"].Value = datos;

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
