﻿

#pragma checksum "d:\mod\documents\visual studio 2013\Projects\StudyApplication\StudyApplication\StudyApplication.Shared\DemoPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A2A3C2AA913F843197DD469D3ABE9F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudyApp
{
    partial class DemoPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 19 "..\..\..\DemoPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnEnglish_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 27 "..\..\..\DemoPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnMaths_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 35 "..\..\..\DemoPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnPhysicalSciences_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 43 "..\..\..\DemoPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.linkQuit_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 44 "..\..\..\DemoPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.comboList_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 49 "..\..\..\DemoPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Button_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


