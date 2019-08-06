using System;
using System.Collections.Generic;
using Conexion;
using System.Data.SqlClient;
using System.Data;
using EjemploConexionDll.Models.Dto;
using System.Configuration;

namespace EjemploConexionDll.Models.Dao
{
    public class ContactosDao
    {
        SqlConnection a;
        public void Conectar()
        {
            ConexionSql con = new ConexionSql();
            a = con.GetConnection();
        }
        public IEnumerable<ContactosDto> GetAllContactos()
        {
            Conectar();
            List<ContactosDto> listContacto = new List<ContactosDto>();
            SqlCommand com = new SqlCommand("spGetAllContactos", a);
            com.CommandType = CommandType.StoredProcedure;
            a.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                ContactosDto contacto = new ContactosDto();
                contacto.Id = int.Parse(rdr["Id"].ToString());
                contacto.Nombre = rdr["Nombre"].ToString();
                contacto.TipoContacto = rdr["TipoContacto"].ToString();
                contacto.Telfijo = rdr["TelFijo"].ToString();
                contacto.Telmovil = rdr["TelMovil"].ToString();
                contacto.FechaNac = DateTime.Parse(rdr["FechaNacimiento"].ToString());
                contacto.Sexo = rdr["Sexo"].ToString();
                contacto.EstadoCivil = rdr["EstadoCivil"].ToString();
                listContacto.Add(contacto);
            }
            a.Close();
            return listContacto;
        }

        public void AddContactos(ContactosDto contacto)
        {
            Conectar();
            SqlCommand com = new SqlCommand("SpAddContacto", a);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            com.Parameters.AddWithValue("@TipoContacto", contacto.TipoContacto);
            com.Parameters.AddWithValue("@TelFijo", contacto.Telfijo);
            com.Parameters.AddWithValue("@TelMovil", contacto.Telmovil);
            com.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNac);
            com.Parameters.AddWithValue("@Sexo", contacto.Sexo);
            com.Parameters.AddWithValue("@EstadoCivil", contacto.EstadoCivil);
            a.Open();
            com.ExecuteNonQuery();
            a.Close();
        }
        public void UpdateContactos(ContactosDto contacto)
        {
            Conectar();
            SqlCommand com = new SqlCommand("SpUpdateContactosAlma", a);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", contacto.Id);
            com.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            com.Parameters.AddWithValue("@TipoContacto", contacto.TipoContacto);
            com.Parameters.AddWithValue("@TelFijo", contacto.Telfijo);
            com.Parameters.AddWithValue("@TelMovil", contacto.Telmovil);
            com.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNac);
            com.Parameters.AddWithValue("@Sexo", contacto.Sexo);
            com.Parameters.AddWithValue("@EstadoCivil", contacto.EstadoCivil);
            a.Open();
            com.ExecuteNonQuery();
            a.Close();
        }
        public ContactosDto GetContactoData(int? id)
        {
            ContactosDto contacto = new ContactosDto();
            Conectar();
            SqlCommand com = new SqlCommand("select * from ContactosMaviAlma where id=" + id, a);
            a.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                contacto.Id = int.Parse(rdr["Id"].ToString());
                contacto.Nombre = rdr["Nombre"].ToString();
                contacto.TipoContacto = rdr["TipoContacto"].ToString();
                contacto.Telfijo = rdr["TelFijo"].ToString();
                contacto.Telmovil = rdr["TelMovil"].ToString();
                contacto.FechaNac = Convert.ToDateTime(rdr["fechaNacimiento"].ToString());
                contacto.Sexo = rdr["Sexo"].ToString();
                contacto.EstadoCivil = rdr["EstadoCivil"].ToString();
            }
            return contacto;
        }
        public void DeleteContactos(int ? id)
        {
            Conectar();
            SqlCommand com = new SqlCommand("SpDeleteContactos", a);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            a.Open();
            com.ExecuteNonQuery();
            a.Close();
        }
    }
}