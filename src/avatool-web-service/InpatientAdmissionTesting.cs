// Avatool Web Service (https://github.com/spectrum-health-systems/avatool-web-service)
// InpatientAdmissionTesting.cs (b200630.1232): Inpatient admission functionality logic.
// Authors:
//	development@aprettycoolprogram.com
// Additional documentation: /AppResource/Doc/Proj/

/* *************************************
 * * >>> THIS IS THE TESTING CLASS <<< *
 * *************************************
 *
 * This class contains source code intended for testing future Avatool Web Service functionality.
 *
 * Once it has been determined that the code functions as expected, it should be copied to "InpatientAdmission.cs"
 */

/* READ THE MANUAL
 * https://github.com/spectrum-health-systems/avatool-web-service/blob/development/src/avatool-web-service/AppResource/Doc/Man/avatool-web-service-manual.md
 */

/* ABOUT SOURCE CODE COMMENTS
 * This code is heavily commented, so that it is abundantly clear as to what it does, and how it works.
 */

using System;
using NTST.ScriptLinkService.Objects;

namespace Avatool_Web_Service
{
    public class InpatientAdmissionTesting
    {
        /// <summary>Verify that the Inpatient Admission Date is the same as the system date.</summary>
        /// <param name="sentObject">The sent OptionObject</param>
        /// <returns>A completed OptionObject.</returns>
        public static OptionObject2 VerifyInpatientAdmissionDate(OptionObject2 sentObject)
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

            /* We will need to initialize a few things, which are specific to your organization - so don't just use the
             * values given below!
             */
            const string typeOfAdmissionField         = "44";
            const string preAdmitToAdmissionDateField = "42";
            const int    preAdmission                 = 3;

            var typeOfAdmission         = 0;
            var preAdmitToAdmissionDate = new DateTime(1900, 1, 1);

            /* We'll start by looping through each of the forms passed via the OptionObject...
             */
            foreach (var form in sentObject.Forms)
            {
                /* ...and for each of those forms, we'll look at each field...
                 */
                foreach (var field in form.CurrentRow.Fields)
                {
                    /* ...and if the field we are looking at is either "Type of Admission" or "Pre-Admit to Admission
                     * Date", we'll do something special.
                     */
                    switch (field.FieldNumber)
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
            systemDate           = DateTime.Today;
            var errorMessageBody = string.Empty;
            var errorMessageCode = 0;

            if (typeOfAdmission == preAdmission)
            {
                if (preAdmitToAdmissionDate != systemDate)
                {
                    errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date!";
                    errorMessageCode = 1;
                }
            }

            var returnObject = new OptionObject2();

            /* If there is a valid error code, add the error message info to the return object.
             */
            if (errorMessageCode != 0)
            {
                returnObject.ErrorCode = errorMessageCode;
                returnObject.ErrorMesg = errorMessageBody;

                //// >>> DEBUGGING ONLY <<<
                //returnOptionObject.ErrorCode = errorMessageCode;
                //returnOptionObject.ErrorMesg = "[ERROR]\nError Code: " + errorMessageCode + "Type of admission: " + typeOfAdmission + "\n" + "PreAdmit Date: " + preAdmitToAdmissionDate + "System Date: " + systemDate;
            }

            /* >>> DEBUGGING ONLY <<<
             *
             * When this block of code is uncommented, a pop-up will always appear with detailed information. This is
             * useful when debugging VerifyInpatientAdmissionDate. If you aren't debugging this code, this block should
             * be commented.
             */
            //if (errorMessageCode == 0)
            //{
            //    returnOptionObject.ErrorCode = 4;
            //    returnOptionObject.ErrorMesg = "[OUT OF BOUNDS ERROR]\nType of admission: " + typeOfAdmission + "\n" + "Date: " + preAdmitToAdmissionDate;
            //}


            /* We need to make sure that the OptionObject is completed prior to returning it.
             */
            return DuOptionObjectTesting.Complete(sentObject, returnObject, true, false);
        }
    }
}