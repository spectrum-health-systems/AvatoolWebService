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