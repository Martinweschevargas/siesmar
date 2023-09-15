using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comciberdef
{
    public class AlistamientoIntegralComandanciaCiberdefensaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistamientoIntegralComandanciaCiberdefensaDTO> ObtenerLista(int? CargaId = null)
        {
            List<AlistamientoIntegralComandanciaCiberdefensaDTO> lista = new List<AlistamientoIntegralComandanciaCiberdefensaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistamientoIntegralComandanciaCiberdefensaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoIntegralComandanciaCiberdefensaDTO()
                        {
                            AlistamientoIntegralCiberdefensaId = Convert.ToInt32(dr["AlistamientoIntegralCiberdefensaId"]),
                            AnioAlistamiento = Convert.ToInt32(dr["AnioAlistamiento"]),
                            SemestreAlistamiento = dr["SemestreAlistamiento"].ToString(),
                            AlistamientoPersonal = Convert.ToDecimal(dr["AlistamientoPersonal"]),
                            AlistamientoEntretenimiento = Convert.ToDecimal(dr["AlistamientoEntretenimiento"]),
                            AlistamientoMaterial = Convert.ToDecimal(dr["AlistamientoMaterial"]),
                            AlistamientoLogistico = Convert.ToDecimal(dr["AlistamientoLogistico"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public List<AlistamientoIntegralComandanciaCiberdefensaDTO> VisualizacionAlistamientoIntegralComandanciaCiberdefensa(int? CargaId = null)
        {
            List<AlistamientoIntegralComandanciaCiberdefensaDTO> lista = new List<AlistamientoIntegralComandanciaCiberdefensaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_ComciberdefVisualizacionAlistamientoIntegralComandanciaCiberdefensa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoIntegralComandanciaCiberdefensaDTO()
                        {

                            AnioAlistamiento = Convert.ToInt32(dr["AnioAlistamiento"]),
                            SemestreAlistamiento = dr["SemestreAlistamiento"].ToString(),
                            AlistamientoPersonal = Convert.ToDecimal(dr["AlistamientoPersonal"]),
                            AlistamientoEntretenimiento = Convert.ToDecimal(dr["AlistamientoEntretenimiento"]),
                            AlistamientoMaterial = Convert.ToDecimal(dr["AlistamientoMaterial"]),
                            AlistamientoLogistico = Convert.ToDecimal(dr["AlistamientoLogistico"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoIntegralComandanciaCiberdefensaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioAlistamiento", SqlDbType.Int);
                    cmd.Parameters["@AnioAlistamiento"].Value = alistamientoICCiberdefensaDTO.AnioAlistamiento;

                    cmd.Parameters.Add("@SemestreAlistamiento", SqlDbType.VarChar,50);
                    cmd.Parameters["@SemestreAlistamiento"].Value = alistamientoICCiberdefensaDTO.SemestreAlistamiento;

                    cmd.Parameters.Add("@AlistamientoPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoPersonal"].Value = alistamientoICCiberdefensaDTO.AlistamientoPersonal;

                    cmd.Parameters.Add("@AlistamientoEntretenimiento", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoEntretenimiento"].Value = alistamientoICCiberdefensaDTO.AlistamientoEntretenimiento;

                    cmd.Parameters.Add("@AlistamientoMaterial", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoMaterial"].Value = alistamientoICCiberdefensaDTO.AlistamientoMaterial;

                    cmd.Parameters.Add("@AlistamientoLogistico", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoLogistico"].Value = alistamientoICCiberdefensaDTO.AlistamientoLogistico;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistamientoICCiberdefensaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoICCiberdefensaDTO.UsuarioIngresoRegistro;

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

        public AlistamientoIntegralComandanciaCiberdefensaDTO BuscarFormato(int Codigo)
        {
            AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO = new AlistamientoIntegralComandanciaCiberdefensaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoIntegralComandanciaCiberdefensaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoIntegralCiberdefensaId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoIntegralCiberdefensaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistamientoICCiberdefensaDTO.AlistamientoIntegralCiberdefensaId = Convert.ToInt32(dr["AlistamientoIntegralCiberdefensaId"]);
                        alistamientoICCiberdefensaDTO.AnioAlistamiento = Convert.ToInt32(dr["AnioAlistamiento"]);
                        alistamientoICCiberdefensaDTO.SemestreAlistamiento = dr["SemestreAlistamiento"].ToString();
                        alistamientoICCiberdefensaDTO.AlistamientoPersonal = Convert.ToDecimal(dr["AlistamientoPersonal"]);
                        alistamientoICCiberdefensaDTO.AlistamientoEntretenimiento = Convert.ToDecimal(dr["AlistamientoEntretenimiento"]);
                        alistamientoICCiberdefensaDTO.AlistamientoMaterial = Convert.ToDecimal(dr["AlistamientoMaterial"]);
                        alistamientoICCiberdefensaDTO.AlistamientoLogistico = Convert.ToDecimal(dr["AlistamientoLogistico"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoICCiberdefensaDTO;
        }

        public string ActualizaFormato(AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistamientoIntegralComandanciaCiberdefensaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoIntegralCiberdefensaId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoIntegralCiberdefensaId"].Value = alistamientoICCiberdefensaDTO.AlistamientoIntegralCiberdefensaId;

                    cmd.Parameters.Add("@AnioAlistamiento", SqlDbType.Int);
                    cmd.Parameters["@AnioAlistamiento"].Value = alistamientoICCiberdefensaDTO.AnioAlistamiento;

                    cmd.Parameters.Add("@SemestreAlistamiento", SqlDbType.VarChar,50);
                    cmd.Parameters["@SemestreAlistamiento"].Value = alistamientoICCiberdefensaDTO.SemestreAlistamiento;

                    cmd.Parameters.Add("@AlistamientoPersonal", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoPersonal"].Value = alistamientoICCiberdefensaDTO.AlistamientoPersonal;

                    cmd.Parameters.Add("@AlistamientoEntretenimiento", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoEntretenimiento"].Value = alistamientoICCiberdefensaDTO.AlistamientoEntretenimiento;

                    cmd.Parameters.Add("@AlistamientoMaterial", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoMaterial"].Value = alistamientoICCiberdefensaDTO.AlistamientoMaterial;

                    cmd.Parameters.Add("@AlistamientoLogistico", SqlDbType.Decimal);
                    cmd.Parameters["@AlistamientoLogistico"].Value = alistamientoICCiberdefensaDTO.AlistamientoLogistico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoICCiberdefensaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistamientoIntegralComandanciaCiberdefensaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoIntegralCiberdefensaId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoIntegralCiberdefensaId"].Value = alistamientoICCiberdefensaDTO.AlistamientoIntegralCiberdefensaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoICCiberdefensaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistamientoIntegralComandanciaCiberdefensaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoIntegralComandanciaCiberdefensa", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoIntegralComandanciaCiberdefensa"].TypeName = "Formato.AlistamientoIntegralComandanciaCiberdefensa";
                    cmd.Parameters["@AlistamientoIntegralComandanciaCiberdefensa"].Value = datos;

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
