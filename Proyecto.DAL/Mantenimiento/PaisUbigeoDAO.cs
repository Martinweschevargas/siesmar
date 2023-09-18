
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PaisUbigeoDAO
    {

        SqlCommand cmd = new();

        public List<PaisUbigeoDTO> ObtenerPaisUbigeos()
        {
            List<PaisUbigeoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PaisUbigeoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PaisUbigeoDTO()
                        {
                            PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]),
                            CodIsoAlfa2 = dr["CodIsoAlfa2"].ToString(),
                            NombrePais = dr["NombrePais"].ToString(),
                            Numerico = dr["NumericoPais"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPaisUbigeo(PaisUbigeoDTO paisUbigeoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PaisUbigeoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodIsoAlfa2", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodIsoAlfa2"].Value = paisUbigeoDTO.CodIsoAlfa2;

                    cmd.Parameters.Add("@NombrePais", SqlDbType.VarChar, 80);
                    cmd.Parameters["@NombrePais"].Value = paisUbigeoDTO.NombrePais;

                    cmd.Parameters.Add("@Numerico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Numerico"].Value = paisUbigeoDTO.Numerico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = paisUbigeoDTO.UsuarioIngresoRegistro;

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

        public PaisUbigeoDTO BuscarPaisUbigeoID(int Codigo)
        {
            PaisUbigeoDTO paisUbigeoDTO = new PaisUbigeoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PaisUbigeoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        paisUbigeoDTO.PaisUbigeoId = Convert.ToInt32(dr["PaisUbigeoId"]);
                        paisUbigeoDTO.CodIsoAlfa2 = dr["CodIsoAlfa2"].ToString();
                        paisUbigeoDTO.NombrePais = dr["NombrePais"].ToString();
                        paisUbigeoDTO.Numerico = dr["Numerico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paisUbigeoDTO;
        }

        public string ActualizarPaisUbigeo(PaisUbigeoDTO paisUbigeoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_PaisUbigeoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = paisUbigeoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@CodIsoAlfa2", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodIsoAlfa2"].Value = paisUbigeoDTO.CodIsoAlfa2;

                    cmd.Parameters.Add("@NombrePais", SqlDbType.VarChar, 80);
                    cmd.Parameters["@NombrePais"].Value = paisUbigeoDTO.NombrePais;

                    cmd.Parameters.Add("@Numerico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Numerico"].Value = paisUbigeoDTO.Numerico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = paisUbigeoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

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

        public bool EliminarPaisUbigeo(PaisUbigeoDTO paisUbigeoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PaisUbigeoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PaisUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@PaisUbigeoId"].Value = paisUbigeoDTO.PaisUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = paisUbigeoDTO.UsuarioIngresoRegistro;

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

    }
}
