using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comoperpac
{
    public class EfectivoCompaniaIntervencionRapidaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EfectivoCompaniaIntervencionRapidaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EfectivoCompaniaIntervencionRapidaDTO> lista = new List<EfectivoCompaniaIntervencionRapidaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EfectivoCompaniaIntervencionRapidaListar", conexion);
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
                        lista.Add(new EfectivoCompaniaIntervencionRapidaDTO()
                        {
                            EfectivoCompaniaIntervencionRapidaId = Convert.ToInt32(dr["EfectivoCompaniaIntervencionRapidaId"]),
                            DescComandanciaNaval = dr["DescComandanciaNaval"].ToString(),
                            DescUbicacionCIRD = dr["DescUbicacionCIRD"].ToString(),
                            CantidadEfectivos = Convert.ToInt32(dr["CantidadEfectivos"]),
                            NivelOrganizacion = Convert.ToDecimal(dr["NivelOrganizacion"]),
                            NivelEquipamiento = Convert.ToDecimal(dr["NivelEquipamiento"]),
                            NivelInstruccion = Convert.ToDecimal(dr["NivelInstruccion"]),
                            NivelEntrenamiento = Convert.ToDecimal(dr["NivelEntrenamiento"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoCompaniaIntervencionRapidaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoComandanciaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaNaval"].Value = efectivoCompaniaIntervencionRapidaDTO.CodigoComandanciaNaval;

                    cmd.Parameters.Add("@CodigoUbicacionCIRD", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUbicacionCIRD"].Value = efectivoCompaniaIntervencionRapidaDTO.CodigoUbicacionCIRD;

                    cmd.Parameters.Add("@CantidadEfectivos", SqlDbType.Int);
                    cmd.Parameters["@CantidadEfectivos"].Value = efectivoCompaniaIntervencionRapidaDTO.CantidadEfectivos;

                    cmd.Parameters.Add("@NivelOrganizacion", SqlDbType.Decimal);
                    cmd.Parameters["@NivelOrganizacion"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelOrganizacion;

                    cmd.Parameters.Add("@NivelEquipamiento", SqlDbType.Decimal);
                    cmd.Parameters["@NivelEquipamiento"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelEquipamiento;

                    cmd.Parameters.Add("@NivelInstruccion", SqlDbType.Decimal);
                    cmd.Parameters["@NivelInstruccion"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelInstruccion;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.Decimal);
                    cmd.Parameters["@NivelEntrenamiento"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = efectivoCompaniaIntervencionRapidaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro;

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

        public EfectivoCompaniaIntervencionRapidaDTO BuscarFormato(int Codigo)
        {
            EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO = new EfectivoCompaniaIntervencionRapidaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoCompaniaIntervencionRapidaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoCompaniaIntervencionRapidaId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoCompaniaIntervencionRapidaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        efectivoCompaniaIntervencionRapidaDTO.EfectivoCompaniaIntervencionRapidaId = Convert.ToInt32(dr["EfectivoCompaniaIntervencionRapidaId"]);
                        efectivoCompaniaIntervencionRapidaDTO.CodigoComandanciaNaval = dr["CodigoComandanciaNaval"].ToString();
                        efectivoCompaniaIntervencionRapidaDTO.CodigoUbicacionCIRD = dr["CodigoUbicacionCIRD"].ToString();
                        efectivoCompaniaIntervencionRapidaDTO.CantidadEfectivos = Convert.ToInt32(dr["CantidadEfectivos"]);
                        efectivoCompaniaIntervencionRapidaDTO.NivelOrganizacion = Convert.ToDecimal(dr["NivelOrganizacion"]);
                        efectivoCompaniaIntervencionRapidaDTO.NivelEquipamiento = Convert.ToDecimal(dr["NivelEquipamiento"]);
                        efectivoCompaniaIntervencionRapidaDTO.NivelInstruccion = Convert.ToDecimal(dr["NivelInstruccion"]);
                        efectivoCompaniaIntervencionRapidaDTO.NivelEntrenamiento = Convert.ToDecimal(dr["NivelEntrenamiento"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return efectivoCompaniaIntervencionRapidaDTO;
        }

        public string ActualizaFormato(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EfectivoCompaniaIntervencionRapidaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EfectivoCompaniaIntervencionRapidaId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoCompaniaIntervencionRapidaId"].Value = efectivoCompaniaIntervencionRapidaDTO.EfectivoCompaniaIntervencionRapidaId;

                    cmd.Parameters.Add("@CodigoComandanciaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoComandanciaNaval"].Value = efectivoCompaniaIntervencionRapidaDTO.CodigoComandanciaNaval;

                    cmd.Parameters.Add("@CodigoUbicacionCIRD", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUbicacionCIRD"].Value = efectivoCompaniaIntervencionRapidaDTO.CodigoUbicacionCIRD;

                    cmd.Parameters.Add("@CantidadEfectivos", SqlDbType.Int);
                    cmd.Parameters["@CantidadEfectivos"].Value = efectivoCompaniaIntervencionRapidaDTO.CantidadEfectivos;

                    cmd.Parameters.Add("@NivelOrganizacion", SqlDbType.Decimal);
                    cmd.Parameters["@NivelOrganizacion"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelOrganizacion;

                    cmd.Parameters.Add("@NivelEquipamiento", SqlDbType.Decimal);
                    cmd.Parameters["@NivelEquipamiento"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelEquipamiento;

                    cmd.Parameters.Add("@NivelInstruccion", SqlDbType.Decimal);
                    cmd.Parameters["@NivelInstruccion"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelInstruccion;

                    cmd.Parameters.Add("@NivelEntrenamiento", SqlDbType.Decimal);
                    cmd.Parameters["@NivelEntrenamiento"].Value = efectivoCompaniaIntervencionRapidaDTO.NivelEntrenamiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EfectivoCompaniaIntervencionRapidaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoCompaniaIntervencionRapidaId", SqlDbType.Int);
                    cmd.Parameters["@EfectivoCompaniaIntervencionRapidaId"].Value = efectivoCompaniaIntervencionRapidaDTO.EfectivoCompaniaIntervencionRapidaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO)
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
                    cmd.Parameters["@Formato"].Value = "EfectivoCompaniaIntervencionRapida";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = efectivoCompaniaIntervencionRapidaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EfectivoCompaniaIntervencionRapidaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EfectivoCompaniaIntervencionRapida", SqlDbType.Structured);
                    cmd.Parameters["@EfectivoCompaniaIntervencionRapida"].TypeName = "Formato.EfectivoCompaniaIntervencionRapida";
                    cmd.Parameters["@EfectivoCompaniaIntervencionRapida"].Value = datos;

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
