using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class MaterialRecreacionEntretenamientoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MaterialRecreacionEntretenamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<MaterialRecreacionEntretenamientoDTO> lista = new List<MaterialRecreacionEntretenamientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MaterialRecreacionEntretenamientoListar", conexion);
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
                        lista.Add(new MaterialRecreacionEntretenamientoDTO()
                        {
                            MaterialRecreacionEntretenamientoId = Convert.ToInt32(dr["MaterialRecreacionEntretenamientoId"]),
                            FechaSolicitud = (dr["FechaSolicitud"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescMaterialDeportivo = dr["DescMaterialDeportivo"].ToString(),
                            CantidadSolicitadoDeportivo = Convert.ToInt32(dr["CantidadSolicitadoDeportivo"]),
                            CantidadAtendidoDeportivo = Convert.ToInt32(dr["CantidadAtendidoDeportivo"]),
                            MontoSolesSolicitadoDeportivo = Convert.ToDecimal(dr["MontoSolesSolicitadoDeportivo"]),
                            MontoSolesAtendidoDeportivo = Convert.ToDecimal(dr["MontoSolesAtendidoDeportivo"]),
                            DescMaterialRecreativo = dr["DescMaterialRecreativo"].ToString(),
                            CantidadSolicitadoRecreativo = Convert.ToInt32(dr["CantidadSolicitadoRecreativo"]),
                            CantidadAtendidoRecreativo = Convert.ToInt32(dr["CantidadAtendidoRecreativo"]),
                            MontoSolesSolicitanteRecreativo = Convert.ToDecimal(dr["MontoSolesSolicitanteRecreativo"]),
                            MontoSolesAtendidoRecreativo = Convert.ToDecimal(dr["MontoSolesAtendidoRecreativo"]),
                            DescMaterialEntretenimiento = dr["DescMaterialEntretenimiento"].ToString(),
                            CantidadSolicitadoEntretenimiento = Convert.ToInt32(dr["CantidadSolicitadoEntretenimiento"]),
                            CantidadAtendidoEntretenimiento = Convert.ToInt32(dr["CantidadAtendidoEntretenimiento"]),
                            MontoSolesSolicitadoEntretenimiento = Convert.ToDecimal(dr["MontoSolesSolicitadoEntretenimiento"]),
                            MontoSolesAtendidoEntretenimiento = Convert.ToDecimal(dr["MontoSolesAtendidoEntretenimiento"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<MaterialRecreacionEntretenamientoDTO> BienestarVisualizacionMaterialRecreacionEntretenmiento(int? CargaId=null, string? fechaInicio=null, string? fechaFin=null)
        {
            List<MaterialRecreacionEntretenamientoDTO> lista = new List<MaterialRecreacionEntretenamientoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionMaterialRecreacionEntretenmiento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechaInicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechaFin;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MaterialRecreacionEntretenamientoDTO()
                        {
                            FechaSolicitud = dr["FechaSolicitud"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescMaterialDeportivo = dr["DescMaterialDeportivo"].ToString(),
                            CantidadSolicitadoDeportivo = Convert.ToInt32(dr["CantidadSolicitadoDeportivo"]),
                            CantidadAtendidoDeportivo = Convert.ToInt32(dr["CantidadAtendidoDeportivo"]),
                            MontoSolesSolicitadoDeportivo = Convert.ToDecimal(dr["MontoSolesSolicitadoDeportivo"]),
                            MontoSolesAtendidoDeportivo = Convert.ToDecimal(dr["MontoSolesAtendidoDeportivo"]),
                            DescMaterialRecreativo = dr["DescMaterialRecreativo"].ToString(),
                            CantidadSolicitadoRecreativo = Convert.ToInt32(dr["CantidadSolicitadoRecreativo"]),
                            CantidadAtendidoRecreativo = Convert.ToInt32(dr["CantidadAtendidoRecreativo"]),
                            MontoSolesSolicitanteRecreativo = Convert.ToDecimal(dr["MontoSolesSolicitanteRecreativo"]),
                            MontoSolesAtendidoRecreativo = Convert.ToDecimal(dr["MontoSolesAtendidoRecreativo"]),
                            DescMaterialEntretenimiento = dr["DescMaterialEntretenimiento"].ToString(),
                            CantidadSolicitadoEntretenimiento = Convert.ToInt32(dr["CantidadSolicitadoEntretenimiento"]),
                            CantidadAtendidoEntretenimiento = Convert.ToInt32(dr["CantidadAtendidoEntretenimiento"]),
                            MontoSolesSolicitadoEntretenimiento = Convert.ToDecimal(dr["MontoSolesSolicitadoEntretenimiento"]),
                            MontoSolesAtendidoEntretenimiento = Convert.ToDecimal(dr["MontoSolesAtendidoEntretenimiento"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MaterialRecreacionEntretenamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = materialRecreacionEntretenamientoDTO.FechaSolicitud;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = materialRecreacionEntretenamientoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoMaterialDeportivo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialDeportivo"].Value = materialRecreacionEntretenamientoDTO.CodigoMaterialDeportivo;

                    cmd.Parameters.Add("@CantidadSolicitadoDeportivo", SqlDbType.Int);
                    cmd.Parameters["@CantidadSolicitadoDeportivo"].Value = materialRecreacionEntretenamientoDTO.CantidadSolicitadoDeportivo;

                    cmd.Parameters.Add("@CantidadAtendidoDeportivo", SqlDbType.Int);
                    cmd.Parameters["@CantidadAtendidoDeportivo"].Value = materialRecreacionEntretenamientoDTO.CantidadAtendidoDeportivo;

                    cmd.Parameters.Add("@MontoSolesSolicitadoDeportivo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesSolicitadoDeportivo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoDeportivo;

                    cmd.Parameters.Add("@MontoSolesAtendidoDeportivo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesAtendidoDeportivo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesAtendidoDeportivo;

                    cmd.Parameters.Add("@CodigoMaterialRecreativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMaterialRecreativo"].Value = materialRecreacionEntretenamientoDTO.CodigoMaterialRecreativo;

                    cmd.Parameters.Add("@CantidadSolicitadoRecreativo", SqlDbType.Int);
                    cmd.Parameters["@CantidadSolicitadoRecreativo"].Value = materialRecreacionEntretenamientoDTO.CantidadSolicitadoRecreativo;

                    cmd.Parameters.Add("@CantidadAtendidoRecreativo", SqlDbType.Int);
                    cmd.Parameters["@CantidadAtendidoRecreativo"].Value = materialRecreacionEntretenamientoDTO.CantidadAtendidoRecreativo;

                    cmd.Parameters.Add("@MontoSolesSolicitanteRecreativo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesSolicitanteRecreativo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesSolicitanteRecreativo;

                    cmd.Parameters.Add("@MontoSolesAtendidoRecreativo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesAtendidoRecreativo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesAtendidoRecreativo;

                    cmd.Parameters.Add("@CodigoMaterialEntretenimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.CodigoMaterialEntretenimiento;

                    cmd.Parameters.Add("@CantidadSolicitadoEntretenimiento", SqlDbType.Int);
                    cmd.Parameters["@CantidadSolicitadoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.CantidadSolicitadoEntretenimiento;

                    cmd.Parameters.Add("@CantidadAtendidoEntretenimiento", SqlDbType.Int);
                    cmd.Parameters["@CantidadAtendidoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.CantidadAtendidoEntretenimiento;

                    cmd.Parameters.Add("@MontoSolesSolicitadoEntretenimiento", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesSolicitadoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoEntretenimiento;

                    cmd.Parameters.Add("@MontoSolesAtendidoEntretenimiento", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesAtendidoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.MontoSolesAtendidoEntretenimiento;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = materialRecreacionEntretenamientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro;

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

        public MaterialRecreacionEntretenamientoDTO BuscarFormato(int Codigo)
        {
            MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO = new MaterialRecreacionEntretenamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MaterialRecreacionEntretenamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRecreacionEntretenamientoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRecreacionEntretenamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        materialRecreacionEntretenamientoDTO.MaterialRecreacionEntretenamientoId = Convert.ToInt32(dr["MaterialRecreacionEntretenamientoId"]);
                        materialRecreacionEntretenamientoDTO.FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyy-MM-dd");
                        materialRecreacionEntretenamientoDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        materialRecreacionEntretenamientoDTO.CodigoMaterialDeportivo = dr["CodigoMaterialDeportivo"].ToString();
                        materialRecreacionEntretenamientoDTO.CantidadSolicitadoDeportivo = Convert.ToInt32(dr["CantidadSolicitadoDeportivo"]);
                        materialRecreacionEntretenamientoDTO.CantidadAtendidoDeportivo = Convert.ToInt32(dr["CantidadAtendidoDeportivo"]);
                        materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoDeportivo = Convert.ToDecimal(dr["MontoSolesSolicitadoDeportivo"]);
                        materialRecreacionEntretenamientoDTO.MontoSolesAtendidoDeportivo = Convert.ToDecimal(dr["MontoSolesAtendidoDeportivo"]);
                        materialRecreacionEntretenamientoDTO.CodigoMaterialRecreativo = dr["CodigoMaterialRecreativo"].ToString();
                        materialRecreacionEntretenamientoDTO.CantidadSolicitadoRecreativo = Convert.ToInt32(dr["CantidadSolicitadoRecreativo"]);
                        materialRecreacionEntretenamientoDTO.CantidadAtendidoRecreativo = Convert.ToInt32(dr["CantidadAtendidoRecreativo"]);
                        materialRecreacionEntretenamientoDTO.MontoSolesSolicitanteRecreativo = Convert.ToDecimal(dr["MontoSolesSolicitanteRecreativo"]);
                        materialRecreacionEntretenamientoDTO.MontoSolesAtendidoRecreativo = Convert.ToDecimal(dr["MontoSolesAtendidoRecreativo"]);
                        materialRecreacionEntretenamientoDTO.CodigoMaterialEntretenimiento = dr["CodigoMaterialEntretenimiento"].ToString();
                        materialRecreacionEntretenamientoDTO.CantidadSolicitadoEntretenimiento = Convert.ToInt32(dr["CantidadSolicitadoEntretenimiento"]);
                        materialRecreacionEntretenamientoDTO.CantidadAtendidoEntretenimiento = Convert.ToInt32(dr["CantidadAtendidoEntretenimiento"]);
                        materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoEntretenimiento = Convert.ToDecimal(dr["MontoSolesSolicitadoEntretenimiento"]);
                        materialRecreacionEntretenamientoDTO.MontoSolesAtendidoEntretenimiento = Convert.ToDecimal(dr["MontoSolesAtendidoEntretenimiento"]); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return materialRecreacionEntretenamientoDTO;
        }

        public string ActualizaFormato(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MaterialRecreacionEntretenamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;	

                    cmd.Parameters.Add("@MaterialRecreacionEntretenamientoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRecreacionEntretenamientoId"].Value = materialRecreacionEntretenamientoDTO.MaterialRecreacionEntretenamientoId;

                    cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date);
                    cmd.Parameters["@FechaSolicitud"].Value = materialRecreacionEntretenamientoDTO.FechaSolicitud;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia"].Value = materialRecreacionEntretenamientoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CodigoMaterialDeportivo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialDeportivo"].Value = materialRecreacionEntretenamientoDTO.CodigoMaterialDeportivo;

                    cmd.Parameters.Add("@CantidadSolicitadoDeportivo", SqlDbType.Int);
                    cmd.Parameters["@CantidadSolicitadoDeportivo"].Value = materialRecreacionEntretenamientoDTO.CantidadSolicitadoDeportivo;

                    cmd.Parameters.Add("@CantidadAtendidoDeportivo", SqlDbType.Int);
                    cmd.Parameters["@CantidadAtendidoDeportivo"].Value = materialRecreacionEntretenamientoDTO.CantidadAtendidoDeportivo;

                    cmd.Parameters.Add("@MontoSolesSolicitadoDeportivo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesSolicitadoDeportivo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoDeportivo;

                    cmd.Parameters.Add("@MontoSolesAtendidoDeportivo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesAtendidoDeportivo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesAtendidoDeportivo;

                    cmd.Parameters.Add("@CodigoMaterialRecreativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoMaterialRecreativo"].Value = materialRecreacionEntretenamientoDTO.CodigoMaterialRecreativo;

                    cmd.Parameters.Add("@CantidadSolicitadoRecreativo", SqlDbType.Int);
                    cmd.Parameters["@CantidadSolicitadoRecreativo"].Value = materialRecreacionEntretenamientoDTO.CantidadSolicitadoRecreativo;

                    cmd.Parameters.Add("@CantidadAtendidoRecreativo", SqlDbType.Int);
                    cmd.Parameters["@CantidadAtendidoRecreativo"].Value = materialRecreacionEntretenamientoDTO.CantidadAtendidoRecreativo;

                    cmd.Parameters.Add("@MontoSolesSolicitanteRecreativo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesSolicitanteRecreativo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesSolicitanteRecreativo;

                    cmd.Parameters.Add("@MontoSolesAtendidoRecreativo", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesAtendidoRecreativo"].Value = materialRecreacionEntretenamientoDTO.MontoSolesAtendidoRecreativo;

                    cmd.Parameters.Add("@CodigoMaterialEntretenimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.CodigoMaterialEntretenimiento;

                    cmd.Parameters.Add("@CantidadSolicitadoEntretenimiento", SqlDbType.Int);
                    cmd.Parameters["@CantidadSolicitadoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.CantidadSolicitadoEntretenimiento;

                    cmd.Parameters.Add("@CantidadAtendidoEntretenimiento", SqlDbType.Int);
                    cmd.Parameters["@CantidadAtendidoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.CantidadAtendidoEntretenimiento;

                    cmd.Parameters.Add("@MontoSolesSolicitadoEntretenimiento", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesSolicitadoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoEntretenimiento;

                    cmd.Parameters.Add("@MontoSolesAtendidoEntretenimiento", SqlDbType.Decimal);
                    cmd.Parameters["@MontoSolesAtendidoEntretenimiento"].Value = materialRecreacionEntretenamientoDTO.MontoSolesAtendidoEntretenimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MaterialRecreacionEntretenamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRecreacionEntretenamientoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialRecreacionEntretenamientoId"].Value = materialRecreacionEntretenamientoDTO.MaterialRecreacionEntretenamientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO)
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
                    cmd.Parameters["@Formato"].Value = "MaterialRecreacionEntretenamiento";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = materialRecreacionEntretenamientoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_MaterialRecreacionEntretenamientoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialRecreacionEntretenamiento", SqlDbType.Structured);
                    cmd.Parameters["@MaterialRecreacionEntretenamiento"].TypeName = "Formato.MaterialRecreacionEntretenamiento";
                    cmd.Parameters["@MaterialRecreacionEntretenamiento"].Value = datos;

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
