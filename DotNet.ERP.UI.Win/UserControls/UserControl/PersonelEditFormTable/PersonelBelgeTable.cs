using DotNet.ERP.Bll.General.PersonelBll;
using DotNet.ERP.Model.Dto.PersonelDto;
using DotNet.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraGrid.Views.Base;
using System;
using DotNet.ERP.UI.Win.Forms.Functions;

namespace DotNet.ERP.UI.Win.UserControls.UserControl.PersonelEditFormTable
{
    public partial class PersonelBelgeTable : BaseTablo
    {
        public PersonelBelgeTable()
        {
            InitializeComponent();

            Bll = new PersonelBelgeBll();
            Tablo = tablo;
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((PersonelBelgeBll)Bll).List(x => x.PersonelId == OwnerForm.Id).ToBindingList<PersonelBelgeL>();
        }
        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;

            var row = new PersonelBelgeL
            {
                PersonelId = OwnerForm.Id,
                VerilisTarihi = DateTime.Now.Date,
                GecerlilikTarihi = DateTime.Now.Date,
                Insert = true
            };

            source.Add(row);

            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colBelgeAdi;

            ButonEnabledDurumu(true);

        }

        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.Tablo_CellValueChanged(sender, e);

            if (e.Column != colKurumlarId) return;

            var entity = tablo.GetRow<PersonelBelgeL>();
            entity.BelgeTuruId = entity.BelgeTuruId;
            entity.KurumlarId = entity.KurumlarId;
        }


        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colKurumAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryKurum, colKurumlarId);

            if (e.FocusedColumn == colBelgeAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryBelge, colBelgeTuruId);
        }
    }
}
