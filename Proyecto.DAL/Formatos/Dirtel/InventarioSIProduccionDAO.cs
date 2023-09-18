using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class InventarioSIProduccionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<InventarioSIProduccionDTO> ObtenerLista(int? CargaId = null)
        {
            List<InventarioSIProduccionDTO> lista = new List<InventarioSIProduccionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_InventarioSIProduccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new InventarioSIProduccionDTO()
                        {
                            InventarioSIProduccionId = Convert.ToInt32(dr["InventarioSIProduccionId"]),
                            NombreSIProduccion = dr["NombreSIProduccion"].ToString(),
                            SiglasSIProduccion = dr["SiglasSIProduccion"].ToString(),
                            DescAreaSatisfaceDirtel = dr["DescAreaSatisfaceDirtel"].ToString(),
                            DescripcionFuncionalidad = dr["DescripcionFuncionalidad"].ToString(),
                            DescCicloDesarrolloSoftware = dr["DescCicloDesarrolloSoftware"].ToString(),
                            AlcanceSIProduccion = dr["AlcanceSIProduccion"].ToString(),
                            ProcedenciaSIProduccion = dr["ProcedenciaSIProduccion"].ToString(),
                            DescDenominacionBaseDato = dr["DescDenominacionBaseDato"].ToString(),
                            ServidorBDSIProduccion = dr["ServidorBDSIProduccion"].ToString(),
                            DescDenominacionLenguajeProgramacion = dr["DescDenominacionLenguajeProgramacion"].ToString(),
                            ServidorWebSIProduccion = dr["ServidorWebSIProduccion"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(), 
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(InventarioSIProduccionDTO inventarioSIProduccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InventarioSIProduccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NombreSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreSIProduccion"].Value = inventarioSIProduccionDTO.NombreSIProduccion;

                    cmd.Parameters.Add("@SiglasSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SiglasSIProduccion"].Value = inventarioSIProduccionDTO.SiglasSIProduccion;

                    cmd.Parameters.Add("@CodigoAreaSatisfaceDirtel ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaSatisfaceDirtel "].Value = inventarioSIProduccionDTO.CodigoAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@DescripcionFuncionalidad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescripcionFuncionalidad"].Value = inventarioSIProduccionDTO.DescripcionFuncionalidad;

                    cmd.Parameters.Add("@CodigoCicloDesarrolloSoftware ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCicloDesarrolloSoftware "].Value = inventarioSIProduccionDTO.CodigoCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@AlcanceSIProduccion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@AlcanceSIProduccion"].Value = inventarioSIProduccionDTO.AlcanceSIProduccion;

                    cmd.Parameters.Add("@ProcedenciaSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ProcedenciaSIProduccion"].Value = inventarioSIProduccionDTO.ProcedenciaSIProduccion;

                    cmd.Parameters.Add("@CodigoDenominacionBaseDato ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionBaseDato "].Value = inventarioSIProduccionDTO.CodigoDenominacionBaseDato;

                    cmd.Parameters.Add("@ServidorBDSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServidorBDSIProduccion"].Value = inventarioSIProduccionDTO.ServidorBDSIProduccion;

                    cmd.Parameters.Add("@CodigoDenominacionLenguajeProgramacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionLenguajeProgramacion"].Value = inventarioSIProduccionDTO.CodigoDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@ServidorWebSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServidorWebSIProduccion"].Value = inventarioSIProduccionDTO.ServidorWebSIProduccion;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = inventarioSIProduccionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = inventarioSIProduccionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inventarioSIProduccionDTO.UsuarioIngresoRegistro;

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

        public InventarioSIProduccionDTO BuscarFormato(int Codigo)
        {
            InventarioSIProduccionDTO inventarioSIProduccionDTO = new InventarioSIProduccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InventarioSIProduccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InventarioSIProduccionId", SqlDbType.Int);
                    cmd.Parameters["@InventarioSIProduccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        inventarioSIProduccionDTO.InventarioSIProduccionId = Convert.ToInt32(dr["InventarioSIProduccionId"]);
                        inventarioSIProduccionDTO.NombreSIProduccion = dr["NombreSIProduccion"].ToString();
                        inventarioSIProduccionDTO.SiglasSIProduccion = dr["SiglasSIProduccion"].ToString();
                        inventarioSIProduccionDTO.CodigoAreaSatisfaceDirtel = dr["CodigoAreaSatisfaceDirtel"].ToString();
                        inventarioSIProduccionDTO.DescripcionFuncionalidad = dr["DescripcionFuncionalidad"].ToString();
                        inventarioSIProduccionDTO.CodigoCicloDesarrolloSoftware = dr["CodigoCicloDesarrolloSoftware"].ToString();
                        inventarioSIProduccionDTO.AlcanceSIProduccion = dr["AlcanceSIProduccion"].ToString();
                        inventarioSIProduccionDTO.ProcedenciaSIProduccion = dr["ProcedenciaSIProduccion"].ToString();
                        inventarioSIProduccionDTO.CodigoDenominacionBaseDato = dr["CodigoDenominacionBaseDato"].ToString();
                        inventarioSIProduccionDTO.ServidorBDSIProduccion = dr["ServidorBDSIProduccion"].ToString();
                        inventarioSIProduccionDTO.CodigoDenominacionLenguajeProgramacion = dr["CodigoDenominacionLenguajeProgramacion"].ToString();
                        inventarioSIProduccionDTO.ServidorWebSIProduccion = dr["ServidorWebSIProduccion"].ToString();
                        inventarioSIProduccionDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return inventarioSIProduccionDTO;
        }

        public string ActualizaFormato(InventarioSIProduccionDTO inventarioSIProduccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_InventarioSIProduccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@InventarioSIProduccionId", SqlDbType.Int);
                    cmd.Parameters["@InventarioSIProduccionId"].Value = inventarioSIProduccionDTO.InventarioSIProduccionId;

                    cmd.Parameters.Add("@NombreSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NombreSIProduccion"].Value = inventarioSIProduccionDTO.NombreSIProduccion;

                    cmd.Parameters.Add("@SiglasSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SiglasSIProduccion"].Value = inventarioSIProduccionDTO.SiglasSIProduccion;

                    cmd.Parameters.Add("@CodigoAreaSatisfaceDirtel ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAreaSatisfaceDirtel "].Value = inventarioSIProduccionDTO.CodigoAreaSatisfaceDirtel;

                    cmd.Parameters.Add("@DescripcionFuncionalidad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescripcionFuncionalidad"].Value = inventarioSIProduccionDTO.DescripcionFuncionalidad;

                    cmd.Parameters.Add("@CodigoCicloDesarrolloSoftware ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCicloDesarrolloSoftware "].Value = inventarioSIProduccionDTO.CodigoCicloDesarrolloSoftware;

                    cmd.Parameters.Add("@AlcanceSIProduccion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@AlcanceSIProduccion"].Value = inventarioSIProduccionDTO.AlcanceSIProduccion;

                    cmd.Parameters.Add("@ProcedenciaSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ProcedenciaSIProduccion"].Value = inventarioSIProduccionDTO.ProcedenciaSIProduccion;

                    cmd.Parameters.Add("@CodigoDenominacionBaseDato ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionBaseDato "].Value = inventarioSIProduccionDTO.CodigoDenominacionBaseDato;

                    cmd.Parameters.Add("@ServidorBDSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServidorBDSIProduccion"].Value = inventarioSIProduccionDTO.ServidorBDSIProduccion;

                    cmd.Parameters.Add("@CodigoDenominacionLenguajeProgramacion ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDenominacionLenguajeProgramacion"].Value = inventarioSIProduccionDTO.CodigoDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@ServidorWebSIProduccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ServidorWebSIProduccion"].Value = inventarioSIProduccionDTO.ServidorWebSIProduccion;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = inventarioSIProduccionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inventarioSIProduccionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(InventarioSIProduccionDTO inventarioSIProduccionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_InventarioSIProduccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InventarioSIProduccionId", SqlDbType.Int);
                    cmd.Parameters["@InventarioSIProduccionId"].Value = inventarioSIProduccionDTO.InventarioSIProduccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = inventarioSIProduccionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_InventarioSIProduccionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InventarioSIProduccion", SqlDbType.Structured);
                    cmd.Parameters["@InventarioSIProduccion"].TypeName = "Formato.InventarioSIProduccion";
                    cmd.Parameters["@InventarioSIProduccion"].Value = datos;

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
