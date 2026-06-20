using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Enums;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.Model.Entities;
using DotNet.ERP.UI.Win.Forms.BaseForms;
using DotNet.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.GenelForms
{
    public partial class KurumBilgileriEditForm : BaseEditForm
    {
        #region Variables
        
        private readonly string _kod;
        private readonly string _kurumAdi;

        #endregion

        public KurumBilgileriEditForm(params object[] prm)
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KurumBilgileriBll(myDataLayoutControl);
            HideItems = new BarItem[] {btnYeni,btnSil };
            BaseKartTuru = KartTuru.Kurum;
            EventsLoad();

            _kod = prm[0].ToString();
            _kurumAdi = prm[1].ToString();
        }
        public override void Yukle()
        {
            OldEntity = ((KurumBilgileriBll)Bll).Single(null) ?? new KurumBilgileriS();
            BaseIslemTuru = OldEntity.Id == 0 ? IslemTuru.EntityInsert : IslemTuru.EntityUpdate;
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = _kod;
            txtKurumAdi.Text = _kurumAdi;
            txtKurumAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KurumBilgileriS)OldEntity;

            Id = entity.Id;
            txtKod.Text = entity.Kod;
            txtKurumAdi.Text = entity.KurumAdi;
            txtVergiDairesi.Id = entity.VergiDairesiId;
            txtVergiDairesi.Text = entity.VergiDairesiAdi;
            txtVergiNo.Text = entity.VergiNo;
            //txtIl.Id = entity.IlId;
            //txtIl.Text = entity.IlAdi;
            //txtIlce.Id = entity.IlceId;
            //txtIlce.Text = entity.IlceAdi;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new KurumBilgileri
            {
                Id = Id,
                Kod = txtKod.Text,
                KurumAdi = txtKurumAdi.Text,
                VergiDairesiId = txtVergiDairesi.Id,
                VergiNo = txtVergiNo.Text,
                //IlId = Convert.ToInt64(txtIl.Id),
                //IlceId = Convert.ToInt64(txtIlce.Id),

            };
            ButonEnabledDurumu();

        }
        protected override void SecimYap(object sender)
        {
            if (sender is MyButtonEdit mbe && mbe.IsClearButtonClick)
                return;

            if (!(sender is ButtonEdit))
                return;

            using (var sec = new Forms.Functions.SelectFunctions())
            {
                if (sender == txtIl)
                    sec.Sec(txtIl);

                else if (sender == txtIlce)
                    sec.Sec(txtIlce, txtIl);

                else if (sender == txtVergiDairesi)
                    sec.Sec(txtVergiDairesi, KartTuru.VergiDairesi);
            }
        }

        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtIl) return;
            txtIl.ControlEnabledChange(txtIlce);
        }

    }
}