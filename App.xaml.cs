

namespace crud_perfume
{

    public partial class App : Application
    {
        public static Database.crudSQLite BD { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "perfume.db3");
            BD = new Database.crudSQLite(dbPath);

            MainPage = new NavigationPage(new Pages.List());
        }
    }
}
