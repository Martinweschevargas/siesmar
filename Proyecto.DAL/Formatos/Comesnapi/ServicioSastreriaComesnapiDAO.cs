using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comesnapi
{
    public class ServicioSastreriaComesnapiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioSastreriaComesnapiDTO> ObtenerLista(int? CargaId = null)
        {
            List<ServicioSastreriaComesnapiDTO> lista = new List<ServicioSastreriaComesnapiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioSastreriaComesnapiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioSastreriaComesnapiDTO()
                        {
                            ServicioSastreriaComesnapiId = Convert.ToInt32(dr["ServicioSastreriaComesnapiId"]),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRecojo = (dr["FechaRecojo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CIP = dr["CIP"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            SexoPersonal = dr["SexoPersonal"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            NumeroPrenda = Convert.ToInt32(dr["NumeroPrenda"]),
                            DescTipoPrenda = dr["DescTipoPrenda"].ToString(),
                            DescServicioSastreria = dr["DescServicioSastreria"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComesnapiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = servicioSastreriaComesnapiDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = servicioSastreriaComesnapiDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar,8);
                    cmd.Parameters["@CIP"].Value = servicioSastreriaComesnapiDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioSastreriaComesnapiDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = servicioSastreriaComesnapiDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonal"].Value = servicioSastreriaComesnapiDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioSastreriaComesnapiDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NumeroPrenda", SqlDbType.Int);
                    cmd.Parameters["@NumeroPrenda"].Value = servicioSastreriaComesnapiDTO.NumeroPrenda;

                    cmd.Parameters.Add("@CodigoTipoPrenda", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPrenda"].Value = servicioSastreriaComesnapiDTO.CodigoTipoPrenda;

                    cmd.Parameters.Add("@CodigoTipoServicioSastreria", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoServicioSastreria"].Value = servicioSastreriaComesnapiDTO.CodigoTipoServicioSastreria;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioSastreriaComesnapiDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioSastreriaComesnapiDTO.UsuarioIngresoRegistro;

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

        public ServicioSastreriaComesnapiDTO BuscarFormato(int Codigo)
        {
            ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO = new ServicioSastreriaComesnapiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComesnapiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSastreriaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSastreriaComesnapiId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioSastreriaComesnapiDTO.ServicioSastreriaComesnapiId = Convert.ToInt32(dr["ServicioSastreriaComesnapiId"]);
                        servicioSastreriaComesnapiDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd");
                        servicioSastreriaComesnapiDTO.FechaRecojo = Convert.ToDateTime(dr["FechaRecojo"]).ToString("yyy-MM-dd");
                        servicioSastreriaComesnapiDTO.CIP = dr["CIP"].ToString();
                        servicioSastreriaComesnapiDTO.CodigoGradoPersonalMilitar =dr["CodigoGradoPersonalMilitar"].ToString();
                        servicioSastreriaComesnapiDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        servicioSastreriaComesnapiDTO.SexoPersonal = dr["SexoPersonal"].ToString();
                        servicioSastreriaComesnapiDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        servicioSastreriaComesnapiDTO.NumeroPrenda = Convert.ToInt32(dr["NumeroPrenda"]);
                        servicioSastreriaComesnapiDTO.CodigoTipoPrenda = dr["CodigoTipoPrenda"].ToString();
                        servicioSastreriaComesnapiDTO.CodigoTipoServicioSastreria = dr["CodigoTipoServicioSastreria"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioSastreriaComesnapiDTO;
        }

        public string ActualizaFormato(ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComesnapiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioSastreriaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSastreriaComesnapiId"].Value = servicioSastreriaComesnapiDTO.ServicioSastreriaComesnapiId;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = servicioSastreriaComesnapiDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = servicioSastreriaComesnapiDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIP"].Value = servicioSastreriaComesnapiDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioSastreriaComesnapiDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = servicioSastreriaComesnapiDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonal"].Value = servicioSastreriaComesnapiDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioSastreriaComesnapiDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NumeroPrenda", SqlDbType.Int);
                    cmd.Parameters["@NumeroPrenda"].Value = servicioSastreriaComesnapiDTO.NumeroPrenda;

                    cmd.Parameters.Add("@CodigoTipoPrenda", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoPrenda"].Value = servicioSastreriaComesnapiDTO.CodigoTipoPrenda;

                    cmd.Parameters.Add("@CodigoTipoServicioSastreria", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoServicioSastreria"].Value = servicioSastreriaComesnapiDTO.CodigoTipoServicioSastreria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioSastreriaComesnapiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioSastreriaComesnapiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSastreriaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioSastreriaComesnapiId"].Value = servicioSastreriaComesnapiDTO.ServicioSastreriaComesnapiId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioSastreriaComesnapiDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioSastreriaComesnapiRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioSastreriaComesnapi", SqlDbType.Structured);
                    cmd.Parameters["@ServicioSastreriaComesnapi"].TypeName = "Formato.ServicioSastreriaComesnapi";
                    cmd.Parameters["@ServicioSastreriaComesnapi"].Value = datos;

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
