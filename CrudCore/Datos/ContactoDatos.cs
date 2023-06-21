using CrudCore.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace CrudCore.Datos
{
    //obtenemos todos los contactos registrados
    public class ContactoDatos
    {

        public List<ContactoModel> Listar()
        {

            var oListar = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oListar.Add(new ContactoModel
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oListar;
        }

        //Obtener un Id por el contacto
        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel contacto)
        {

            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", contacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
                throw;
            }

            return rpta;
        }


        public bool Editar(ContactoModel contacto)
        {

            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", contacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", contacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
                throw;
            }

            return rpta;
        }


        public bool Eliminar(int idContacto)
        {

            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Elimina", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", idContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
                throw;
            }

            return rpta;
        }



    }







}
