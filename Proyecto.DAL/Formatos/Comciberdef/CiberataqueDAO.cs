using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comciberdef
{
    public class CiberataqueDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CiberataqueDTO> ObtenerLista(int? CargaId = null)
        {
            List<CiberataqueDTO> lista = new List<CiberataqueDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CiberataqueListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CiberataqueDTO()
                        {
                            CiberataqueId = Convert.ToInt32(dr["CiberataqueId"]),
                            IdentificadorCiberataque = Convert.ToInt32(dr["IdentificadorCiberataque"]),
                            DescAccionAnteCiberataque = dr["DescAccionAnteCiberataque"].ToString(),
                            FechaCiberataques = (dr["FechaCiberataques"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoCiberataque = dr["DescTipoCiberataque"].ToString(),
                            DescSeveridadCiberataque = dr["DescSeveridadCiberataque"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<CiberataqueDTO> VisualizacionCiberataque( int? CargaId= null)
        {
            List<CiberataqueDTO> lista = new List<CiberataqueDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_ComciberdefVisualizacionCiberataque", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CiberataqueDTO()
                        {
      
                            IdentificadorCiberataque = Convert.ToInt32(dr["IdentificadorCiberataque"]),
                            DescAccionAnteCiberataque = dr["DescAccionAnteCiberataque"].ToString(),
                            FechaCiberataques = (dr["FechaCiberataques"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoCiberataque = dr["DescTipoCiberataque"].ToString(),
                            DescSeveridadCiberataque = dr["DescSeveridadCiberataque"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }

        public List<CiberataqueDTO> CantidadCiberataquesXSeveridadSegunAccion(string? accionAnteCiberataque=null, string? fecha_inicio=null, string? fecha_fin=null, int? CargaId=null)
        {
            List<CiberataqueDTO> lista = new List<CiberataqueDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_ComciberdefCantidadCiberataquesXSeveridadSegunAccion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@accionAnteCiberataque", SqlDbType.VarChar,260);
                cmd.Parameters["@accionAnteCiberataque"].Value = accionAnteCiberataque;

                cmd.Parameters.Add("@fecha_inicio", SqlDbType.Date);
                cmd.Parameters["@fecha_inicio"].Value = fecha_inicio;

                cmd.Parameters.Add("@fecha_fin", SqlDbType.Date);
                cmd.Parameters["@fecha_fin"].Value = fecha_fin;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CiberataqueDTO()
                        {

                            FechaInicio = dr["FechaInicio"].ToString(),
                            FechaFin = dr["FechaFin"].ToString(),
                            DescSeveridadCiberataque = dr["DescAccionAnteCiberataque"].ToString(),
                            DescAccionAnteCiberataque = dr["DescTipoCiberataque"].ToString(),
                            CantidadCiberataques = dr["CantidadCiberataques"].ToString(),
                            PorcentajeCiberataque = dr["PorcentajeCiberataque"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }

        public List<CiberataqueDTO> CantidadCiberataquesXtipoAccionSegunTiposCiberataques(string? tipoCiberataque=null, string? fecha_inicio = null, string? fecha_fin = null , int? CargaId=null)
        {
            List<CiberataqueDTO> lista = new List<CiberataqueDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_ComciberdefCantidadCiberataquesXtipoAccionSegunTiposCiberataques", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@accionAnteCiberataque", SqlDbType.VarChar, 260);
                cmd.Parameters["@accionAnteCiberataque"].Value = tipoCiberataque;

                cmd.Parameters.Add("@fecha_inicio", SqlDbType.Date);
                cmd.Parameters["@fecha_inicio"].Value = fecha_inicio;

                cmd.Parameters.Add("@fecha_fin", SqlDbType.Date);
                cmd.Parameters["@fecha_fin"].Value = fecha_fin;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CiberataqueDTO()
                        {


                            FechaInicio = dr["FechaInicio"].ToString(),
                            FechaFin = dr["FechaFin"].ToString(),
                            DescAccionAnteCiberataque = dr["DescAccionAnteCiberataque"].ToString(),
                            DescTipoCiberataque = dr["DescTipoCiberataque"].ToString(),
                            CantidadCiberataques = dr["CantidadCiberataques"].ToString(),
                            PorcentajeCiberataque = dr["PorcentajeCiberataque"].ToString(),


                        });
                    }
                }
            }
            return lista;
        }
        public string AgregarRegistro(CiberataqueDTO ciberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CiberataqueRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdentificadorCiberataque", SqlDbType.Int);
                    cmd.Parameters["@IdentificadorCiberataque"].Value = ciberataqueDTO.IdentificadorCiberataque;

                    cmd.Parameters.Add("@CodigoAccionAnteCiberataque", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAccionAnteCiberataque"].Value = ciberataqueDTO.CodigoAccionAnteCiberataque;

                    cmd.Parameters.Add("@FechaCiberataques", SqlDbType.Date);
                    cmd.Parameters["@FechaCiberataques"].Value = ciberataqueDTO.FechaCiberataques;

                    cmd.Parameters.Add("@CodigoTipoCiberataque", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoCiberataque"].Value = ciberataqueDTO.CodigoTipoCiberataque;

                    cmd.Parameters.Add("@CodigoSeveridadCiberataque", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSeveridadCiberataque"].Value = ciberataqueDTO.CodigoSeveridadCiberataque;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ciberataqueDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ciberataqueDTO.UsuarioIngresoRegistro;

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

        public CiberataqueDTO BuscarFormato(int Codigo)
        {
            CiberataqueDTO ciberataqueDTO = new CiberataqueDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CiberataqueEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@CiberataqueId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ciberataqueDTO.CiberataqueId = Convert.ToInt32(dr["CiberataqueId"]);
                        ciberataqueDTO.IdentificadorCiberataque = Convert.ToInt32(dr["IdentificadorCiberataque"]);
                        ciberataqueDTO.CodigoAccionAnteCiberataque = dr["CodigoAccionAnteCiberataque"].ToString();
                        ciberataqueDTO.FechaCiberataques = Convert.ToDateTime(dr["FechaCiberataques"]).ToString("yyy-MM-dd");
                        ciberataqueDTO.CodigoTipoCiberataque = dr["CodigoTipoCiberataque"].ToString();
                        ciberataqueDTO.CodigoSeveridadCiberataque = dr["CodigoSeveridadCiberataque"].ToString();

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ciberataqueDTO;
        }

        public string ActualizaFormato(CiberataqueDTO ciberataqueDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CiberataqueActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@CiberataqueId"].Value = ciberataqueDTO.CiberataqueId;

                    cmd.Parameters.Add("@IdentificadorCiberataque", SqlDbType.Int);
                    cmd.Parameters["@IdentificadorCiberataque"].Value = ciberataqueDTO.IdentificadorCiberataque;

                    cmd.Parameters.Add("@CodigoAccionAnteCiberataque", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAccionAnteCiberataque"].Value = ciberataqueDTO.CodigoAccionAnteCiberataque;

                    cmd.Parameters.Add("@FechaCiberataques", SqlDbType.Date);
                    cmd.Parameters["@FechaCiberataques"].Value = ciberataqueDTO.FechaCiberataques;

                    cmd.Parameters.Add("@CodigoTipoCiberataque", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoCiberataque"].Value = ciberataqueDTO.CodigoTipoCiberataque;

                    cmd.Parameters.Add("@CodigoSeveridadCiberataque", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSeveridadCiberataque"].Value = ciberataqueDTO.CodigoSeveridadCiberataque;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ciberataqueDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CiberataqueDTO ciberataqueDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CiberataqueEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CiberataqueId", SqlDbType.Int);
                    cmd.Parameters["@CiberataqueId"].Value = ciberataqueDTO.CiberataqueId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ciberataqueDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CiberataqueRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Ciberataque", SqlDbType.Structured);
                    cmd.Parameters["@Ciberataque"].TypeName = "Formato.Ciberataque";
                    cmd.Parameters["@Ciberataque"].Value = datos;

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
