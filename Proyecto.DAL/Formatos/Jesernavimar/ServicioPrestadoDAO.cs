using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Jesernavimar;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Jesernavimar
{
    public class ServicioPrestadoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioPrestadoDTO> ObtenerLista(int? CargaId = null, int? Mes = null, int? Anio = null)
        {
            List<ServicioPrestadoDTO> lista = new List<ServicioPrestadoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioPrestadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                cmd.Parameters["@R_Mes"].Value = Mes;

                cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                cmd.Parameters["@R_Anio"].Value = Anio;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ServicioPrestadoDTO()
                        {
                            ServicioPrestadoId = Convert.ToInt32(dr["ServicioPrestadoId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DocumentoServicio = dr["DocumentoServicio"].ToString(),
                            FechaServicioPrestado = (dr["FechaServicioPrestado"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescUnidadAuxiliarNaval = dr["DescUnidadNaval"].ToString(),
                            NroViajeComercial = dr["NroViajeComercial"].ToString(),
                            DescPuertoPeruZarpe = dr["DescPuertoPeru"].ToString(),
                            DescDepartamentoZarpe = dr["DescDepartamento"].ToString(),
                            DescProvinciaZarpe = dr["DescProvincia"].ToString(),
                            DescDistritoZarpe = dr["DescDistrito"].ToString(),
                            FechaHoraZarpe = Convert.ToDateTime(dr["FechaHoraZarpe"]).ToString("yyy-MM-dd"),
                            Ocurrencia = dr["Ocurrencia"].ToString(),
                            DescPuertoPeruArribo = dr["DescPuertoPeru"].ToString(),
                            DescDepartamentoArribo = dr["DescDepartamento"].ToString(),
                            DescProvinciaArribo = dr["DescProvincia"].ToString(),
                            DescDistritoArribo = dr["DescDistrito"].ToString(),
                            FechaHoraArribo = Convert.ToDateTime(dr["FechaHoraArribo"]).ToString("yyy-MM-dd"),
                            EmpresaReceptoraServicio = dr["EmpresaReceptoraServicio"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioPrestadoDTO servicioPrestadoDTO, int mes, int anio)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPrestadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = servicioPrestadoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DocumentoServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DocumentoServicio"].Value = servicioPrestadoDTO.DocumentoServicio;

                    cmd.Parameters.Add("@FechaServicioPrestado", SqlDbType.Date);
                    cmd.Parameters["@FechaServicioPrestado"].Value = servicioPrestadoDTO.FechaServicioPrestado;

                    cmd.Parameters.Add("@UnidadAuxiliarNaval", SqlDbType.Int);
                    cmd.Parameters["@UnidadAuxiliarNaval"].Value = servicioPrestadoDTO.UnidadAuxiliarNaval;

                    cmd.Parameters.Add("@NroViajeComercial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NroViajeComercial"].Value = servicioPrestadoDTO.NroViajeComercial;

                    cmd.Parameters.Add("@PuertoPeruZarpe", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruZarpe"].Value = servicioPrestadoDTO.PuertoPeruZarpe;

                    cmd.Parameters.Add("@DepartamentoZarpe", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoZarpe"].Value = servicioPrestadoDTO.DepartamentoZarpe;

                    cmd.Parameters.Add("@ProvinciaZarpe", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaZarpe"].Value = servicioPrestadoDTO.ProvinciaZarpe;

                    cmd.Parameters.Add("@DistritoZarpe", SqlDbType.Int);
                    cmd.Parameters["@DistritoZarpe"].Value = servicioPrestadoDTO.DistritoZarpe;

                    cmd.Parameters.Add("@FechaHoraZarpe", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraZarpe"].Value = servicioPrestadoDTO.FechaHoraZarpe;

                    cmd.Parameters.Add("@Ocurrencia", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Ocurrencia"].Value = servicioPrestadoDTO.Ocurrencia;

                    cmd.Parameters.Add("@PuertoPeruArribo", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruArribo"].Value = servicioPrestadoDTO.PuertoPeruArribo;

                    cmd.Parameters.Add("@DepartamentoArribo", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoArribo"].Value = servicioPrestadoDTO.DepartamentoArribo;

                    cmd.Parameters.Add("@ProvinciaArribo", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaArribo"].Value = servicioPrestadoDTO.ProvinciaArribo;

                    cmd.Parameters.Add("@DistritoArribo", SqlDbType.Int);
                    cmd.Parameters["@DistritoArribo"].Value = servicioPrestadoDTO.DistritoArribo;

                    cmd.Parameters.Add("@FechaHoraArribo", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraArribo"].Value = servicioPrestadoDTO.FechaHoraArribo;

                    cmd.Parameters.Add("@EmpresaReceptoraServicio", SqlDbType.VarChar, 500);
                    cmd.Parameters["@EmpresaReceptoraServicio"].Value = servicioPrestadoDTO.EmpresaReceptoraServicio;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioPrestadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPrestadoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                    cmd.Parameters["@R_Mes"].Value = mes;

                    cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                    cmd.Parameters["@R_Anio"].Value = anio;


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

        public ServicioPrestadoDTO BuscarFormato(int Codigo)
        {
            ServicioPrestadoDTO servicioPrestadoDTO = new ServicioPrestadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPrestadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPrestadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        servicioPrestadoDTO.ServicioPrestadoId = Convert.ToInt32(dr["ServicioPrestadoId"]);
                        servicioPrestadoDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        servicioPrestadoDTO.DocumentoServicio = dr["DocumentoServicio"].ToString();
                        servicioPrestadoDTO.FechaServicioPrestado = Convert.ToDateTime(dr["FechaServicioPrestado"]).ToString("yyy-MM-dd");
                        servicioPrestadoDTO.UnidadAuxiliarNaval = Convert.ToInt32(dr["UnidadAuxiliarNaval"]);
                        servicioPrestadoDTO.NroViajeComercial = dr["NroViajeComercial"].ToString();
                        servicioPrestadoDTO.PuertoPeruZarpe = Convert.ToInt32(dr["PuertoPeruZarpe"]);
                        servicioPrestadoDTO.DepartamentoZarpe = Convert.ToInt32(dr["DepartamentoZarpe"]);
                        servicioPrestadoDTO.ProvinciaZarpe = Convert.ToInt32(dr["ProvinciaZarpe"]);
                        servicioPrestadoDTO.DistritoZarpe = Convert.ToInt32(dr["DistritoZarpe"]);
                        servicioPrestadoDTO.FechaHoraZarpe = Convert.ToDateTime(dr["FechaHoraZarpe"]).ToString("yyy-MM-dd");
                        servicioPrestadoDTO.Ocurrencia = dr["Ocurrencia"].ToString();
                        servicioPrestadoDTO.PuertoPeruArribo = Convert.ToInt32(dr["PuertoPeruArribo"]);
                        servicioPrestadoDTO.DepartamentoArribo = Convert.ToInt32(dr["DepartamentoArribo"]);
                        servicioPrestadoDTO.ProvinciaArribo = Convert.ToInt32(dr["ProvinciaArribo"]);
                        servicioPrestadoDTO.DistritoArribo = Convert.ToInt32(dr["DistritoArribo"]);
                        servicioPrestadoDTO.FechaHoraArribo = Convert.ToDateTime(dr["FechaHoraArribo"]).ToString("yyy-MM-dd");
                        servicioPrestadoDTO.EmpresaReceptoraServicio = dr["EmpresaReceptoraServicio"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioPrestadoDTO;
        }

        public string ActualizaFormato(ServicioPrestadoDTO servicioPrestadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioPrestadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPrestadoId"].Value = servicioPrestadoDTO.ServicioPrestadoId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = servicioPrestadoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@DocumentoServicio", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DocumentoServicio"].Value = servicioPrestadoDTO.DocumentoServicio;

                    cmd.Parameters.Add("@FechaServicioPrestado", SqlDbType.Date);
                    cmd.Parameters["@FechaServicioPrestado"].Value = servicioPrestadoDTO.FechaServicioPrestado;

                    cmd.Parameters.Add("@UnidadAuxiliarNaval", SqlDbType.Int);
                    cmd.Parameters["@UnidadAuxiliarNaval"].Value = servicioPrestadoDTO.UnidadAuxiliarNaval;

                    cmd.Parameters.Add("@NroViajeComercial", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NroViajeComercial"].Value = servicioPrestadoDTO.NroViajeComercial;

                    cmd.Parameters.Add("@PuertoPeruZarpe", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruZarpe"].Value = servicioPrestadoDTO.PuertoPeruZarpe;

                    cmd.Parameters.Add("@DepartamentoZarpe", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoZarpe"].Value = servicioPrestadoDTO.DepartamentoZarpe;

                    cmd.Parameters.Add("@ProvinciaZarpe", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaZarpe"].Value = servicioPrestadoDTO.ProvinciaZarpe;

                    cmd.Parameters.Add("@DistritoZarpe", SqlDbType.Int);
                    cmd.Parameters["@DistritoZarpe"].Value = servicioPrestadoDTO.DistritoZarpe;

                    cmd.Parameters.Add("@FechaHoraZarpe", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraZarpe"].Value = servicioPrestadoDTO.FechaHoraZarpe;

                    cmd.Parameters.Add("@Ocurrencia", SqlDbType.VarChar, 500);
                    cmd.Parameters["@Ocurrencia"].Value = servicioPrestadoDTO.Ocurrencia;

                    cmd.Parameters.Add("@PuertoPeruArribo", SqlDbType.Int);
                    cmd.Parameters["@PuertoPeruArribo"].Value = servicioPrestadoDTO.PuertoPeruArribo;

                    cmd.Parameters.Add("@DepartamentoArribo", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoArribo"].Value = servicioPrestadoDTO.DepartamentoArribo;

                    cmd.Parameters.Add("@ProvinciaArribo", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaArribo"].Value = servicioPrestadoDTO.ProvinciaArribo;

                    cmd.Parameters.Add("@DistritoArribo", SqlDbType.Int);
                    cmd.Parameters["@DistritoArribo"].Value = servicioPrestadoDTO.DistritoArribo;

                    cmd.Parameters.Add("@FechaHoraArribo", SqlDbType.DateTime);
                    cmd.Parameters["@FechaHoraArribo"].Value = servicioPrestadoDTO.FechaHoraArribo;

                    cmd.Parameters.Add("@EmpresaReceptoraServicio", SqlDbType.VarChar, 500);
                    cmd.Parameters["@EmpresaReceptoraServicio"].Value = servicioPrestadoDTO.EmpresaReceptoraServicio;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPrestadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioPrestadoDTO servicioPrestadoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioPrestadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPrestadoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioPrestadoId"].Value = servicioPrestadoDTO.ServicioPrestadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioPrestadoDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, int mes, int anio)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_ServicioPrestadoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioPrestado", SqlDbType.Structured);
                    cmd.Parameters["@ServicioPrestado"].TypeName = "Formato.ServicioPrestado";
                    cmd.Parameters["@ServicioPrestado"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@R_Mes", SqlDbType.Int);
                    cmd.Parameters["@R_Mes"].Value = mes;

                    cmd.Parameters.Add("@R_Anio", SqlDbType.Int);
                    cmd.Parameters["@R_Anio"].Value = anio;

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
