using crud_perfume.Model;

namespace crud_perfume.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private async void SalvarAlteracoes(object sender, EventArgs e)
    {
        try
        {
            var perfume = BindingContext as Perfume;

            if (perfume == null)
            {
                await DisplayAlert("Erro", "Perfume não encontrado.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                await DisplayAlert("Erro", "Digite o nome do perfume!", "OK");
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVolume.Text))
            {
                await DisplayAlert("Erro", "Digite o volume do perfume!", "OK");
                txtVolume.Focus();
                return;
            }

            var update = new Perfume
            {
                Id = perfume.Id,
                Nome = txtNome.Text,
                Volume = int.Parse(txtVolume.Text)
            };

            await App.BD.Update(update);
            await DisplayAlert("Sucesso", "Perfume alterado com sucesso!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro ao salvar", ex.Message, "OK");
        }
    }
}
