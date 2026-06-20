using System;
using DotNet.ERP.Bll.General;
using DotNet.ERP.Common.Message;
using DotNet.ERP.Model.Dto;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable
{
    public partial class YorumlarTable : BaseTablo
    {
        public YorumlarTable()
        {
            InitializeComponent();

            Bll = new YorumlarBll();
            Tablo = tablo;
            EventsLoad();
        }

        protected  internal override void Listele()
        {
            tablo.GridControl.DataSource = ((YorumlarBll)Bll).List(x => x.KisiId == OwnerForm.Id).ToBindingList<YorumlarL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            var row = new YorumlarL
            {
                    KisiId = OwnerForm.Id,
                    Tarih = DateTime.Now,
                    Insert = true
            };

            source.Add(row);            

            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colYorum;

            ButonEnabledDurumu(true);

        }
        protected internal override bool HataliGiris()
        {
            bool hatali = false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<YorumlarL>(i);
                if ((entity.Insert || entity.Update) && string.IsNullOrWhiteSpace(entity.Yorum))
                {
                    tablo.FocusedRowHandle = i;
                    tablo.SetColumnError(colYorum, "Yorum alanına geçerli bir değer giriniz.");
                    hatali = true;
                }
            }

            if (hatali)
            {
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption}"); //Error Messages
                return true;
            }

            return false;
        }
    }
}