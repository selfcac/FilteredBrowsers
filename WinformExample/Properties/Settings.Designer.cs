﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CefSharp.WinForms.Example.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\Yoni\\Desktop\\selfcac\\CefSharp.WinForms.Filtered\\SamplePolicies\\policy.js" +
            "on")]
        public string httpPolicyPath {
            get {
                return ((string)(this["httpPolicyPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\Yoni\\Desktop\\selfcac\\CefSharp.WinForms.Filtered\\SamplePolicies\\all_time." +
            "json")]
        public string timePolicyPath {
            get {
                return ((string)(this["timePolicyPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("123123")]
        public string bypassSecret {
            get {
                return ((string)(this["bypassSecret"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\ProxyChromeFlow\\FilteredDownloads")]
        public string saveFolder {
            get {
                return ((string)(this["saveFolder"]));
            }
            set {
                this["saveFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\Yoni\\Desktop\\selfcac\\CefSharp.WinForms.Filtered\\SamplePolicies\\xpath.txt" +
            "")]
        public string xpathPolicyPath {
            get {
                return ((string)(this["xpathPolicyPath"]));
            }
            set {
                this["xpathPolicyPath"] = value;
            }
        }
    }
}
