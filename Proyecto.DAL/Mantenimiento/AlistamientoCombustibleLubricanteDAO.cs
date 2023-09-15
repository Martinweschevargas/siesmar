using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoCombustibleLubricanteDAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoCombustibleLubricanteDTO> ObtenerAlistamientoCombustibleLubricantes()
        {
            List<AlistamientoCombustibleLubricanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoCombustibleLubricanteDTO()
                        {
                            AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]),
                            CodigoAlistamientoCombustibleLubricante = dr["CodigoAlistamientoCombustibleLubricante"].ToString(),
                            DescSistemaCombustibleLubricante = dr["DescSistemaCombustibleLubricante"].ToString(),
                            DescSubsistemaCombustibleLubricante = dr["DescSubsistemaCombustibleLubricante"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            CombustibleLubricante = dr["CombustibleLubricante"].ToString(),
                            Existente = dr["Existente"].ToString(),
                            NecesariasGLS = dr["NecesariasGLS"].ToString(),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO AlistamientoCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CodigoAlistamientoCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaCombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSubsistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaCombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoCombustibleLubricanteDTO.Equipo;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@Existente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Existente"].Value = AlistamientoCombustibleLubricanteDTO.Existente;

                    cmd.Parameters.Add("@NecesariasGLS", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NecesariasGLS"].Value = AlistamientoCombustibleLubricanteDTO.NecesariasGLS;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = AlistamientoCombustibleLubricanteDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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

        public AlistamientoCombustibleLubricanteDTO BuscarAlistamientoCombustibleLubricanteID(int Codigo)
        {
            AlistamientoCombustibleLubricanteDTO AlistamientoCombustibleLubricanteDTO = new AlistamientoCombustibleLubricanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AlistamientoCombustibleLubricanteDTO.AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]);
                        AlistamientoCombustibleLubricanteDTO.CodigoAlistamientoCombustibleLubricante = dr["CodigoAlistamientoCombustibleLubricante"].ToString();
                        AlistamientoCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante = dr["CodigoSistemaCombustibleLubricante"].ToString();
                        AlistamientoCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante = dr["CodigoSubsistemaCombustibleLubricante"].ToString();
                        AlistamientoCombustibleLubricanteDTO.Equipo = dr["Equipo"].ToString();
                        AlistamientoCombustibleLubricanteDTO.CombustibleLubricante = dr["CombustibleLubricante"].ToString();
                        AlistamientoCombustibleLubricanteDTO.Existente = dr["Existente"].ToString();
                        AlistamientoCombustibleLubricanteDTO.NecesariasGLS = dr["NecesariasGLS"].ToString();
                        AlistamientoCombustibleLubricanteDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AlistamientoCombustibleLubricanteDTO;
        }

        public string ActualizarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO AlistamientoCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = AlistamientoCombustibleLubricanteDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CodigoAlistamientoCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaCombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSubsistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaCombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoCombustibleLubricanteDTO.Equipo;

                    cmd.Parameters.Add("@CombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CombustibleLubricante"].Value = AlistamientoCombustibleLubricanteDTO.CombustibleLubricante;

                    cmd.Parameters.Add("@Existente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Existente"].Value = AlistamientoCombustibleLubricanteDTO.Existente;

                    cmd.Parameters.Add("@NecesariasGLS", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NecesariasGLS"].Value = AlistamientoCombustibleLubricanteDTO.NecesariasGLS;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = AlistamientoCombustibleLubricanteDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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
        public string EliminarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO AlistamientoCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = AlistamientoCombustibleLubricanteDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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
