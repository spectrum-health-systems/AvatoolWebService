

using System;
using System.ComponentModel;
using System.Web.Services;

using NTST.ScriptLinkService.Objects;

namespace Avatool_Web_Service
{
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
        {
            switch(action)
            {
                case "CheckSubscriberPolicyNumber":
                    return CheckSubscriberPolicyNumber(sentOptionObject);

                case "VerifyInpatientAdmissionDate":
                    return VerifyInpatientAdmissionDate(sentOptionObject);

                default:
                    return sentOptionObject;
            }
        }

        public static OptionObject2 CheckSubscriberPolicyNumber(OptionObject2 sentOptionObject)
        {
            //Define the field we are looking for
            //Init a placeholder
            const string subscriberPolicyNumber      = "263";
            var          subscriberPolicyNumberValue = "";

            //Create a return box
            //var returnOptionObject = new OptionObject2();

            var returnOptionObject = sentOptionObject;

            // Loop through forms
            foreach(var form in returnOptionObject.Forms)
            {
                // Loop through form fields
                foreach(var field in form.CurrentRow.Fields)
                {
                    // Do something with certian fields.
                    switch(field.FieldNumber)
                    {
                        case subscriberPolicyNumber:
                            field.FieldValue += "TEST";
                            //field.FieldValue.Trim();
                            //subscriberPolicyNumberValue = field.FieldValue;
                            break;

                        default:
                            break;
                    }
                }
            }

            //Ask what to do?

            //Trim()
            //var finalValue = subscriberPolicyNumberValue.Trim();

            //Put the trimmed data into the box

            //Complete the box and return.
            return CompleteOptionObject(sentOptionObject, returnOptionObject, true, false);
        }

        /// <summary>Verify that the Inpatient Admission Date is the same as the system date.</summary>
        /// <param name="sentOptionObject">The sent OptionObject</param>
        /// <returns>A completed OptionObject.</returns>
        public static OptionObject2 VerifyInpatientAdmissionDate(OptionObject2 sentOptionObject)
        {
            /* This method verifies that an existing Pre-Admission date is the same as the system date.
             *
             * Here is how it works:
             *
             *  - When a completed Admission form is submitted, we check to if the "Admission Type" is "Pre-Admission".
             *
             *  - If the "Admission Type" is set to  "Pre-Admission" and the "Pre-Admission Date" is not the same as
             *    the system date, a pop-up will notify the user that they need to modify the Pre-Admission Date field
             *    to equal the system time, and the user will be returned to the form to modify the Pre-Admission Date.
             *
             *  - If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the
             *    same as the system date, the form is submitted normally.
             */

            /* Let's initialize a bunch of stuff!
             */

            /* You will need to modify these values to match the fieldIDs for your organization.
             */
            const string typeOfAdmissionField         = "44";
            const string preAdmitToAdmissionDateField = "42";
            const int    preAdmission                 = 3;

            var typeOfAdmission         = 0;
            var preAdmitToAdmissionDate = new DateTime(1900, 1, 1);

            /* We'll start by looping through each of the forms passed via the OptionObject.
             */
            foreach(var form in sentOptionObject.Forms)
            {
                /* And for each of those forms, we'll look at each field.
                 */
                foreach(var field in form.CurrentRow.Fields)
                {
                    /* If the field we are looking at is either "Type of Admission" or "Pre-Admit to Admission Date",
                     * we'll do something special.
                     */
                    switch(field.FieldNumber)
                    {
                        case typeOfAdmissionField:
                            typeOfAdmission = int.Parse(field.FieldValue);                                             // TODO Convert.ToInt()?
                            break;

                        case preAdmitToAdmissionDateField:
                            preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);
                            break;

                        default:
                            break;
                    }
                }
            }

            /* These are the valid Error Codes that can be used with myAvatar:
             *  1: Returns an Error Message and stops further processing of scripts (if set)
             *  2: Returns an Error Message with OK/Cancel buttons (further scripts are stopped if Cancelled)
             *  3: Returns an Error Message with OK button
             *  4: Returns an Error Message with Yes/No buttons (further scripts are stopped if No)
             *  5: Returns a URL to be opened in a new browser
             *
             * We are interested in Error Codes 1 and 4, the default being Error Code 1.
             *
             * Use Error Code 1 if you want to force the user to fix the date issue prior to submitting the form. Keep
             * in mind that when using this Error Code, the form cannot be submitted until the Pre-Admission Date
             * matches the system date.
             *
             * Use Error Code 4 to allow the user to ignore the date issue, and submit the form with different dates.
             */
            var systemDate       = new DateTime(1900, 1, 1); // TODO Use the same formatting as the above declaration.
            systemDate = DateTime.Today;
            var errorMessageBody = string.Empty;
            var errorMessageCode = 0;

            if(typeOfAdmission == preAdmission)
            {
                if(preAdmitToAdmissionDate != systemDate)
                {
                    errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date!";
                    errorMessageCode = 1;
                }
            }

            var returnOptionObject = new OptionObject2();

            /* If there is a valid error code, add the error message info to the return object.
             */
            if(errorMessageCode != 0)
            {
                returnOptionObject.ErrorCode = errorMessageCode;
                returnOptionObject.ErrorMesg = errorMessageBody;

                //// DEBUGGING ONLY
                //returnOptionObject.ErrorCode = errorMessageCode;
                //returnOptionObject.ErrorMesg = "[ERROR]\nError Code: " + errorMessageCode + "Type of admission: " + typeOfAdmission + "\n" + "PreAdmit Date: " + preAdmitToAdmissionDate + "System Date: " + systemDate;
            }


            /* We need to make sure that the OptionObject is completed prior to returning it.
             */
            return CompleteOptionObject(sentOptionObject, returnOptionObject, true, false);
        }

        /// <summary>Completes the content of an OptionObject2 object.</summary>
        /// <param name="sentOptionObject">  A complete OptionObject that contains the original data.</param>
        /// <param name="returnOptionObject">Data that will add to, or overwrite, data in the sentOptionObject.</param>
        /// <param name="recommended">       Fields that are recommended to set (true/false) [true].</param>
        /// <param name="notRecommended">    Fields that not recommended to set (true/false) [false].</param>
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
            completedOptionObject.EntityID = sentOptionObject.EntityID;
            completedOptionObject.Facility = sentOptionObject.Facility;
            completedOptionObject.NamespaceName = sentOptionObject.NamespaceName;
            completedOptionObject.OptionId = sentOptionObject.OptionId;
            completedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;
            completedOptionObject.ServerName = sentOptionObject.ServerName;
            completedOptionObject.SystemCode = sentOptionObject.SystemCode;

            // Since it is recommended that these be explicitly set prior to returning the OptionObject2, they should
            // always be set by passing "true" as the value for the "recommended" argument. The if statement does its
            // best job to catch any invalid argument values.
            if(recommended)
            {
                completedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
                completedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
                completedOptionObject.OptionUserId = sentOptionObject.OptionUserId;

                // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use
                // the data that exists in the sentOptionObject.
                if(returnOptionObject.ErrorCode >= 1)
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
            // contain data when returned to myAvatar, this script will fail. The if statement does its best job to
            // catch any invalid argument values.
            if(notRecommended)
            {
                completedOptionObject.Forms = sentOptionObject.Forms;
            }

            return completedOptionObject;
        }
    }
}