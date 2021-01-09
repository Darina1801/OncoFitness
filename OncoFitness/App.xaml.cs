﻿using OncoFitness.Services;
using OncoFitness.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OncoFitness
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockQAndADataStore>();
			DependencyService.Register<MockTrainingDataStore>();
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
