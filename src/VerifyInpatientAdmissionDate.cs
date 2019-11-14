// ===========================================================================================================  3:28 PM
//    FILENAME: AvatoolWebService.VerifyInpatientAdmissionDate.cs
//       BUILD: 20191114
//     PROJECT: Avatool-Web-Service (https://github.com/APrettyCoolProgram/Avatool-Web-Service)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

using NTST.ScriptLinkService.Objects;
using System;

namespace Avatool_Web_Service
{
    public partial class AvatoolWebService
    {
        /// <summary>
        /// Verify that the Inpatient Admission Date is the same as the system date.
        /// </summary>
        /// <param name="sentOptionObject">The sent OptionObject</param>
        /// <returns>A completed OptionObject.</returns>
        public static OptionObject2 VerifyInpatientAdmissionDate(OptionObject2 sentOptionObject)
        {
            /* Documentation for VerifyInpatientAdmissionDate() can be found here:
             *   https://github.com/spectrum-health-systems/Avatool-Web-Service/blob/master/doc/Using-VerifyInpatientAdmissionDate.md
             */

            /* You will need to modify these values to match the fieldIDs for your organization. See the
             * VerifyInpatientAdmissionDate() documentation for details
             */
            const string typeOfAdmissionFieldId         = "44";
            const string preAdmitToAdmissionDateFieldId = "42";
            const int    preAdmissionId                 = 3;

            var typeOfAdmission         = 0;
            var preAdmitToAdmissionDate = new DateTime(1900, 1, 1);

            foreach (var form in sentOptionObject.Forms)
            {
                foreach (var field in form.CurrentRow.Fields)
                {
                    switch (field.FieldNumber)
                    {
                        case typeOfAdmissionFieldId:
                            typeOfAdmission = int.Parse(field.FieldValue); // TODO Convert.ToInt()?

                            break;

                        case preAdmitToAdmissionDateFieldId:
                            preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);

                            break;
                    }
                }
            }

            var systemDate       = new DateTime(2019, 1, 18); // TODO Use the same formatting as the above declaration.
            var errorMessageBody = string.Empty;
            var errorMessageCode = 0;

            if (typeOfAdmission == preAdmissionId)
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

            return CompleteOptionObject(sentOptionObject, returnOptionObject, true, false);
        }
    }
}