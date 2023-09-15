using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class Formula2CalificativoCentacDAO
    {

        SqlCommand cmd = new();

        public List<Formula2CalificativoCentacDTO> ObtenerFormula2CalificativoCentacs()
        {
            List<Formula2CalificativoCentacDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_Formula2CalificativoCentacListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new Formula2CalificativoCentacDTO()
                        {
                            Formula2CalificativoCentacId = Convert.ToInt32(dr["Formula2CalificativoCentacId"]),
                            DescFormula2CalificativoCentac = dr["DescFormula2CalificativoCentac"].ToString(),
                            CodigoFormula2CalificativoCentac = dr["CodigoFormula2CalificativoCentac"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFormula2CalificativoCentac(Formula2CalificativoCentacDTO formula2CalificativoCentacDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_Formula2CalificativoCentacRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFormula2CalificativoCentac", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescFormula2CalificativoCentac"].Value = formula2CalificativoCentacDTO.DescFormula2CalificativoCentac;

                    cmd.Parameters.Add("@CodigoFormula2CalificativoCentac", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoFormula2CalificativoCentac"].Value = formula2CalificativoCentacDTO.CodigoFormula2CalificativoCentac;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formula2CalificativoCentacDTO.UsuarioIngresoRegistro;

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

        public Formula2CalificativoCentacDTO BuscarFormula2CalificativoCentacID(int Codigo)
        {
            Formula2CalificativoCentacDTO formula2CalificativoCentacDTO = new Formula2CalificativoCentacDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_Formula2CalificativoCentacEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formula2CalificativoCentacId", SqlDbType.Int);
                    cmd.Parameters["@Formula2CalificativoCentacId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        formula2CalificativoCentacDTO.Formula2CalificativoCentacId = Convert.ToInt32(dr["Formula2CalificativoCentacId"]);
                        formula2CalificativoCentacDTO.DescFormula2CalificativoCentac = dr["DescFormula2CalificativoCentac"].ToString();
                        formula2CalificativoCentacDTO.CodigoFormula2CalificativoCentac = dr["CodigoFormula2CalificativoCentac"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return formula2CalificativoCentacDTO;
        }

        public string ActualizarFormula2CalificativoCentac(Formula2CalificativoCentacDTO formula2CalificativoCentacDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_Formula2CalificativoCentacActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formula2CalificativoCentacId", SqlDbType.Int);
                    cmd.Parameters["@Formula2CalificativoCentacId"].Value = formula2CalificativoCentacDTO.Formula2CalificativoCentacId;

                    cmd.Parameters.Add("@DescFormula2CalificativoCentac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFormula2CalificativoCentac"].Value = formula2CalificativoCentacDTO.DescFormula2CalificativoCentac;

                    cmd.Parameters.Add("@CodigoFormula2CalificativoCentac", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoFormula2CalificativoCentac"].Value = formula2CalificativoCentacDTO.CodigoFormula2CalificativoCentac;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formula2CalificativoCentacDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormula2CalificativoCentac(Formula2CalificativoCentacDTO formula2CalificativoCentacDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_Formula2CalificativoCentacEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formula2CalificativoCentacId", SqlDbType.Int);
                    cmd.Parameters["@Formula2CalificativoCentacId"].Value = formula2CalificativoCentacDTO.Formula2CalificativoCentacId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = formula2CalificativoCentacDTO.UsuarioIngresoRegistro;

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
