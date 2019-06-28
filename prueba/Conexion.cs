using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prueba
{
    class Conexion
    {
        #region
        string tablaMesa =          "create table if not exists Mesa(" +
                                    "numero integer," +
                                    "dia int," +
                                    "y int," +
                                    "x int," +
                                    "alto int," +
                                    "ancho int," +
                                    "tag varchar," +
                                    "ocupada boolean," +
                                    "primary key(dia, numero) );"; 

        string tablaPedido =         "create table if not exists Pedido(" +
                                     "numeroPedido int," +
                                     "mesa int," +
                                     "FOREIGN KEY(mesa) REFERENCES mesa(numero));";

        string tablaComida =        "create table if not exists Comida(" +
                                    "id_comida int," +
                                    "nombre varchar," +
                                    "precio float);";

        string tablaPedidoComida =  "create table if not exists Pedido_Comida(" +
                                    "numeroPedido int," +
                                    "id_comida int," +
                                    "cantidad int," +
                                    "primary key(numeroPedido, id_comida)," +
                                    "foreign key(numeroPedido) references pedido(numeroPedido)," +
                                    "foreign key(id_comida) references comida(id_comida))";

        #endregion





        /// <summary>
        /// el objeto que se encarga de manejar la conexion con la base de datos
        /// </summary>
        SQLiteConnection connection;

        /// <summary>
        /// el objeto que se encarga de ejecutar los comandos que le pasemos
        /// </summary>
        SQLiteCommand command;

        /// <summary>
        /// lo utilizamos para adapatar contenido a la tabla
        /// </summary>
        SQLiteDataAdapter dataAdapter;


        /// <summary>
        /// lo usamos para pasarle datos a una tabla
        /// </summary>
        DataSet dataSet;

        /// <summary>
        /// conectamos al objeto connection, ahora ya estamos conectados a la base de datos
        /// </summary>
        private void conectar()
        {

            try
            {
                this.connection = new SQLiteConnection("Data Source = datos.restaurant");
                this.connection.Open();
                this.connection.DefaultTimeout = 1;
                dataSet = new DataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("no pudo realizarse la conexion" + ex);
            }
        }

        /// <summary>
        /// desconectamos al objeto connection, cerramos comunicacion con la base de datos
        /// </summary>
        private void desconectar()
        {
            try
            {
                this.connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("no puso realizarse la desconexion");
            }
        }

        /// <summary>
        /// crea el archivo que va a ser la base de datos y todas las tablas
        /// </summary>
        /// <param name="nombre">nombre del archico. por defecto esta datos.grupoDeTrabajo</param>
        public void crearBaseDeDatos(string nombre = "datos.restaurant")
        {
            if (!File.Exists(nombre))
            {
                SQLiteConnection.CreateFile("datos.restaurant");
            }

            try
            {

                //abrimos coneccion
                conectar();

                //preparamos un objeto que va a ejecutar todo el comando
                command = new SQLiteCommand(tablaMesa + tablaPedido + tablaComida + tablaPedidoComida, this.connection);


                //  
                //ejecutamos el comando
                command.ExecuteNonQuery();

                //desconectamos el objeto
                command.Connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }
            finally
            {
                //cerramos la coneccion
                desconectar();
            }

        }

        /// <summary>
        /// guarda una mesa
        /// </summary>
        /// <param name="control"> mesa </param>
        /// <param name="pestaña"> pestaña del modo edicion </param>
        public void guardarMesa(Item control, int pestaña)
        {
            try
            {
                //buscamos las cosas que nos importan
                int dia = pestaña;
                int numero = nroMesa(dia);
                int y = control.Location.Y;
                int x = control.Location.X;
                int alto = control.Height;
                int ancho = control.Width;
                string tag = control.Tag.ToString();
                bool ocupada = false;
                                
                conectar();

                string sql = "insert into mesa(numero, dia, y, x, alto, ancho, tag, ocupada) values" +
                         "(" + numero + "," + dia + "," + y + "," + x + "," + alto + "," + ancho + ",'" + tag + "','" + ocupada + "')";
              
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                command.Connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }
            finally
            {
                desconectar();
            }
        }

        //devuelve el numero de mesas dentro de un dia/modo edicion
        private int nroMesa(int dia)
        {
            conectar();
            string sql = "SELECT max(numero) FROM Mesa where dia = " + dia + " ORDER BY numero DESC";
            //SELECT max(numeroidentificador) FROM elementodelplancontables ORDER BY Id DESC;
            command = new SQLiteCommand(sql, connection);

            SQLiteDataReader lector = command.ExecuteReader();
            try
            {
                if (lector.Read())
                {
                    int numero = lector.GetInt32(0) + 1;
                    lector.Close();
                    command.Connection.Close();                    
                    desconectar();
                    return numero;
                }
                else return 1;

            }
            catch (Exception)
            {
                lector.Close();
                command.Connection.Close();
                desconectar();
                return 1;

            }

        }

    }
}
