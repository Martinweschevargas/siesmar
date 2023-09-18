using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresna
{
    public class EgresoPromocionesDiresnaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EgresoPromocionesDiresnaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<EgresoPromocionesDiresnaDTO> lista = new List<EgresoPromocionesDiresnaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EgresoPromocionDiresnaListar", conexion);
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
                        lista.Add(new EgresoPromocionesDiresnaDTO()
                        {
                            EgresoPromocionId = Convert.ToInt32(dr["EgresoPromocionId"]),
                            DNIEgresado = dr["DNIEgresado"].ToString(),
                            SexoEgresado = dr["SexoEgresado"].ToString(),
                            FechaResolIngreso = (dr["FechaResolIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaResolEgreso = (dr["FechaResolEgreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ConcursoAdminisionIngreso = dr["ConcursoAdminisionIngreso"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDiresnaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DNIEgresado", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIEgresado"].Value = egresoPromocionesDiresnaDTO.DNIEgresado;

                    cmd.Parameters.Add("@SexoEgresado", SqlDbType.VarChar,15);
                    cmd.Parameters["@SexoEgresado"].Value = egresoPromocionesDiresnaDTO.SexoEgresado;

                    cmd.Parameters.Add("@FechaResolIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolIngreso"].Value = egresoPromocionesDiresnaDTO.FechaResolIngreso;

                    cmd.Parameters.Add("@FechaResolEgreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolEgreso"].Value = egresoPromocionesDiresnaDTO.FechaResolEgreso;

                    cmd.Parameters.Add("@ConcursoAdminisionIngreso", SqlDbType.VarChar,15);
                    cmd.Parameters["@ConcursoAdminisionIngreso"].Value = egresoPromocionesDiresnaDTO.ConcursoAdminisionIngreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = egresoPromocionesDiresnaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro;

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

        public EgresoPromocionesDiresnaDTO BuscarFormato(int Codigo)
        {
            EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO = new EgresoPromocionesDiresnaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDiresnaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EgresoPromocionId", SqlDbType.Int);
                    cmd.Parameters["@EgresoPromocionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        egresoPromocionesDiresnaDTO.EgresoPromocionId = Convert.ToInt32(dr["EgresoPromocionId"]);
                        egresoPromocionesDiresnaDTO.DNIEgresado = dr["DNIEgresado"].ToString();
                        egresoPromocionesDiresnaDTO.SexoEgresado = dr["SexoEgresado"].ToString();
                        egresoPromocionesDiresnaDTO.FechaResolIngreso = Convert.ToDateTime(dr["FechaResolIngreso"]).ToString("yyy-MM-dd");
                        egresoPromocionesDiresnaDTO.FechaResolEgreso = Convert.ToDateTime(dr["FechaResolEgreso"]).ToString("yyy-MM-dd");
                        egresoPromocionesDiresnaDTO.ConcursoAdminisionIngreso = dr["ConcursoAdminisionIngreso"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return egresoPromocionesDiresnaDTO;
        }

        public string ActualizaFormato(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDiresnaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EgresoPromocionId", SqlDbType.Int);
                    cmd.Parameters["@EgresoPromocionId"].Value = egresoPromocionesDiresnaDTO.EgresoPromocionId;

                    cmd.Parameters.Add("@DNIEgresado", SqlDbType.Int);
                    cmd.Parameters["@DNIEgresado"].Value = egresoPromocionesDiresnaDTO.DNIEgresado;

                    cmd.Parameters.Add("@SexoEgresado", SqlDbType.VarChar,10);
                    cmd.Parameters["@SexoEgresado"].Value = egresoPromocionesDiresnaDTO.SexoEgresado;

                    cmd.Parameters.Add("@FechaResolIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolIngreso"].Value = egresoPromocionesDiresnaDTO.FechaResolIngreso;

                    cmd.Parameters.Add("@FechaResolEgreso", SqlDbType.Date);
                    cmd.Parameters["@FechaResolEgreso"].Value = egresoPromocionesDiresnaDTO.FechaResolEgreso;

                    cmd.Parameters.Add("@ConcursoAdminisionIngreso", SqlDbType.VarChar,15);
                    cmd.Parameters["@ConcursoAdminisionIngreso"].Value = egresoPromocionesDiresnaDTO.ConcursoAdminisionIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EgresoPromocionDiresnaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EgresoPromocionId", SqlDbType.Int);
                    cmd.Parameters["@EgresoPromocionId"].Value = egresoPromocionesDiresnaDTO.EgresoPromocionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO)
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
                    cmd.Parameters["@Formato"].Value = "EgresoPromocionDiresna";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = egresoPromocionesDiresnaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_EgresoPromocionDiresnaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EgresoPromocionesDiresna", SqlDbType.Structured);
                    cmd.Parameters["@EgresoPromocionesDiresna"].TypeName = "Formato.EgresoPromocionDiresna";
                    cmd.Parameters["@EgresoPromocionesDiresna"].Value = datos;

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
