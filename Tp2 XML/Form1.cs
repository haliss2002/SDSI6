using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tp2_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Caminho onde o arquivo será salvo, no meu caso será:
            //C:\inetpub\wwwroot\exemplos\exemplo3.xml
            string strFilePath = "C:\Users\Halis\source\repos\Tp XML\xmls\XMLFile.xml“;
            //Esta linha indica que o o arquivo xml sera salvo, diferente dos outros exemplos
            XmlTextWriter xtw = new XmlTextWriter(strFilePath, Encoding.UTF8);
            //A linha abaixo vai identar o código, se não usar isso tudo ficará em uma linha.
            xtw.Formatting = Formatting.Indented;
            //Escreve a declaração do documento <?xml version="1.0" encoding="utf-8"?>
            xtw.WriteStartDocument();
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartDocument();
            xtw.WriteStartElement("turmas");
            xtw.WriteStartElement("turma");
            xtw.WriteAttributeString("nome", textBox1.Text);
            xtw.WriteStartElement("professor");
            xtw.WriteElementString("nome", textBox2.Text);
            xtw.WriteEndElement();
            xtw.WriteStartElement("Materia");
            xtw.WriteElementString("nome", textBox3.Text);            

            xtw.WriteEndElement();
            xtw.WriteEndDocument();
            //libera o XmlTextWriter
            xtw.Flush();
            //fechar o XmlTextWriter
            xtw.Close();
            //Termina aqui
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument documento = new XmlDocument();
            documento.Load("c://" + textBox4.Text);
            XmlNodeReader nos = new XmlNodeReader(documento);
            int endentar = -1;
            while (nos.Read())
            {
                switch (nos.NodeType)
                {
                    case XmlNodeType.Element:
                        endentar++;
                        if (nos.Name == "turma")
                        {
                            textBox1.Text += nos.Name;
                        }
                        else if (nos.Name == "professor")
                        {
                            textBox2.Text = nos.Name;
                        }
                        else if (nos.Name == "materia")
                            textBox3.Text = nos.Name;
                        break;

                }
            }
        }

    }
}
