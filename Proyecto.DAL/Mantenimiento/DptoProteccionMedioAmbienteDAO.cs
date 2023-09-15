using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DptoProteccionMedioAmbienteDAO
    {

        SqlCommand cmd = new();

        public List<DptoProteccionMedioAmbienteDTO> ObtenerDptoProteccionMedioAmbientes()
        {
            List<DptoProteccionMedioAmbienteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DptoProteccionMedioAmbienteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DptoProteccionMedioAmbienteDTO()
                        {
                            DptoProteccionMedioAmbienteId = Convert.ToInt32(dr["DptoProteccionMedioAmbienteId"]),
                            DescDptoProteccionMedioAmbiente = dr["DescDptoProteccionMedioAmbiente"].ToString(),
                            CodigoDptoProteccionMedioAmbiente = dr["CodigoDptoProteccionMedioAmbiente"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO DptoProteccionMedioAmbienteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoProteccionMedioAmbienteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDptoProteccionMedioAmbiente", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescDptoProteccionMedioAmbiente"].Value = DptoProteccionMedioAmbienteDTO.DescDptoProteccionMedioAmbiente;

                    cmd.Parameters.Add("@CodigoDptoProteccionMedioAmbiente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDptoProteccionMedioAmbiente"].Value = DptoProteccionMedioAmbienteDTO.CodigoDptoProteccionMedioAmbiente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoProteccionMedioAmbienteDTO.UsuarioIngresoRegistro;

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

        public DptoProteccionMedioAmbienteDTO BuscarDptoProteccionMedioAmbienteID(int Codigo)
        {
            DptoProteccionMedioAmbienteDTO DptoProteccionMedioAmbienteDTO = new DptoProteccionMedioAmbienteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoProteccionMedioAmbienteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoProteccionMedioAmbienteId", SqlDbType.Int);
                    cmd.Parameters["@DptoProteccionMedioAmbienteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        DptoProteccionMedioAmbienteDTO.DptoProteccionMedioAmbienteId = Convert.ToInt32(dr["DptoProteccionMedioAmbienteId"]);
                        DptoProteccionMedioAmbienteDTO.DescDptoProteccionMedioAmbiente = dr["DescDptoProteccionMedioAmbiente"].ToString();
                        DptoProteccionMedioAmbienteDTO.CodigoDptoProteccionMedioAmbiente = dr["CodigoDptoProteccionMedioAmbiente"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return DptoProteccionMedioAmbienteDTO;
        }

        public string ActualizarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO DptoProteccionMedioAmbienteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoProteccionMedioAmbienteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoProteccionMedioAmbienteId", SqlDbType.Int);
                    cmd.Parameters["@DptoProteccionMedioAmbienteId"].Value = DptoProteccionMedioAmbienteDTO.DptoProteccionMedioAmbienteId;

                    cmd.Parameters.Add("@DescDptoProteccionMedioAmbiente", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescDptoProteccionMedioAmbiente"].Value = DptoProteccionMedioAmbienteDTO.DescDptoProteccionMedioAmbiente;

                    cmd.Parameters.Add("@CodigoDptoProteccionMedioAmbiente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDptoProteccionMedioAmbiente"].Value = DptoProteccionMedioAmbienteDTO.CodigoDptoProteccionMedioAmbiente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoProteccionMedioAmbienteDTO.UsuarioIngresoRegistro;

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

        public string EliminarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO DptoProteccionMedioAmbienteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoProteccionMedioAmbienteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoProteccionMedioAmbienteId", SqlDbType.Int);
                    cmd.Parameters["@DptoProteccionMedioAmbienteId"].Value = DptoProteccionMedioAmbienteDTO.DptoProteccionMedioAmbienteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoProteccionMedioAmbienteDTO.UsuarioIngresoRegistro;

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
