using MauiAppCadastroDeEventos.Models;
using System.Xml.Linq;

namespace MauiAppCadastroDeEventos.Views;

public partial class CadastrarEventos : ContentPage
{
      
	public CadastrarEventos()
	{
        InitializeComponent();

        dtpck_inicio.MinimumDate = DateTime.Now;
        dtpck_inicio.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_termino.MinimumDate = dtpck_inicio.Date.AddDays(1);
        dtpck_termino.MaximumDate = dtpck_inicio.Date.AddMonths(6);
	}


    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_inicio = elemento.Date;

        dtpck_termino.MinimumDate = data_selecionada_inicio.AddDays(1);
        dtpck_termino.MaximumDate = data_selecionada_inicio.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {

          

            DuracaoEvento d = new DuracaoEvento()
            {
                QntPessoas = Convert.ToDouble(stp_pessoas.Value),
                DataInicio = dtpck_inicio.Date,
                DataFim = dtpck_termino.Date,
                LocalEvento = txt_local.Text,
                NomeEvento = txt_evento.Text,
                ValorPessoa = Convert.ToDouble(txt_valor.Text),
                ValorTotal = Convert.ToDouble(stp_pessoas.Value) * Convert.ToDouble(txt_valor.Text),
            };

            await Navigation.PushAsync(new EventoCadastrado()
            {
                BindingContext = d,
            });


        } 
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

}