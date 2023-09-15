using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diresgrum;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Diresgrum
{
    public class CubrimientoVacantesGrumeteDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<CubrimientoVacantesGrumeteDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<CubrimientoVacantesGrumeteDTO> lista = new List<CubrimientoVacantesGrumeteDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_CubrimientoVacanteGrumeteListar", conexion);
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
                        lista.Add(new CubrimientoVacantesGrumeteDTO()
                        {
                            CubrimientoVacanteGrumeteId = Convert.ToInt32(dr["CubrimientoVacanteGrumeteId"]),
                            AnioCubrimientoVacante = Convert.ToInt32(dr["AnioCubrimientoVacante"]),
                            NumeroContingente = Convert.ToInt32(dr["NumeroContingente"]),
                            DescEspecialidadGrumete = dr["DescEspecialidadGrumete"].ToString(),
                            SexoGrumete = dr["SexoGrumete"].ToString(),
                            NumeroRequerido = Convert.ToInt32(dr["NumeroRequerido"]),
                            NumeroEfectivo = Convert.ToInt32(dr["NumeroEfectivo"]),
                            DeficitVacante = Convert.ToInt32(dr["DeficitVacante"]),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CubrimientoVacanteGrumeteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioCubrimientoVacante", SqlDbType.Int);
                    cmd.Parameters["@AnioCubrimientoVacante"].Value = cubrimientoVacantesGrumeteDTO.AnioCubrimientoVacante;

                    cmd.Parameters.Add("@NumeroContingente", SqlDbType.Int);
                    cmd.Parameters["@NumeroContingente"].Value = cubrimientoVacantesGrumeteDTO.NumeroContingente;

                    cmd.Parameters.Add("@CodigoEspecialidadGrumete", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGrumete"].Value = cubrimientoVacantesGrumeteDTO.CodigoEspecialidadGrumete;

                    cmd.Parameters.Add("@SexoGrumete", SqlDbType.VarChar, 10);
                    cmd.Parameters["@SexoGrumete"].Value = cubrimientoVacantesGrumeteDTO.SexoGrumete;

                    cmd.Parameters.Add("@NumeroRequerido", SqlDbType.Int);
                    cmd.Parameters["@NumeroRequerido"].Value = cubrimientoVacantesGrumeteDTO.NumeroRequerido;

                    cmd.Parameters.Add("@NumeroEfectivo", SqlDbType.Int);
                    cmd.Parameters["@NumeroEfectivo"].Value = cubrimientoVacantesGrumeteDTO.NumeroEfectivo;

                    cmd.Parameters.Add("@DeficitVacante", SqlDbType.Int);
                    cmd.Parameters["@DeficitVacante"].Value = cubrimientoVacantesGrumeteDTO.DeficitVacante;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = cubrimientoVacantesGrumeteDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro;

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

        public CubrimientoVacantesGrumeteDTO BuscarFormato(int Codigo)
        {
            CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO = new CubrimientoVacantesGrumeteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CubrimientoVacanteGrumeteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CubrimientoVacanteGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@CubrimientoVacanteGrumeteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        cubrimientoVacantesGrumeteDTO.CubrimientoVacanteGrumeteId = Convert.ToInt32(dr["CubrimientoVacanteGrumeteId"]);
                        cubrimientoVacantesGrumeteDTO.AnioCubrimientoVacante = Convert.ToInt32(dr["AnioCubrimientoVacante"]);
                        cubrimientoVacantesGrumeteDTO.NumeroContingente = Convert.ToInt32(dr["NumeroContingente"]);
                        cubrimientoVacantesGrumeteDTO.CodigoEspecialidadGrumete = dr["CodigoEspecialidadGrumete"].ToString();
                        cubrimientoVacantesGrumeteDTO.SexoGrumete = dr["SexoGrumete"].ToString();
                        cubrimientoVacantesGrumeteDTO.NumeroRequerido = Convert.ToInt32(dr["NumeroRequerido"]);
                        cubrimientoVacantesGrumeteDTO.NumeroEfectivo = Convert.ToInt32(dr["NumeroEfectivo"]);
                        cubrimientoVacantesGrumeteDTO.DeficitVacante = Convert.ToInt32(dr["DeficitVacante"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return cubrimientoVacantesGrumeteDTO;
        }

        public string ActualizaFormato(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_CubrimientoVacanteGrumeteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CubrimientoVacanteGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@CubrimientoVacanteGrumeteId"].Value = cubrimientoVacantesGrumeteDTO.CubrimientoVacanteGrumeteId;

                    cmd.Parameters.Add("@AnioCubrimientoVacante", SqlDbType.Int);
                    cmd.Parameters["@AnioCubrimientoVacante"].Value = cubrimientoVacantesGrumeteDTO.AnioCubrimientoVacante;

                    cmd.Parameters.Add("@NumeroContingente", SqlDbType.Int);
                    cmd.Parameters["@NumeroContingente"].Value = cubrimientoVacantesGrumeteDTO.NumeroContingente;

                    cmd.Parameters.Add("@CodigoEspecialidadGrumete", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEspecialidadGrumete"].Value = cubrimientoVacantesGrumeteDTO.CodigoEspecialidadGrumete;

                    cmd.Parameters.Add("@SexoGrumete", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SexoGrumete"].Value = cubrimientoVacantesGrumeteDTO.SexoGrumete;

                    cmd.Parameters.Add("@NumeroRequerido", SqlDbType.Int);
                    cmd.Parameters["@NumeroRequerido"].Value = cubrimientoVacantesGrumeteDTO.NumeroRequerido;

                    cmd.Parameters.Add("@NumeroEfectivo", SqlDbType.Int);
                    cmd.Parameters["@NumeroEfectivo"].Value = cubrimientoVacantesGrumeteDTO.NumeroEfectivo;

                    cmd.Parameters.Add("@DeficitVacante", SqlDbType.Int);
                    cmd.Parameters["@DeficitVacante"].Value = cubrimientoVacantesGrumeteDTO.DeficitVacante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_CubrimientoVacanteGrumeteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CubrimientoVacanteGrumeteId", SqlDbType.Int);
                    cmd.Parameters["@CubrimientoVacanteGrumeteId"].Value = cubrimientoVacantesGrumeteDTO.CubrimientoVacanteGrumeteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO)
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
                    cmd.Parameters["@Formato"].Value = "CubrimientoVacanteGrumete";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = cubrimientoVacantesGrumeteDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_CubrimientoVacanteGrumeteRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CubrimientoVacanteGrumete", SqlDbType.Structured);
                    cmd.Parameters["@CubrimientoVacanteGrumete"].TypeName = "Formato.CubrimientoVacanteGrumete";
                    cmd.Parameters["@CubrimientoVacanteGrumete"].Value = datos;

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