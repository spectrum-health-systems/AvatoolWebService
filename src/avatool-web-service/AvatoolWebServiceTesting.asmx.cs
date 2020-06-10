/* Project: Avatool Web Service
 * AvatoolWebServiceStating.asmx.cs: The main file.
 * b0610.1141
 * (c) 2020 A Pretty Cool Program
 * https://github.com/spectrum-health-systems/avatool-web-service)
 * Licensed under the Apache License 2.0
 */

/* This code is heavily commented, the intention being that it's abundantly clear as to what it does, and how it works.
 */

/* FUNCTIONALITY TESTING
 * ---------------------
 * This class contains source code intended for testing future Avatool Web Service functionality.
 */

using System.ComponentModel;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace Avatool_Web_Service
{
    /// <summary>Summary description for AvatoolWebService.</summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    public class AvatoolWebServiceTesting : WebService
    {
        /// <summary>Returns the Avatool Web Service version number.</summary>
        /// <returns>The Avatool Web Service version number.</returns>
        [WebMethod]
        public string GetVersion()
        {
            /* This method is required by myAvatar.
             */
            return "VERSION 1.3";
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
                    objectToReturn = InpatientAdmissionTesting.VerifyInpatientAdmissionDate(sentObject);
                    break;

                default:
                    objectToReturn = sentObject;
                    break;
            }

            return objectToReturn;
        }
    }
}