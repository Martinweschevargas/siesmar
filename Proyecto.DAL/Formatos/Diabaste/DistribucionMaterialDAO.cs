using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diabaste
{
    public class DistribucionMaterialDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<DistribucionMaterialDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<DistribucionMaterialDTO> lista = new List<DistribucionMaterialDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_DistribucionMaterialListar", conexion);
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
                        lista.Add(new DistribucionMaterialDTO()
                        {
                            DistribucionMaterialId = Convert.ToInt32(dr["DistribucionMaterialId"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            DescMes = dr["DescMes"].ToString(),
                            DescAreaDiperadmon = dr["DescAreaDiperadmon"].ToString(),
                            DescTipoMaterial = dr["DescTipoMaterial"].ToString(),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            CantidadMaterialEntregado = Convert.ToInt32(dr["CantidadMaterialEntregado"]),
                            FechaEntrega = (dr["FechaEntrega"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(DistribucionMaterialDTO distribucionMaterialDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DistribucionMaterialRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = distribucionMaterialDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = distribucionMaterialDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = distribucionMaterialDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoTipoMaterial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoMaterial"].Value = distribucionMaterialDTO.CodigoTipoMaterial;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = distribucionMaterialDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CantidadMaterialEntregado", SqlDbType.Int);
                    cmd.Parameters["@CantidadMaterialEntregado"].Value = distribucionMaterialDTO.CantidadMaterialEntregado;

                    cmd.Parameters.Add("@FechaEntrega", SqlDbType.Date);
                    cmd.Parameters["@FechaEntrega"].Value = distribucionMaterialDTO.FechaEntrega;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = distribucionMaterialDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionMaterialDTO.UsuarioIngresoRegistro;

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

        public DistribucionMaterialDTO BuscarFormato(int Codigo)
        {
            DistribucionMaterialDTO distribucionMaterialDTO = new DistribucionMaterialDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DistribucionMaterialEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DistribucionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DistribucionMaterialId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        distribucionMaterialDTO.DistribucionMaterialId = Convert.ToInt32(dr["DistribucionMaterialId"]);
                        distribucionMaterialDTO.Anio = Convert.ToInt32(dr["Anio"]);
                        distribucionMaterialDTO.NumeroMes = dr["NumeroMes"].ToString();
                        distribucionMaterialDTO.CodigoAreaDiperadmon = dr["CodigoAreaDiperadmon"].ToString();
                        distribucionMaterialDTO.CodigoTipoMaterial = dr["CodigoTipoMaterial"].ToString();
                        distribucionMaterialDTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        distribucionMaterialDTO.CantidadMaterialEntregado = Convert.ToInt32(dr["CantidadMaterialEntregado"]);
                        distribucionMaterialDTO.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]).ToString("yyy-MM-dd"); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return distribucionMaterialDTO;
        }

        public string ActualizaFormato(DistribucionMaterialDTO distribucionMaterialDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_DistribucionMaterialActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@DistribucionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DistribucionMaterialId"].Value = distribucionMaterialDTO.DistribucionMaterialId;

                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters["@Anio"].Value = distribucionMaterialDTO.Anio;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar, 20);
                    cmd.Parameters["@NumeroMes"].Value = distribucionMaterialDTO.NumeroMes;

                    cmd.Parameters.Add("@CodigoAreaDiperadmon", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaDiperadmon"].Value = distribucionMaterialDTO.CodigoAreaDiperadmon;

                    cmd.Parameters.Add("@CodigoTipoMaterial", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoMaterial"].Value = distribucionMaterialDTO.CodigoTipoMaterial;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = distribucionMaterialDTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@CantidadMaterialEntregado", SqlDbType.Int);
                    cmd.Parameters["@CantidadMaterialEntregado"].Value = distribucionMaterialDTO.CantidadMaterialEntregado;

                    cmd.Parameters.Add("@FechaEntrega", SqlDbType.Date);
                    cmd.Parameters["@FechaEntrega"].Value = distribucionMaterialDTO.FechaEntrega;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionMaterialDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(DistribucionMaterialDTO distribucionMaterialDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_DistribucionMaterialEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DistribucionMaterialId", SqlDbType.Int);
                    cmd.Parameters["@DistribucionMaterialId"].Value = distribucionMaterialDTO.DistribucionMaterialId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionMaterialDTO.UsuarioIngresoRegistro;

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


        public bool EliminarCarga(DistribucionMaterialDTO distribucionMaterialDTO)
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
                    cmd.Parameters["@Formato"].Value = "DistribucionMaterial";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = distribucionMaterialDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = distribucionMaterialDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_DistribucionMaterialRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DistribucionMaterial", SqlDbType.Structured);
                    cmd.Parameters["@DistribucionMaterial"].TypeName = "Formato.DistribucionMaterial";
                    cmd.Parameters["@DistribucionMaterial"].Value = datos;

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
