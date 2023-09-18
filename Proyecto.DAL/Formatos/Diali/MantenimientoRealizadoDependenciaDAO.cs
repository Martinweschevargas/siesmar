using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diali
{
    public class MantenimientoRealizadoDependenciaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MantenimientoRealizadoDependenciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<MantenimientoRealizadoDependenciaDTO> lista = new List<MantenimientoRealizadoDependenciaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MantenimientoRealizadoDependenciaListar", conexion);
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
                        lista.Add(new MantenimientoRealizadoDependenciaDTO()
                        {
                            MantenimientoDependUnidId = Convert.ToInt32(dr["MantenimientoDependUnidId"]),
                            TipoUnidadMantenimiento = dr["TipoUnidadMantenimiento"].ToString(),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescMes = dr["DescMes"].ToString(),
                            TareaProgramada = Convert.ToInt32(dr["TareaProgramada"]),
                            TareaEjecutada = Convert.ToInt32(dr["TareaEjecutada"]),
                            TareaNoEjecutada = Convert.ToInt32(dr["TareaNoEjecutada"]),
                            TNEFaltapersonal = Convert.ToInt32(dr["TNEFaltapersonal"]),
                            TNEFaltaTiempo = Convert.ToInt32(dr["TNEFaltaTiempo"]),
                            TNEFaltaRepuesto = Convert.ToInt32(dr["TNEFaltaRepuesto"]),
                            TNEFaltaMaterial = Convert.ToInt32(dr["TNEFaltaMaterial"]),
                            TNEFaltaPresupuesto = Convert.ToInt32(dr["TNEFaltaPresupuesto"]),
                            TNEFaltaHerramienta = Convert.ToInt32(dr["TNEFaltaHerramienta"]),
                            TNEFaltaInstrumento = Convert.ToInt32(dr["TNEFaltaInstrumento"]),
                            TNEFaltaConocimiento = Convert.ToInt32(dr["TNEFaltaConocimiento"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });

                    }

                }
            }
            return lista;
        }

        public string AgregarRegistro(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MantenimientoRealizadoDependenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TipoUnidadMantenimiento", SqlDbType.VarChar, 40);
                    cmd.Parameters["@TipoUnidadMantenimiento"].Value = mantenimientoRealizadoDTO.TipoUnidadMantenimiento;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = mantenimientoRealizadoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = mantenimientoRealizadoDTO.NumeroMes;

                    cmd.Parameters.Add("@TareaProgramada", SqlDbType.Int);
                    cmd.Parameters["@TareaProgramada"].Value = mantenimientoRealizadoDTO.TareaProgramada;

                    cmd.Parameters.Add("@TareaEjecutada", SqlDbType.Int);
                    cmd.Parameters["@TareaEjecutada"].Value = mantenimientoRealizadoDTO.TareaEjecutada;

                    cmd.Parameters.Add("@TareaNoEjecutada", SqlDbType.Int);
                    cmd.Parameters["@TareaNoEjecutada"].Value = mantenimientoRealizadoDTO.TareaNoEjecutada;

                    cmd.Parameters.Add("@TNEFaltapersonal", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltapersonal"].Value = mantenimientoRealizadoDTO.TNEFaltapersonal;

                    cmd.Parameters.Add("@TNEFaltaTiempo", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaTiempo"].Value = mantenimientoRealizadoDTO.TNEFaltaTiempo;

                    cmd.Parameters.Add("@TNEFaltaRepuesto", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaRepuesto"].Value = mantenimientoRealizadoDTO.TNEFaltaRepuesto;

                    cmd.Parameters.Add("@TNEFaltaMaterial", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaMaterial"].Value = mantenimientoRealizadoDTO.TNEFaltaMaterial;

                    cmd.Parameters.Add("@TNEFaltaPresupuesto", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaPresupuesto"].Value = mantenimientoRealizadoDTO.TNEFaltaPresupuesto;

                    cmd.Parameters.Add("@TNEFaltaHerramienta", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaHerramienta"].Value = mantenimientoRealizadoDTO.TNEFaltaHerramienta;

                    cmd.Parameters.Add("@TNEFaltaInstrumento", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaInstrumento"].Value = mantenimientoRealizadoDTO.TNEFaltaInstrumento;

                    cmd.Parameters.Add("@TNEFaltaConocimiento", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaConocimiento"].Value = mantenimientoRealizadoDTO.TNEFaltaConocimiento;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = mantenimientoRealizadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoRealizadoDTO.UsuarioIngresoRegistro;

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

        public MantenimientoRealizadoDependenciaDTO BuscarFormato(int Codigo)
        {
            MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO = new MantenimientoRealizadoDependenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MantenimientoRealizadoDependenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoDependUnidId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoDependUnidId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        mantenimientoRealizadoDTO.MantenimientoDependUnidId = Convert.ToInt32(dr["MantenimientoDependUnidId"]);
                        mantenimientoRealizadoDTO.TipoUnidadMantenimiento = dr["TipoUnidadMantenimiento"].ToString();
                        mantenimientoRealizadoDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        mantenimientoRealizadoDTO.NumeroMes = dr["NumeroMes"].ToString();
                        mantenimientoRealizadoDTO.TareaProgramada = Convert.ToInt32(dr["TareaProgramada"]);
                        mantenimientoRealizadoDTO.TareaEjecutada = Convert.ToInt32(dr["TareaEjecutada"]);
                        mantenimientoRealizadoDTO.TareaNoEjecutada = Convert.ToInt32(dr["TareaNoEjecutada"]);
                        mantenimientoRealizadoDTO.TNEFaltapersonal = Convert.ToInt32(dr["TNEFaltapersonal"]);
                        mantenimientoRealizadoDTO.TNEFaltaTiempo = Convert.ToInt32(dr["TNEFaltaTiempo"]);
                        mantenimientoRealizadoDTO.TNEFaltaRepuesto = Convert.ToInt32(dr["TNEFaltaRepuesto"]);
                        mantenimientoRealizadoDTO.TNEFaltaMaterial = Convert.ToInt32(dr["TNEFaltaMaterial"]);
                        mantenimientoRealizadoDTO.TNEFaltaPresupuesto = Convert.ToInt32(dr["TNEFaltaPresupuesto"]);
                        mantenimientoRealizadoDTO.TNEFaltaHerramienta = Convert.ToInt32(dr["TNEFaltaHerramienta"]);
                        mantenimientoRealizadoDTO.TNEFaltaInstrumento = Convert.ToInt32(dr["TNEFaltaInstrumento"]);
                        mantenimientoRealizadoDTO.TNEFaltaConocimiento = Convert.ToInt32(dr["TNEFaltaConocimiento"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return mantenimientoRealizadoDTO;
        }

        public string ActualizaFormato(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MantenimientoRealizadoDependenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoDependUnidId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoDependUnidId"].Value = mantenimientoRealizadoDTO.MantenimientoDependUnidId;

                    cmd.Parameters.Add("@TipoUnidadMantenimiento", SqlDbType.VarChar, 40);
                    cmd.Parameters["@TipoUnidadMantenimiento"].Value = mantenimientoRealizadoDTO.TipoUnidadMantenimiento;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = mantenimientoRealizadoDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@NumeroMes", SqlDbType.VarChar,20);
                    cmd.Parameters["@NumeroMes"].Value = mantenimientoRealizadoDTO.NumeroMes;

                    cmd.Parameters.Add("@TareaProgramada", SqlDbType.Int);
                    cmd.Parameters["@TareaProgramada"].Value = mantenimientoRealizadoDTO.TareaProgramada;

                    cmd.Parameters.Add("@TareaEjecutada", SqlDbType.Int);
                    cmd.Parameters["@TareaEjecutada"].Value = mantenimientoRealizadoDTO.TareaEjecutada;

                    cmd.Parameters.Add("@TareaNoEjecutada", SqlDbType.Int);
                    cmd.Parameters["@TareaNoEjecutada"].Value = mantenimientoRealizadoDTO.TareaNoEjecutada;

                    cmd.Parameters.Add("@TNEFaltapersonal", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltapersonal"].Value = mantenimientoRealizadoDTO.TNEFaltapersonal;

                    cmd.Parameters.Add("@TNEFaltaTiempo", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaTiempo"].Value = mantenimientoRealizadoDTO.TNEFaltaTiempo;

                    cmd.Parameters.Add("@TNEFaltaRepuesto", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaRepuesto"].Value = mantenimientoRealizadoDTO.TNEFaltaRepuesto;

                    cmd.Parameters.Add("@TNEFaltaMaterial", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaMaterial"].Value = mantenimientoRealizadoDTO.TNEFaltaMaterial;

                    cmd.Parameters.Add("@TNEFaltaPresupuesto", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaPresupuesto"].Value = mantenimientoRealizadoDTO.TNEFaltaPresupuesto;

                    cmd.Parameters.Add("@TNEFaltaHerramienta", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaHerramienta"].Value = mantenimientoRealizadoDTO.TNEFaltaHerramienta;

                    cmd.Parameters.Add("@TNEFaltaInstrumento", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaInstrumento"].Value = mantenimientoRealizadoDTO.TNEFaltaInstrumento;

                    cmd.Parameters.Add("@TNEFaltaConocimiento", SqlDbType.Int);
                    cmd.Parameters["@TNEFaltaConocimiento"].Value = mantenimientoRealizadoDTO.TNEFaltaConocimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoRealizadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MantenimientoRealizadoDependenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoDependUnidId", SqlDbType.Int);
                    cmd.Parameters["@MantenimientoDependUnidId"].Value = mantenimientoRealizadoDTO.MantenimientoDependUnidId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoRealizadoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO)
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
                    cmd.Parameters["@Formato"].Value = "MantenimientoRealizadoDependencia";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = mantenimientoRealizadoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = mantenimientoRealizadoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_MantenimientoRealizadoDependenciaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MantenimientoRealizadoDependencia", SqlDbType.Structured);
                    cmd.Parameters["@MantenimientoRealizadoDependencia"].TypeName = "Formato.MantenimientoRealizadoDependencia";
                    cmd.Parameters["@MantenimientoRealizadoDependencia"].Value = datos;

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
