using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzodos
{
    public class ServicioBrindadoBaseCallaoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ServicioBrindadoBaseCallaoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<ServicioBrindadoBaseCallaoDTO> lista = new List<ServicioBrindadoBaseCallaoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ServicioBrindadoBaseCallaoListar", conexion);
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
                        lista.Add(new ServicioBrindadoBaseCallaoDTO()
                        {
                            ServicioBrindadoBaseCallaoId = Convert.ToInt32(dr["ServicioBrindadoBaseCallaoId"]),
                            FechaServicio = (dr["FechaServicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EmpresaReceptoraServicio = dr["EmpresaReceptoraServicio"].ToString(),
                            DescServicioBrindado = dr["DescServicioBrindado"].ToString(),
                            TiempoEmpleado = dr["TiempoEmpleado"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioBrindadoBaseCallaoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaServicio", SqlDbType.Date);
                    cmd.Parameters["@FechaServicio"].Value = servicioBrindadoBaseCallaoDTO.FechaServicio;

                    cmd.Parameters.Add("@EmpresaReceptoraServicio", SqlDbType.VarChar,500);
                    cmd.Parameters["@EmpresaReceptoraServicio"].Value = servicioBrindadoBaseCallaoDTO.EmpresaReceptoraServicio;

                    cmd.Parameters.Add("@CodigoServicioBrindado", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoServicioBrindado"].Value = servicioBrindadoBaseCallaoDTO.CodigoServicioBrindado;

                    cmd.Parameters.Add("@TiempoEmpleado", SqlDbType.Time);
                    cmd.Parameters["@TiempoEmpleado"].Value = servicioBrindadoBaseCallaoDTO.TiempoEmpleado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioBrindadoBaseCallaoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro;

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

        public ServicioBrindadoBaseCallaoDTO BuscarFormato(int Codigo)
        {
            ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO = new ServicioBrindadoBaseCallaoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioBrindadoBaseCallaoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioBrindadoBaseCallaoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioBrindadoBaseCallaoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        servicioBrindadoBaseCallaoDTO.ServicioBrindadoBaseCallaoId = Convert.ToInt32(dr["ServicioBrindadoBaseCallaoId"]);
                        servicioBrindadoBaseCallaoDTO.FechaServicio = Convert.ToDateTime(dr["FechaServicio"]).ToString("yyy-MM-dd");
                        servicioBrindadoBaseCallaoDTO.EmpresaReceptoraServicio = dr["EmpresaReceptoraServicio"].ToString();
                        servicioBrindadoBaseCallaoDTO.CodigoServicioBrindado = dr["CodigoServicioBrindado"].ToString();
                        servicioBrindadoBaseCallaoDTO.TiempoEmpleado = dr["TiempoEmpleado"].ToString(); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return servicioBrindadoBaseCallaoDTO;
        }

        public string ActualizaFormato(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ServicioBrindadoBaseCallaoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ServicioBrindadoBaseCallaoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioBrindadoBaseCallaoId"].Value = servicioBrindadoBaseCallaoDTO.ServicioBrindadoBaseCallaoId;

                    cmd.Parameters.Add("@FechaServicio", SqlDbType.Date);
                    cmd.Parameters["@FechaServicio"].Value = servicioBrindadoBaseCallaoDTO.FechaServicio;

                    cmd.Parameters.Add("@EmpresaReceptoraServicio", SqlDbType.VarChar,500);
                    cmd.Parameters["@EmpresaReceptoraServicio"].Value = servicioBrindadoBaseCallaoDTO.EmpresaReceptoraServicio;

                    cmd.Parameters.Add("@CodigoServicioBrindado", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoServicioBrindado"].Value = servicioBrindadoBaseCallaoDTO.CodigoServicioBrindado;

                    cmd.Parameters.Add("@TiempoEmpleado", SqlDbType.Time);
                    cmd.Parameters["@TiempoEmpleado"].Value = servicioBrindadoBaseCallaoDTO.TiempoEmpleado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ServicioBrindadoBaseCallaoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioBrindadoBaseCallaoId", SqlDbType.Int);
                    cmd.Parameters["@ServicioBrindadoBaseCallaoId"].Value = servicioBrindadoBaseCallaoDTO.ServicioBrindadoBaseCallaoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO)
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
                    cmd.Parameters["@Formato"].Value = "ServicioBrindadoBaseCallao";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = servicioBrindadoBaseCallaoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ServicioBrindadoBaseCallaoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ServicioBrindadoBaseCallao", SqlDbType.Structured);
                    cmd.Parameters["@ServicioBrindadoBaseCallao"].TypeName = "Formato.ServicioBrindadoBaseCallao";
                    cmd.Parameters["@ServicioBrindadoBaseCallao"].Value = datos;

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