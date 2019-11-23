using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLWEB
{
    public partial class frmQLND : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLW");
            var collection = db.GetCollection<LND>("NguoiDoc");
            var query = collection.AsQueryable<LND>().ToList();
            dataGridView1.DataSource = query;
        }
        public frmQLND()
        {
            InitializeComponent();
        }

        private void frmQLND_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLW");
            var collection = db.GetCollection<LND>("NguoiDoc");

            LND l = new LND();
            l.tenND = txtTenND.Text;
            collection.InsertOne(l);
            LoadData();
            txtTenND.Text = "";
        }
    }

    public class LND
    {
        public ObjectId id { get; set; }
        public string tenND { get; set; }
    }
}
