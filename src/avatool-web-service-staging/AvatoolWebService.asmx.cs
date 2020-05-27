/* Project: Avatool Web Service
 * AvatoolWebServiceStating.asmx.cs: The main file.
 * b0527.1204
 * (c) 2020 A Pretty Cool Program
 * https://github.com/spectrum-health-systems/avatool-web-service)
 * Licensed under the Apache License 2.0
 */

/* >>> THIS IS THE STAGING BRANCH <<<
 * This code is heavily commented, the intention being that it's abundantly
 * clear as to what it does, and how it works.
 */

using System.ComponentModel;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace Avatool_Web_Service
{
    /// <summary>
    /// Summary description for AvatoolWebService.
    /// </summary>
    [WebService(Namespace         = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    public class AvatoolWebService : WebService
    {
        /// <summary>
        /// Returns the Avatool Web Service version number.
        /// </summary>
        /// <returns>The Avatool Web Service version number.</returns>
        [WebMethod]
        public string GetVersion()
        {
            /* This method is required by myAvatar.
             */
            return "VERSION 1.1";
        }

        /// <summary>
        /// Performs an Avatool Web Service "action".
        /// </summary>
        /// <param name="sentOptionObject">The OptionObject2 object from myAvatar.</param>
        /// <param name="action">The action you want the Web Service to perform.</param>
        /// <returns>A completed OptionObject.</returns>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
        {
            /* When you add a ScriptLink event in myAvatar, you need to pass an action that the Avatool Web Service
             * will perform, each of which is handled by an individual method.
             *
             * The Avatool Web Service has the following valid actions:
             *
             *  [VerifyInpatientAdmissionDate]
             *      Verify that the Inpatient Admission Date is
             *      the same as the system date.
             *
             * For more information about how to use ScriptLink events, please see the Avatool Web Service README.md:
             *
             *      https://github.com/spectrum-health-systems/avatool-web-service/blob/master/README.md
             */

            var optionObjectToReturn = new OptionObject2();

            switch (action)
            {
                case "VerifyInpatientAdmissionDate":
                    optionObjectToReturn = InpatientAdmission.VerifyInpatientAdmissionDate(sentOptionObject);
                    break;

                default:
                    optionObjectToReturn = sentOptionObject;
                    break;
            }

            return optionObjectToReturn;
        }
    }
}