using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combasnai
{
    public class AlistCombustibleLubricanteCombasnaiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistCombustibleLubricanteCombasnaiDTO> ObtenerLista()
        {
            List<AlistCombustibleLubricanteCombasnaiDTO> lista = new List<AlistCombustibleLubricanteCombasnaiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombasnaiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistCombustibleLubricanteCombasnaiDTO()
                        {
                            AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Articulo = dr["Articulo"].ToString(),
                            Equipo = dr["Equipo"].ToString(),
                            UnidadMedida = dr["UnidadMedida"].ToString(),
                            Cargo = Convert.ToInt32(dr["Cargo"]),
                            Aumento = Convert.ToInt32(dr["Aumento"]),
                            Consuo = Convert.ToInt32(dr["Consuo"]),
                            Existencia = Convert.ToInt32(dr["Existencia"]),


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombasnaiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                
                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistCombustibleLubricanteCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricante2Id;


                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteCombasnaiDTO.UsuarioIngresoRegistro;

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

        public AlistCombustibleLubricanteCombasnaiDTO BuscarFormato(int Codigo)
        {
            AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO = new AlistCombustibleLubricanteCombasnaiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombasnaiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]);
                        alistCombustibleLubricanteCombasnaiDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricante2Id = Convert.ToInt32(dr["AlistamientoCombustibleLubricante2Id"]);
                        alistCombustibleLubricanteCombasnaiDTO.Articulo = dr["Articulo"].ToString();
                        alistCombustibleLubricanteCombasnaiDTO.Equipo = dr["Equipo"].ToString();
                        alistCombustibleLubricanteCombasnaiDTO.UnidadMedida = dr["UnidadMedida"].ToString();
                        alistCombustibleLubricanteCombasnaiDTO.Cargo = Convert.ToInt32(dr["Cargo"]);
                        alistCombustibleLubricanteCombasnaiDTO.Aumento = Convert.ToInt32(dr["Aumento"]);
                        alistCombustibleLubricanteCombasnaiDTO.Consuo = Convert.ToInt32(dr["Consuo"]);
                        alistCombustibleLubricanteCombasnaiDTO.Existencia = Convert.ToInt32(dr["Existencia"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistCombustibleLubricanteCombasnaiDTO;
        }

        public string ActualizaFormato(AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombasnaiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = alistCombustibleLubricanteCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricante2Id", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricante2Id"].Value = alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricante2Id;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteCombasnaiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombasnaiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteCombasnaiDTO.UsuarioIngresoRegistro;

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
        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteCombasnaiRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistCombustibleLubricanteCombasnaiRegistrar", SqlDbType.Structured);
                    cmd.Parameters["@AlistCombustibleLubricanteCombasnaiRegistrar"].TypeName = "Formato.AlistCombustibleLubricanteCombasnaiRegistrar";
                    cmd.Parameters["@AlistCombustibleLubricanteCombasnaiRegistrar"].Value = datos;

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

