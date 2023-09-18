using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EntidadFinancieraGrupoDAO
    {

        SqlCommand cmd = new();

        public List<EntidadFinancieraGrupoDTO> ObtenerEntidadFinancieraGrupos()
        {
            List<EntidadFinancieraGrupoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraGrupoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EntidadFinancieraGrupoDTO()
                        {
                            EntidadFinancieraGrupoId = Convert.ToInt32(dr["EntidadFinancieraGrupoId"]),
                            DescEntidadFinancieraGrupo = dr["DescEntidadFinancieraGrupo"].ToString(),
                            CodigoEntidadFinancieraGrupo = dr["CodigoEntidadFinancieraGrupo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEntidadFinancieraGrupo(EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraGrupoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescEntidadFinancieraGrupo", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescEntidadFinancieraGrupo"].Value = entidadFinancieraGrupoDTO.DescEntidadFinancieraGrupo;

                    cmd.Parameters.Add("@CodigoEntidadFinancieraGrupo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoEntidadFinancieraGrupo"].Value = entidadFinancieraGrupoDTO.CodigoEntidadFinancieraGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadFinancieraGrupoDTO.UsuarioIngresoRegistro;

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
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return IND_OPERACION;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public EntidadFinancieraGrupoDTO BuscarEntidadFinancieraGrupoID(int Codigo)
        {
            EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO = new EntidadFinancieraGrupoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraGrupoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadFinancieraGrupoId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraGrupoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        entidadFinancieraGrupoDTO.EntidadFinancieraGrupoId = Convert.ToInt32(dr["EntidadFinancieraGrupoId"]);
                        entidadFinancieraGrupoDTO.DescEntidadFinancieraGrupo = dr["DescEntidadFinancieraGrupo"].ToString();
                        entidadFinancieraGrupoDTO.CodigoEntidadFinancieraGrupo = dr["CodigoEntidadFinancieraGrupo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return entidadFinancieraGrupoDTO;
        }

        public string ActualizarEntidadFinancieraGrupo(EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraGrupoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadFinancieraGrupoId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraGrupoId"].Value = entidadFinancieraGrupoDTO.EntidadFinancieraGrupoId;

                    cmd.Parameters.Add("@DescEntidadFinancieraGrupo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEntidadFinancieraGrupo"].Value = entidadFinancieraGrupoDTO.DescEntidadFinancieraGrupo;

                    cmd.Parameters.Add("@CodigoEntidadFinancieraGrupo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoEntidadFinancieraGrupo"].Value = entidadFinancieraGrupoDTO.CodigoEntidadFinancieraGrupo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadFinancieraGrupoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarEntidadFinancieraGrupo(EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EntidadFinancieraGrupoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EntidadFinancieraGrupoId", SqlDbType.Int);
                    cmd.Parameters["@EntidadFinancieraGrupoId"].Value = entidadFinancieraGrupoDTO.EntidadFinancieraGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = entidadFinancieraGrupoDTO.UsuarioIngresoRegistro;

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
