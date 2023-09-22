using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class ProgramaDiqueoComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ProgramaDiqueoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ProgramaDiqueoComfasubDTO> lista = new List<ProgramaDiqueoComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ProgramaDiqueoComfasubListar", conexion);
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
                        lista.Add(new ProgramaDiqueoComfasubDTO()
                        {
                            ProgramaDiqueoComfasubId = Convert.ToInt32(dr["ProgramaDiqueoComfasubId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString(),
                            Subclasificacion = dr["Subclasificacion"].ToString(),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaSalida = (dr["FechaSalida"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            PermanenciaDia = Convert.ToInt32(dr["PermanenciaDia"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProgramaDiqueoComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = programaDiqueoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = programaDiqueoComfasubDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = programaDiqueoComfasubDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaSalida", SqlDbType.Date);
                    cmd.Parameters["@FechaSalida"].Value = programaDiqueoComfasubDTO.FechaSalida;

                    cmd.Parameters.Add("@PermanenciaDia", SqlDbType.Int);
                    cmd.Parameters["@PermanenciaDia"].Value = programaDiqueoComfasubDTO.PermanenciaDia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = programaDiqueoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaDiqueoComfasubDTO.UsuarioIngresoRegistro;

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

        public ProgramaDiqueoComfasubDTO BuscarFormato(int Codigo)
        {
            ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO = new ProgramaDiqueoComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProgramaDiqueoComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaDiqueoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaDiqueoComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        programaDiqueoComfasubDTO.ProgramaDiqueoComfasubId = Convert.ToInt32(dr["ProgramaDiqueoComfasubId"]);
                        programaDiqueoComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        programaDiqueoComfasubDTO.CodigoAlistamientoMaterialRequerido2N = dr["CodigoAlistamientoMaterialRequerido2N"].ToString();
                        programaDiqueoComfasubDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd");
                        programaDiqueoComfasubDTO.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]).ToString("yyy-MM-dd");
                        programaDiqueoComfasubDTO.PermanenciaDia = Convert.ToInt32(dr["PermanenciaDia"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return programaDiqueoComfasubDTO;
        }

        public string ActualizaFormato(ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProgramaDiqueoComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ProgramaDiqueoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaDiqueoComfasubId"].Value = programaDiqueoComfasubDTO.ProgramaDiqueoComfasubId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = programaDiqueoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = programaDiqueoComfasubDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = programaDiqueoComfasubDTO.FechaIngreso;

                    cmd.Parameters.Add("@FechaSalida", SqlDbType.Date);
                    cmd.Parameters["@FechaSalida"].Value = programaDiqueoComfasubDTO.FechaSalida;

                    cmd.Parameters.Add("@PermanenciaDia", SqlDbType.Int);
                    cmd.Parameters["@PermanenciaDia"].Value = programaDiqueoComfasubDTO.PermanenciaDia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaDiqueoComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProgramaDiqueoComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaDiqueoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaDiqueoComfasubId"].Value = programaDiqueoComfasubDTO.ProgramaDiqueoComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaDiqueoComfasubDTO.UsuarioIngresoRegistro;

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


        public bool EliminarCarga(ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "ProgramaDiqueoComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = programaDiqueoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaDiqueoComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ProgramaDiqueoComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaDiqueoComfasub", SqlDbType.Structured);
                    cmd.Parameters["@ProgramaDiqueoComfasub"].TypeName = "Formato.ProgramaDiqueoComfasub";
                    cmd.Parameters["@ProgramaDiqueoComfasub"].Value = datos;

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
