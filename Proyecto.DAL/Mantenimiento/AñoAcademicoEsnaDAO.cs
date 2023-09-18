using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AñoAcademicoEsnaDAO
    {

        SqlCommand cmd = new();

        public List<AñoAcademicoEsnaDTO> ObtenerAñoAcademicoEsnas()
        {
            List<AñoAcademicoEsnaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AnioAcademicoEsnaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AñoAcademicoEsnaDTO()
                        {
                            AñoAcademicoEsnaId = Convert.ToInt32(dr["AnioAcademicoEsnaId"]),
                            DescAñoAcademicoEsna = dr["DescAnioAcademicoEsna"].ToString(),
                            CodigoAñoAcademicoEsna = dr["CodigoAnioAcademicoEsna"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAñoAcademicoEsna(AñoAcademicoEsnaDTO añoAcademicoEsnaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AnioAcademicoEsnaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAnioAcademicoEsna", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@DescAnioAcademicoEsna"].Value = añoAcademicoEsnaDTO.DescAñoAcademicoEsna;

                    cmd.Parameters.Add("@CodigoAnioAcademicoEsna", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAnioAcademicoEsna"].Value = añoAcademicoEsnaDTO.CodigoAñoAcademicoEsna;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = añoAcademicoEsnaDTO.UsuarioIngresoRegistro;

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

        public AñoAcademicoEsnaDTO BuscarAñoAcademicoEsnaID(int Codigo)
        {
            AñoAcademicoEsnaDTO añoAcademicoEsnaDTO = new AñoAcademicoEsnaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AnioAcademicoEsnaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioAcademicoEsnaId", SqlDbType.Int);
                    cmd.Parameters["@AnioAcademicoEsnaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        añoAcademicoEsnaDTO.AñoAcademicoEsnaId = Convert.ToInt32(dr["AnioAcademicoEsnaId"]);
                        añoAcademicoEsnaDTO.DescAñoAcademicoEsna = dr["DescAnioAcademicoEsna"].ToString();
                        añoAcademicoEsnaDTO.CodigoAñoAcademicoEsna = dr["CodigoAnioAcademicoEsna"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return añoAcademicoEsnaDTO;
        }

        public string ActualizarAñoAcademicoEsna(AñoAcademicoEsnaDTO añoAcademicoEsnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AnioAcademicoEsnaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioAcademicoEsnaId", SqlDbType.Int);
                    cmd.Parameters["@AnioAcademicoEsnaId"].Value = añoAcademicoEsnaDTO.AñoAcademicoEsnaId;

                    cmd.Parameters.Add("@DescAnioAcademicoEsna", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAnioAcademicoEsna"].Value = añoAcademicoEsnaDTO.DescAñoAcademicoEsna;

                    cmd.Parameters.Add("@CodigoAnioAcademicoEsna", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAnioAcademicoEsna"].Value = añoAcademicoEsnaDTO.CodigoAñoAcademicoEsna;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = añoAcademicoEsnaDTO.UsuarioIngresoRegistro;

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

        public string EliminarAñoAcademicoEsna(AñoAcademicoEsnaDTO añoAcademicoEsnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AnioAcademicoEsnaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AnioAcademicoEsnaId", SqlDbType.Int);
                    cmd.Parameters["@AnioAcademicoEsnaId"].Value = añoAcademicoEsnaDTO.AñoAcademicoEsnaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = añoAcademicoEsnaDTO.UsuarioIngresoRegistro;

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
