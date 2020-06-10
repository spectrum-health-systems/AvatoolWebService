/* Project: Avatool Web Service
 * DuOptionObject.cs: OptionObject2 stuff.
 * b0610.1141
 * (c) 2020 A Pretty Cool Program
 * https://github.com/spectrum-health-systems/avatool-web-service)
 * Licensed under the Apache License 2.0
 */

using NTST.ScriptLinkService.Objects;

namespace Avatool_Web_Service
{
    public class DuOptionObject
    {
       /// <summary>Completes the content of an OptionObject2 object.</summary>
        /// <param name="sentObject">A complete OptionObject that contains the original data.</param>
        /// <param name="returnObject">Data that will add to, or overwrite, data in the sentOptionObject.</param>
        /// <param name="recommended">Fields that are recommended to set (true/false) [true].</param>
        /// <param name="notRecommended">Fields that not recommended to set (true/false) [false].</param>
        /// <returns>A completed OptionObject</returns>
        public static OptionObject2 Complete(OptionObject2 sentObject, OptionObject2 returnObject, bool recommended, bool notRecommended)
        {
            /* This method will make sure that all of the fields of an OptionObject2 object that are not explicitly set
             * are set to whatever the original values in "sentOptionObject" were. This ensures that the OptionObject2
             * that is returned to Avatar contains the required information. Currently this is done using brute force,
             * but eventually it will be accomplished with a loop.
             */
            var completedObject = new OptionObject2();

            // Since these fields MUST be explicitly set prior to returning the OptionObject2, they are always set. If
            // these fields are null when returned to Avatar, the script will fail.
            completedObject.EntityID        = sentObject.EntityID;
            completedObject.Facility        = sentObject.Facility;
            completedObject.NamespaceName   = sentObject.NamespaceName;
            completedObject.OptionId        = sentObject.OptionId;
            completedObject.ParentNamespace = sentObject.ParentNamespace;
            completedObject.ServerName      = sentObject.ServerName;
            completedObject.SystemCode      = sentObject.SystemCode;

            // Since it is recommended that these be explicitly set prior to returning the OptionObject2, they should
            // always be set by passing "true" as the value for the "recommended" argument. The if statement does its
            // best job to catch any invalid argument values.
            if (recommended)
            {
                completedObject.EpisodeNumber = sentObject.EpisodeNumber;
                completedObject.OptionStaffId = sentObject.OptionStaffId;
                completedObject.OptionUserId  = sentObject.OptionUserId;

                // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use
                // the data that exists in the sentOptionObject.
                if (returnObject.ErrorCode >= 1)
                {
                    completedObject.ErrorCode = returnObject.ErrorCode;
                    completedObject.ErrorMesg = returnObject.ErrorMesg;
                }
                else
                {
                    completedObject.ErrorCode = sentObject.ErrorCode;
                    completedObject.ErrorMesg = sentObject.ErrorMesg;
                }
            }

            // Since it is recommended that these NOT BE explicitly set prior to returning the OptionObject2, avoid
            // setting them by passing "false" as the value for the "recommended" argument. Generally, if these fields
            // contain data when returned to myAvatar, this script will fail. The if statement does its  best job to
            // catch any invalid argument values.
            if (notRecommended)
            {
                completedObject.Forms = sentObject.Forms;
            }

            return completedObject;
        }
    }
}