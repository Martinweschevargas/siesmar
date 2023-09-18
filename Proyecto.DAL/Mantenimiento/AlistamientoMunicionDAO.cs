using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoMunicionDAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoMunicionDTO> ObtenerAlistamientoMunicions()
        {
            List<AlistamientoMunicionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMunicionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMunicionDTO()
                        {
                            AlistamientoMunicionId = Convert.ToInt32(dr["AlistamientoMunicionId"]),
                            CodigoAlistamientoMunicion = dr["CodigoAlistamientoMunicion"].ToString(),
                            DescSistemaMunicion = dr["DescSistemaMunicion"].ToString(),
                            DescSubsistemaMunicion = dr["DescSubsistemaMunicion"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            Municion = dr["Municion"].ToString(),
                            Existente = dr["Existente"].ToString(),
                            Necesaria = Convert.ToInt32(dr["Necesaria"]),
                            CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoMunicion(AlistamientoMunicionDTO AlistamientoMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMunicionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = AlistamientoMunicionDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@CodigoSistemaMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaMunicion"].Value = AlistamientoMunicionDTO.CodigoSistemaMunicion;

                    cmd.Parameters.Add("@CodigoSubsistemaMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaMunicion"].Value = AlistamientoMunicionDTO.CodigoSubsistemaMunicion;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoMunicionDTO.Equipo;

                    cmd.Parameters.Add("@Municion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Municion"].Value = AlistamientoMunicionDTO.Municion;

                    cmd.Parameters.Add("@Existente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Existente"].Value = AlistamientoMunicionDTO.Existente;

                    cmd.Parameters.Add("@Necesaria", SqlDbType.Int);
                    cmd.Parameters["@Necesaria"].Value = AlistamientoMunicionDTO.Necesaria;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = AlistamientoMunicionDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoMunicionDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMunicionDTO BuscarAlistamientoMunicionID(int Codigo)
        {
            AlistamientoMunicionDTO AlistamientoMunicionDTO = new AlistamientoMunicionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMunicionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AlistamientoMunicionDTO.AlistamientoMunicionId = Convert.ToInt32(dr["AlistamientoMunicionId"]);
                        AlistamientoMunicionDTO.CodigoAlistamientoMunicion = dr["CodigoAlistamientoMunicion"].ToString();
                        AlistamientoMunicionDTO.CodigoSistemaMunicion = dr["CodigoSistemaMunicion"].ToString();
                        AlistamientoMunicionDTO.CodigoSubsistemaMunicion = dr["SubCodigoSistemaMunicion"].ToString();
                        AlistamientoMunicionDTO.Equipo = dr["Equipo"].ToString();
                        AlistamientoMunicionDTO.Municion = dr["Municion"].ToString();
                        AlistamientoMunicionDTO.Existente = dr["Existente"].ToString();
                        AlistamientoMunicionDTO.Necesaria = Convert.ToInt32(dr["Necesaria"]);
                        AlistamientoMunicionDTO.CoeficientePonderacion = Convert.ToInt32(dr["CoeficientePonderacion"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AlistamientoMunicionDTO;
        }

        public string ActualizarAlistamientoMunicion(AlistamientoMunicionDTO AlistamientoMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMunicionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionId"].Value = AlistamientoMunicionDTO.AlistamientoMunicionId;

                    cmd.Parameters.Add("@CodigoAlistamientoMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMunicion"].Value = AlistamientoMunicionDTO.CodigoAlistamientoMunicion;

                    cmd.Parameters.Add("@CodigoSistemaMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaMunicion"].Value = AlistamientoMunicionDTO.CodigoSistemaMunicion;

                    cmd.Parameters.Add("@CodigoSubsistemaMunicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaMunicion"].Value = AlistamientoMunicionDTO.CodigoSubsistemaMunicion;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoMunicionDTO.Equipo;

                    cmd.Parameters.Add("@Municion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Municion"].Value = AlistamientoMunicionDTO.Municion;

                    cmd.Parameters.Add("@Existente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Existente"].Value = AlistamientoMunicionDTO.Existente;

                    cmd.Parameters.Add("@Necesaria", SqlDbType.Int);
                    cmd.Parameters["@Necesaria"].Value = AlistamientoMunicionDTO.Necesaria;

                    cmd.Parameters.Add("@CoeficientePonderacion", SqlDbType.Int);
                    cmd.Parameters["@CoeficientePonderacion"].Value = AlistamientoMunicionDTO.CoeficientePonderacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoMunicionDTO.UsuarioIngresoRegistro;

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
        public string EliminarAlistamientoMunicion(AlistamientoMunicionDTO AlistamientoMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMunicionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMunicionId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMunicionId"].Value = AlistamientoMunicionDTO.AlistamientoMunicionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoMunicionDTO.UsuarioIngresoRegistro;

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
