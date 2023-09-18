using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comesguard
{
    public class IngresoDatoServicioPeluqueriaDAO
    {

        SqlCommand cmd = new SqlCommand();


        public List<IngresoDatoServicioPeluqueriaDTO> ObtenerLista(int? CargaId = null)
        {
            List<IngresoDatoServicioPeluqueriaDTO> lista = new List<IngresoDatoServicioPeluqueriaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_IngresoDatoServicioPeluqueriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new IngresoDatoServicioPeluqueriaDTO()
                        {
                            IngresoDatoServicioPeluqueriaId = Convert.ToInt32(dr["IngresoDatoServicioPeluqueriaId"]),
                            FechaServicio = (dr["FechaServicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CIP = dr["CIP"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioPeluqueriaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaServicio", SqlDbType.Date);       
                    cmd.Parameters["@FechaServicio"].Value = ingresoDatoServicioPeluqueriaDTO.FechaServicio;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar, 8); ;     
                    cmd.Parameters["@CIP"].Value = ingresoDatoServicioPeluqueriaDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal ", SqlDbType.VarChar, 20);   
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);   
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ingresoDatoServicioPeluqueriaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro;

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

        public IngresoDatoServicioPeluqueriaDTO BuscarFormato(int Codigo)
        {
            IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO = new IngresoDatoServicioPeluqueriaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioPeluqueriaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioPeluqueriaId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioPeluqueriaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioPeluqueriaId = Convert.ToInt32(dr["IngresoDatoServicioPeluqueriaId"]);
                        ingresoDatoServicioPeluqueriaDTO.FechaServicio = Convert.ToDateTime(dr["FechaServicio"]).ToString("yyy-MM-dd");
                        ingresoDatoServicioPeluqueriaDTO.CIP = dr["CIP"].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal"].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingresoDatoServicioPeluqueriaDTO;
        }

        public string ActualizaFormato(IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioPeluqueriaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@IngresoDatoServicioPeluqueriaId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioPeluqueriaId"].Value = ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioPeluqueriaId;

                    cmd.Parameters.Add("@FechaServicio", SqlDbType.Date);
                    cmd.Parameters["@FechaServicio"].Value = ingresoDatoServicioPeluqueriaDTO.FechaServicio;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar, 8); ;
                    cmd.Parameters["@CIP"].Value = ingresoDatoServicioPeluqueriaDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioPeluqueriaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioPeluqueriaId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioPeluqueriaId"].Value = ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioPeluqueriaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_IngresoDatoServicioPeluqueriaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioPeluqueria", SqlDbType.Structured);
                    cmd.Parameters["@IngresoDatoServicioPeluqueria"].TypeName = "Formato.IngresoDatoServicioPeluqueria";
                    cmd.Parameters["@IngresoDatoServicioPeluqueria"].Value = datos;

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

