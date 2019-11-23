using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using System;
using System.Collections;
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
    public partial class frmQLBV : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLW");
            var collection = db.GetCollection<LBV>("BaiViet");
            var query = collection.AsQueryable().ToList();
            var users = collection.Find(new BsonDocument()).ToList();

            var documents = collection.Find(new BsonDocument()).ToList();
            //lstProduct.Items.Clear();
            foreach (BsonDocument document in documents)
            {
                string ma = document["Ma"].AsString;
                string ten = document["Ten"].AsString;
                double gia = document["DonGia"].AsDouble;
                lstProduct.Items.Add(documents);
            }

            dataGridView1.DataSource = users;

        }

        public frmQLBV()
        {
            InitializeComponent();
        }

        private void frmQLBV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QLW");
            var collection = db.GetCollection<LBV>("BaiViet");

            LBV l = new LBV();
            l.tenBV = txtTenBV.Text;
            l.urlAnh = txturlAnh.Text;
            l.tomTat = txtTomtat.Text;
            l.noiDung = txtNoidung.Text;
            l.ngayTao = dtpNgaytao.Value;
            //l.tacGia.id = txtIDTG.Text;
            //l.tacGia.tenTG = txtTenTG.Text;
            //l.tacGia.soBaiViet =int.Parse(txtsoBaiViet.Text);
            l.tacGia = new TG("01", "Nguyen Thi A", 2);
            //l.chuyenMuc.id = txtIDCM.Text;
            //l.chuyenMuc.tenCM = txtTenCM.Text;
            l.chuyenMuc = new CM("01", "Hoc tap");
            l.luotXem = 5;


            //l.nguoiDoc.Add(new ND("Ms01", "Nguyen Van A"));
            collection.InsertOne(l);
            LoadData();
            txtTenND.Text = "";
        }
    }

    public class LBV
    {
        public ObjectId id { get; set; }
        public string tenBV { get; set; }
        public string urlAnh { get; set; }
        public string tomTat { get; set; }
        public string noiDung { get; set; }
        public DateTime ngayTao { get; set; }
        public TG tacGia { get; set; }
        public CM chuyenMuc { get; set; }
        public int luotXem { get; set; }
        public ArrayList nguoiDoc { get; set; }

    }
    public class CM
    {
        public CM()
        {

        }
        public CM(string id, string tenCM)
        {
            this.id = id;
            this.tenCM = tenCM;
        }
        public string id { get; set; }
        public string tenCM { get; set; }
    }
    public class TG
    {
        public TG()
        {

        }
        public TG(string id, string tenTG, int soBaiViet)
        {
            this.id = id;
            this.tenTG = tenTG;
            this.soBaiViet = soBaiViet;
        }
        public string id { get; set; }
        public string tenTG { get; set; }
        public int soBaiViet { get; set; }
    }
    public class ND
    {

        public ND() { }
        public ND(string id, string tenND)
        {
            this.id = id;
            this.tenND = tenND;
        }

        public string id{ get; set; }
        public string tenND { get; set; }
    }

}
