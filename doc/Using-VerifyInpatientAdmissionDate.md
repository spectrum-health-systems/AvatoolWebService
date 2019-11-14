# THE AVATOOL WEB SERVICE VerifyInpatientAdmissionDate CALL

## CONTENTS
[INTRODUCTION](#introduction)<br>
[BEFORE YOU BEGIN](#before-you-begin)<br>
[CREATING THE AVATOOL WEB SERVICE PROJECT](#creating-the-avatool-web-service-project)<br>
[ADDING A NEW WEB SERVICE TO THE PROJECT](#adding-a-new-web-service-to-the-project)<br>
[ADDING THE NETSMART SCRIPTLINK SERVICE TO THE PROJECT](#adding-the-netsmart-scriptLink-service-to-the-project)<br>
[ADDING REQUIRED METHODS](#adding-required-methods)<br>
[CLEANUP](#cleanup)<br>
[ADDITIONAL READING](#additional-reading)<br>

## INTRODUCTION
If you are curious as to how the Avatool Web Service was created, or you are looking for some information on creating your own custom web service for myAvatar, these are the steps I took.

## BEFORE YOU BEGIN
To create the Avatool Web Service, I used:
* Visual Studio 2019 Community version 16.3.6.
* .NET Framework 4.6, since SOAP is not supported in .NET Core
* C#

If you want to skip the steps below, you can download the [Avatool Web Service v0.0 project](https://github.com/APrettyCoolProgram/Avatool-Web-Service/releases/tag/v0.0.0.0), which was built using this document.

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

You can create multiple Web Services, with each handling different funcionality (and there are probably benefits to doing so), but the Avatool Web Service has a single Web Service that handles everything. That way it is (hopefully) easier to use.

So let's add a Web Service to the Avatool Web Service project.

1. Right click the **Avatool-Web-Service** project
2. Choose **Add** > **New Item...**
3. Choose **Visual C** > **Web** > **web Service (ASMX**)
4. Name the Web Service **AvatoolWebService.asmx**
5. Click **Add**
6. Right click the **AvatoolWebService.asmx** file and choose **Set as Start Page**

## ADDING THE NETSMART SCRIPTLINK SERVICE
In order for our new AvatoolWebService Web Service to work, we'll need to add the Netsmart ScriptLink Service to our project. The Netsmart ScriptLink Service can be found in the Applicaition Exchange on the Netsmart Cares portal.

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

```
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

Custom Web Services that interface with myAvatar require two methods to be present.

The first is `GetVersion()`
```
[WebMethod]
public string GetVersion()
{
    return "VERSION 1.0";
}
```
The second method is `RunScript()`
```
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
```
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