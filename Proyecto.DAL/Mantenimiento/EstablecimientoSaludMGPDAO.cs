using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EstablecimientoSaludMGPDAO
    {

        SqlCommand cmd = new();

        public List<EstablecimientoSaludMGPDTO> ObtenerEstablecimientoSaludMGPs()
        {
            List<EstablecimientoSaludMGPDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EstablecimientoSaludMGPListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EstablecimientoSaludMGPDTO()
                        {
                            EstablecimientoSaludMGPId = Convert.ToInt32(dr["EstablecimientoSaludMGPId"]),
                            CodigoEstablecimientoRENAES = dr["CodigoEstablecimientoRENAES"].ToString(),
                            CodigoRenaesMindef = dr["CodigoRenaesMindef"].ToString(),
                            DescEntidadMilitar = dr["DescEntidadMilitar"].ToString(),
                            DescEstablecimientoSalud = dr["DescEstablecimientoSalud"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEstablecimientoSaludMGP(EstablecimientoSaludMGPDTO establecimientoSaludMGPDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstablecimientoSaludMGPRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEstablecimientoRENAES", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoRENAES"].Value = establecimientoSaludMGPDTO.CodigoEstablecimientoRENAES;

                    cmd.Parameters.Add("@CodigoRenaesMindef", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRenaesMindef"].Value = establecimientoSaludMGPDTO.CodigoRenaesMindef;

                    cmd.Parameters.Add("@EntidadMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EntidadMilitarId"].Value = establecimientoSaludMGPDTO.EntidadMilitarId;

                    cmd.Parameters.Add("@DescEstablecimientoSalud", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescEstablecimientoSalud"].Value = establecimientoSaludMGPDTO.DescEstablecimientoSalud;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = establecimientoSaludMGPDTO.UsuarioIngresoRegistro;

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

        public EstablecimientoSaludMGPDTO BuscarEstablecimientoSaludMGPID(int Codigo)
        {
            EstablecimientoSaludMGPDTO establecimientoSaludMGPDTO = new EstablecimientoSaludMGPDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstablecimientoSaludMGPEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstablecimientoSaludMGPId", SqlDbType.Int);
                    cmd.Parameters["@EstablecimientoSaludMGPId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        establecimientoSaludMGPDTO.EstablecimientoSaludMGPId = Convert.ToInt32(dr["EstablecimientoSaludMGPId"]);
                        establecimientoSaludMGPDTO.CodigoEstablecimientoRENAES = dr["CodigoEstablecimientoRENAES"].ToString();
                        establecimientoSaludMGPDTO.CodigoRenaesMindef = dr["CodigoRenaesMindef"].ToString();
                        establecimientoSaludMGPDTO.EntidadMilitarId = Convert.ToInt32(dr["EntidadMilitarId"]);
                        establecimientoSaludMGPDTO.DescEstablecimientoSalud = dr["DescEstablecimientoSalud"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return establecimientoSaludMGPDTO;
        }

        public string ActualizarEstablecimientoSaludMGP(EstablecimientoSaludMGPDTO establecimientoSaludMGPDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EstablecimientoSaludMGPActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstablecimientoSaludMGPId", SqlDbType.Int);
                    cmd.Parameters["@EstablecimientoSaludMGPId"].Value = establecimientoSaludMGPDTO.EstablecimientoSaludMGPId;

                    cmd.Parameters.Add("@CodigoEstablecimientoRENAES", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEstablecimientoRENAES"].Value = establecimientoSaludMGPDTO.CodigoEstablecimientoRENAES;

                    cmd.Parameters.Add("@CodigoRenaesMindef", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoRenaesMindef"].Value = establecimientoSaludMGPDTO.CodigoRenaesMindef;

                    cmd.Parameters.Add("@EntidadMilitarId", SqlDbType.Int);
                    cmd.Parameters["@EntidadMilitarId"].Value = establecimientoSaludMGPDTO.EntidadMilitarId;

                    cmd.Parameters.Add("@DescEstablecimientoSalud", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescEstablecimientoSalud"].Value = establecimientoSaludMGPDTO.DescEstablecimientoSalud;
                    
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = establecimientoSaludMGPDTO.UsuarioIngresoRegistro;

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

        public string EliminarEstablecimientoSaludMGP(EstablecimientoSaludMGPDTO establecimientoSaludMGPDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EstablecimientoSaludMGPEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EstablecimientoSaludMGPId", SqlDbType.Int);
                    cmd.Parameters["@EstablecimientoSaludMGPId"].Value = establecimientoSaludMGPDTO.EstablecimientoSaludMGPId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = establecimientoSaludMGPDTO.UsuarioIngresoRegistro;

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
