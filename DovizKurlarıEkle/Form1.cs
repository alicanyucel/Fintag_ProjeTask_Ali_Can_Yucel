using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace DovizKurlarıEkle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest wrq = (HttpWebRequest)HttpWebRequest.Create("http://www.tcmb.gov.tr/kurlar/today.xml");
            HttpWebResponse rsp = (HttpWebResponse)wrq.GetResponse();
            Stream sr = rsp.GetResponseStream();
            XmlTextReader xtr = new XmlTextReader(sr);
            DataSet ds = new DataSet();
            ds.ReadXml(xtr);
            grdKurListesi.DataSource = ds.Tables[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ROTCU0Q;Initial Catalog=FintagDB;Integrated Security=true");
            for (int i = 0;i<=grdKurListesi.Rows.Count; i++)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Fiyatlar(KurTipi,KurSatis,KurAlis,KurTarihi)values(@KurTipi,@KurSatis,@KurAlis,@KurTarihi)", con);
                    cmd.Parameters.AddWithValue("@KurTipi", grdKurListesi.Rows[i].Cells["Kod"].Value.ToString());
                    cmd.Parameters.AddWithValue("@KurSatis", grdKurListesi.Rows[i].Cells["BanknoteSelling"].Value.ToString() == "" ? 0.00 : grdKurListesi.Rows[i].Cells["BanknoteSelling"].Value);
                    cmd.Parameters.AddWithValue("@KurAlis", grdKurListesi.Rows[i].Cells["BanknoteBuying"].Value.ToString() == "" ? 0.00 : grdKurListesi.Rows[i].Cells["BanknoteBuying"].Value);
                    cmd.Parameters.AddWithValue("@KurTarihi", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString()); 
                }
               
               

            }
            MessageBox.Show("Kurlar cekiliyor");
            con.Close();
        }
    }
}
