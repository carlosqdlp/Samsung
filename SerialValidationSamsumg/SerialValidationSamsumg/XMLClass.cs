using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Librerias para XML
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;

namespace SerialValidationSamsumg
{
    class XMLClass
    {

        public static string _host, _user, _pass;

        public void CrearXml()
        {
            try
            {
                //1.-Creamos un nuevo objeto llamado myFileXml
                System.Xml.Linq.XDocument myFileXml = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),//Cabecera del archivo xml
                    new XComment("Data para conectarse al servidor SQL"),//Comentario
                    new XElement("Datos",
                        new XElement("conexion",
                            new XElement("servidor",
                                new XElement("name", "GCC"),
                                new XElement("host", "192.168.1.58"),
                                new XElement("user", "scpinc"),
                                new XElement("pass", "SCP1nc@dmin")
                                )//fin de <servidor>
                            )//Fin de <conexion>
                        )//Fin de <Datos>
                    );//Fin del objeto
                myFileXml.Save(@"datosConexion.xml");//guardando el archivo.
            }
            catch (Exception msgError)
            {
                MessageBox.Show(msgError.ToString());
            }
        }//Fin Crear


        public void CargarXml()
        {

            try
            {
                //1.-Declaramos un nuevo objetoXml llamado xmlConexion para cargar el archivo xml
                XElement xmlConexion = XElement.Load("datosConexion.xml");
                //2.-Declaramos una variable string para guardar el contenido del xml
                string xml = xmlConexion.ToString();
                //MessageBox.Show(xml);
                //3.-Construimos la query que nos devolvera la estructura del xml
                XElement query = (from item in xmlConexion.XPathSelectElements("./conexion/servidor")
                                  where item.Element("name").Value == "GCC"
                                  select item).FirstOrDefault();
                //4.-Pasamos el valor de cada elemento encontrado a una variable
                _host = Convert.ToString(query.Element("host").Value);
                _user = Convert.ToString(query.Element("user").Value);
                _pass = Convert.ToString(query.Element("pass").Value);


            }
            catch (Exception msgError)
            {
                MessageBox.Show(msgError.ToString());

            }
        }//Fin CargarXml

        public void GuardarXml()
        {
            try
            {
                //1.-Creamos un nuevo objeto llamado myFileXml
                //MessageBox.Show(_host +" "+_user+" "+_pass);
                System.Xml.Linq.XDocument myFileXml = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),//Cabecera del archivo xml
                    new XComment("Data para conectarse al servidor SQL"),//Comentario
                    new XElement("Datos",
                        new XElement("conexion",
                            new XElement("servidor",
                                new XElement("name", "GCC"),
                                new XElement("host", _host),
                                new XElement("user", _user),
                                new XElement("pass", _pass)
                                )//fin de <servidor>
                            )//Fin de <conexion>
                        )//Fin de <Datos>
                    );//Fin del objeto
                myFileXml.Save(@"datosConexion.xml");//guardando el archivo.            
            }//fin try
            catch (Exception msgError)
            {
                MessageBox.Show(msgError.ToString());
            }
        }
    }
}
