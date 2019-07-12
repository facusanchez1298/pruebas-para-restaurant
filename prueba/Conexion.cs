using prueba.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prueba
{
    class Conexion
    {

        #region tablas

        string tablaMesa = "create table if not exists Mesa(" +
                                    "numero integer," +
                                    "dia int," +
                                    "y int," +
                                    "x int," +
                                    "alto int," +
                                    "ancho int," +
                                    "tag varchar," +
                                    "ocupada boolean," +
                                    "llegada varchar default ''," +
                                    "primary key(dia, numero) );";

        

        string tablaPedido = "create table if not exists Pedido(" +
                                     "numeroPedido int," +
                                     "mesa int," +
                                     "FOREIGN KEY(mesa) REFERENCES mesa(numero));";



        string tablaComida = "create table if not exists Comida(" +
                                    "id_comida int," +
                                    "nombre varchar," +
                                    "vegetariano boolean," +
                                    "sinTacc boolean," +
                                    "precio float);";



        string tablaPedidoComida = "create table if not exists Pedido_Comida(" +
                                    "numeroPedido int," +
                                    "id_comida int," +
                                    "cantidad int," +
                                    "primary key(numeroPedido, id_comida)," +
                                    "foreign key(numeroPedido) references pedido(numeroPedido)," +
                                    "foreign key(id_comida) references comida(id_comida));";

        string tablaMozo = "create table if not exists Mozo(" +
                                    "nombre varchar," +
                                    "id integer primary key," +
                                    "mañana boolean," +
                                    "tarde boolean, " +
                                    "noche boolean);";






        #endregion

        #region propiedades
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

        #endregion

        #region conectar, desconectar y crear

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
                command = new SQLiteCommand(tablaMesa + tablaPedido + tablaComida + tablaPedidoComida + tablaMozo, this.connection);


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



        #endregion

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

        /// <summary>
        /// carga las mesas en un form
        /// </summary>
        /// <param name="ver"></param>
        /// <param name="plantilla"></param>
        internal void cargarMesas(Ver ver, int plantilla)
        {



            conectar();
            String consulta = "select * from mesa where dia = " + plantilla;


            SQLiteCommand command = new SQLiteCommand(consulta, connection);


            try
            {
                SQLiteDataReader lector = command.ExecuteReader();

                while (lector.Read())
                {

                    int numero = lector.GetInt32(0);
                    int dia = lector.GetInt32(1);
                    int y = lector.GetInt32(2);
                    int x = lector.GetInt32(3);
                    int alto = lector.GetInt32(4);
                    int ancho = lector.GetInt32(5);
                    string tag = lector.GetString(6);
                    bool ocupado = bool.Parse(lector.GetString(7));

                    DateTime dateTime;

                    if (!lector.GetString(8).Equals(""))
                    {
                        dateTime = DateTime.Parse(lector.GetString(8));
                    }
                    else dateTime = new DateTime();

                    Item item = new Item();
                    item.darIndex(numero);
                    item.Llegada = dateTime;
                    item.Location = new Point(x, y);
                    item.Size = new Size(ancho, alto);
                    item.Tag = tag;
                    item.estaOcupado(ocupado);
                    item.BackColor = SystemColors.ActiveCaption;
                    item.Show();



                    switch (tag)
                    {
                        case "Mesa Grande":
                            item.Image = Resources.mesa_grande_negra_recorte;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;

                            break;

                        case "Mesita":
                            item.Image = Resources.mesita_redonda;
                            item.SizeMode = PictureBoxSizeMode.Zoom;

                            break;

                        case "Tabla Cocina":
                            item.Image = Resources.tabla_grande;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;

                            break;

                        case "Tabla Bar":
                            item.Image = Resources.tabla_bar;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;
                            break;

                        case "Mesa Redonda":
                            item.Image = Resources.mesa_redonda_normal;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Mesa Redonda Negra":
                            item.Image = Resources.dining_table; ;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Mesa Redonda Madera":
                            item.Image = Resources.MesaRedondaMadera1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Mesa Cuadrada":
                            item.Image = Resources.mesa_cuadrada;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Mesa cuadrada 4 sillas":
                            item.Image = Resources.mesa_cuadrada_4_sillas1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Mesa Rectangular":
                            item.Image = Resources.MesaCuadrada_grande;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Mesa Redonda 8 sillas":
                            item.Image = Resources.mesa_redonda_8_sillas1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Mesa Redonda 6 sillas":
                            item.Image = Resources.mesa_redonda_6_sillas;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;


                        case "Mesa Redonda 4 sillas":
                            item.Image = Resources.mesa_redonda_4_sillas;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Silla":
                            item.Image = Resources.Silla1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Silla Roja":
                            item.Image = Resources.silla_Roja;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            item.Click += ver.item_DoubleClick;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;

                        case "Pared":
                            item.Image = Resources.pared_roja;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;
                            item.MouseHover += ver.Mouse_hover;
                            item.MouseLeave += ver.Mouse_Leave;
                            break;
                    }


                    //rota la imagen
                    if (item.Height >= item.Width)
                    {
                        item.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    ver.Controls.Add(item);

                    ver.Controls.Add(item);

                }


                ver.plano1.SendToBack();
                lector.Close();
                command.Connection.Close();

            }
            catch (Exception e)
            {
                command.Connection.Close();
                throw new Exception("no se pudo realizar la coneccion: " + e);
            }
            finally
            {
                command.Connection.Close();
            }
        }



        /// <summary>
        /// carga las mesas en un userControl.Editor
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="v"></param>
        internal void cargarMesas(Editor editor, int plantilla)
        {
            conectar();
            String consulta = "select * from mesa where dia = " + plantilla;


            SQLiteCommand command = new SQLiteCommand(consulta, connection);

            try
            {
                SQLiteDataReader lector = command.ExecuteReader();

                while (lector.Read())
                {

                    int numero = lector.GetInt32(0);
                    int dia = lector.GetInt32(1);
                    int y = lector.GetInt32(2);
                    int x = lector.GetInt32(3);
                    int alto = lector.GetInt32(4);
                    int ancho = lector.GetInt32(5);
                    string tag = lector.GetString(6);
                    bool ocupado = bool.Parse(lector.GetString(7));
                    DateTime dateTime;

                    if (!lector.GetString(8).Equals(""))
                    {
                        dateTime = DateTime.Parse(lector.GetString(8));
                    }
                    else dateTime = new DateTime();

                    Item item = new Item();
                    item.darIndex(numero);
                    item.Llegada = dateTime;
                    item.Llegada = dateTime;
                    item.Location = new Point(x, y);
                    item.Size = new Size(ancho, alto);
                    item.Tag = tag;
                    item.estaOcupado(ocupado);
                    item.BackColor = SystemColors.ActiveCaption;
                    item.Show();

                    switch (tag)
                    {
                        case "Mesa Grande":
                            item.Image = Resources.mesa_grande_negra_recorte;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesita":
                            item.Image = Resources.mesita_redonda;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Tabla Cocina":
                            item.Image = Resources.tabla_grande;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;
                            break;

                        case "Tabla Bar":
                            item.Image = Resources.tabla_bar;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;
                            break;

                        case "Mesa Redonda":
                            item.Image = Resources.mesa_redonda_normal;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa Redonda Negra":
                            item.Image = Resources.dining_table;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa Redonda Madera":
                            item.Image = Resources.MesaRedondaMadera1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa Cuadrada":
                            item.Image = Resources.mesa_cuadrada;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa cuadrada 4 sillas":
                            item.Image = Resources.mesa_cuadrada_4_sillas1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa Rectangular":
                            item.Image = Resources.MesaCuadrada_grande;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa Redonda 8 sillas":
                            item.Image = Resources.mesa_redonda_8_sillas1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa Redonda 6 sillas":
                            item.Image = Resources.mesa_redonda_6_sillas;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Mesa Redonda 4 sillas":
                            item.Image = Resources.mesa_redonda_4_sillas;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Silla":
                            item.Image = Resources.Silla1;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Silla Roja":
                            item.Image = Resources.silla_Roja;
                            item.SizeMode = PictureBoxSizeMode.Zoom;
                            break;

                        case "Pared":
                            item.Image = Resources.pared_roja;
                            item.SizeMode = PictureBoxSizeMode.StretchImage;
                            break;
                    }


                    if (item.Height >= item.Width)
                    {
                        item.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    editor.Controls.Add(item);

                }

                lector.Close();
                command.Connection.Close();

            }
            catch (Exception e)
            {
                command.Connection.Close();
                throw new Exception("no se pudo realizar la coneccion: " + e);
            }
            finally
            {
                command.Connection.Close();
            }
        }



        /// <summary>
        /// devuelve el numero de mesas dentro de una plantilla de edicion
        /// </summary>
        /// <param name="plantilla"></param>
        /// <returns></returns>
        private int nroMesa(int plantilla)
        {
            conectar();
            string sql = "SELECT max(numero) FROM Mesa where dia = " + plantilla + " ORDER BY numero DESC";
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

        internal void BorrarMozo(int index)
        {
            try
            {

                conectar();

                string sql = "delete from Mozo where id = " + index;

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

        internal void borrarComida(float id)
        {
            try
            {

                conectar();

                string sql = "delete from comida where id_comida = " + id;

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

        public void borrarMesa(Item seleccionado, int plantilla)
        {
            try
            {

                conectar();

                string sql = "delete from mesa where numero = " + seleccionado.index + " and dia = " + plantilla;

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

        public void cargarTablaMesas(DataGridView dataGridView, int dia)
        {
            try
            {
                conectar();
                string sql = "select numero as 'Mesa', ocupada as 'Ocupada', llegada " +
                    "from mesa " +
                    "where dia = " + dia +
                    " and tag != 'Pared' and " +
                    "tag != 'Tabla Bar' and " +
                    "tag != 'Tabla Cocina' and " +
                    "tag != 'Mesita';";
                dataAdapter = new SQLiteDataAdapter(sql, connection);

                dataSet = new DataSet();
                dataSet.Reset();

                DataTable dt = new DataTable();
                dataAdapter.Fill(dataSet);

                dt = dataSet.Tables[0];

                dataGridView.DataSource = dt;
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

        internal void ocuparMesa(Item item, int plantilla, bool estado)
        {
            try
            {

                conectar();

                string sql = "update mesa set ocupada = '" + estado + "'" +
                    "  where numero = " + item.index + " and dia = " + plantilla;

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

        internal void editarMesa(Item seleccionado, int plantilla)
        {
            try
            {

                conectar();

                string sql = "update mesa set y = " + seleccionado.Location.Y + ", x = " + seleccionado.Location.X + " ," +
                    "alto = " + seleccionado.Height + ", ancho = " + seleccionado.Width +
                    "  where numero = " + seleccionado.index + " and dia = " + plantilla;

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

        internal void EditarIngreso(DateTime now, Item item, int plantilla)
        {
            try
            {

                conectar();

                string sql = "update mesa set llegada = '" + now.ToLongTimeString() +
                    "'  where numero = " + item.index + " and dia = " + plantilla;

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

        internal void guardarSalida(Item item, int plantilla)
        {
            try
            {

                conectar();

                string sql = "update mesa set llegada = ''" +
                    "  where numero = " + item.index + " and dia = " + plantilla;

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

        internal void agregarPedido(Datos padre, int id_comida, int cantidad)
        {
            try
            {
                int Pedido = padre.numeroPedido;
                conectar();

                string sql = "insert into Pedido_Comida values(" + Pedido + ", " + id_comida + ", " + cantidad + ")";

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

        internal DataTable CargarTablaComida()
        {
            try
            {
                conectar();
                string sql = "select * from Comida ";

                dataAdapter = new SQLiteDataAdapter(sql, connection);

                dataSet = new DataSet();
                dataSet.Reset();

                DataTable dt = new DataTable();
                dataAdapter.Fill(dataSet);

                dt = dataSet.Tables[0];


                return dt;
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

        internal object CargarTablaComida(string filtro, bool vegetariano, bool sinTACC)
        {
            try
            {
                conectar();
                string sql;



                if (!vegetariano && !sinTACC) sql = "select * from Comida where nombre like '%" + filtro + "%'";
                else if ((!vegetariano) && (sinTACC)) sql = "select * from Comida where nombre like '%" + filtro + "%' and sinTACC = '" + sinTACC + "'";
                else if ((vegetariano) && (!sinTACC)) sql = "select * from Comida where nombre like '%" + filtro + "%' and vegetariano = '" + vegetariano + "'";
                else sql = "select * from Comida where nombre like '%" + filtro + "%' and vegetariano = '" + vegetariano + "' and sinTACC = '" + sinTACC + "'";

                dataAdapter = new SQLiteDataAdapter(sql, connection);

                dataSet = new DataSet();
                dataSet.Reset();

                DataTable dt = new DataTable();
                dataAdapter.Fill(dataSet);

                dt = dataSet.Tables[0];


                return dt;
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

        internal DataTable CargarTablaComida(string filtro)
        {
            try
            {
                conectar();
                string sql = "select * from Comida where nombre like '%" + filtro + "%'";

                dataAdapter = new SQLiteDataAdapter(sql, connection);

                dataSet = new DataSet();
                dataSet.Reset();

                DataTable dt = new DataTable();
                dataAdapter.Fill(dataSet);

                dt = dataSet.Tables[0];


                return dt;
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

        internal DataTable cargarTablaPedido(int numeroPedido)
        {
            try
            {
                conectar();
                string sql = "select pedido_comida.numeroPedido, pedido_comida.id_comida, comida.nombre, comida.precio, pedido_comida.cantidad from  pedido_comida, comida  " +
                             "where pedido_comida.numeroPedido = " + numeroPedido +
                             " and comida.id_comida = pedido_comida.id_comida";

                dataAdapter = new SQLiteDataAdapter(sql, connection);

                dataSet = new DataSet();
                dataSet.Reset();

                DataTable dt = new DataTable();
                dataAdapter.Fill(dataSet);

                dt.Columns.Add("Total", typeof(float));

                foreach (DataGridViewRow item in dt.Rows)
                {
                    float precio = float.Parse(item.Cells["precio"].Value.ToString());
                    int cantidad = int.Parse(item.Cells["cantidad"].Value.ToString());
                    item.Cells["total"].Value = precio * cantidad;
                }


                dt = dataSet.Tables[0];


                return dt;
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

        internal DataTable cargarTablaMozos(string filtro, bool mañana, bool tarde, bool noche)
        {
            try
            {
                conectar();
                string sql;

                if (!mañana && !tarde && !noche) sql = "select * from Mozo where nombre like '%" + filtro + "%'";
                else sql = "select * from Mozo where nombre like '%" + filtro + "%' and mañana = '" + mañana + "' and tarde = '" + tarde + "' and noche = '" + noche + "'";

                dataAdapter = new SQLiteDataAdapter(sql, connection);

                dataSet = new DataSet();
                dataSet.Reset();

                DataTable dt = new DataTable();
                dataAdapter.Fill(dataSet);

                dt = dataSet.Tables[0];


                return dt;
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

        internal void AgregarComida(string nombre, bool vegetariano, bool sinTACC, float precio)
        {
            try
            {
                conectar();

                string sql = "insert into Comida values(null ,'" + nombre + "','" + vegetariano + "', '" + sinTACC + "', " + precio + ")";

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

        internal void agregarMozo(string filtro, bool estaALaMañana, bool estaALaTarde, bool estaALaNoche)
        {
            try
            {
                conectar();

                string sql = "insert into Mozo values ('" + filtro + "', null, '" + estaALaMañana + "','" + estaALaTarde + "','" + estaALaNoche + "')";

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

        internal object CargarComboBoxMozos()
        {
            try
            {
                conectar();
                string sql = "select * from Mozo";

                dataAdapter = new SQLiteDataAdapter(sql, connection);

                dataSet = new DataSet();
                dataSet.Reset();

                DataTable dt = new DataTable();
                dataAdapter.Fill(dataSet);

                dt = dataSet.Tables[0];
                return dt;
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


    }
}


