# Avatool Web Service Manual
> v2.0

***THIS DOCUMENT IS A WORK IN PROGRESS!***
***LAST UPDATED 6/30/20***

# ADDING A SCRIPT LINK EVENT TO A FORM
In order to have the Avatar Web Service do something, you need to have something *call* the web service. You'll do this by adding a ScriptLink event on the form you're working with. In order to do this:
1. Open the **Form Designer** form
2. Choose the myAvatar™ form you want to use from the **Forms** dropdown
3. Choose the form tab from the **Tabs** dropdown
4. Click the **Show Tab** button

You will now see the form tab in designer mode. In the upper left of myAvatar™ you will see a **Settings** button:

![Form Designer settings](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/AppResource/Asset/Image/Document/Manual/form-designer-settings-button.png)

Clicking the **Settings** button will bring you to the ScriptLink options page:

![Blank ScriptLink options](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/AppResource/Asset/Image/Document/Manual/scriptlink-blank.png)

The first thing you will need to do is import the Avatool Web Service WSDL. Before you actually click the **Import** button, you should make sure that the WSDL URL is correct. You can verify the WDSL URL by typing it into a web browser address bar.

For example, URL of `https://your-organization.com/AvatoolWebService.asmx?WSDL` should display XML that looks something like this:

![XML example](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/image/readme/xml-example.png)

If you see the XML:
1. Copy/paste the URL from your browsers address bar into the **Import WSDL for ScriptLink** field in myAvatar™
2. Click the **Import** button.

You should get a popup letting you know the WSDL was imported successfully.

Next we will need to choose an event that will call the Avatool Web Service, and determine the action that will take place. This will all be done on the ScriptLink options page:

![ScriptLink options example](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/image/readme/scriptlink-example.png)

Our example will call the *VerifyInpatientAdmissionDate* action on the form's *Pre-File* event:
1. Click the dropdown in the **Pre-File** row under the **Availble Scripts** column
2. Choose **AvatoolWebService** (the *red* box)
3. Type "VerifyInpatientAdmissionDate" in the **Pre-File** row under the **Script Parameter** column (the *purple* box)
4. Uncheck the **Disable All Scripts For Form** and **Disable All Scripts on Error** boxes  (the *green* box)
5. Click **Return to Designer** (the *yellow* box), and the ScriptLink options page will close, and you will be back on the **Tab Designer** page
6. Click the **Save** button, and you bw returned to the **Form Designer** page
7. Click **Submit**


