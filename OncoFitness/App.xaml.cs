using OncoFitness.Database;
using OncoFitness.Services;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace OncoFitness
{
	public partial class App : Application
	{
        public const string DatabaseNameConst = "MyDatabaseDB.db";
        public static OncoFitnessAsyncRepository database;
        public static OncoFitnessAsyncRepository Database
        {
            get
            {
                if (database == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseNameConst);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"OncoFitness.Database.{DatabaseNameConst}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new OncoFitnessAsyncRepository(dbPath);
                }
                return database;
            }
        }

        public App()
		{
			InitializeComponent();

			DependencyService.Register<ObsoleteMockQAndADataStore>();
			DependencyService.Register<ObsoleteMockTrainingDataStore>();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
