﻿#pragma checksum "..\..\..\UIElemente\WohneinheitUiElement.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C63F6D19988A6C16A54A439F1DCAC2AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34014
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Heizungssteuerung.UIElemente;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace Heizungssteuerung.UIElemente {
    
    
    /// <summary>
    /// WohneinheitUiElement
    /// </summary>
    public partial class WohneinheitUiElement : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Heizungssteuerung.UIElemente.WohneinheitUiElement WohneinheitUiElementUserControl;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FeuerIcon;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FrostIcon;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FensterIcon;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image StoerIcon;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image MultipleIcon;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Heizungssteuerung;component/uielemente/wohneinheituielement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.WohneinheitUiElementUserControl = ((Heizungssteuerung.UIElemente.WohneinheitUiElement)(target));
            return;
            case 2:
            
            #line 14 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZielTemperaturErhoehen_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 17 "..\..\..\UIElemente\WohneinheitUiElement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZielTemperaturVerringern_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FeuerIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.FrostIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.FensterIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.StoerIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.MultipleIcon = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

