using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comesnapi
{
    public class ServicioLavanderiaComesnapiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioLavanderiaComesnapiDTO> ObtenerLista(int? CargaId=null)
        {
            List<ServicioLavanderiaComesnapiDTO> lista = new List<ServicioLavanderiaComesnapiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioLavanderiaComesnapiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioLavanderiaComesnapiDTO()
                        {
                            ServicioLavanderiaComesnapiId = Convert.ToInt32(dr["ServicioLavanderiaComesnapiId"]),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRecojo = (dr["FechaRecojo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CIP = dr["CIP"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            SexoPersonal = dr["SexoPersonal"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            NumeroPrenda = Convert.ToInt32(dr["NumeroPrenda"]),
                            DescServicioLavanderia = dr["DescServicioLavanderia"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioLavanderiaComesnapiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
            
                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = servicioLavanderiaComesnapiDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = servicioLavanderiaComesnapiDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar,8);
                    cmd.Parameters["@CIP"].Value = servicioLavanderiaComesnapiDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioLavanderiaComesnapiDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = servicioLavanderiaComesnapiDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonal"].Value = servicioLavanderiaComesnapiDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioLavanderiaComesnapiDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NumeroPrenda", SqlDbType.Int);
                    cmd.Parameters["@NumeroPrenda"].Value = servicioLavanderiaComesnapiDTO.NumeroPrenda;

                    cmd.Parameters.Add("@CodigoServicioLavanderia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoServicioLavanderia"].Value = servicioLavanderiaComesnapiDTO.CodigoServicioLavanderia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioLavanderiaComesnapiDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLavanderiaComesnapiDTO.UsuarioIngresoRegistro;

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

        public ServicioLavanderiaComesnapiDTO BuscarFormato(int Codigo)
        {
            ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO = new ServicioLavanderiaComesnapiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioLavanderiaComesnapiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLavanderiaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLavanderiaComesnapiId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioLavanderiaComesnapiDTO.ServicioLavanderiaComesnapiId = Convert.ToInt32(dr["ServicioLavanderiaComesnapiId"]);
                        servicioLavanderiaComesnapiDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd");
                        servicioLavanderiaComesnapiDTO.FechaRecojo = Convert.ToDateTime(dr["FechaRecojo"]).ToString("yyy-MM-dd");
                        servicioLavanderiaComesnapiDTO.CIP = dr["CIP"].ToString();
                        servicioLavanderiaComesnapiDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        servicioLavanderiaComesnapiDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        servicioLavanderiaComesnapiDTO.SexoPersonal = dr["SexoPersonal"].ToString();
                        servicioLavanderiaComesnapiDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        servicioLavanderiaComesnapiDTO.NumeroPrenda = Convert.ToInt32(dr["NumeroPrenda"]);
                        servicioLavanderiaComesnapiDTO.CodigoServicioLavanderia = dr["CodigoServicioLavanderia"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioLavanderiaComesnapiDTO;
        }

        public string ActualizaFormato(ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioLavanderiaComesnapiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioLavanderiaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLavanderiaComesnapiId"].Value = servicioLavanderiaComesnapiDTO.ServicioLavanderiaComesnapiId;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = servicioLavanderiaComesnapiDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = servicioLavanderiaComesnapiDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIP"].Value = servicioLavanderiaComesnapiDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioLavanderiaComesnapiDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = servicioLavanderiaComesnapiDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@SexoPersonal", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoPersonal"].Value = servicioLavanderiaComesnapiDTO.SexoPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioLavanderiaComesnapiDTO.CodigoDependencia;

                    cmd.Parameters.Add("@NumeroPrenda", SqlDbType.Int);
                    cmd.Parameters["@NumeroPrenda"].Value = servicioLavanderiaComesnapiDTO.NumeroPrenda;

                    cmd.Parameters.Add("@CodigoServicioLavanderia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoServicioLavanderia"].Value = servicioLavanderiaComesnapiDTO.CodigoServicioLavanderia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLavanderiaComesnapiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioLavanderiaComesnapiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLavanderiaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioLavanderiaComesnapiId"].Value = servicioLavanderiaComesnapiDTO.ServicioLavanderiaComesnapiId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioLavanderiaComesnapiDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioLavanderiaComesnapiRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioLavanderiaComesnapi", SqlDbType.Structured);
                    cmd.Parameters["@ServicioLavanderiaComesnapi"].TypeName = "Formato.ServicioLavanderiaComesnapi";
                    cmd.Parameters["@ServicioLavanderiaComesnapi"].Value = datos;

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
