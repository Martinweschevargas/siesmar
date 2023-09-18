using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperama
{
    public class IngresoAlistamientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<IngresoAlistamientoDTO> ObtenerLista(int? CargaId = null)
        {
            List<IngresoAlistamientoDTO> lista = new List<IngresoAlistamientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_IngresoAlistamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new IngresoAlistamientoDTO()
                        {
                            IngresoAlistamientoId = Convert.ToInt32(dr["IngresoAlistamientoId"]),
                            DescComandanciaDependencia = dr["DescComandanciaDependencia"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            Aliper = Convert.ToDecimal(dr["Aliper"]),
                            Alient = Convert.ToDecimal(dr["Alient"]),
                            Alimat = Convert.ToDecimal(dr["Alimat"]),
                            Alilog = Convert.ToDecimal(dr["Alilog"]),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(IngresoAlistamientoDTO ingresoAlistamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoAlistamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoAlistamientoId", SqlDbType.Int);
                    cmd.Parameters["@IngresoAlistamientoId"].Value = ingresoAlistamientoDTO.IngresoAlistamientoId;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = ingresoAlistamientoDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar);
                    cmd.Parameters["@CodigoDependencia"].Value = ingresoAlistamientoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Aliper", SqlDbType.Decimal);
                    cmd.Parameters["@Aliper"].Value = ingresoAlistamientoDTO.Aliper;

                    cmd.Parameters.Add("@Alient", SqlDbType.Decimal);
                    cmd.Parameters["@Alient"].Value = ingresoAlistamientoDTO.Alient;

                    cmd.Parameters.Add("@Alimat", SqlDbType.Decimal);
                    cmd.Parameters["@Alimat"].Value = ingresoAlistamientoDTO.Alimat;

                    cmd.Parameters.Add("@Alilog", SqlDbType.Decimal);
                    cmd.Parameters["@Alilog"].Value = ingresoAlistamientoDTO.Alilog;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = ingresoAlistamientoDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = ingresoAlistamientoDTO.FechaTermino;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ingresoAlistamientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoAlistamientoDTO.UsuarioIngresoRegistro;

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

        public IngresoAlistamientoDTO BuscarFormato(int Codigo)
        {
            IngresoAlistamientoDTO ingresoAlistamientoDTO = new IngresoAlistamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoAlistamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoAlistamientoId", SqlDbType.Int);
                    cmd.Parameters["@IngresoAlistamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ingresoAlistamientoDTO.IngresoAlistamientoId = Convert.ToInt32(dr["IngresoAlistamientoId"]);
                        ingresoAlistamientoDTO.CodigoComandanciaDependencia = dr["CodigoComandanciaDependencia"].ToString();
                        ingresoAlistamientoDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        ingresoAlistamientoDTO.Aliper = Convert.ToDecimal(dr["Aliper"]);
                        ingresoAlistamientoDTO.Alient = Convert.ToDecimal(dr["Alient"]);
                        ingresoAlistamientoDTO.Alimat = Convert.ToDecimal(dr["Alimat"]);
                        ingresoAlistamientoDTO.Alilog = Convert.ToDecimal(dr["Alilog"]);
                        ingresoAlistamientoDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        ingresoAlistamientoDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd"); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingresoAlistamientoDTO;
        }

        public string ActualizaFormato(IngresoAlistamientoDTO ingresoAlistamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_IngresoAlistamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@IngresoAlistamientoId", SqlDbType.Int);
                    cmd.Parameters["@IngresoAlistamientoId"].Value = ingresoAlistamientoDTO.IngresoAlistamientoId;

                    cmd.Parameters.Add("@CodigoComandanciaDependencia", SqlDbType.VarChar);
                    cmd.Parameters["@CodigoComandanciaDependencia"].Value = ingresoAlistamientoDTO.CodigoComandanciaDependencia;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar);
                    cmd.Parameters["@CodigoDependencia"].Value = ingresoAlistamientoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Aliper", SqlDbType.Decimal);
                    cmd.Parameters["@Aliper"].Value = ingresoAlistamientoDTO.Aliper;

                    cmd.Parameters.Add("@Alient", SqlDbType.Decimal);
                    cmd.Parameters["@Alient"].Value = ingresoAlistamientoDTO.Alient;

                    cmd.Parameters.Add("@Alimat", SqlDbType.Decimal);
                    cmd.Parameters["@Alimat"].Value = ingresoAlistamientoDTO.Alimat;

                    cmd.Parameters.Add("@Alilog", SqlDbType.Decimal);
                    cmd.Parameters["@Alilog"].Value = ingresoAlistamientoDTO.Alilog;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = ingresoAlistamientoDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = ingresoAlistamientoDTO.FechaTermino;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoAlistamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(IngresoAlistamientoDTO ingresoAlistamientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoAlistamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoAlistamientoId", SqlDbType.Int);
                    cmd.Parameters["@IngresoAlistamientoId"].Value = ingresoAlistamientoDTO.IngresoAlistamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoAlistamientoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_IngresoAlistamientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoAlistamiento", SqlDbType.Structured);
                    cmd.Parameters["@IngresoAlistamiento"].TypeName = "Formato.IngresoAlistamiento";
                    cmd.Parameters["@IngresoAlistamiento"].Value = datos;

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
