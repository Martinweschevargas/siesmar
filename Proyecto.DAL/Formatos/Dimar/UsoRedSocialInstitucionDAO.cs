using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dimar
{
    public class UsoRedSocialInstitucionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<UsoRedSocialInstitucionDTO> ObtenerLista(int? CargaId = null)
        {
            List<UsoRedSocialInstitucionDTO> lista = new List<UsoRedSocialInstitucionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_UsoRedSocialInstitucionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UsoRedSocialInstitucionDTO()
                        {
                            UsoRedSocialInstitucionId = Convert.ToInt32(dr["UsoRedSocialInstitucionId"]),
                            DescRedSocial = dr["DescRedSocial"].ToString(),
                            FechaEmision = (dr["FechaEmision"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NumeroSeguidores = Convert.ToInt32(dr["NumeroSeguidores"]),
                            IncrementoSeguidores = Convert.ToInt32(dr["IncrementoSeguidores"]),
                            TemaMasComentado = dr["TemaMasComentado"].ToString(),
                            DescPublicoObjetivo = dr["DescPublicoObjetivo"].ToString(),
                            NumeroPublicaciones = Convert.ToInt32(dr["NumeroPublicaciones"]),
                            TotalSeguidoresCreacion = Convert.ToInt32(dr["TotalSeguidoresCreacion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoRedSocialInstitucionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoRedSocial ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRedSocial "].Value = usoRedSocialInstitucionDTO.CodigoRedSocial;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = usoRedSocialInstitucionDTO.FechaEmision;

                    cmd.Parameters.Add("@NumeroSeguidores", SqlDbType.Int);
                    cmd.Parameters["@NumeroSeguidores"].Value = usoRedSocialInstitucionDTO.NumeroSeguidores;

                    cmd.Parameters.Add("@IncrementoSeguidores", SqlDbType.Int);
                    cmd.Parameters["@IncrementoSeguidores"].Value = usoRedSocialInstitucionDTO.IncrementoSeguidores;

                    cmd.Parameters.Add("@TemaMasComentado", SqlDbType.VarChar, 100);
                    cmd.Parameters["@TemaMasComentado"].Value = usoRedSocialInstitucionDTO.TemaMasComentado;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = usoRedSocialInstitucionDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@NumeroPublicaciones", SqlDbType.Int);
                    cmd.Parameters["@NumeroPublicaciones"].Value = usoRedSocialInstitucionDTO.NumeroPublicaciones;

                    cmd.Parameters.Add("@TotalSeguidoresCreacion", SqlDbType.Int);
                    cmd.Parameters["@TotalSeguidoresCreacion"].Value = usoRedSocialInstitucionDTO.TotalSeguidoresCreacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = usoRedSocialInstitucionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoRedSocialInstitucionDTO.UsuarioIngresoRegistro;

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

        public UsoRedSocialInstitucionDTO BuscarFormato(int Codigo)
        {
            UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO = new UsoRedSocialInstitucionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoRedSocialInstitucionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoRedSocialInstitucionId", SqlDbType.Int);
                    cmd.Parameters["@UsoRedSocialInstitucionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        usoRedSocialInstitucionDTO.UsoRedSocialInstitucionId = Convert.ToInt32(dr["UsoRedSocialInstitucionId"]);
                        usoRedSocialInstitucionDTO.CodigoRedSocial = dr["CodigoRedSocial"].ToString();
                        usoRedSocialInstitucionDTO.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]).ToString("yyy-MM-dd");
                        usoRedSocialInstitucionDTO.NumeroSeguidores = Convert.ToInt32(dr["NumeroSeguidores"]);
                        usoRedSocialInstitucionDTO.IncrementoSeguidores = Convert.ToInt32(dr["IncrementoSeguidores"]);
                        usoRedSocialInstitucionDTO.TemaMasComentado = dr["TemaMasComentado"].ToString();
                        usoRedSocialInstitucionDTO.CodigoPublicoObjetivo = dr["CodigoPublicoObjetivo"].ToString();
                        usoRedSocialInstitucionDTO.NumeroPublicaciones = Convert.ToInt32(dr["NumeroPublicaciones"]);
                        usoRedSocialInstitucionDTO.TotalSeguidoresCreacion = Convert.ToInt32(dr["TotalSeguidoresCreacion"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return usoRedSocialInstitucionDTO;
        }

        public string ActualizaFormato(UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_UsoRedSocialInstitucionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@UsoRedSocialInstitucionId", SqlDbType.Int);
                    cmd.Parameters["@UsoRedSocialInstitucionId"].Value = usoRedSocialInstitucionDTO.UsoRedSocialInstitucionId;

                    cmd.Parameters.Add("@CodigoRedSocial ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRedSocial "].Value = usoRedSocialInstitucionDTO.CodigoRedSocial;

                    cmd.Parameters.Add("@FechaEmision", SqlDbType.Date);
                    cmd.Parameters["@FechaEmision"].Value = usoRedSocialInstitucionDTO.FechaEmision;

                    cmd.Parameters.Add("@NumeroSeguidores", SqlDbType.Int);
                    cmd.Parameters["@NumeroSeguidores"].Value = usoRedSocialInstitucionDTO.NumeroSeguidores;

                    cmd.Parameters.Add("@IncrementoSeguidores", SqlDbType.Int);
                    cmd.Parameters["@IncrementoSeguidores"].Value = usoRedSocialInstitucionDTO.IncrementoSeguidores;

                    cmd.Parameters.Add("@TemaMasComentado", SqlDbType.VarChar, 100);
                    cmd.Parameters["@TemaMasComentado"].Value = usoRedSocialInstitucionDTO.TemaMasComentado;

                    cmd.Parameters.Add("@CodigoPublicoObjetivo ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPublicoObjetivo "].Value = usoRedSocialInstitucionDTO.CodigoPublicoObjetivo;

                    cmd.Parameters.Add("@NumeroPublicaciones", SqlDbType.Int);
                    cmd.Parameters["@NumeroPublicaciones"].Value = usoRedSocialInstitucionDTO.NumeroPublicaciones;

                    cmd.Parameters.Add("@TotalSeguidoresCreacion", SqlDbType.Int);
                    cmd.Parameters["@TotalSeguidoresCreacion"].Value = usoRedSocialInstitucionDTO.TotalSeguidoresCreacion;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoRedSocialInstitucionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_UsoRedSocialInstitucionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoRedSocialInstitucionId", SqlDbType.Int);
                    cmd.Parameters["@UsoRedSocialInstitucionId"].Value = usoRedSocialInstitucionDTO.UsoRedSocialInstitucionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = usoRedSocialInstitucionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_UsoRedSocialInstitucionMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UsoRedSocialInstitucion", SqlDbType.Structured);
                    cmd.Parameters["@UsoRedSocialInstitucion"].TypeName = "Formato.UsoRedSocialInstitucion";
                    cmd.Parameters["@UsoRedSocialInstitucion"].Value = datos;

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