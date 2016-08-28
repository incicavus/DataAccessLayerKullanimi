using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataKatmani;

namespace DataKatmaniKullanimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataAccessLayer data = new DataAccessLayer();


        private void Form1_Load(object sender, EventArgs e)
        {
            cbKategori.DisplayMember = "CategoryName";
            cbKategori.ValueMember = "CategoryID";

            cbKategori.DataSource = data.GetDataTable("select * from Categories");

            gvUrun.DataSource = null;//cbKategori verikaynağına sahip olunca gv de veri ile dolmuş olur.

            cbKategori.SelectedIndex = -1;
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            List<Parametreler> liste = new List<Parametreler>();

            //Parametreler p=new Parametreler { Name="@ad", Value=txtAd.Text};
            //liste.Add(p);


            liste.Add(new Parametreler { Name = "@ad", Value = txtAd.Text });
            liste.Add(new Parametreler { Name = "@aciklama", Value = txtAciklama.Text });

            data.RunASqlStatement("insert Categories (CategoryName,Description) values(@ad,@aciklama)", liste);

            Form1_Load(sender, e);

            txtAd.Clear();
            txtAciklama.Clear();

        }   

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmUrunEkle frm = new frmUrunEkle((int)cbKategori.SelectedValue);//CategoryID bilgisini taşıyan bir ürün ekleme formunu açmış oluyoruz.
            frm.ShowDialog();
        }

        private void cbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Parametreler> liste = new List<Parametreler>();
            liste.Add(new Parametreler { Name = "@id", Value = cbKategori.SelectedValue });
            gvUrun.DataSource = data.GetDataTable("select * from Products where CategoryID=@id",liste);


        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            List<Parametreler> liste = new List<Parametreler>();
            liste.Add(new Parametreler { Name = "@min", Value = txtMin.Text });
            liste.Add(new Parametreler { Name = "@max", Value = txtMax.Text });
            //liste.Add(new Parametreler { Name = "@id", Value = cbKategori.SelectedValue });//id den bağımsız yapıyoruz.
            gvUrun.DataSource=data.GetDataTable("select * from Products where UnitPrice between @min and @max  ", liste);

           
        }

       



    }
}
