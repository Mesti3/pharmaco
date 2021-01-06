﻿#pragma checksum "..\..\..\..\components\medicine\medicine.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "538E5E72B1F1C5603AEB5AD3B89841CE3DAB615FEDE945A5B9B5AFEEDE0E337A"
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
using pharmaco.components.button;
using pharmaco.components.filter;
using pharmaco.components.medicine_components;


namespace pharmaco.components.medicine_components {
    
    
    /// <summary>
    /// medicine_detail
    /// </summary>
    public partial class medicine_detail : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid medicine_grid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel left_stack_panel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox box;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal pharmaco.components.filter.filter medicine_filter;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal pharmaco.components.button.green_button order_button;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal pharmaco.components.button.green_button back_button;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid right_grid;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel big_right_stack_panel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label medicine_name;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label medicine_form;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\components\medicine\medicine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scroll_view;
        
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
            System.Uri resourceLocater = new System.Uri("/pharmaco;component/components/medicine/medicine.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\components\medicine\medicine.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.medicine_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.left_stack_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.box = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 4:
            this.medicine_filter = ((pharmaco.components.filter.filter)(target));
            return;
            case 5:
            this.order_button = ((pharmaco.components.button.green_button)(target));
            return;
            case 6:
            this.back_button = ((pharmaco.components.button.green_button)(target));
            return;
            case 7:
            this.right_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.big_right_stack_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.medicine_name = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.medicine_form = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.scroll_view = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

