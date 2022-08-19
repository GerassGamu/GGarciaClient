using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Profesor
    {

        public static ML.Result AddClient(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Instancia a la Conexión generada en el DL
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "ProfesorAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = profesor.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = profesor.ApellidoPaterno;


                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = profesor.ApellidoMaterno;


                        collection[3] = new SqlParameter("@Sueldo", System.Data.SqlDbType.Decimal);
                        collection[3].Value = profesor.Sueldo;



                        cmd.Parameters.AddRange(collection);
                        //Se abre la conexión
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
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
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
        public static ML.Result DeleteClient(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {

                    string query = "ProfesorDelete";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se debe tomar en cuneta que para hacer una modificacion debemos de recuperar el valor del id del usuario para poder hacer el uso de este a la hora de mandar a llamar al metodo update.
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdProfesor", System.Data.SqlDbType.Int);
                        collection[0].Value = profesor.IdProfesor;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
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
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;

        }
        public static ML.Result UpdateClient(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {

                    string query = "ProfesorUpdate";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se debe tomar en cuneta que para hacer una modificacion debemos de recuperar el valor del id del usuario para poder hacer el uso de este a la hora de mandar a llamar al metodo update.

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = profesor.Nombre;


                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = profesor.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = profesor.ApellidoMaterno;

                        collection[3] = new SqlParameter("@Sueldo", System.Data.SqlDbType.Decimal);
                        collection[3].Value = profesor.Sueldo;


                        collection[4] = new SqlParameter("@IdProfesor", System.Data.SqlDbType.Int);
                        collection[4].Value = profesor.IdProfesor;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
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
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;

        }

        public static ML.Result GetAllClient()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProfesorGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Se abre la conexión
                        cmd.Connection.Open();


                        //DataTable se define
                        DataTable ProfesorTable = new DataTable();

                        //Adapter para llenar  el Data Table
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //Se llena
                        da.Fill(ProfesorTable);

                        //inicializador condicion incrementador si es mayor a 0
                        if (ProfesorTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in ProfesorTable.Rows)
                            {
                                ML.Profesor profesor = new ML.Profesor();
                                profesor.IdProfesor = int.Parse(row[0].ToString());
                                profesor.Nombre = row[1].ToString();
                                profesor.ApellidoPaterno = row[2].ToString();
                                profesor.ApellidoMaterno = row[3].ToString();

                                profesor.Sueldo = decimal.Parse(row[4].ToString());

                                result.Objects.Add(profesor);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al momento Consultar un Profesor";
                        }
                        cmd.Connection.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }
        public static ML.Result GetByIdClient(int IdProfesor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProfesorGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdProfesor", SqlDbType.Int);
                        collection[0].Value = IdProfesor;

                        cmd.Parameters.AddRange(collection);


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable ProfesorTable = new DataTable();

                            da.Fill(ProfesorTable);

                            cmd.Connection.Open();

                            if (ProfesorTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                DataRow row = ProfesorTable.Rows[0];

                                ML.Profesor profesor = new ML.Profesor();
                                profesor.IdProfesor = int.Parse(row[0].ToString());
                                profesor.Nombre = row[1].ToString();
                                profesor.ApellidoPaterno = row[2].ToString();
                                profesor.ApellidoMaterno = row[3].ToString();
                                profesor.Sueldo = decimal.Parse(row[4].ToString());


                                result.Object = profesor;  //boxing 

                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros en la tabla Profesor";
                            }


                        }

                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }




    }
}
