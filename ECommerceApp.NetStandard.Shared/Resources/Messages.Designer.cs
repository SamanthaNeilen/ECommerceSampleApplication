﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECommerceApp.NetStandard.Shared.Resources {
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
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ECommerceApp.NetStandard.Shared.Resources.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to sdfsdfsd.
        /// </summary>
        public static string dsfsdfs {
            get {
                return ResourceManager.GetString("dsfsdfs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is required.
        /// </summary>
        public static string FieldRequired {
            get {
                return ResourceManager.GetString("FieldRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Emailadress is invalid.
        /// </summary>
        public static string InvalidEmailAdress {
            get {
                return ResourceManager.GetString("InvalidEmailAdress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Housenumber is a numeric value.
        /// </summary>
        public static string InvalidHouseNumber {
            get {
                return ResourceManager.GetString("InvalidHouseNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Phonenumbers must be a valid dutch phonenumber.
        /// </summary>
        public static string InvalidPhonenumber {
            get {
                return ResourceManager.GetString("InvalidPhonenumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zipcode must be in format 1111AA.
        /// </summary>
        public static string InvalidZipCode {
            get {
                return ResourceManager.GetString("InvalidZipCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} can be no longer then {1} characters.
        /// </summary>
        public static string MaxLength {
            get {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }
    }
}
