﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatesCarSite.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ColumnNamesForDebts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ColumnNamesForDebts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MatesCarSite.Resources.ColumnNamesForDebts", typeof(ColumnNamesForDebts).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kierowca.
        /// </summary>
        public static string Driver {
            get {
                return ResourceManager.GetString("Driver", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dłużnik.
        /// </summary>
        public static string IdLoanDebtor {
            get {
                return ResourceManager.GetString("IdLoanDebtor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wierzyciel.
        /// </summary>
        public static string IdLoanHolder {
            get {
                return ResourceManager.GetString("IdLoanHolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wartość długu.
        /// </summary>
        public static string LoanValue {
            get {
                return ResourceManager.GetString("LoanValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Droga.
        /// </summary>
        public static string Route {
            get {
                return ResourceManager.GetString("Route", resourceCulture);
            }
        }
    }
}
