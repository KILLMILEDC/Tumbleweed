﻿#pragma checksum "..\..\..\AboutWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3CB5E39C04BA3220BD45E14E008EEAAB78767B25"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Tumbleweed;


namespace Tumbleweed {
    
    
    /// <summary>
    /// AboutWindow
    /// </summary>
    public partial class AboutWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LOGOImage;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Title;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Version;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UVersion;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Author;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AboutCancelButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PayImage;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ChatImage;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\AboutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Linenese;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tumbleweed;component/aboutwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AboutWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LOGOImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.Title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Version = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.UVersion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Author = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.AboutCancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\AboutWindow.xaml"
            this.AboutCancelButton.Click += new System.Windows.RoutedEventHandler(this.AboutCancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PayImage = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.ChatImage = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.Linenese = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

