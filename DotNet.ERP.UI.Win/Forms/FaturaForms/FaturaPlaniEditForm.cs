using System;
using System.Linq;
using System.Windows.Forms;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DevExpress.XtraBars;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.FaturaForms
{
    public partial class FaturaPlaniEditForm : BaseEditForm
    {
        public FaturaPlaniEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            BaseKartTuru = KartTuru.Fatura;
            EventsLoad();

            HideItems = new BarItem[] { btnYeni };
            btnSil.Caption = "İptal Et";
        }

  

        public override void Yukle()
        {
            TabloYukle();

            using (var bll = new HizmetBilgileriBll())
            {

                var list = bll.FaturaPlaniList(x => x.TahakkukId == Id).ToList();

                txtOgrenciNo.Text = list[0].OkulNo;
                txtAdi.Text = list[0].Adi;
                txtSoyadi.Text = list[0].Soyadi;
                txtSinif.Text = list[0].SinifAdi;
                txtVeliAdi.Text = list[0].VeliAdi;
                txtVeliSoyadi.Text = list[0].VeliSoyadi;
                txtYakinlik.Text = list[0].VeliYakinlikAdi;
                txtMeslek.Text = list[0].VeliMeslekAdi;

                tablo.GridControl.DataSource = list;
                
            }
        }

        protected internal override void ButonEnabledDurumu()
        {

            Functions.GeneralFunctions.ButtonEnabledDurumu(btnKaydet,btnGerial,faturaPlaniTable.TableValueChanged);
        }

        protected override void TabloYukle()
        {
            faturaPlaniTable.OwnerForm = this;
            faturaPlaniTable.Yukle();
            
        }

        protected override bool EntityInsert()
        {
            return faturaPlaniTable.Kaydet();
        }

        protected override bool EntityUpdate()
        {
            return faturaPlaniTable.Kaydet();
        }

        protected override void EntityDelete()
        {
            if (Messages.HayirSeciliEvetHayir("Fatura Planı İptal Edilecek.Onaylıyor Musunuz?", "İptal Onay") != DialogResult.Yes) return;

            var source = faturaPlaniTable.Tablo.DataController.ListSource.Cast<FaturaPlaniL>()
                .Where(x => x.TahakkukTarih == null).ToList();
            if (source.Count == 0) return;
            
            source.ForEach(x => x.Delete = true);
            faturaPlaniTable.Tablo.RefleshDataSource();
            faturaPlaniTable.TableValueChanged = true;
            ButonEnabledDurumu();
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            faturaPlaniTable.Tablo.Focus();
        }
    }
}