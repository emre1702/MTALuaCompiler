﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MTALuaCompiler
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {

        [STAThread]
        static void Main()
        {
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }
    }
}