using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comesguard
{
    public class IngresoDatoServicioSastreriaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<IngresoDatoServicioSastreriaDTO> ObtenerLista(int? CargaId = null)
        {
            List<IngresoDatoServicioSastreriaDTO> lista = new List<IngresoDatoServicioSastreriaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_IngresoDatoServicioSastreriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new IngresoDatoServicioSastreriaDTO()
                        {
                            IngresoDatoServicioSastreriaId = Convert.ToInt32(dr["IngresoDatoServicioSastreriaId"]),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaRecojo = (dr["FechaRecojo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CIP = dr["CIP"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            DescEspecialidad = dr["DescEspecialidad"].ToString(),
                            Sexo = dr["Sexo"].ToString(),
                            DescDependencia = dr["DescDependencia "].ToString(),
                            DescServicioSastreria = dr["DescServicioSastreria"].ToString(),
                            CantidadPrendas = Convert.ToInt32(dr["CantidadPrendas"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(IngresoDatoServicioSastreriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioSastreriaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = ingresoDatoServicioPeluqueriaDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = ingresoDatoServicioPeluqueriaDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIP"].Value = ingresoDatoServicioPeluqueriaDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Sexo"].Value = ingresoDatoServicioPeluqueriaDTO.Sexo;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoServicioSastreria ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoServicioSastreria "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoTipoServicioSastreria;

                    cmd.Parameters.Add("@CantidadPrendas", SqlDbType.Int);
                    cmd.Parameters["@CantidadPrendas"].Value = ingresoDatoServicioPeluqueriaDTO.CantidadPrendas;

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

        public IngresoDatoServicioSastreriaDTO BuscarFormato(int Codigo)
        {
            IngresoDatoServicioSastreriaDTO ingresoDatoServicioPeluqueriaDTO = new IngresoDatoServicioSastreriaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioSastreriaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioSastreriaId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioSastreriaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioSastreriaId = Convert.ToInt32(dr["IngresoDatoServicioSastreriaId"]);
                        ingresoDatoServicioPeluqueriaDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd");
                        ingresoDatoServicioPeluqueriaDTO.FechaRecojo = Convert.ToDateTime(dr["FechaRecojo"]).ToString("yyy-MM-dd");
                        ingresoDatoServicioPeluqueriaDTO.CIP = dr["CIP"].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar "].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal = dr["CodigoEspecialidadGenericaPersonal "].ToString();
                        ingresoDatoServicioPeluqueriaDTO.Sexo = dr["Sexo"].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CodigoDependencia = dr["CodigoDependencia "].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CodigoTipoServicioSastreria = dr["CodigoTipoServicioSastreria "].ToString();
                        ingresoDatoServicioPeluqueriaDTO.CantidadPrendas = Convert.ToInt32(dr["CantidadPrendas"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingresoDatoServicioPeluqueriaDTO;
        }

        public string ActualizaFormato(IngresoDatoServicioSastreriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioSastreriaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@IngresoDatoServicioSastreriaId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioSastreriaId"].Value = ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioSastreriaId;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = ingresoDatoServicioPeluqueriaDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaRecojo", SqlDbType.Date);
                    cmd.Parameters["@FechaRecojo"].Value = ingresoDatoServicioPeluqueriaDTO.FechaRecojo;

                    cmd.Parameters.Add("@CIP", SqlDbType.VarChar, 8);
                    cmd.Parameters["@CIP"].Value = ingresoDatoServicioPeluqueriaDTO.CIP;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@CodigoEspecialidadGenericaPersonal ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGenericaPersonal "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal;

                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Sexo"].Value = ingresoDatoServicioPeluqueriaDTO.Sexo;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoTipoServicioSastreria ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoServicioSastreria "].Value = ingresoDatoServicioPeluqueriaDTO.CodigoTipoServicioSastreria;

                    cmd.Parameters.Add("@CantidadPrendas", SqlDbType.Int);
                    cmd.Parameters["@CantidadPrendas"].Value = ingresoDatoServicioPeluqueriaDTO.CantidadPrendas;

                    cmd.Parameters.Add("@CantidadPrendas", SqlDbType.Int);
                    cmd.Parameters["@CantidadPrendas"].Value = ingresoDatoServicioPeluqueriaDTO.CantidadPrendas;

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

        public bool EliminarFormato(IngresoDatoServicioSastreriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioSastreriaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioSastreriaId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioSastreriaId"].Value = ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioSastreriaId;

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
                    var cmd = new SqlCommand("Formato.usp_IngresoDatoServicioSastreriaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioSastreria", SqlDbType.Structured);
                    cmd.Parameters["@IngresoDatoServicioSastreria"].TypeName = "Formato.IngresoDatoServicioSastreria";
                    cmd.Parameters["@IngresoDatoServicioSastreria"].Value = datos;

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
