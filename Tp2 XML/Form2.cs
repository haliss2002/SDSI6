using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Tp2_XML
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            voo v2 = new voo();
            string entrada;
            using (StreamReader lido = new StreamReader("C:\Users\Halis\source\repos\Tp XML\xmls\XMLFILE1.json"))
            {
                entrada = lido.ReadLine();
            }
            v2 = JsonConvert.DeserializeObject<voo>(entrada);
            foreach (var obj in jsonObj.objectList)
            {
                comboBox1.Items.Add(v2.codigo);
                dataGridView1.Columns.Add("codigo", v2.codigio);
                dataGridView1.Columns.Add("origem", v2.origem);
                dataGridView1.Columns.Add("destino", v2.destino);
                dataGridView1.Columns.Add("horario", v2.horario);
                dataGridView1.Columns.Add("compania", v2.compania);
                dataGridView1.Columns.Add("operando", v2.operando);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            voo v1 = new voo();
            v1.codigo = comboBox1.Text ;
            v1.compania = dataGridView1.Rows(i).Cells(0) ;
            v1.destino = dataGridView1.Rows(i).Cells(0);
            v1.origem = dataGridView1.Rows(i).Cells(0);
            v1.horario = dataGridView1.Rows(i).Cells(0);
            v1.operando = dataGridView1.Rows(i).Cells(0);
            string saida;
            saida = JsonConvert.SerializeObject(v1);
            Response.Write(saida);

        }
    }
}
