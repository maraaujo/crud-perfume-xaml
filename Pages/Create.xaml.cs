using crud_perfume.Model;

namespace crud_perfume.Pages;

public partial class Create : ContentPage
{
    public Create()
    {
        InitializeComponent();
    }

    private async void Salvar(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                await DisplayAlert("Erro", "Digite o nome do perfume!", "OK");
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVolume.Text))
            {
                await DisplayAlert("Erro", "Digite o volume!", "OK");
                txtVolume.Focus();
                return;
            }

            var novoPerfume = new Perfume
            {
                Nome = txtNome.Text,
                Volume = int.Parse(txtVolume.Text)
            };

            await App.BD.Insert(novoPerfume);

            await DisplayAlert("Sucesso", "Perfume cadastrado com sucesso!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro ao salvar", ex.Message, "OK");
        }
    }
}
