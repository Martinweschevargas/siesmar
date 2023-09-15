using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comesnapi
{
    public class ServicioPeluqueriaComesnapiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioPeluqueriaComesnapiDTO> ObtenerLista(int? CargaId=null)
        {
            List<ServicioPeluqueriaComesnapiDTO> lista = new List<ServicioPeluqueriaComesnapiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComesnapiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioPeluqueriaComesnapiDTO()
                        {
                            ServicioPeluqueriaComesnapiId = Convert.ToInt32(dr["ServicioPeluqueriaComesnapiId"]),
                            Fecha = (dr["Fecha"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CIPPersonal = dr["CIPPersonal"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComesnapiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = servicioPeluqueriaComesnapiDTO.Fecha;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar,20);
                    cmd.Parameters["@CIPPersonal"].Value = servicioPeluqueriaComesnapiDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioPeluqueriaComesnapiDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = servicioPeluqueriaComesnapiDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioPeluqueriaComesnapiDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioPeluqueriaComesnapiDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPeluqueriaComesnapiDTO.UsuarioIngresoRegistro;

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

        public ServicioPeluqueriaComesnapiDTO BuscarFormato(int Codigo)
        {
            ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO = new ServicioPeluqueriaComesnapiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComesnapiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPeluqueriaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPeluqueriaComesnapiId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioPeluqueriaComesnapiDTO.ServicioPeluqueriaComesnapiId = Convert.ToInt32(dr["ServicioPeluqueriaComesnapiId"]);
                        servicioPeluqueriaComesnapiDTO.Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("yyy-MM-dd");
                        servicioPeluqueriaComesnapiDTO.CIPPersonal =dr["CIPPersonal"].ToString();
                        servicioPeluqueriaComesnapiDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        servicioPeluqueriaComesnapiDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        servicioPeluqueriaComesnapiDTO.CodigoDependencia = dr["CodigoDependencia"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioPeluqueriaComesnapiDTO;
        }

        public string ActualizaFormato(ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComesnapiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioPeluqueriaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPeluqueriaComesnapiId"].Value = servicioPeluqueriaComesnapiDTO.ServicioPeluqueriaComesnapiId;

                    cmd.Parameters.Add("@Fecha", SqlDbType.Date);
                    cmd.Parameters["@Fecha"].Value = servicioPeluqueriaComesnapiDTO.Fecha;

                    cmd.Parameters.Add("@CIPPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CIPPersonal"].Value = servicioPeluqueriaComesnapiDTO.CIPPersonal;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = servicioPeluqueriaComesnapiDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal"].Value = servicioPeluqueriaComesnapiDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = servicioPeluqueriaComesnapiDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPeluqueriaComesnapiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComesnapiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPeluqueriaComesnapiId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPeluqueriaComesnapiId"].Value = servicioPeluqueriaComesnapiDTO.ServicioPeluqueriaComesnapiId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPeluqueriaComesnapiDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioPeluqueriaComesnapiRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPeluqueriaComesnapi", SqlDbType.Structured);
                    cmd.Parameters["@ServicioPeluqueriaComesnapi"].TypeName = "Formato.ServicioPeluqueriaComesnapi";
                    cmd.Parameters["@ServicioPeluqueriaComesnapi"].Value = datos;

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
