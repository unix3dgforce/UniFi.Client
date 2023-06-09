﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniFi.Core {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UniFi.Core.Resources.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Method Add not supported.
        /// </summary>
        public static string Access_Error_Method_Add {
            get {
                return ResourceManager.GetString("Access_Error_Method_Add", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method Delete not supported.
        /// </summary>
        public static string Access_Error_Method_Delete {
            get {
                return ResourceManager.GetString("Access_Error_Method_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method Get not supported.
        /// </summary>
        public static string Access_Error_Method_Get {
            get {
                return ResourceManager.GetString("Access_Error_Method_Get", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method GetAll not supported.
        /// </summary>
        public static string Access_Error_Method_GetAll {
            get {
                return ResourceManager.GetString("Access_Error_Method_GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method Update not supported.
        /// </summary>
        public static string Access_Error_Method_Update {
            get {
                return ResourceManager.GetString("Access_Error_Method_Update", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to complete API request.
        /// </summary>
        public static string Api_Error_Request {
            get {
                return ResourceManager.GetString("Api_Error_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Backup generation error.
        /// </summary>
        public static string Backup_Error_Generation {
            get {
                return ResourceManager.GetString("Backup_Error_Generation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Filename cannot be empty.
        /// </summary>
        public static string Backup_Info_NotEmpty_Filename {
            get {
                return ResourceManager.GetString("Backup_Info_NotEmpty_Filename", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Backup named &quot;{0}&quot; not found.
        /// </summary>
        public static string Backup_Info_NotFound_Filename {
            get {
                return ResourceManager.GetString("Backup_Info_NotFound_Filename", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entity already exists.
        /// </summary>
        public static string Global_Entity_AlreadyExists {
            get {
                return ResourceManager.GetString("Global_Entity_AlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entity delete is not allowed.
        /// </summary>
        public static string Global_Entity_DontAllowDeletion {
            get {
                return ResourceManager.GetString("Global_Entity_DontAllowDeletion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entity not found.
        /// </summary>
        public static string Global_Entity_NotFound {
            get {
                return ResourceManager.GetString("Global_Entity_NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error.
        /// </summary>
        public static string Global_Error {
            get {
                return ResourceManager.GetString("Global_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successful.
        /// </summary>
        public static string Global_Successful {
            get {
                return ResourceManager.GetString("Global_Successful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mac address cannot be empty.
        /// </summary>
        public static string Services_NotEmpty_MacAddress {
            get {
                return ResourceManager.GetString("Services_NotEmpty_MacAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid URL.
        /// </summary>
        public static string Validate_Error_FirmwareUrl {
            get {
                return ResourceManager.GetString("Validate_Error_FirmwareUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id cannot be null.
        /// </summary>
        public static string Validate_Error_Id {
            get {
                return ResourceManager.GetString("Validate_Error_Id", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to String &quot;{0}&quot; is not a MAC address.
        /// </summary>
        public static string Validate_Error_MacAddress {
            get {
                return ResourceManager.GetString("Validate_Error_MacAddress", resourceCulture);
            }
        }
    }
}
