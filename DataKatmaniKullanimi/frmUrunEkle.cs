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
    public partial class frmUrunEkle : Form
    {
        int kategori;

        public frmUrunEkle(int CategoryId)
        {
            InitializeComponent();
            kategori = CategoryId;
        }
        
        private void frmUrunEkle_Load(object sender, EventArgs e)
        {

        }

        DataAccessLayer data = new DataAccessLayer();

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //4 parametre

            List<Parametreler> liste = new List<Parametreler>();

            liste.Add(new Parametreler { Name = "@ad", Value = txtName.Text });
            liste.Add(new Parametreler { Name = "@fiyat", Value = data.ToCurrencyDB(txtFiyat.Text)});
            liste.Add(new Parametreler { Name = "@stok", Value = txtStok.Text });
            liste.Add(new Parametreler { Name = "@kategori", Value = kategori });


            data.RunASqlStatement("insert Products (ProductName,UnitsInStock, UnitPrice,CategoryID) values(@ad,@stok,@fiyat,@kategori)", liste);
            txtName.Clear();
            txtStok.Clear();
            txtFiyat.Clear();






        }
    }
}
