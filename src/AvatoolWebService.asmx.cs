// ===========================================================================================================  2:46 PM
//    FILENAME: AvatoolWebService.asmx.cs
//       BUILD: 20191114
//     PROJECT: Avatool-Web-Service (https://github.com/spectrum-health-systems/Avatool-Web-Service)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

using NTST.ScriptLinkService.Objects;
using System.ComponentModel;
using System.Web.Services;

namespace Avatool_Web_Service
{
    /// <summary>Summary description for AvatoolWebService</summary>
    [WebService(Namespace         = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public partial class AvatoolWebService : WebService
    {
        /// <summary>Returns the Avatool Web Service version number.</summary>
        /// <returns>The Avatool Web Service version number.</returns>
        [WebMethod]
        public string GetVersion()
        {
            // This method is required by myAvatar.
            return "VERSION 1.1";
        }

        /// <summary>Performs an Avatool Web Service actionRequest. </summary>
        /// <param name="optionObjectFromMyAvatar">The OptionObject2 object from myAvatar.</param>
        /// <param name="actionRequest">The action you want the Web Service to perform.</param>
        /// <returns>A completed OptionObject for the actionRequest.</returns>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 optionObjectFromMyAvatar, string actionRequest)
        {
            return actionRequest switch
            {
                "VerifyInpatientAdmissionDate" => VerifyInpatientAdmissionDate(optionObjectFromMyAvatar),
                _                              => optionObjectFromMyAvatar
            };
        }
    }
}