using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DenominacionBaseDatoDAO
    {

        SqlCommand cmd = new();

        public List<DenominacionBaseDatoDTO> ObtenerDenominacionBaseDatos()
        {
            List<DenominacionBaseDatoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DenominacionBaseDatosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DenominacionBaseDatoDTO()
                        {
                            DenominacionBaseDatoId = Convert.ToInt32(dr["DenominacionBaseDatoId"]),
                            DescDenominacionBaseDato = dr["DescDenominacionBaseDato"].ToString(),
                            CodigoDenominacionBaseDato = dr["CodigoDenominacionBaseDato"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDenominacionBaseDato(DenominacionBaseDatoDTO denominacionBaseDatosDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionBaseDatosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDenominacionBaseDato", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescDenominacionBaseDato"].Value = denominacionBaseDatosDTO.DescDenominacionBaseDato;

                    cmd.Parameters.Add("@CodigoDenominacionBaseDato", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoDenominacionBaseDato"].Value = denominacionBaseDatosDTO.CodigoDenominacionBaseDato;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denominacionBaseDatosDTO.UsuarioIngresoRegistro;

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

        public DenominacionBaseDatoDTO BuscarDenominacionBaseDatoID(int Codigo)
        {
            DenominacionBaseDatoDTO denominacionBaseDatosDTO = new DenominacionBaseDatoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionBaseDatosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionBaseDatoId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionBaseDatoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        denominacionBaseDatosDTO.DenominacionBaseDatoId = Convert.ToInt32(dr["DenominacionBaseDatoId"]);
                        denominacionBaseDatosDTO.DescDenominacionBaseDato = dr["DescDenominacionBaseDato"].ToString();
                        denominacionBaseDatosDTO.CodigoDenominacionBaseDato = dr["CodigoDenominacionBaseDato"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return denominacionBaseDatosDTO;
        }

        public string ActualizarDenominacionBaseDato(DenominacionBaseDatoDTO denominacionBaseDatosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionBaseDatosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionBaseDatoId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionBaseDatoId"].Value = denominacionBaseDatosDTO.DenominacionBaseDatoId;

                    cmd.Parameters.Add("@DescDenominacionBaseDato", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDenominacionBaseDato"].Value = denominacionBaseDatosDTO.DescDenominacionBaseDato;

                    cmd.Parameters.Add("@CodigoDenominacionBaseDato", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDenominacionBaseDato"].Value = denominacionBaseDatosDTO.CodigoDenominacionBaseDato;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denominacionBaseDatosDTO.UsuarioIngresoRegistro;

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

        public string EliminarDenominacionBaseDato(DenominacionBaseDatoDTO denominacionBaseDatosDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionBaseDatosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionBaseDatoId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionBaseDatoId"].Value = denominacionBaseDatosDTO.DenominacionBaseDatoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denominacionBaseDatosDTO.UsuarioIngresoRegistro;

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
