// ===========================================================================================================  2:46 PM
//    FILENAME: AvatoolWebService.asmx.cs
//       BUILD: 20191114
//     PROJECT: Avatool-Web-Service (https://github.com/APrettyCoolProgram/Avatool-Web-Service)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

/* This code is heavily commented, the intention being that it's abundantly clear as to what it does, and how it works.
 */

using NTST.ScriptLinkService.Objects;
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
    public partial class AvatoolWebService : WebService
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
        /// Performs an Avatool Web Service "action".
        /// </summary>
        /// <param name="sentOptionObject">The OptionObject2 object from myAvatar.</param>
        /// <param name="action">The action you want the Web Service to perform.</param>
        /// <returns>A completed OptionObject.</returns>
        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
        {
            /* When you create an Avatool Web Service ScriptLink event in myAvatar, you need to pass an action that the
             * web service will perform. This action is the defined in the "parameter" field for the "Available Script"
             * that you have selected in the Form Designer. Each action is handled by an individual method.
             *
             * The action must be one of the case statements in the block of code below. The official Avatool Web
             * Service release has the following potential actions:
             *
             *  - VerifyInpatientAdmissionDate : Verify that the Inpatient Admission Date is the same as the system
             *                                   date.
             */
            switch (action)
            {
                case "VerifyInpatientAdmissionDate":
                    return VerifyInpatientAdmissionDate(sentOptionObject); // TODO Define the OptionObject here, and have a single return statement.

                default:
                    return sentOptionObject; // TODO Define the OptionObject here, and have a single return statement.
            }

            return sentOptionObject;
        }

        /* THIS METHOD HAS BEEN MOVED TO VerifyInpatientAdmissionDate.cs
         *
         * This block should be removed prior to releasing v1.1
         */
        ///////// <summary>
        ///////// Verify that the Inpatient Admission Date is the same as the system date.
        ///////// </summary>
        ///////// <param name="sentOptionObject">The sent OptionObject</param>
        ///////// <returns>A completed OptionObject.</returns>
        //////public static OptionObject2 VerifyInpatientAdmissionDate(OptionObject2 sentOptionObject)
        //////{
        //////    /* Documentation for VerifyInpatientAdmissionDate() can be found here:
        //////     *   https://github.com/spectrum-health-systems/Avatool-Web-Service/blob/master/doc/Using-VerifyInpatientAdmissionDate.md
        //////     */

        //////    /* You will need to modify these values to match the fieldIDs for your organization. See the
        //////     * VerifyInpatientAdmissionDate() documentation for details
        //////     */
        //////    const string typeOfAdmissionFieldId         = "44";
        //////    const string preAdmitToAdmissionDateFieldId = "42";
        //////    const int    preAdmissionId                 = 3;

        //////    var typeOfAdmission         = 0;
        //////    var preAdmitToAdmissionDate = new DateTime(1900, 1, 1);

        //////    foreach (var form in sentOptionObject.Forms)
        //////    {
        //////        foreach (var field in form.CurrentRow.Fields)
        //////        {
        //////            switch (field.FieldNumber)
        //////            {
        //////                case typeOfAdmissionFieldId:
        //////                    typeOfAdmission = int.Parse(field.FieldValue); // TODO Convert.ToInt()?

        //////                    break;

        //////                case preAdmitToAdmissionDateFieldId:
        //////                    preAdmitToAdmissionDate = Convert.ToDateTime(field.FieldValue);

        //////                    break;
        //////            }
        //////        }
        //////    }

        //////    var systemDate       = new DateTime(2019, 1, 18); // TODO Use the same formatting as the above declaration.
        //////    var errorMessageBody = string.Empty;
        //////    var errorMessageCode = 0;

        //////    if (typeOfAdmission == preAdmissionId)
        //////    {
        //////        if (preAdmitToAdmissionDate != systemDate)
        //////        {
        //////            errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date";

        //////            /* You can give the user the option of ignoring the warning. See the VerifyInpatientAdmissionDate()
        //////             * documentation for details
        //////             */
        //////            errorMessageCode = 1;
        //////        }
        //////    }

        //////    var returnOptionObject = new OptionObject2();

        //////    if (errorMessageCode != 0)
        //////    {
        //////        returnOptionObject.ErrorCode = errorMessageCode;
        //////        returnOptionObject.ErrorMesg = errorMessageBody;
        //////    }

        //////    /* >>> DEBUGGING ONLY <<<
        //////     *
        //////     * When this block of code is uncommented, a pop-up will always appear with detailed information. This is
        //////     * useful when debugging VerifyInpatientAdmissionDate. If you aren't debugging this code, this block should
        //////     * be commented.
        //////     */
        //////    //if (errorMessageCode == 0)
        //////    //{
        //////    //    returnOptionObject.ErrorCode = 4;
        //////    //    returnOptionObject.ErrorMesg = "[OUT OF BOUNDS ERROR]\nType of admission: " + typeOfAdmission + "\n" + "Date: " + preAdmitToAdmissionDate;
        //////    //}

        //////    return CompleteOptionObject(sentOptionObject, returnOptionObject, true, false);
        //////}


        /* THIS METHOD HAS BEEN MOVED TO CompleteOptionObject.cs
         *
         * This block should be removed prior to releasing v1.1
         */
        ///////// <summary>
        ///////// Completes the content of an OptionObject2 object.
        ///////// </summary>
        ///////// <param name="sentOptionObject">A complete OptionObject that contains the original data.</param>
        ///////// <param name="returnOptionObject">Data that will add to, or overwrite, data in the sentOptionObject.</param>
        ///////// <param name="recommended">Fields that are recommended to set (true/false) [true].</param>
        ///////// <param name="notRecommended">Fields that not recommended to set (true/false) [false].</param>
        ///////// <returns>A completed OptionObject</returns>
        //////public static OptionObject2 CompleteOptionObject(OptionObject2 sentOptionObject, OptionObject2 returnOptionObject, bool recommended, bool notRecommended)
        //////{
        //////    /* This method will make sure that all of the fields of an OptionObject2 object that are not explicitly set
        //////     * are set to whatever the original values in "sentOptionObject" were. This ensures that the OptionObject2
        //////     * that is returned to Avatar contains the required information. Currently this is done using brute force,
        //////     * but eventually it will be accomplished with a loop.
        //////     */
        //////    var completedOptionObject = new OptionObject2();

        //////    // Since these fields MUST be explicitly set prior to returning the OptionObject2, they are always set. If
        //////    // these fields are null when returned to Avatar, the script will fail.
        //////    completedOptionObject.EntityID        = sentOptionObject.EntityID;
        //////    completedOptionObject.Facility        = sentOptionObject.Facility;
        //////    completedOptionObject.NamespaceName   = sentOptionObject.NamespaceName;
        //////    completedOptionObject.OptionId        = sentOptionObject.OptionId;
        //////    completedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;
        //////    completedOptionObject.ServerName      = sentOptionObject.ServerName;
        //////    completedOptionObject.SystemCode      = sentOptionObject.SystemCode;

        //////    // Since it is recommended that these be explicitly set prior to returning the OptionObject2, they should
        //////    // always be set by passing "true" as the value for the "recommended" argument. The if statement does its
        //////    // best job to catch any invalid argument values.
        //////    if (recommended)
        //////    {
        //////        completedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
        //////        completedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
        //////        completedOptionObject.OptionUserId  = sentOptionObject.OptionUserId;

        //////        // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use
        //////        // the data that exists in the sentOptionObject.
        //////        if (returnOptionObject.ErrorCode >= 1)
        //////        {
        //////            completedOptionObject.ErrorCode = returnOptionObject.ErrorCode;
        //////            completedOptionObject.ErrorMesg = returnOptionObject.ErrorMesg;
        //////        }
        //////        else
        //////        {
        //////            completedOptionObject.ErrorCode = sentOptionObject.ErrorCode;
        //////            completedOptionObject.ErrorMesg = sentOptionObject.ErrorMesg;
        //////        }
        //////    }

        //////    // Since it is recommended that these NOT BE explicitly set prior to returning the OptionObject2, avoid
        //////    // setting them by passing "false" as the value for the "recommended" argument. Generally, if these fields
        //////    // contain data when returned to myAvatar, this script will fail. The if statement does its  best job to
        //////    // catch any invalid argument values.
        //////    if (notRecommended)
        //////    {
        //////        completedOptionObject.Forms = sentOptionObject.Forms;
        //////    }

        //////    return completedOptionObject;
        //////}
    }
}