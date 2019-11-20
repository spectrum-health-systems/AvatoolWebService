// ===========================================================================================================  10:10 AM
//    FILENAME: AdmissionDate.cs
//       BUILD: 20191120
//     PROJECT: Avatool-Web-Service (https://github.com/spectrum-health-systems/Avatool-Web-Service)
//     AUTHORS: development@aprettycoolprogram.com
//   COPYRIGHT: Copyright 2019 A Pretty Cool Program
//     LICENSE: Apache License, Version 2.0
// ====================================================================================================================

namespace Avatool_Web_Service
{
    public class AdmissionDateDetails
    {
        public string TypeOfAdmissionFieldId;
        public string PreAdmitToAdmissionDateFieldId;
        public int    PreAdmissionId;

        public AdmissionDateDetails()
        {
            /* You will need to modify these values to match the fieldIDs for your organization. See the
             * VerifyInpatientAdmissionDate() documentation for details
             */
            TypeOfAdmissionFieldId         = "44";
            PreAdmitToAdmissionDateFieldId = "42";
            PreAdmissionId                 = 3;
        }
    }
}