using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comciberdef
{
    public class CapacidadComandanciaCiberdefensaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CapacidadComandanciaCiberdefensaDTO> ObtenerLista(int? CargaId = null)
        {
            List<CapacidadComandanciaCiberdefensaDTO> lista = new List<CapacidadComandanciaCiberdefensaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CapacidadComandanciaCiberdefensaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapacidadComandanciaCiberdefensaDTO()
                        {
                            CapacidadComandanciaCiberdefensaId = Convert.ToInt32(dr["CapacidadComandanciaCiberdefensaId"]),
                            AnioCapacidadCiberdefensa = Convert.ToInt32(dr["AnioCapacidadCiberdefensa"]),
                            CapacidadComandoControl = Convert.ToDecimal(dr["CapacidadComandoControl"]),
                            CapacidadOperacionesDefensa = Convert.ToDecimal(dr["CapacidadOperacionesDefensa"]),
                            CapacidadOperacionesExplotacion = Convert.ToDecimal(dr["CapacidadOperacionesExplotacion"]),
                            CapacidadOperacionRespuesta = Convert.ToDecimal(dr["CapacidadOperacionRespuesta"]),
                            CapacidadInvestigacionDigital = Convert.ToDecimal(dr["CapacidadInvestigacionDigital"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<CapacidadComandanciaCiberdefensaDTO> VisualizacionCapacidadComandanciaCiberdefensa(int? CargaId = null)
        {
            List<CapacidadComandanciaCiberdefensaDTO> lista = new List<CapacidadComandanciaCiberdefensaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_ComciberdefVisualizacionCapacidadComandanciaCiberdefensa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CapacidadComandanciaCiberdefensaDTO()
                        {
                            AnioCapacidadCiberdefensa = Convert.ToInt32(dr["AnioCapacidadCiberdefensa"]),
                            CapacidadComandoControl = Convert.ToDecimal(dr["CapacidadComandoControl"]),
                            CapacidadOperacionesDefensa = Convert.ToDecimal(dr["CapacidadOperacionesDefensa"]),
                            CapacidadOperacionesExplotacion = Convert.ToDecimal(dr["CapacidadOperacionesExplotacion"]),
                            CapacidadOperacionRespuesta = Convert.ToDecimal(dr["CapacidadOperacionRespuesta"]),
                            CapacidadInvestigacionDigital = Convert.ToDecimal(dr["CapacidadInvestigacionDigital"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacidadComandanciaCiberdefensaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioCapacidadCiberdefensa", SqlDbType.Int);
                    cmd.Parameters["@AnioCapacidadCiberdefensa"].Value = capacidadComandanciaCiberdefensaDTO.AnioCapacidadCiberdefensa;

                    cmd.Parameters.Add("@CapacidadComandoControl", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadComandoControl"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadComandoControl;

                    cmd.Parameters.Add("@CapacidadOperacionesDefensa", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadOperacionesDefensa"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesDefensa;

                    cmd.Parameters.Add("@CapacidadOperacionesExplotacion", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadOperacionesExplotacion"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesExplotacion;

                    cmd.Parameters.Add("@CapacidadOperacionRespuesta", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadOperacionRespuesta"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadOperacionRespuesta;

                    cmd.Parameters.Add("@CapacidadInvestigacionDigital", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadInvestigacionDigital"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadInvestigacionDigital;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = capacidadComandanciaCiberdefensaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacidadComandanciaCiberdefensaDTO.UsuarioIngresoRegistro;

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

        public CapacidadComandanciaCiberdefensaDTO BuscarFormato(int Codigo)
        {
            CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO = new CapacidadComandanciaCiberdefensaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacidadComandanciaCiberdefensaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadComandanciaCiberdefensaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadComandanciaCiberdefensaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        capacidadComandanciaCiberdefensaDTO.CapacidadComandanciaCiberdefensaId = Convert.ToInt32(dr["CapacidadComandanciaCiberdefensaId"]);
                        capacidadComandanciaCiberdefensaDTO.AnioCapacidadCiberdefensa = Convert.ToInt32(dr["AnioCapacidadCiberdefensa"]);
                        capacidadComandanciaCiberdefensaDTO.CapacidadComandoControl = Convert.ToDecimal(dr["CapacidadComandoControl"]);
                        capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesDefensa = Convert.ToDecimal(dr["CapacidadOperacionesDefensa"]);
                        capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesExplotacion = Convert.ToDecimal(dr["CapacidadOperacionesExplotacion"]);
                        capacidadComandanciaCiberdefensaDTO.CapacidadOperacionRespuesta = Convert.ToDecimal(dr["CapacidadOperacionRespuesta"]);
                        capacidadComandanciaCiberdefensaDTO.CapacidadInvestigacionDigital = Convert.ToDecimal(dr["CapacidadInvestigacionDigital"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return capacidadComandanciaCiberdefensaDTO;
        }

        public string ActualizaFormato(CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CapacidadComandanciaCiberdefensaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CapacidadComandanciaCiberdefensaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadComandanciaCiberdefensaId"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadComandanciaCiberdefensaId;

                    cmd.Parameters.Add("@AnioCapacidadCiberdefensa", SqlDbType.Int);
                    cmd.Parameters["@AnioCapacidadCiberdefensa"].Value = capacidadComandanciaCiberdefensaDTO.AnioCapacidadCiberdefensa;

                    cmd.Parameters.Add("@CapacidadComandoControl", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadComandoControl"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadComandoControl;

                    cmd.Parameters.Add("@CapacidadOperacionesDefensa", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadOperacionesDefensa"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesDefensa;

                    cmd.Parameters.Add("@CapacidadOperacionesExplotacion", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadOperacionesExplotacion"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesExplotacion;

                    cmd.Parameters.Add("@CapacidadOperacionRespuesta", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadOperacionRespuesta"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadOperacionRespuesta;

                    cmd.Parameters.Add("@CapacidadInvestigacionDigital", SqlDbType.Decimal);
                    cmd.Parameters["@CapacidadInvestigacionDigital"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadInvestigacionDigital;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacidadComandanciaCiberdefensaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CapacidadComandanciaCiberdefensaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadComandanciaCiberdefensaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadComandanciaCiberdefensaId"].Value = capacidadComandanciaCiberdefensaDTO.CapacidadComandanciaCiberdefensaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = capacidadComandanciaCiberdefensaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CapacidadComandanciaCiberdefensaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CapacidadComandanciaCiberdefensa", SqlDbType.Structured);
                    cmd.Parameters["@CapacidadComandanciaCiberdefensa"].TypeName = "Formato.CapacidadComandanciaCiberdefensa";
                    cmd.Parameters["@CapacidadComandanciaCiberdefensa"].Value = datos;

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
