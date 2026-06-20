using System;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.GenelForms;
using DevExpress.XtraEditors;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.Forms.SinifForms
{
    public partial class SinifEditForm : BaseEditForm
    {
        public SinifEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new SinifBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Sinif;
            EventsLoad();
        }
        
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new SinifS() : ((SinifBll)Bll).Single(Functions.FilterFunctions.Filter<Sinif>(Id));
            NesneyiKontrollereBagla();
            
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((SinifBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId);
            txtSinifAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (SinifS) OldEntity;

            txtKod.Text = entity.Kod;
            txtSinifAdi.Text = entity.SinifAdi;
            txtGrup.Id = entity.GrupId;
            txtGrup.Text = entity.GrupAdi;
            txtHedefOgrenciSayisi.Value = entity.HedefOgrenciSayisi;
            txtHedefCiro.Value = entity.HedefCiro;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Sinif
            {
                Id = Id,
                Kod = txtKod.Text,
                SinifAdi = txtSinifAdi.Text,
                GrupId = Convert.ToInt64(txtGrup.Id),
                HedefOgrenciSayisi = (int)txtHedefOgrenciSayisi.Value,
                HedefCiro = txtHedefCiro.Value,
                Aciklama = txtAciklama.Text,
                SubeId = AnaForm.SubeId,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((SinifBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId);
        }
        protected override bool EntityUpdate()
        {
            return ((SinifBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId);
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new Functions.SelectFunctions())
                if(sender == txtGrup)
                    sec.Sec(txtGrup);
        }


    }
}