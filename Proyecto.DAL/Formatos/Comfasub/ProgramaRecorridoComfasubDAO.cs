using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comfasub
{
    public class ProgramaRecorridoComfasubDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ProgramaRecorridoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ProgramaRecorridoComfasubDTO> lista = new List<ProgramaRecorridoComfasubDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ProgramaRecorridoComfasubListar", conexion);
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
                        lista.Add(new ProgramaRecorridoComfasubDTO()
                        {
                            ProgramaRecorridoComfasubId = Convert.ToInt32(dr["ProgramaRecorridoComfasubId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            CapacidadIntrinseca = dr["CapacidadIntrinseca"].ToString(),
                            Subclasificacion = dr["Subclasificacion"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            RecorridoDia = Convert.ToInt32(dr["RecorridoDia"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProgramaRecorridoComfasubRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = programaRecorridoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = programaRecorridoComfasubDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = programaRecorridoComfasubDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = programaRecorridoComfasubDTO.FechaTermino;

                    cmd.Parameters.Add("@RecorridoDia", SqlDbType.Int);
                    cmd.Parameters["@RecorridoDia"].Value = programaRecorridoComfasubDTO.RecorridoDia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = programaRecorridoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaRecorridoComfasubDTO.UsuarioIngresoRegistro;

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

        public ProgramaRecorridoComfasubDTO BuscarFormato(int Codigo)
        {
            ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO = new ProgramaRecorridoComfasubDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProgramaRecorridoComfasubEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaRecorridoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaRecorridoComfasubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        programaRecorridoComfasubDTO.ProgramaRecorridoComfasubId = Convert.ToInt32(dr["ProgramaRecorridoComfasubId"]);
                        programaRecorridoComfasubDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        programaRecorridoComfasubDTO.CodigoAlistamientoMaterialRequerido2N = dr["CodigoAlistamientoMaterialRequerido2N"].ToString();
                        programaRecorridoComfasubDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        programaRecorridoComfasubDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        programaRecorridoComfasubDTO.RecorridoDia = Convert.ToInt32(dr["RecorridoDia"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return programaRecorridoComfasubDTO;
        }

        public string ActualizaFormato(ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ProgramaRecorridoComfasubActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ProgramaRecorridoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaRecorridoComfasubId"].Value = programaRecorridoComfasubDTO.ProgramaRecorridoComfasubId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = programaRecorridoComfasubDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido2N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido2N"].Value = programaRecorridoComfasubDTO.CodigoAlistamientoMaterialRequerido2N;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = programaRecorridoComfasubDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = programaRecorridoComfasubDTO.FechaTermino;

                    cmd.Parameters.Add("@RecorridoDia", SqlDbType.Int);
                    cmd.Parameters["@RecorridoDia"].Value = programaRecorridoComfasubDTO.RecorridoDia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaRecorridoComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ProgramaRecorridoComfasubEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaRecorridoComfasubId", SqlDbType.Int);
                    cmd.Parameters["@ProgramaRecorridoComfasubId"].Value = programaRecorridoComfasubDTO.ProgramaRecorridoComfasubId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaRecorridoComfasubDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO)
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
                    cmd.Parameters["@Formato"].Value = "ProgramaRecorridoComfasub";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = programaRecorridoComfasubDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = programaRecorridoComfasubDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ProgramaRecorridoComfasubRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProgramaRecorridoComfasub", SqlDbType.Structured);
                    cmd.Parameters["@ProgramaRecorridoComfasub"].TypeName = "Formato.ProgramaRecorridoComfasub";
                    cmd.Parameters["@ProgramaRecorridoComfasub"].Value = datos;

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
