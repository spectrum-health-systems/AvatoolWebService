# SETTING UP IIS v10 FOR THE AVATAR WEB SERVICE
*Last updated May 20, 2020*

### CONTENTS
[INTRODUCTION](#introduction)<br>
[BEFORE YOU BEGIN](#before-you-begin)<br>
[SETTING UP IIS](#setting-up-iis)<br>
[ADDITIONAL FUNCTIONALITY](#additional-functionality)<br>

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