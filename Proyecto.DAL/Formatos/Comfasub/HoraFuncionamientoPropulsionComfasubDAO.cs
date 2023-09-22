using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class HoraFuncionamientoPropulsionComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<HoraFuncionamientoPropulsionComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<HoraFuncionamientoPropulsionComfasubDTO> lista = new List<HoraFuncionamientoPropulsionComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_HoraFuncionamientoPropulsionComfasubListar", conexion);
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
                        lista.Add(new HoraFuncionamientoPropulsionComfasubDTO()
                        {
                            HoraFuncionamientoPropulsionComfasubId = Convert.ToInt32(dr["HoraFuncionamientoPropulsionComfasubId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescSistemaPropulsion = dr["DescSistemaPropulsion"].ToString(),
                            DescEquipoSistemaPropulsion = dr["DescEquipoSistemaPropulsion"].ToString(),
                            HoraFijadaRecorridoTotal = Convert.ToInt32(dr["HoraFijadaRecorridoTotal"]),
                            HoraFijadaRecorridoParcial = Convert.ToInt32(dr["HoraFijadaRecorridoParcial"]),
                            FechaUltimoRecorrdio = (dr["FechaUltimoRecorrdio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            HoraUltimoRecorrido = Convert.ToInt32(dr["HoraUltimoRecorrido"]),
                            HoraTotalInstalacion = Convert.ToInt32(dr["HoraTotalInstalacion"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_HoraFuncionamientoPropulsionComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = horaFuncionamientoPropulsionComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoEquipoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEquipoSistemaPropulsion"].Value = horaFuncionamientoPropulsionComfasubDTO.CodigoEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@HoraFijadaRecorridoTotal", SqlDbType.Int);
                    cmd.Parameters["@HoraFijadaRecorridoTotal"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoTotal;

                    cmd.Parameters.Add("@HoraFijadaRecorridoParcial", SqlDbType.Int);
                    cmd.Parameters["@HoraFijadaRecorridoParcial"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoParcial;

                    cmd.Parameters.Add("@FechaUltimoRecorrdio", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoRecorrdio"].Value = horaFuncionamientoPropulsionComfasubDTO.FechaUltimoRecorrdio;

                    cmd.Parameters.Add("@HoraUltimoRecorrido", SqlDbType.Int);
                    cmd.Parameters["@HoraUltimoRecorrido"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraUltimoRecorrido;

                    cmd.Parameters.Add("@HoraTotalInstalacion", SqlDbType.Int);
                    cmd.Parameters["@HoraTotalInstalacion"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraTotalInstalacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = horaFuncionamientoPropulsionComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = horaFuncionamientoPropulsionComfasubDTO.UsuarioIngresoRegistro;

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

        public HoraFuncionamientoPropulsionComfasubDTO BuscarFormato(int Codigo)
        {
            HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO = new HoraFuncionamientoPropulsionComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_HoraFuncionamientoPropulsionComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@HoraFuncionamientoPropulsionComfasubId", SqlDbType.Int);
                    cmd.Parameters["@HoraFuncionamientoPropulsionComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        horaFuncionamientoPropulsionComfasubDTO.HoraFuncionamientoPropulsionComfasubId = Convert.ToInt32(dr["HoraFuncionamientoPropulsionComfasubId"]);
                        horaFuncionamientoPropulsionComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString(); ToString();
                        horaFuncionamientoPropulsionComfasubDTO.CodigoEquipoSistemaPropulsion = dr["CodigoEquipoSistemaPropulsion"].ToString();ToString();
                        horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoTotal = Convert.ToInt32(dr["HoraFijadaRecorridoTotal"]);
                        horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoParcial = Convert.ToInt32(dr["HoraFijadaRecorridoParcial"]);
                        horaFuncionamientoPropulsionComfasubDTO.FechaUltimoRecorrdio = Convert.ToDateTime(dr["FechaUltimoRecorrdio"]).ToString("yyy-MM-dd");
                        horaFuncionamientoPropulsionComfasubDTO.HoraUltimoRecorrido = Convert.ToInt32(dr["HoraUltimoRecorrido"]);
                        horaFuncionamientoPropulsionComfasubDTO.HoraTotalInstalacion = Convert.ToInt32(dr["HoraTotalInstalacion"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return horaFuncionamientoPropulsionComfasubDTO;
        }

        public string ActualizaFormato(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_HoraFuncionamientoPropulsionComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@HoraFuncionamientoPropulsionComfasubId", SqlDbType.Int);
                    cmd.Parameters["@HoraFuncionamientoPropulsionComfasubId"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraFuncionamientoPropulsionComfasubId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = horaFuncionamientoPropulsionComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoEquipoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEquipoSistemaPropulsion"].Value = horaFuncionamientoPropulsionComfasubDTO.CodigoEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@HoraFijadaRecorridoTotal", SqlDbType.Int);
                    cmd.Parameters["@HoraFijadaRecorridoTotal"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoTotal;

                    cmd.Parameters.Add("@HoraFijadaRecorridoParcial", SqlDbType.Int);
                    cmd.Parameters["@HoraFijadaRecorridoParcial"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoParcial;

                    cmd.Parameters.Add("@FechaUltimoRecorrdio", SqlDbType.Date);
                    cmd.Parameters["@FechaUltimoRecorrdio"].Value = horaFuncionamientoPropulsionComfasubDTO.FechaUltimoRecorrdio;

                    cmd.Parameters.Add("@HoraUltimoRecorrido", SqlDbType.Int);
                    cmd.Parameters["@HoraUltimoRecorrido"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraUltimoRecorrido;

                    cmd.Parameters.Add("@HoraTotalInstalacion", SqlDbType.Int);
                    cmd.Parameters["@HoraTotalInstalacion"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraTotalInstalacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = horaFuncionamientoPropulsionComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_HoraFuncionamientoPropulsionComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@HoraFuncionamientoPropulsionComfasubId", SqlDbType.Int);
                    cmd.Parameters["@HoraFuncionamientoPropulsionComfasubId"].Value = horaFuncionamientoPropulsionComfasubDTO.HoraFuncionamientoPropulsionComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = horaFuncionamientoPropulsionComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "HoraFuncionamientoPropulsionComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = horaFuncionamientoPropulsionComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = horaFuncionamientoPropulsionComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_HoraFuncionamientoPropulsionComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@HoraFuncionamientoPropulsionComfasub", SqlDbType.Structured);
                    cmd.Parameters["@HoraFuncionamientoPropulsionComfasub"].TypeName = "Formato.HoraFuncionamientoPropulsionComfasub";
                    cmd.Parameters["@HoraFuncionamientoPropulsionComfasub"].Value = datos;

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
