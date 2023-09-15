using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comesguard
{
    public class IngresoDatoServicioAlimentacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<IngresoDatoServicioAlimentacionDTO> ObtenerLista(int? CargaId = null)
        {
            List<IngresoDatoServicioAlimentacionDTO> lista = new List<IngresoDatoServicioAlimentacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_IngresoDatoServicioAlimentacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new IngresoDatoServicioAlimentacionDTO()
                        {
                            IngresoDatoServicioAlimentacionId = Convert.ToInt32(dr["IngresoDatoServicioAlimentacionId"]),
                            NumeroRacion = Convert.ToInt32(dr["NumeroRacion"]),
                            DescMes = dr["DescMes"].ToString(),
                            PeriodoDias = Convert.ToInt32(dr["PeriodoDias"]),
                            DescDependencia = dr["NombreDependencia"].ToString(),
                            CantidadPersupe = Convert.ToInt32(dr["CantidadPersupe"]),
                            CantidadPersuba = Convert.ToInt32(dr["CantidadPersuba"]),
                            CantidadPermar = Convert.ToInt32(dr["CantidadPermar"]),
                            TotalPersonalVacaciones = Convert.ToInt32(dr["TotalPersonalVacaciones"]),
                            TotalPersonalDiaHabil = Convert.ToInt32(dr["TotalPersonalDiaHabil"]),
                            TotalPersonalDiaNoHabil = Convert.ToInt32(dr["TotalPersonalDiaNoHabil"]),
                            DiaHabil = Convert.ToInt32(dr["DiaHabil"]),
                            DiaNoHabil = Convert.ToInt32(dr["DiaNoHabil"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioAlimentacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroRacion", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacion"].Value = ingresoDatoServicioAlimentacionDTO.NumeroRacion;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = ingresoDatoServicioAlimentacionDTO.MesId;

                    cmd.Parameters.Add("@PeriodoDias", SqlDbType.Int);
                    cmd.Parameters["@PeriodoDias"].Value = ingresoDatoServicioAlimentacionDTO.PeriodoDias;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioAlimentacionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CantidadPersupe", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersupe"].Value = ingresoDatoServicioAlimentacionDTO.CantidadPersupe;

                    cmd.Parameters.Add("@CantidadPersuba", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersuba"].Value = ingresoDatoServicioAlimentacionDTO.CantidadPersuba;

                    cmd.Parameters.Add("@CantidadPermar", SqlDbType.Int);
                    cmd.Parameters["@CantidadPermar"].Value = ingresoDatoServicioAlimentacionDTO.CantidadPermar;

                    cmd.Parameters.Add("@TotalPersonalVacaciones", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalVacaciones"].Value = ingresoDatoServicioAlimentacionDTO.TotalPersonalVacaciones;

                    cmd.Parameters.Add("@TotalPersonalDiaHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaHabil"].Value = ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaHabil;

                    cmd.Parameters.Add("@TotalPersonalDiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaNoHabil"].Value = ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaNoHabil;

                    cmd.Parameters.Add("@DiaHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaHabil"].Value = ingresoDatoServicioAlimentacionDTO.DiaHabil;

                    cmd.Parameters.Add("@DiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaNoHabil"].Value = ingresoDatoServicioAlimentacionDTO.DiaNoHabil;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = ingresoDatoServicioAlimentacionDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioAlimentacionDTO.UsuarioIngresoRegistro;

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

        public IngresoDatoServicioAlimentacionDTO BuscarFormato(int Codigo)
        {
            IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO = new IngresoDatoServicioAlimentacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioAlimentacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioAlimentacionId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioAlimentacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        ingresoDatoServicioAlimentacionDTO.IngresoDatoServicioAlimentacionId = Convert.ToInt32(dr["IngresoDatoServicioAlimentacionId"]);
                        ingresoDatoServicioAlimentacionDTO.NumeroRacion = Convert.ToInt32(dr["NumeroRacion"]);
                        ingresoDatoServicioAlimentacionDTO.MesId = Convert.ToInt32(dr["MesId"]);
                        ingresoDatoServicioAlimentacionDTO.PeriodoDias = Convert.ToInt32(dr["PeriodoDias"]);
                        ingresoDatoServicioAlimentacionDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        ingresoDatoServicioAlimentacionDTO.CantidadPersupe = Convert.ToInt32(dr["CantidadPersupe"]);
                        ingresoDatoServicioAlimentacionDTO.CantidadPersuba = Convert.ToInt32(dr["CantidadPersuba"]);
                        ingresoDatoServicioAlimentacionDTO.CantidadPermar = Convert.ToInt32(dr["CantidadPermar"]);
                        ingresoDatoServicioAlimentacionDTO.TotalPersonalVacaciones = Convert.ToInt32(dr["TotalPersonalVacaciones"]);
                        ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaHabil = Convert.ToInt32(dr["TotalPersonalDiaHabil"]);
                        ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaNoHabil = Convert.ToInt32(dr["TotalPersonalDiaNoHabil"]);
                        ingresoDatoServicioAlimentacionDTO.DiaHabil = Convert.ToInt32(dr["DiaHabil"]);
                        ingresoDatoServicioAlimentacionDTO.DiaNoHabil = Convert.ToInt32(dr["DiaNoHabil"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ingresoDatoServicioAlimentacionDTO;
        }

        public string ActualizaFormato(IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioAlimentacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@IngresoDatoServicioAlimentacionId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioAlimentacionId"].Value = ingresoDatoServicioAlimentacionDTO.IngresoDatoServicioAlimentacionId;

                    cmd.Parameters.Add("@NumeroRacion", SqlDbType.Int);
                    cmd.Parameters["@NumeroRacion"].Value = ingresoDatoServicioAlimentacionDTO.NumeroRacion;

                    cmd.Parameters.Add("@MesId", SqlDbType.Int);
                    cmd.Parameters["@MesId"].Value = ingresoDatoServicioAlimentacionDTO.MesId;

                    cmd.Parameters.Add("@PeriodoDias", SqlDbType.Int);
                    cmd.Parameters["@PeriodoDias"].Value = ingresoDatoServicioAlimentacionDTO.PeriodoDias;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = ingresoDatoServicioAlimentacionDTO.CodigoDependencia;

                    cmd.Parameters.Add("@CantidadPersupe", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersupe"].Value = ingresoDatoServicioAlimentacionDTO.CantidadPersupe;

                    cmd.Parameters.Add("@CantidadPersuba", SqlDbType.Int);
                    cmd.Parameters["@CantidadPersuba"].Value = ingresoDatoServicioAlimentacionDTO.CantidadPersuba;

                    cmd.Parameters.Add("@CantidadPermar", SqlDbType.Int);
                    cmd.Parameters["@CantidadPermar"].Value = ingresoDatoServicioAlimentacionDTO.CantidadPermar;

                    cmd.Parameters.Add("@TotalPersonalVacaciones", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalVacaciones"].Value = ingresoDatoServicioAlimentacionDTO.TotalPersonalVacaciones;

                    cmd.Parameters.Add("@TotalPersonalDiaHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaHabil"].Value = ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaHabil;

                    cmd.Parameters.Add("@TotalPersonalDiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@TotalPersonalDiaNoHabil"].Value = ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaNoHabil;

                    cmd.Parameters.Add("@DiaHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaHabil"].Value = ingresoDatoServicioAlimentacionDTO.DiaHabil;

                    cmd.Parameters.Add("@DiaNoHabil", SqlDbType.Int);
                    cmd.Parameters["@DiaNoHabil"].Value = ingresoDatoServicioAlimentacionDTO.DiaNoHabil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioAlimentacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_IngresoDatoServicioAlimentacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioAlimentacionId", SqlDbType.Int);
                    cmd.Parameters["@IngresoDatoServicioAlimentacionId"].Value = ingresoDatoServicioAlimentacionDTO.IngresoDatoServicioAlimentacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ingresoDatoServicioAlimentacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_IngresoDatoServicioAlimentacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngresoDatoServicioAlimentacion", SqlDbType.Structured);
                    cmd.Parameters["@IngresoDatoServicioAlimentacion"].TypeName = "Formato.IngresoDatoServicioAlimentacion";
                    cmd.Parameters["@IngresoDatoServicioAlimentacion"].Value = datos;

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
