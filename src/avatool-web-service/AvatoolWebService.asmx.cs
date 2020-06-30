// Avatool Web Service (https://github.com/spectrum-health-systems/avatool-web-service)
// AvatoolWebService.asmx.cs (b200630.1232): Main logic for the Avatool Web Service.
// Authors:
//	development@aprettycoolprogram.com
// Additional documentation: /AppResource/Doc/Proj/

/* THIS IS THE PRODUCTION CLASS!
 * This class contains source code intended for production Avatool Web Service functionality.
 *
 * All testing code can be found in "AvatoolWebServiceTesting.asmx.cs"
 */

/* READ THE MANUAL
 * https://github.com/spectrum-health-systems/avatool-web-service/blob/development/src/avatool-web-service/AppResource/Doc/Man/avatool-web-service-manual.md
 */

/* ABOUT SOURCE CODE COMMENTS
 * This code is heavily commented, so that it is abundantly clear as to what it does, and how it works.
 */

using System.ComponentModel;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace Avatool_Web_Service
{
    /// <summary>Summary description for AvatoolWebService.</summary>
    [WebService(Namespace         = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    public class AvatoolWebService : WebService
    {
        /// <summary>Returns the Avatool Web Service version number.</summary>
        /// <returns>The Avatool Web Service version number.</returns>
        [WebMethod]
        public string GetVersion()
        {
            /* This method is required by myAvatar.
             */
            return "VERSION 1.2";
        }

        /// <summary>Performs an Avatool Web Service "action".</summary>
        /// <param name="sentObject">The OptionObject2 object from myAvatar.</param>
        /// <param name="action">The action you want the Web Service to perform.</param>
        /// <returns>A completed OptionObject.</returns>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentObject, string action)
        {
            /* This method is required by myAvatar.
             *
             * When you add a ScriptLink event in myAvatar, you need to pass an action that the Avatool Web Service
             * will perform, each of which is handled by an individual method.
             *
             * The Avatool Web Service has the following valid actions:
             *
             *  [VerifyInpatientAdmissionDate]
             *      Verify that the Inpatient Admission Date is the same as the
             *      system date.
             *
             * For more information about how to use ScriptLink events, please see the Avatool Web Service README.md:
             *
             *      https://github.com/spectrum-health-systems/avatool-web-service/blob/master/README.md
             */

            var objectToReturn = new OptionObject2();

            switch (action)
            {
                case "VerifyInpatientAdmissionDate":
                    objectToReturn = InpatientAdmission.VerifyInpatientAdmissionDate(sentObject);
                    break;

                default:
                    objectToReturn = sentObject;
                    break;
            }

            return objectToReturn;
        }
    }
}