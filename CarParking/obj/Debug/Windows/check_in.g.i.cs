﻿#pragma checksum "..\..\..\Windows\check_in.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AC2EC96EF9B5EAE0A9C7FC62EC78ABD2C27561B6C326290E2092B8258701D1A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using курсовой;


namespace курсовой {
    
    
    /// <summary>
    /// check_in
    /// </summary>
    public partial class check_in : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox car;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox date_time;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox number_on_parking;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox user;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox type;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox period;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox summa;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button choose_plase;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Windows\check_in.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
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
            System.Uri resourceLocater = new System.Uri("/курсовой;component/windows/check_in.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\check_in.xaml"
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
            
            #line 10 "..\..\..\Windows\check_in.xaml"
            ((курсовой.check_in)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\..\Windows\check_in.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.car = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\Windows\check_in.xaml"
            this.car.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.car_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.date_time = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\Windows\check_in.xaml"
            this.date_time.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.date_time_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.number_on_parking = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.user = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.type = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.period = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\Windows\check_in.xaml"
            this.period.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.period_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.summa = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\Windows\check_in.xaml"
            this.summa.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged_1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.choose_plase = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Windows\check_in.xaml"
            this.choose_plase.Click += new System.Windows.RoutedEventHandler(this.choose_plase_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Windows\check_in.xaml"
            this.Minimize.Click += new System.Windows.RoutedEventHandler(this.Minimize_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Windows\check_in.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