# METHOD CALLS
Currently there is a single call in the Avatool Web Service:
* [**VerifyInpatientAdmissionDate**](https://github.com/spectrum-health-systems/AvatoolWebService/blob/development/doc/using-VerifyInpatientAdmissionDate.md): verifies that a client's Pre-Admission Date is the same as the current date.



# DISABLING
What you can do, though, is check the **Disable All Scripts For Form** and **Disable All Scripts on Error** boxes on the ScriptLink options page, which will ScriptLink from calling any custom web services.

In order to do this:
1. Open the **Form Designer** form
2. Choose the myAvatar™ form you want to use from the **Forms** dropdown
3. Choose the form tab from the **Tabs** dropdown
4. Click the **Show Tab** button

You will now see the form tab in designer mode. In the upper left of myAvatar™ you will see a **Settings** button:

![Form Designer settings](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/image/readme/form-designer-settings-button.png)

Clicking the **Settings** button will bring you to the ScriptLink options page:

![ScriptLink options example](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/image/readme/scriptlink-example.png)

Then, make sure both **Disable All Scripts For Form** and **Disable All Scripts on Error** boxes on the ScriptLink options page are checked, which will ScriptLink from calling any custom web services.

![Blank ScriptLink options](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/image/readme/scriptlink-blank.png)





# CREATING THE AVATOOL WEB SERVICE

## INTRODUCTION
If you are curious as to how the Avatool Web Service was created, or you are looking for some information on creating your own custom web service for myAvatar™, these are the steps I took.

## BEFORE YOU BEGIN
To create the Avatool Web Service, I used:
* Visual Studio 2019 Community version 16.3.6.
* .NET Framework 4.6, since SOAP is not supported in .NET Core
* C#

## CREATING THE AVATOOL WEB SERVICE PROJECT
First, we need to create an empty ASP.NET Web Application project. Using Visual Studio 2019:

1. Go to **File** > **New** > **Project...**
2. Select **ASP.NET Web Application (.NET Framework)**
3. Click **Next**
4. Name the project *Avatool-Web-Service*
5. Verify that **.NET Framework 4.6** is selected
6. Click **Create**
7. In the **Create a new ASP.NET Core Web Application** dialog, select **Empty**
8. Verify that **Configure for HTTPS** (under **Advanced**) is checked
9. Click **Create**

## ADDING A NEW WEB SERVICE TO THE PROJECT
Now you have a brand new project for the Avatool Web Service, but since we created an empty project, it doesn't actually have any Web Services assigned to it.

You can create multiple Web Services, with each handling different functionality (and there are probably benefits to doing so), but the Avatool Web Service has a single Web Service that handles everything. That way it is (hopefully) easier to use.

So let's add a Web Service to the Avatool Web Service project.

1. Right click the **Avatool-Web-Service** project
2. Choose **Add** > **New Item...**
3. Choose **Visual C** > **Web** > **web Service (ASMX**)
4. Name the Web Service **AvatoolWebService.asmx**
5. Click **Add**
6. Right click the **AvatoolWebService.asmx** file and choose **Set as Start Page**

## ADDING THE NETSMART SCRIPTLINK SERVICE
In order for our new AvatoolWebService Web Service to work, we'll need to add the Netsmart ScriptLink Service to our project. The Netsmart ScriptLink Service can be found in the Application Exchange on the Netsmart Cares portal.

### OBTAINING THE NETSMART SCRIPTLINK SERVICE
1. Login to the *Netsmart Cares portal*
2. Go to the *Application Exchange* by choosing **Community** > **App Exchange**
3. Under **Quick Links** choose **Avatar ScriptLink Library**

The Netsmart ScriptLink Service is bundled with the "Brief ScriptLink Tutorial with OptionObject2".

As of November 2019, the "Brief ScriptLink Tutorial with OptionObject2" was seven entries down, and released on 12/27/2013 by Iam Notreal.

4. Find the "Brief ScriptLink Tutorial with OptionObject2" entry, and click **Download**

The downloaded file is a .zip archive, which you'll need to extract. Once extracted:

1. Copy the extracted folder to the root of the Avatool Web Service project:
   ```
   136_180_9_ScriptLinkTutorialWithOptionObject2/ScriptLinkTutorialWithOptionObject2/DotNetCode/ScriptLinkServiceComplete/NTST.ScriptLinkService.Objects/
   ```

When complete, the folder structure of the Avatool Web Service project should look like this:
```
    /bin/
    /NTST.ScriptLinkService.Objects/
    /obj/
    /packages/
    /Properties/
    /AvatoolWebService.asmx
    /AvatoolWebService.asmx.cs
    ...
```
### ADDING A REFERENCE TO THE NETSMART SCRIPTLINK SERVICE
Now we need to add a reference to the Netsmart ScriptLink Service to our project.

1. Right-click the **Avatool-Web-Service** solution and choose **Add** > **Existing Project..**
2. Navgate to the **NTST.ScriptLinkService.Objects** folder in the */Avatool-Web-Wervice/*
3. Choose the  **NTST.ScriptLinkService.Objects.vbproj** file
4. Click **Open**

If a message pops up letting you know that the Netsmart ScriptLink Service targets a .NET Framework version that's not installed (in this case, .NET 3.5), choose the **Change the target to .NET Framework 4.6.1...** option, then click **OK**.

Next we need to add a Netsmart ScriptLink Service reference to the Avatool Web Service project

10. Right-click the **Avatool-Web-Service** project and choose **Add** > **Reference..**
11. Under **Projects**, check the box that says **NTST.ScriptLinkService.Objects**
12. Click **OK**

# ADDING REQUIRED METHODS
Your *AvatoolWebService.asmx.cs* file should look like this:

```c#
using System.Web.Services;

namespace Avatool_Web_Service
{
    /// <summary>
    /// Summary description for AvatoolWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class AvatoolWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
```

Custom Web Services that interface with myAvatar™ require two methods to be present.

The first is `GetVersion()`
```c#
[WebMethod]
public string GetVersion()
{
    return "VERSION 1.0";
}
```
The second method is `RunScript()`
```c#
[WebMethod]
public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
{
    switch (action)
    {
        case "doSomething":
            return methodName(sentOptionObject);
        default:
            break;
    }
    return sentOptionObject;
}
```

Replace the `HelloWorld()` method with the `GetVersion()` and `RunScript()` methods, and add a `using NTST.ScriptLinkService.Objects` statment to the file.

The modified file should look like this:
```c#
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace Avatool_Web_Service
{
    /// <summary>
    /// Summary description for AvatoolWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class AvatoolWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        [WebMethod]
        public OptionObject2 RunScript(OptionObject2 sentOptionObject, string action)
        {
            switch (action)
            {
                case "doSomething":
                    return MethodName(sentOptionObject);
                default:
                    break;
            }
            return sentOptionObject;
        }

        public static OptionObject2 MethodName(OptionObject2 sentOptionObject)
        {
            return new OptionObject2();
        }
    }
}
```
# CLEANUP
Prior to starting development, I spent some time adding headers to files, creating various development files (i.e. changelogs, roadmaps).




# SETTING UP IIS v10 FOR THE AVATAR WEB SERVICE
*Last updated May 20, 2020*

## INTRODUCTION
You'll also need a location to host the Avatool Web Service. In our environment, the Avatool Web Service resides on a Microsoft Windows Server 2019 with IIS. These are the notes I took when setting up IIS.

You can also have Netsmart host your custom web services (for a fee), but the Avatool Web Service has not been tested in a hosted environment.

## BEFORE YOU BEGIN
These notes/steps aren't perfect, so YMMV.

## SETTING UP IIS
### INSTALLING IIS
1. Start the "Add Roles and Features Wizard" from the Server Manager Dashboard.
2. On the "Installation Type" page, choose "Rold-based or feature-based installation"
3. On the "Server Selection" page, choose your server
4. On the "Server Roles" page, check "Web Server (IIS)
5. When the popup appears detailing the required tools, click "Add Features"
6. On the "Features" page, make sure the following ".NET 4.7 Features" options are checked:
    * .Net Framework 4.7
    * ASP.NET 4.7
    * WCF Services > TCP Port Sharing
7. On the "Role Services" page, make sure the following options are checked:
    * HTTP Redirection
    * FTP Server

### CREATING AN APPLICATION POOL
I’m not sure this step is necessary, but it helps to make things a little more organized…maybe? I’m not an IIS expert, so I’m not sure.

Right-click the **Application Pools** connection, and choose **Add Application Pool…**.

The new application pool should be a *.NET 4.0 CLR (.NET 4.5)* pool. I’ve chosen .NET 4.5, since it lines up with the Netsmart ScriptLink Objects that we will be using, but you can choose another .NET version.

I’ve named the application pool *AvatoolWebService*.

This is what my application pool setup looks like:

![Application Pool example](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/doc/image/setup-iis/application-pool-example.png)

Again, I’m sure that all of these are not necessary, nor do all of the application pools need to be started.

### DISABLE THE DEFAULT WEBSITE
Right-click the Default Web Site, then **Manage Web Site** > **Stop**

### CREATE A NEW SITE
Right-click the **Sites** connection, and choose **Add Website…**.

![New Site example](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/doc/image/setup-iis/new-site-example.png)

Complete the following fields:
* Site name: *AvatoolWebService*
* Application pool: *AvatoolWebService*
* Physical path: */path/to/your/files/* (Mine is "c:\AvatoolWebService)

For now, leave the Binding section alone, and click "OK"

If you get a warning about duplicate sites using port 80

### INSTALL THE ASP.NET ROLE
ASP.NET is required by Web Services, so add the ASP.NET role to IIS.

Once that’s done, your IIS roles should look like this:

![Roles example](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/doc/image/setup-iis/roles-example.png)

And your AvatoolWebService site should look like this:

![Home example](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/doc/image/setup-iis/home-example.png)

### ENABLE DIRECTORY BROWSING
Double-click on the **Directory Browsing** icon

![Directory Browsing example](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/doc/image/setup-iis/directory-browsing-example.png)

Choose **Enable**, then **Apply**.

At this point, you should be able to point a browser to your website, and see the landing page.

### ADDITIONAL FUNCTIONALITY
I'm going to try to put together some documentation for the following, but for now you will also need to:
* Add the FTP Server Role to IIS
* Install an SSL Certificate








# AvatoolWebService.VerifyInpatientAdmissionDate()

## INTRODUCTION
When an Admission form is submitted, The Avatool Web Service *VerifyInpatientAdmissionDate* call compares a client Pre-Admission date with the system (current) date.

If the dates match, the form is submitted normally.

If the dates do not match, the user is notified and returned to the Admission form to correct the Pre-Admission date.

## BEFORE YOU BEGIN
I would recommend that you review the sourcecode for [VerifyInpatientAdmissionDate()](https://raw.githubusercontent.com/spectrum-health-systems/AvatoolWebService/master/src/AvatoolWebService.asmx.cs).

## HOW IT WORKS
The VerifyInpatientAdmissionDate() call verifies that an existing Pre-Admission date is the same as the system date.

Here is how it works:
* When a completed Admission form is submitted, we check to if the "Admission Type" is "Pre-Admission".
* If the "Admission Type" is set to  "Pre-Admission" and the "Pre-Admission Date" is not the same as the system date, a pop-up will notify the user that they need to modify the Pre-Admission Date field to equal the system time, and the user will be returned to the form to modify the Pre-Admission Date.
* If the "Admission Type" is not set to "Pre-Admission", or if it is and the Pre-Admission Date is the same as the system date, the form is submitted normally.

## INSTALLATION
You don't *install* the VerifyInpatientAdmissionDate() call, you create a *ScriptLink event* for it.

The VerifyInpatientAdmissionDate() call is designed to be used on the **Pre-File** event of the **Admission Form**. The ScriptLink event should be added to the **Admission tab** of the form.

## CONFIGURATION
### REQUIRED
The VerifyInpatientAdmissionDate() call will require some customization, which will need to be done in the sourcecode.

First, you will need to verify that the following lines contain the **typeOfAdmission** and **preAdmitToAdmissionDate** FieldIDs:
```c#
const string typeOfAdmissionField         = "####";
const string preAdmitToAdmissionDateField = "####";
```

Next, you will need to verify that the following line contains the dictionary entry for the **PreAdmission** admission type:
```c#
const int preAdmission = #####;
```

### OPTIONAL
The default behavoir of the VerifyInpatientAdmissionDate() call is to display a warning that the *Pre-Admission date* does not match the *system date*, and require the user to return to the form and correct enter the correct Pre-Admit date.

This is because the Error Code, by default, is "1"
```c#
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
```c#
if (typeOfAdmission == preAdmission)
{
    if (preAdmitToAdmissionDate != systemDate)
    {
        errorMessageBody = "WARNING\nThe Pre-Admission date does not match today's date";
        errorMessageCode = 4;
    }
}
```