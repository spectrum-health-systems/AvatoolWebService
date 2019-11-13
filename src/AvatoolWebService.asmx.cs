// ===========================================================================================================  3:01 PM
//    FILENAME: AvatoolWebService.asmx.cs
//       BUILD: 20191029
//     PROJECT: Avatool-Web-Service (https://github.com/APrettyCoolProgram/Avatool-Web-Service)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

using NTST.ScriptLinkService.Objects;
using System;
using System.ComponentModel;
using System.Web.Services;

namespace Avatool_Web_Service
{
    /// <summary>
    /// Summary description for AvatoolWebService
    /// </summary>
    [WebService(Namespace         = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class AvatoolWebService : WebService
    {
        /// <summary>
        /// Returns the Avatool Web Service version number.
        /// </summary>
        /// <returns>The Avatool Web Service version number</returns>
        [WebMethod]
        public string GetVersion()
        {
            /* This method is required by myAvatar.
             */
            return "VERSION 1.0";
        }

        /// <summary>
        /// Performs an Avatool Web Service action
        /// </summary>
        /// <param name="sentOptionObject">The OptionObject2 object from myAvatar.</param>
        /// <param name="action"></param>
        /// <returns></returns>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
        {
            switch (action)
            {
                case "VerifyInpatientAdmissionDate":
                    return VerifyInpatientAdmissionDate(sentOptionObject);
            }

            return sentOptionObject;
        }

        public static OptionObject2 VerifyInpatientAdmissionDate(OptionObject2 sentOptionObject)
        {
            /*Using the form Admission verify that the user is changing the apreadmit to admission date when selecting Admission from the dropdown
             option for Type of Admission
             */

            /* This is the empty OptionObject that we will complete and send back to myAvatar.
             */
            var returnOptionObject = new OptionObject2();

            /* These are the ID numbers for the Type of Admission dropdown and Pre-admit to Admission date fields.
             * You will need to modify these to match your environment.
             */
            const string typeOfAdmissionField         = "44";
            const string preAdmitToAdmissionDateField = "42";

            /* Placeholders
             */
            var typeOfAdmission         = 0;
            var preAdmitToAdmissionDate = new DateTime(1900, 1, 1);

            /* Since we are going to compare the date on the form to today's date, we need today's date.
             **/
            var todaysDate = new DateTime(2019, 1, 18);

            // Loop through the forms in the sent option,
            foreach (var form in sentOptionObject.Forms)
            {
                foreach (var field in form.CurrentRow.Fields)
                {
                    switch (field.FieldNumber)
                    {
                        case typeOfAdmissionField:
                            typeOfAdmission = int.Parse(field.FieldValue);

                            break;

                        case preAdmitToAdmissionDateField:
                            preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);

                            break;
                    }
                }
            }

            // Placeholders for potential error message information
            var errorMessageBody = string.Empty;
            var errorMessageCode = 0;

            if (typeOfAdmission == 3)
            {
                if (preAdmitToAdmissionDate != todaysDate)
                {
                    errorMessageBody = "HEY LOOK AT THE DATE. DO YOU WANT TO FIX?";
                    errorMessageCode = 1; // This should be 4 if you want to give the option
                }
                else
                {
                    // Do nothing.
                }
            }
            else
            {
                // Do nothing.
            }

            // As long as there is an error code, add the error message info to the return object.
            if (errorMessageCode != 0)
            {
                returnOptionObject.ErrorCode = errorMessageCode;
                returnOptionObject.ErrorMesg = errorMessageBody;
            }
            else
            {
                // Catcher
                returnOptionObject.ErrorCode = 4;
                returnOptionObject.ErrorMesg = "[OUT OF BOUNDS ERROR]\nType of admission: " + typeOfAdmission + "\n" + "Date: " + preAdmitToAdmissionDate;
            }


            // We need to make sure that the OptionObject is completed prior to returning it.
            return CompleteOptionObject(sentOptionObject, returnOptionObject, true, false);
        }

        /// <summary>
        /// Completes the content of an OptionObject2 object.
        /// </summary>
        /// <param name="sentOptionObject">A complete OptionObject that contains the original data.</param>
        /// <param name="returnOptionObject">Data that will add to, or overwrite, data in the sentOptionObject.</param>
        /// <param name="recommended">Fields that are recommended to set (true/false) [true].</param>
        /// <param name="notRecommended">Fields that not recommended to set (true/false) [false].</param>
        /// <returns>A completed OptionObject</returns>
        public static OptionObject2 CompleteOptionObject(OptionObject2 sentOptionObject, OptionObject2 returnOptionObject, bool recommended, bool notRecommended)
        {
            /* This method will make sure that all of the fields of an OptionObject2 object that are not explicitly set
             * are set to whatever the original values in "sentOptionObject" were. This ensures that the OptionObject2
             * that is returned to Avatar contains the required information. Currently this is done using brute force,
             * but eventually it will be accomplished with a loop.
             */
            var completedOptionObject = new OptionObject2();

            // Since these fields MUST be explicitly set prior to returning the OptionObject2, they are always set. If
            // these fields are null when returned to Avatar, the script will fail.
            completedOptionObject.EntityID        = sentOptionObject.EntityID;
            completedOptionObject.Facility        = sentOptionObject.Facility;
            completedOptionObject.NamespaceName   = sentOptionObject.NamespaceName;
            completedOptionObject.OptionId        = sentOptionObject.OptionId;
            completedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;
            completedOptionObject.ServerName      = sentOptionObject.ServerName;
            completedOptionObject.SystemCode      = sentOptionObject.SystemCode;

            // Since it is recommended that these be explicitly set prior to returning the OptionObject2, they should
            // always be set by passing "true" as the value for the "recommended" argument. The if statement does its
            // best job to catch any invalid argument values.
            if (recommended)
            {
                completedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
                completedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
                completedOptionObject.OptionUserId  = sentOptionObject.OptionUserId;

                // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use
                // the data that exists in the sentOptionObject.
                if (returnOptionObject.ErrorCode >= 1)
                {
                    completedOptionObject.ErrorCode = returnOptionObject.ErrorCode;
                    completedOptionObject.ErrorMesg = returnOptionObject.ErrorMesg;
                }
                else
                {
                    completedOptionObject.ErrorCode = sentOptionObject.ErrorCode;
                    completedOptionObject.ErrorMesg = sentOptionObject.ErrorMesg;
                }
            }

            // Since it is recommended that these NOT BE explicitly set prior to returning the OptionObject2, avoid
            // setting them by passing "false" as the value for the "recommended" argument. Generally, if these fields
            // contain data when returned to myAvatar, this script will fail. The if statement does its  best job to
            // catch any invalid argument values.
            if (notRecommended)
            {
                completedOptionObject.Forms = sentOptionObject.Forms;
            }

            return completedOptionObject;
        }
    }
}