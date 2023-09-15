using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class AlistCombustibleLubricanteComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<AlistCombustibleLubricanteComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<AlistCombustibleLubricanteComzocuatroDTO> lista = new List<AlistCombustibleLubricanteComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistCombustibleLubricanteComzocuatroDTO()
                        {
                            AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Articulo = dr["DescUnidadNaval"].ToString(),
                            Equipo = dr["DescUnidadNaval"].ToString(),
                            DescUnidadMedidad = dr["DescUnidadNaval"].ToString(),
                            Cargo = Convert.ToInt32(dr["Cargo"]),
                            Aumento = Convert.ToInt32(dr["Aumento"]),
                            Consumo = Convert.ToInt32(dr["Consumo"]),
                            Existencia = Convert.ToInt32(dr["Existencia"]),
                            PromedioPonderado = Convert.ToDecimal(dr["PromedioPonderado"]),
                            SubPromedioParcial = Convert.ToDecimal(dr["SubPromedioParcial"]),
                            CargaId = Convert.ToInt32(dr["CargaId"])


                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistCombustibleLubricanteComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante2"].Value = alistCombustibleLubricanteComzocuatroDTO.CodigoAlistamientoCombustibleLubricante2;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistCombustibleLubricanteComzocuatroDTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@UnidadNavSubPromedioParcialalId"].Value = alistCombustibleLubricanteComzocuatroDTO.SubPromedioParcial;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = alistCombustibleLubricanteComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteComzocuatroDTO.UsuarioIngresoRegistro;

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

        public AlistCombustibleLubricanteComzocuatroDTO BuscarFormato(int Codigo)
        {
            AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO = new AlistCombustibleLubricanteComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        alistCombustibleLubricanteComzocuatroDTO.AlistamientoCombustibleLubricanteId = Convert.ToInt32(dr["AlistamientoCombustibleLubricanteId"]);
                        alistCombustibleLubricanteComzocuatroDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        alistCombustibleLubricanteComzocuatroDTO.CodigoAlistamientoCombustibleLubricante2 = dr["CodigoAlistamientoCombustibleLubricante2"].ToString(); 
                        alistCombustibleLubricanteComzocuatroDTO.PromedioPonderado = Convert.ToDecimal(dr["CodigoAlistamientoCombustibleLubricante2"]);
                        alistCombustibleLubricanteComzocuatroDTO.SubPromedioParcial = Convert.ToDecimal(dr["CodigoAlistamientoCombustibleLubricante2"]);


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistCombustibleLubricanteComzocuatroDTO;
        }

        public string ActualizaFormato(AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteComzocuatroDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = alistCombustibleLubricanteComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@CodigoAlistamientoCombustibleLubricante2", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoCombustibleLubricante2"].Value = alistCombustibleLubricanteComzocuatroDTO.CodigoAlistamientoCombustibleLubricante2;

                    cmd.Parameters.Add("@PromedioPonderado", SqlDbType.Decimal);
                    cmd.Parameters["@PromedioPonderado"].Value = alistCombustibleLubricanteComzocuatroDTO.PromedioPonderado;

                    cmd.Parameters.Add("@SubPromedioParcial", SqlDbType.Decimal);
                    cmd.Parameters["@UnidadNavSubPromedioParcialalId"].Value = alistCombustibleLubricanteComzocuatroDTO.SubPromedioParcial;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoCombustibleLubricanteId"].Value = alistCombustibleLubricanteComzocuatroDTO.AlistamientoCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistCombustibleLubricanteComzocuatroDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_AlistCombustibleLubricanteComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistCombustibleLubricanteComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@AlistamientoCombustibleLubricante"].TypeName = "Formato.AlistamientoCombustibleLubricante";
                    cmd.Parameters["@AlistamientoCombustibleLubricante"].Value = datos;

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
