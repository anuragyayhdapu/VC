﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "304623D2E30DD6E078E015F121992F993163FE4FFE06E394E9068D9E50048A3F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ozeki.Media;
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
using VC;
using ValueConverter;


namespace VC {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SettingsGrid;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AccountSettings;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DisplayNameText;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameText;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordText;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneLineStateText;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PresenceStateText;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ConferenceRoomSettings;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DialToCallText;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox RoomPassword;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CallStateText;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PrivacySettings;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox VideoFeedToggle;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox MicToggle;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SpeakerToggle;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView MembersListView;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Ozeki.Media.VideoViewerWPF videoViewer;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Ozeki.Media.VideoViewerWPF videoViewerReciever;
        
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
            System.Uri resourceLocater = new System.Uri("/BEL_VC;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.SettingsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.AccountSettings = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.DisplayNameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.UserNameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PasswordText = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            
            #line 84 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SipRegistrationButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 91 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SipUnregistrationButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PhoneLineStateText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.PresenceStateText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.ConferenceRoomSettings = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.DialToCallText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.RoomPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 13:
            
            #line 152 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CallButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 156 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CallHangUpButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.CallStateText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.PrivacySettings = ((System.Windows.Controls.Grid)(target));
            return;
            case 17:
            this.VideoFeedToggle = ((System.Windows.Controls.CheckBox)(target));
            
            #line 190 "..\..\MainWindow.xaml"
            this.VideoFeedToggle.Click += new System.Windows.RoutedEventHandler(this.VideoFeedToggle_Checked);
            
            #line default
            #line hidden
            return;
            case 18:
            this.MicToggle = ((System.Windows.Controls.CheckBox)(target));
            
            #line 196 "..\..\MainWindow.xaml"
            this.MicToggle.Click += new System.Windows.RoutedEventHandler(this.MicToggle_Checked);
            
            #line default
            #line hidden
            return;
            case 19:
            this.SpeakerToggle = ((System.Windows.Controls.CheckBox)(target));
            
            #line 202 "..\..\MainWindow.xaml"
            this.SpeakerToggle.Click += new System.Windows.RoutedEventHandler(this.SpeakerToggle_Checked);
            
            #line default
            #line hidden
            return;
            case 20:
            this.MembersListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 21:
            this.videoViewer = ((Ozeki.Media.VideoViewerWPF)(target));
            return;
            case 22:
            this.videoViewerReciever = ((Ozeki.Media.VideoViewerWPF)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
