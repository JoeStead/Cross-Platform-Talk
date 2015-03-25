using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using StackViewer.Windows.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace StackViewer.Windows
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new StackViewer.App());
        }


    }
}