# AvatoolWebService.VerifyInpatientAdmissionDate()

### CONTENTS
[INTRODUCTION](#introduction)<br>
[BEFORE YOU BEGIN](#before-you-begin)<br>
[HOW IT WORKS](#how-it-works)<br>
[INSTALLATION](#installation)<br>
[CONFIGURATION](#configuration)<br>

## INTRODUCTION
When an Admission form is submitted, The Avatool Web Service *VerifyInpatientAdmissionDate* call compares a client Pre-Admission date with the system (current) date.

If the dates match, the form is submitted normally.

If the dates do not match, the user is notified and returned to the Admission form to correct the Pre-Admission date.

## BEFORE YOU BEGIN
I would recommend that you review the sourcecode for [VerifyInpatientAdmissionDate()]().

## HOW IT WORKS
The VerifyInpatientAdmissionDate() call verifies that an existing Pre-Admission date is the same as the system date.

Here is how it works:
* When a completed Admission form is submitted, we check to if the "Admission Type" is "Pre-Admission".
* If the "Admission Type" is set to  "Pre-Admission" and the "Pre-Admission Date" is not the same as the system date, a pop-up will notify the user that they need to modify the Pre-Admission Date field to equal the system time, and the user will be returned to the form to modify the Pre-Admission Date.
* If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the same as the system date, the form is submitted normally.

## INSTALLATION
You don't *install* the VerifyInpatientAdmissionDate() call, you create a *ScriptLink event* for it.

The VerifyInpatientAdmissionDate() call is designed to be used on the **Pre-File** event of the **Admisssion Form**. The ScriptLink event should be added to the **Admission tab** of the form.

## CONFIGURATION
### REQUIRED
The VerifyInpatientAdmissionDate() call will require some customization, which will need to be done in the sourcecode.

First, you will need to verify that the following lines contain the **typeOfAdmission** and **preAdmitToAdmissionDate** FieldIDs:
```
const string typeOfAdmissionField         = "####";
const string preAdmitToAdmissionDateField = "####";
```

Next, you will need to verify that the following line contains the dictionary entry for the **PreAdmission** admission type:
```
const int preAdmission = #####;
```

### OPTIONAL
The default behavoir of the VerifyInpatientAdmissionDate() call is to display a warning that the *Pre-Admission date* does not match the *system date*, and require the user to return to the form and correct enter the correct Pre-Admit date.

This is because the Error Code, by default, is "1"
```
if (typeOfAdmission == preAdmission)
{
    if (preAdmitToAdmissionDate != systemDate)
    {
        errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date";
        errorMessageCode = 1;
    }
}
```

If you want to give users the option of ignoring the warning, and submitting the Admission form with a Pre-Admit date that doesn't match the system date, just change the Error Code to "4":
```
if (typeOfAdmission == preAdmission)
{
    if (preAdmitToAdmissionDate != systemDate)
    {
        errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date";
        errorMessageCode = 4;
    }
}
```