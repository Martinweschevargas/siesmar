using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class NivelAlistamientoDAO
    {

        SqlCommand cmd = new();

        public List<NivelAlistamientoDTO> ObtenerNivelAlistamientos()
        {
            List<NivelAlistamientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_NivelAlistamientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new NivelAlistamientoDTO()
                        {
                            NivelAlistamientoId = Convert.ToInt32(dr["NivelAlistamientoId"]),
                            DescNivelAlistamiento = dr["DescNivelAlistamiento"].ToString(),
                            Calificativo = dr["Calificativo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarNivelAlistamiento(NivelAlistamientoDTO nivelAlistamientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelAlistamientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescNivelAlistamiento", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescNivelAlistamiento"].Value = nivelAlistamientoDTO.DescNivelAlistamiento;

                    cmd.Parameters.Add("@Calificativo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@Calificativo"].Value = nivelAlistamientoDTO.Calificativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelAlistamientoDTO.UsuarioIngresoRegistro;

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

        public NivelAlistamientoDTO BuscarNivelAlistamientoID(int Codigo)
        {
            NivelAlistamientoDTO nivelAlistamientoDTO = new NivelAlistamientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelAlistamientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelAlistamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelAlistamientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        nivelAlistamientoDTO.NivelAlistamientoId = Convert.ToInt32(dr["NivelAlistamientoId"]);
                        nivelAlistamientoDTO.DescNivelAlistamiento = dr["DescNivelAlistamiento"].ToString();
                        nivelAlistamientoDTO.Calificativo = dr["Calificativo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return nivelAlistamientoDTO;
        }

        public string ActualizarNivelAlistamiento(NivelAlistamientoDTO nivelAlistamientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_NivelAlistamientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelAlistamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelAlistamientoId"].Value = nivelAlistamientoDTO.NivelAlistamientoId;

                    cmd.Parameters.Add("@DescNivelAlistamiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescNivelAlistamiento"].Value = nivelAlistamientoDTO.DescNivelAlistamiento;

                    cmd.Parameters.Add("@Calificativo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@Calificativo"].Value = nivelAlistamientoDTO.Calificativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = nivelAlistamientoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarNivelAlistamiento(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_NivelAlistamientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NivelAlistamientoId", SqlDbType.Int);
                    cmd.Parameters["@NivelAlistamientoId"].Value = Codigo;
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
