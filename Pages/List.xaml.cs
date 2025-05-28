
using crud_perfume.Model;

namespace crud_perfume.Pages;

public partial class List : ContentPage
{
    public List()
    {
        InitializeComponent();
    }

    private async void AdicionarPerfume(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Create());
    }

    private async void ProcurarAsync(object sender, TextChangedEventArgs e)
    {
        var texto = txtBusca.Text;
        if (string.IsNullOrWhiteSpace(texto))
        {
            await CarregarDados();
        }
        else
        {
            lstPerfumes.ItemsSource = await App.BD.Search(texto);
        }
    }

    private async Task CarregarDados()
    {
        var lista = await App.BD.GetAll();
        lstPerfumes.ItemsSource = lista;
    }

    private async void CarregarLista(object sender, EventArgs e)
    {
        await CarregarDados();
        lstPerfumes.IsRefreshing = false;
    }

    private async void SelecionarPerfume(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var perfumeSelecionado = e.SelectedItem as Perfume;
            await Navigation.PushAsync(new Create { BindingContext = perfumeSelecionado });
            lstPerfumes.SelectedItem = null;
        }
    }

    private async void ExcluirPerfume(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        if (menuItem?.BindingContext is Perfume perfume)
        {
            bool confirmacao = await DisplayAlert("Confirmar", $"Deseja excluir '{perfume.Nome}'?", "Sim", "Não");
            if (confirmacao)
            {
                await App.BD.Delete(perfume.Id);
                await DisplayAlert("Removido", "Perfume excluído com sucesso!", "OK");
                CarregarDados();
            }
        }
    }


}
