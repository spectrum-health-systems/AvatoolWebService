# SETTING UP IIS v10 FOR THE AVATAR WEB SERVICE

## CONTENTS
[INTRODUCTION](#introduction)<br>
[BEFORE YOU BEGIN](#before-you-begin)<br>
[SETTING UP IIS](#setting-up-iis)<br>
[ADDITIONAL FUNCTIONALITY](#additional-functionality)<br>

## INTRODUCTION
You'll also need a location to host the Avatool Web Service. In our environment, the Avatool Web Service resides on a Microsoft Windows Server 2019 with IIS. These are the notes I took when setting up IIS.
You can also have Netsmart host your custom web services (for a fee), but the Avatool Web Service has not been tested in a hosted environment.

## BEFORE YOU BEGIN
These notes/steps aren't perfect, and I don't plan on updating them, so YMMV.

## SETTING UP IIS
### INSTALLING IIS
I'm not going to document the procedure for adding the IIS role to a server, as it's pretty straight forward.

### CREATING AN APPLICATION POOL
I’m not sure this step is necessary, but it helps to make things a little more organized…maybe? I’m not an IIS expert, so I’m not sure.

Right-click the **Application Pools** connection, and choose **Add Application Pool…**.

The new application pool should be a *.NET 4.0 CLR (.NET 4.5)* pool. I’ve chosen .NET 4.5, since it lines up with the Netsmart ScriptLink Objects that we will be using, but you can choose another .NET version.

I’ve named the application pool *AvatoolWebService*.

This is what my application pool setup looks like:

![Application Pool example]()

Again, I’m sure that all of these are not necessary, nor do all of the application pools need to be started.

### CREATE A NEW SITE
Right-click the **Sites** connection, and choose **Add Website…**.

![Application Pool example]()

Complete the following fields:
* Site name: *AvatoolWebService*
* Application pool: *AvatoolWebService*
* Physical path: */path/to/your/files/*
  
You will also need to setup the site bindings for both port 80 and 443.

### DISABLE THE DEFAULT WEBSITE
Might as well.

Right-click the Default Web Site, then **Manage Web Site** > **Stop**

### INSTALL THE ASP.NET ROLE
ASP.NET is required by Web Services, so add the ASP.NET role to IIS.

Once that’s done, your IIS roles should look like this:

![Roles example]()

And your AvatoolWebService site should look like this:

![Home example]()

### ENABLE DIRECTORY BROWSING
Double-click on the **Directory Browsing** icon

![Directory Browsing example]()

Choose **Enable**, then **Apply**.

At this point, you should be able to point a browser to your website, and see the landing page.

### ADDITIONAL FUNCTIONALITY
I'm going to try to put together some documentation for the following, but for now you will also need to:
* Add the FTP Server Role to IIS
* Install an SSL Certificate