using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comciberdef
{
    public class CooperacionBilateralMultilateralCiberdefensaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CooperacionBilateralMultilateralCiberdefensaDTO> ObtenerLista(int? CargaId = null)
        {
            List<CooperacionBilateralMultilateralCiberdefensaDTO> lista = new List<CooperacionBilateralMultilateralCiberdefensaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CooperacionBilateralMultilateralCiberdefensaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CooperacionBilateralMultilateralCiberdefensaDTO()
                        {
                            CooperacionBilateralMultilateralId = Convert.ToInt32(dr["CooperacionBilateralMultilateralId"]),
                            FechaCooperacion = (dr["FechaCooperacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoAcuerdo = dr["CodigoTipoAcuerdo"].ToString(),
                            AsuntoCooperacion = dr["AsuntoCooperacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<CooperacionBilateralMultilateralCiberdefensaDTO> VisualizacionCooperacionBilateralMultilateralCiberdefensa(int? CargaId = null)
        {
            List<CooperacionBilateralMultilateralCiberdefensaDTO> lista = new List<CooperacionBilateralMultilateralCiberdefensaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ComciberdefVisualizacionCooperacionBilateralMultilateralCiberdefensa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CooperacionBilateralMultilateralCiberdefensaDTO()
                        {
                            FechaCooperacion = (dr["FechaCooperacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescTipoAcuerdo = dr["CodigoTipoAcuerdo"].ToString(),
                            AsuntoCooperacion = dr["AsuntoCooperacion"].ToString(),
                         
                        });
                    }
                }
            }
            return lista;
        }
        public string AgregarRegistro(CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CooperacionBilateralMultilateralCiberdefensaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaCooperacion", SqlDbType.Date);
                    cmd.Parameters["@FechaCooperacion"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.FechaCooperacion;

                    cmd.Parameters.Add("@CodigoTipoAcuerdo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoAcuerdo"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.CodigoTipoAcuerdo;

                    cmd.Parameters.Add("@AsuntoCooperacion", SqlDbType.VarChar,500);
                    cmd.Parameters["@AsuntoCooperacion"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.AsuntoCooperacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.UsuarioIngresoRegistro;

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

        public CooperacionBilateralMultilateralCiberdefensaDTO BuscarFormato(int Codigo)
        {
            CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO = new CooperacionBilateralMultilateralCiberdefensaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CooperacionBilateralMultilateralCiberdefensaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CooperacionBilateralMultilateralId", SqlDbType.Int);
                    cmd.Parameters["@CooperacionBilateralMultilateralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        cooperacionBilateralMultilateralCiberdefensaDTO.CooperacionBilateralMultilateralId = Convert.ToInt32(dr["CooperacionBilateralMultilateralId"]);
                        cooperacionBilateralMultilateralCiberdefensaDTO.FechaCooperacion = Convert.ToDateTime(dr["FechaCooperacion"]).ToString("yyy-MM-dd");
                        cooperacionBilateralMultilateralCiberdefensaDTO.CodigoTipoAcuerdo = dr["CodigoTipoAcuerdo"].ToString();
                        cooperacionBilateralMultilateralCiberdefensaDTO.AsuntoCooperacion = dr["AsuntoCooperacion"].ToString(); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cooperacionBilateralMultilateralCiberdefensaDTO;
        }

        public string ActualizaFormato(CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CooperacionBilateralMultilateralCiberdefensaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CooperacionBilateralMultilateralId", SqlDbType.Int);
                    cmd.Parameters["@CooperacionBilateralMultilateralId"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.CooperacionBilateralMultilateralId;

                    cmd.Parameters.Add("@FechaCooperacion", SqlDbType.Date);
                    cmd.Parameters["@FechaCooperacion"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.FechaCooperacion;

                    cmd.Parameters.Add("@CodigoTipoAcuerdo", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoAcuerdo"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.CodigoTipoAcuerdo;

                    cmd.Parameters.Add("@AsuntoCooperacion", SqlDbType.VarChar,500);
                    cmd.Parameters["@AsuntoCooperacion"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.AsuntoCooperacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CooperacionBilateralMultilateralCiberdefensaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CooperacionBilateralMultilateralId", SqlDbType.Int);
                    cmd.Parameters["@CooperacionBilateralMultilateralId"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.CooperacionBilateralMultilateralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cooperacionBilateralMultilateralCiberdefensaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CooperacionBilateralMultilateralCiberdefensaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CooperacionBilateralMultilateralCiberdefensa", SqlDbType.Structured);
                    cmd.Parameters["@CooperacionBilateralMultilateralCiberdefensa"].TypeName = "Formato.CooperacionBilateralMultilateralCiberdefensa";
                    cmd.Parameters["@CooperacionBilateralMultilateralCiberdefensa"].Value = datos;

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
