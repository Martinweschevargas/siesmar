using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class OrigenTerrenoDAO
    {

        SqlCommand cmd = new();

        public List<OrigenTerrenoDTO> ObtenerOrigenTerrenos()
        {
            List<OrigenTerrenoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_OrigenTerrenoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OrigenTerrenoDTO()
                        {
                            OrigenTerrenoId = Convert.ToInt32(dr["OrigenTerrenoId"]),
                            DescOrigenTerreno = dr["DescOrigenTerreno"].ToString(),
                            CodigoOrigenTerreno = dr["CodigoOrigenTerreno"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarOrigenTerreno(OrigenTerrenoDTO origenTerrenoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrigenTerrenoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescOrigenTerreno", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescOrigenTerreno"].Value = origenTerrenoDTO.DescOrigenTerreno;

                    cmd.Parameters.Add("@CodigoOrigenTerreno", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoOrigenTerreno"].Value = origenTerrenoDTO.CodigoOrigenTerreno;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = origenTerrenoDTO.UsuarioIngresoRegistro;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public OrigenTerrenoDTO BuscarOrigenTerrenoID(int Codigo)
        {
            OrigenTerrenoDTO origenTerrenoDTO = new OrigenTerrenoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrigenTerrenoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrigenTerrenoId", SqlDbType.Int);
                    cmd.Parameters["@OrigenTerrenoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        origenTerrenoDTO.OrigenTerrenoId = Convert.ToInt32(dr["OrigenTerrenoId"]);
                        origenTerrenoDTO.DescOrigenTerreno = dr["DescOrigenTerreno"].ToString();
                        origenTerrenoDTO.CodigoOrigenTerreno = dr["CodigoOrigenTerreno"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return origenTerrenoDTO;
        }

        public string ActualizarOrigenTerreno(OrigenTerrenoDTO origenTerrenoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_OrigenTerrenoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrigenTerrenoId", SqlDbType.Int);
                    cmd.Parameters["@OrigenTerrenoId"].Value = origenTerrenoDTO.OrigenTerrenoId;

                    cmd.Parameters.Add("@DescOrigenTerreno", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescOrigenTerreno"].Value = origenTerrenoDTO.DescOrigenTerreno;

                    cmd.Parameters.Add("@CodigoOrigenTerreno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoOrigenTerreno"].Value = origenTerrenoDTO.CodigoOrigenTerreno;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = origenTerrenoDTO.UsuarioIngresoRegistro;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public bool EliminarOrigenTerreno(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrigenTerrenoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrigenTerrenoId", SqlDbType.Int);
                    cmd.Parameters["@OrigenTerrenoId"].Value = Codigo;
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

    }
}
