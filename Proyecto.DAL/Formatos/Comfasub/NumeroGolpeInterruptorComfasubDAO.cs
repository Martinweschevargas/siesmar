using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class NumeroGolpeInterruptorComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<NumeroGolpeInterruptorComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<NumeroGolpeInterruptorComfasubDTO> lista = new List<NumeroGolpeInterruptorComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_NumeroGolpeInterruptorComfasubListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NumeroGolpeInterruptorComfasubDTO()
                        {
                            NumeroGolpeInterruptorComfasubId = Convert.ToInt32(dr["NumeroGolpeInterruptorComfasubId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaPropulsion = dr["DescSistemaPropulsion"].ToString(),
                            DescSubSistemaPropulsion = dr["DescSubSistemaPropulsion"].ToString(),
                            DescEquipoSistemaPropulsion = dr["DescEquipoSistemaPropulsion"].ToString(),
                            GolpeFijadoRecorridoTotal = Convert.ToInt32(dr["GolpeFijadoRecorridoTotal"]),
                            GolpeFijadoRecorridoParcial = Convert.ToInt32(dr["GolpeFijadoRecorridoParcial"]),
                            GolpeUltimoRecorrido = Convert.ToInt32(dr["GolpeUltimoRecorrido"]),
                            GolpeTotalInstalacion = Convert.ToInt32(dr["GolpeTotalInstalacion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NumeroGolpeInterruptorComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = numeroGolpeInterruptorComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoEquipoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEquipoSistemaPropulsion"].Value = numeroGolpeInterruptorComfasubDTO.CodigoEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@GolpeFijadoRecorridoTotal", SqlDbType.Int);
                    cmd.Parameters["@GolpeFijadoRecorridoTotal"].Value = numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoTotal;

                    cmd.Parameters.Add("@GolpeFijadoRecorridoParcial", SqlDbType.Int);
                    cmd.Parameters["@GolpeFijadoRecorridoParcial"].Value = numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoParcial;

                    cmd.Parameters.Add("@GolpeUltimoRecorrido", SqlDbType.Int);
                    cmd.Parameters["@GolpeUltimoRecorrido"].Value = numeroGolpeInterruptorComfasubDTO.GolpeUltimoRecorrido;

                    cmd.Parameters.Add("@GolpeTotalInstalacion", SqlDbType.Int);
                    cmd.Parameters["@GolpeTotalInstalacion"].Value = numeroGolpeInterruptorComfasubDTO.GolpeTotalInstalacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = numeroGolpeInterruptorComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroGolpeInterruptorComfasubDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public NumeroGolpeInterruptorComfasubDTO BuscarFormato(int Codigo)
        {
            NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO = new NumeroGolpeInterruptorComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NumeroGolpeInterruptorComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroGolpeInterruptorComfasubId", SqlDbType.Int);
                    cmd.Parameters["@NumeroGolpeInterruptorComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        numeroGolpeInterruptorComfasubDTO.NumeroGolpeInterruptorComfasubId = Convert.ToInt32(dr["NumeroGolpeInterruptorComfasubId"]);
                        numeroGolpeInterruptorComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        numeroGolpeInterruptorComfasubDTO.CodigoEquipoSistemaPropulsion = dr["CodigoEquipoSistemaPropulsion"].ToString();
                        numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoTotal = Convert.ToInt32(dr["GolpeFijadoRecorridoTotal"]);
                        numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoParcial = Convert.ToInt32(dr["GolpeFijadoRecorridoParcial"]);
                        numeroGolpeInterruptorComfasubDTO.GolpeUltimoRecorrido = Convert.ToInt32(dr["GolpeUltimoRecorrido"]);
                        numeroGolpeInterruptorComfasubDTO.GolpeTotalInstalacion = Convert.ToInt32(dr["GolpeTotalInstalacion"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return numeroGolpeInterruptorComfasubDTO;
        }

        public string ActualizaFormato(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_NumeroGolpeInterruptorComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@NumeroGolpeInterruptorComfasubId", SqlDbType.Int);
                    cmd.Parameters["@NumeroGolpeInterruptorComfasubId"].Value = numeroGolpeInterruptorComfasubDTO.NumeroGolpeInterruptorComfasubId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = numeroGolpeInterruptorComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoEquipoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEquipoSistemaPropulsion"].Value = numeroGolpeInterruptorComfasubDTO.CodigoEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@GolpeFijadoRecorridoTotal", SqlDbType.Int);
                    cmd.Parameters["@GolpeFijadoRecorridoTotal"].Value = numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoTotal;

                    cmd.Parameters.Add("@GolpeFijadoRecorridoParcial", SqlDbType.Int);
                    cmd.Parameters["@GolpeFijadoRecorridoParcial"].Value = numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoParcial;

                    cmd.Parameters.Add("@GolpeUltimoRecorrido", SqlDbType.Int);
                    cmd.Parameters["@GolpeUltimoRecorrido"].Value = numeroGolpeInterruptorComfasubDTO.GolpeUltimoRecorrido;

                    cmd.Parameters.Add("@GolpeTotalInstalacion", SqlDbType.Int);
                    cmd.Parameters["@GolpeTotalInstalacion"].Value = numeroGolpeInterruptorComfasubDTO.GolpeTotalInstalacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroGolpeInterruptorComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_NumeroGolpeInterruptorComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroGolpeInterruptorComfasubId", SqlDbType.Int);
                    cmd.Parameters["@NumeroGolpeInterruptorComfasubId"].Value = numeroGolpeInterruptorComfasubDTO.NumeroGolpeInterruptorComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroGolpeInterruptorComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "NumeroGolpeInterruptorComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = numeroGolpeInterruptorComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = numeroGolpeInterruptorComfasubDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_NumeroGolpeInterruptorComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroGolpeInterruptorComfasub", SqlDbType.Structured);
                    cmd.Parameters["@NumeroGolpeInterruptorComfasub"].TypeName = "Formato.NumeroGolpeInterruptorComfasub";
                    cmd.Parameters["@NumeroGolpeInterruptorComfasub"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
