using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;


                        //agregar parametros 
                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("@NombreLibro", SqlDbType.VarChar);
                        collection[0].Value = libro.NombreLibro;

                        collection[1] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("@NumeroPaginas", System.Data.SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.VarChar);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        //pasarle a mi command los parametros
                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //ejecutando nuestra sentencia
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string querySP = "LibroGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = querySP; 
                        cmd.CommandType = CommandType.StoredProcedure;
                        contex.Open();

                        DataTable LibroTable = new DataTable(); 
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); 
                     
                        sqlDataAdapter.Fill(LibroTable);

                        if (LibroTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in LibroTable.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.NombreLibro = row[1].ToString();

                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[2].ToString());
                                libro.Autor.NombreAutor = row[3].ToString();

                                libro.NumeroPaginas = int.Parse(row[4].ToString());
                                libro.FechaPublicacion = row[5].ToString();

                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[6].ToString());
                                libro.Editorial.NombreEditorial = row[7].ToString();

                                libro.Edicion = row[8].ToString();

                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.NombreGenero = row[10].ToString();


                                result.Objects.Add(libro);//Agrega todos los datos a usuario


                            }
                        }
                    }
                }
                result.Correct = true;
            }// cierre de try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }


    }
}
