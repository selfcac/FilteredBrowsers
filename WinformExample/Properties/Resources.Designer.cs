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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CefSharp.WinForms.Example.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap chromium_256 {
            get {
                object obj = ResourceManager.GetObject("chromium_256", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (function (_xpath,upCount) {
        ///	function getElementByXpath(path) {
        ///		return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
        ///	}
        ///
        ///	var elem = getElementByXpath(_xpath);
        ///	while (upCount &gt; 0) {
        ///		if (elem) {
        ///			elem = elem.parentNode;
        ///		}
        ///		upCount--;
        ///	}
        ///
        ///	if (elem) {
        ///		elem.style.visibility = &quot;hidden&quot;;
        ///	}
        ///})({xpath},{count}).
        /// </summary>
        internal static string HideElement {
            get {
                return ResourceManager.GetString("HideElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //console.log({count})
        /////console.log({xpath})
        ///
        ///(function (_xpath,upCount) {
        ///	function getElementByXpath(path) {
        ///		return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
        ///	}
        ///
        ///	var elem = getElementByXpath(_xpath);
        ///	while (upCount &gt; 0) {
        ///		if (elem) {
        ///			elem = elem.parentNode;
        ///		}
        ///		upCount--;
        ///	}
        ///
        ///	if (elem) {
        ///		var lastColor = elem.style.backgroundColor;
        ///		var lastBorder = elem.style.border;
        ///
        ///		elem.style.backgroundColor = &quot;yellow&quot;;
        ///		e [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string HighlightElement {
            get {
                return ResourceManager.GetString("HighlightElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (function () {
        ///	var timeLeft = {len};
        ///
        ///    var v = document.createElement(&quot;span&quot;)
        ///    v.style.backgroundColor=&quot;yellow&quot;;
        ///    v.style.borderColor = &quot;black&quot;
        ///    v.style.border = &quot;2px solid black&quot;
        ///    v.style.position = &quot;absolute&quot;
        ///    v.style.padding=&quot;5px&quot;
        ///	v.style.zIndex = &quot;9999&quot;;
        ///    v.innerText = &quot;⌛ &quot;+timeLeft+&quot; ⌛&quot;
        ///
        ///    document.body.appendChild(v)
        ///
        ///    var mouse_callback = function(e) {
        ///		var x = e.clientX + window.scrollX;
        ///		var y = e.clientY + window.scrollY;
        ///
        ///		v.style.left = &quot;&quot; + x + &quot; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MovingCurserJS {
            get {
                return ResourceManager.GetString("MovingCurserJS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap nav_left_green {
            get {
                object obj = ResourceManager.GetObject("nav_left_green", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap nav_plain_green {
            get {
                object obj = ResourceManager.GetObject("nav_plain_green", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap nav_plain_red {
            get {
                object obj = ResourceManager.GetObject("nav_plain_red", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap nav_right_green {
            get {
                object obj = ResourceManager.GetObject("nav_right_green", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /////document.elementFromPoint(x, y);
        ///
        ///// Copyright 2018 The Chromium Authors. All rights reserved.
        ///// Use of this source code is governed by a BSD-style license that can be
        ///// found in the LICENSE file.
        ///
        ///Elements = {};
        ///Elements.DOMPath = {};
        ///
        ////**
        /// * @param {!Node} node
        /// * @param {boolean=} optimized
        /// * @return {string}
        /// */
        ///
        ///
        /// // =====================&gt; USAGE: Elements.DOMPath.xPath($0,true | false)
        ///
        ///
        ///
        ///
        ///Elements.DOMPath.xPath = function (node, optimized) {
        ///    if (node.nodeType === Node [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string XPathCalc_Chrominum {
            get {
                return ResourceManager.GetString("XPathCalc_Chrominum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  /////document.elementFromPoint(x, y);
        ///
        /// (function() {
        ///	 function getPathTo(element) {
        ///		if (element.id!==&apos;&apos;)
        ///			return &apos;id(&quot;&apos;+element.id+&apos;&quot;)&apos;;
        ///		if (element===document.body)
        ///			return element.tagName;
        ///
        ///		var ix= 0;
        ///		var siblings= element.parentNode.childNodes;
        ///		for (var i= 0; i&lt;siblings.length; i++) {
        ///			var sibling= siblings[i];
        ///			if (sibling===element)
        ///				return getPathTo(element.parentNode)+&apos;/&apos;+element.tagName+&apos;[&apos;+(ix+1)+&apos;]&apos;;
        ///			if (sibling.nodeType===1 &amp;&amp; sibling.tagName===element.ta [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string XPathCalc_FromPoint {
            get {
                return ResourceManager.GetString("XPathCalc_FromPoint", resourceCulture);
            }
        }
    }
}
