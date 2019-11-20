// ===========================================================================================================  3:28 PM
//    FILENAME: AvatoolWebService.VerifyInpatientAdmissionDate.cs
//       BUILD: 20191120
//     PROJECT: Avatool-Web-Service (https://github.com/spectrum-health-systems/Avatool-Web-Service)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* Detailed documentation for VerifyInpatientAdmissionDate() can be found here:
 *   https://github.com/spectrum-health-systems/Avatool-Web-Service/blob/master/doc/Using-VerifyInpatientAdmissionDate.md
 */

using NTST.ScriptLinkService.Objects;
using System;

namespace Avatool_Web_Service
{
    public partial class AvatoolWebService
    {
        /// <summary> Verify that the Inpatient Admission Date is the same as the system date.</summary>
        /// <param name="optionObjectFromMyAvatar">The OptionObject2 object from myAvatar.</param>
        /// <returns>A completed OptionObject with the VerifyInpatientAdmissionDate information.</returns>
        public static OptionObject2 VerifyInpatientAdmissionDate(OptionObject2 optionObjectFromMyAvatar)
        {
            ///* You will need to modify these values to match the fieldIDs for your organization. See the
            // * VerifyInpatientAdmissionDate() documentation for details
            // */
            //const string typeOfAdmissionFieldId         = "44";
            //const string preAdmitToAdmissionDateFieldId = "42";
            //const int    preAdmissionId                 = 3;
            var admissionDateDetails = new AdmissionDateDetails();

            var typeOfAdmission         = 0;
            var preAdmitToAdmissionDate = new DateTime(1900, 1, 1);

            foreach (var form in optionObjectFromMyAvatar.Forms)
            {
                foreach (var field in form.CurrentRow.Fields)
                {
                    if (field.FieldNumber == admissionDateDetails.TypeOfAdmissionFieldId)
                    {
                        typeOfAdmission = int.Parse(field.FieldValue);
                    }
                    else if (field.FieldNumber == admissionDateDetails.PreAdmitToAdmissionDateFieldId)
                    {
                        preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);
                    }
                }
            }

            var systemDate       = new DateTime(2019, 1, 18); // TODO Use the same formatting as the above declaration.
            var errorMessageBody = string.Empty;
            var errorMessageCode = 0;

            if (typeOfAdmission == admissionDateDetails.PreAdmissionId)
            {
                if (preAdmitToAdmissionDate != systemDate)
                {
                    errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date";

                    /* You can give the user the option of ignoring the warning. See the VerifyInpatientAdmissionDate()
                     * documentation for details
                     */
                    errorMessageCode = 1;
                }
            }

            var returnOptionObject = new OptionObject2();

            if (errorMessageCode != 0)
            {
                returnOptionObject.ErrorCode = errorMessageCode;
                returnOptionObject.ErrorMesg = errorMessageBody;
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

            return CompleteOptionObject(optionObjectFromMyAvatar, returnOptionObject, true, false);
        }



    }
}