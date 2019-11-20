# AVATOOL WEB SERVICE DEVELOP<ENT NOTES
## ROADMAP
#### v1.1.0.0
* Split actions into seperate classes
* Split returning the OO2 into a seperate class

#### v1.2.0.0
* Add Appointment Scheduler code



#### QUEUE
* actionRequest list in external file
* JSON files define what each actionRequest does


VerifyInpatientAdmissionDate.cs.VerifyInpatientAdmissionDate()

Should this block use "int.TryParse" or "Convert.Int32"?

    if (field.FieldNumber == typeOfAdmissionFieldId)
    {
        typeOfAdmission = int.Parse(field.FieldValue);
    }

