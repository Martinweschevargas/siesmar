using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoRepuestoCriticoDAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoRepuestoCriticoDTO> ObtenerAlistamientoRepuestoCriticos()
        {
            List<AlistamientoRepuestoCriticoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoRepuestoCriticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoRepuestoCriticoDTO()
                        {
                            AlistamientoRepuestoCriticoId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoId"]),
                            CodigoAlistamientoRepuestoCritico = dr["CodigoAlistamientoRepuestoCritico"].ToString(),
                            DescSistemaRepuestoCritico = dr["DescSistemaRepuestoCritico"].ToString(),
                            DescSubsistemaRepuestoCritico = dr["DescSubsistemaRepuestoCritico"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            Repuesto = dr["Repuesto"].ToString(),
                            Existente = dr["Existente"].ToString(),
                            Necesario = dr["Necesario"].ToString(),
                            CoeficientePonderacion = dr["CoeficientePonderacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO AlistamientoRepuestoCriticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoRepuestoCriticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoAlistamientoRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoRepuestoCritico"].Value = AlistamientoRepuestoCriticoDTO.CodigoAlistamientoRepuestoCritico;

                    cmd.Parameters.Add("@CodigoSistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaRepuestoCritico"].Value = AlistamientoRepuestoCriticoDTO.CodigoSistemaRepuestoCritico;

                    cmd.Parameters.Add("@CodigoSubsistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaRepuestoCritico"].Value = AlistamientoRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoRepuestoCriticoDTO.Equipo;

                    cmd.Parameters.Add("@Repuesto", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Repuesto"].Value = AlistamientoRepuestoCriticoDTO.Repuesto;

                    cmd.Parameters.Add("@Existente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Existente"].Value = AlistamientoRepuestoCriticoDTO.Existente;

                    cmd.Parameters.Add("@Necesario", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Necesario"].Value = AlistamientoRepuestoCriticoDTO.Necesario;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CoeficientePonderacion"].Value = AlistamientoRepuestoCriticoDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro;

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

        public AlistamientoRepuestoCriticoDTO BuscarAlistamientoRepuestoCriticoID(int Codigo)
        {
            AlistamientoRepuestoCriticoDTO AlistamientoRepuestoCriticoDTO = new AlistamientoRepuestoCriticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoRepuestoCriticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AlistamientoRepuestoCriticoDTO.AlistamientoRepuestoCriticoId = Convert.ToInt32(dr["AlistamientoRepuestoCriticoId"]);
                        AlistamientoRepuestoCriticoDTO.CodigoAlistamientoRepuestoCritico = dr["CodigoAlistamientoRepuestoCritico"].ToString();
                        AlistamientoRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = dr["CodigoSistemaRepuestoCritico"].ToString();
                        AlistamientoRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = dr["CodigoSubsistemaRepuestoCritico"].ToString();
                        AlistamientoRepuestoCriticoDTO.Equipo = dr["Equipo"].ToString();
                        AlistamientoRepuestoCriticoDTO.Repuesto = dr["Repuesto"].ToString();
                        AlistamientoRepuestoCriticoDTO.Existente = dr["Existente"].ToString();
                        AlistamientoRepuestoCriticoDTO.Necesario = dr["Necesario"].ToString();
                        AlistamientoRepuestoCriticoDTO.CoeficientePonderacion = dr["CoeficientePonderacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AlistamientoRepuestoCriticoDTO;
        }

        public string ActualizarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO AlistamientoRepuestoCriticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoRepuestoCriticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = AlistamientoRepuestoCriticoDTO.AlistamientoRepuestoCriticoId;

                    cmd.Parameters.Add("@CodigoAlistamientoRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoRepuestoCritico"].Value = AlistamientoRepuestoCriticoDTO.CodigoAlistamientoRepuestoCritico;

                    cmd.Parameters.Add("@CodigoSistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaRepuestoCritico"].Value = AlistamientoRepuestoCriticoDTO.CodigoSistemaRepuestoCritico;

                    cmd.Parameters.Add("@CodigoSubsistemaRepuestoCritico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaRepuestoCritico"].Value = AlistamientoRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoRepuestoCriticoDTO.Equipo;

                    cmd.Parameters.Add("@Repuesto", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Repuesto"].Value = AlistamientoRepuestoCriticoDTO.Repuesto;

                    cmd.Parameters.Add("@Existente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Existente"].Value = AlistamientoRepuestoCriticoDTO.Existente;

                    cmd.Parameters.Add("@Necesario", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Necesario"].Value = AlistamientoRepuestoCriticoDTO.Necesario;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CoeficientePonderacion"].Value = AlistamientoRepuestoCriticoDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro;

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
        public string EliminarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO AlistamientoRepuestoCriticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoRepuestoCriticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoRepuestoCriticoId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoRepuestoCriticoId"].Value = AlistamientoRepuestoCriticoDTO.AlistamientoRepuestoCriticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro;

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
