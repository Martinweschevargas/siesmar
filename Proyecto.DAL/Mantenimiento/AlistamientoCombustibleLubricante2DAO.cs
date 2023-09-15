using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoCombustibleLubricante2DAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoCombustibleLubricante2DTO> ObtenerAlistamientoCombustibleLubricante2s()
        {
            List<AlistamientoCombustibleLubricante2DTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricante2Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoCombustibleLubricante2DTO()
                        {
                            AlistamientoCombustibleLubricante2Id = Convert.ToInt32(dr["AlistamientoCombustibleLubricante2Id"]),
                            CodigoAlistamientoCombustibleLubricante2 = dr["CodigoAlistamientoCombustibleLubricante2"].ToString(),
                            Articulo = dr["Articulo"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            DescUnidadMedida = dr["DescUnidadMedida"].ToString(),
                            Cargo = Convert.ToInt32(dr["Cargo"]),
                            Aumento = Convert.ToInt32(dr["Aumento"]),
                            Consumo = Convert.ToInt32(dr["Consumo"]),
                            Existencia = Convert.ToInt32(dr["Existencia"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO AlistamientoCombustibleLubricante2DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricante2Registrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante2", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante2"].Value = AlistamientoCombustibleLubricante2DTO.CodigoAlistamientoCombustibleLubricante2;

                    cmd.Parameters.Add("@Articulo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Articulo"].Value = AlistamientoCombustibleLubricante2DTO.Articulo;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoCombustibleLubricante2DTO.Equipo;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = AlistamientoCombustibleLubricante2DTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@Cargo", SqlDbType.Int);
                    cmd.Parameters["@Cargo"].Value = AlistamientoCombustibleLubricante2DTO.Cargo;

                    cmd.Parameters.Add("@Aumento", SqlDbType.Int);
                    cmd.Parameters["@Aumento"].Value = AlistamientoCombustibleLubricante2DTO.Aumento;
                   
                    cmd.Parameters.Add("@Consumo", SqlDbType.Int);
                    cmd.Parameters["@Consumo"].Value = AlistamientoCombustibleLubricante2DTO.Consumo;

                    cmd.Parameters.Add("@Existencia", SqlDbType.Int);
                    cmd.Parameters["@Existencia"].Value = AlistamientoCombustibleLubricante2DTO.Existencia;
                    
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoCombustibleLubricante2DTO.UsuarioIngresoRegistro;

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

        public AlistamientoCombustibleLubricante2DTO BuscarAlistamientoCombustibleLubricante2ID(int Codigo)
        {
            AlistamientoCombustibleLubricante2DTO AlistamientoCombustibleLubricante2DTO = new AlistamientoCombustibleLubricante2DTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricante2Encontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AlistamientoCombustibleLubricante2DTO.AlistamientoCombustibleLubricante2Id = Convert.ToInt32(dr["AlistamientoCombustibleLubricante2Id"]);
                        AlistamientoCombustibleLubricante2DTO.CodigoAlistamientoCombustibleLubricante2 = dr["CodigoAlistamientoCombustibleLubricante2"].ToString();
                        AlistamientoCombustibleLubricante2DTO.Articulo = dr["Articulo"].ToString();
                        AlistamientoCombustibleLubricante2DTO.Equipo = dr["Equipo"].ToString();
                        AlistamientoCombustibleLubricante2DTO.CodigoUnidadMedida = dr["CodigoUnidadMedida"].ToString();
                        AlistamientoCombustibleLubricante2DTO.Cargo = Convert.ToInt32(dr["Cargo"]);
                        AlistamientoCombustibleLubricante2DTO.Aumento = Convert.ToInt32(dr["Aumento"]);
                        AlistamientoCombustibleLubricante2DTO.Consumo = Convert.ToInt32(dr["Consumo"]);
                        AlistamientoCombustibleLubricante2DTO.Existencia = Convert.ToInt32(dr["Existencia"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AlistamientoCombustibleLubricante2DTO;
        }

        public string ActualizarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO AlistamientoCombustibleLubricante2DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricante2Actualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = AlistamientoCombustibleLubricante2DTO.AlistamientoCombustibleLubricante2Id;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante2", SqlDbType.VarChar, 100);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante2"].Value = AlistamientoCombustibleLubricante2DTO.CodigoAlistamientoCombustibleLubricante2;

                    cmd.Parameters.Add("@Articulo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Articulo"].Value = AlistamientoCombustibleLubricante2DTO.Articulo;

                    cmd.Parameters.Add("@Equipo", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Equipo"].Value = AlistamientoCombustibleLubricante2DTO.Equipo;

                    cmd.Parameters.Add("@CodigoUnidadMedida", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadMedida"].Value = AlistamientoCombustibleLubricante2DTO.CodigoUnidadMedida;

                    cmd.Parameters.Add("@Cargo", SqlDbType.Int);
                    cmd.Parameters["@Cargo"].Value = AlistamientoCombustibleLubricante2DTO.Cargo;

                    cmd.Parameters.Add("@Aumento", SqlDbType.Int);
                    cmd.Parameters["@Aumento"].Value = AlistamientoCombustibleLubricante2DTO.Aumento;

                    cmd.Parameters.Add("@Consumo", SqlDbType.Int);
                    cmd.Parameters["@Consumo"].Value = AlistamientoCombustibleLubricante2DTO.Consumo;

                    cmd.Parameters.Add("@Existencia", SqlDbType.Int);
                    cmd.Parameters["@Existencia"].Value = AlistamientoCombustibleLubricante2DTO.Existencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoCombustibleLubricante2DTO.UsuarioIngresoRegistro;

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

        public string EliminarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO AlistamientoCombustibleLubricante2DTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoCombustibleLubricante2Eliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = AlistamientoCombustibleLubricante2DTO.AlistamientoCombustibleLubricante2Id;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AlistamientoCombustibleLubricante2DTO.UsuarioIngresoRegistro;

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
