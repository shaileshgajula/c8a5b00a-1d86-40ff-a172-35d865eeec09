﻿#pragma checksum "C:\Users\Dubies\Documents\Visual Studio 2010\Projects\LocksmithControl\Locksmith\Views\AllCompanies.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0CA322B6601F22FF138AAA0C2F01E26F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.21006.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Locksmith.Views {
    
    
    public partial class AllCompanies : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.DataGrid _DataGridAllCompanies;
        
        internal System.Windows.Controls.Button _buttonSubmitChanges;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Locksmith;component/Views/AllCompanies.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this._DataGridAllCompanies = ((System.Windows.Controls.DataGrid)(this.FindName("_DataGridAllCompanies")));
            this._buttonSubmitChanges = ((System.Windows.Controls.Button)(this.FindName("_buttonSubmitChanges")));
        }
    }
}
