<!---------------------------------------------------------------------------------------------------------------------
FILENAME: README.md
 PROJECT: gru-codebase-repository(https://github.com/aprettycoolprogram/gru/src/gru-repository-template)
 VERSION: Version 4.0.0.200114
 UPDATED: 01-14-2020 (9:00 PM)
 AUTHORS: development@aprettycoolprogram.com

Copyright 2019-2020 A Pretty Cool Program

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
specific language governing permissions and limitations under the License.
---------------------------------------------------------------------------------------------------------------------->

<!-- INFORMATION-------------------------------------------------------------------------------------------------------
This is a customizable README.md template written in GitHub-flavored Markdown (content) and HTML (layout). The source
contains an abundance of comments walking you through how to use each component.
---------------------------------------------------------------------------------------------------------------------->

<h2 align="center">
  Avatool Web Service
  <br>
  <img src="https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/repo/image/logo/avatool-webservice-logo-100x100.png" alt="Avatool Web Service" width="200">
  <br>
  A custom Web service for Netsmart's myAvatar™ EHR
  <br>
  <br>
</h2>
<br>

<div align="center">

  ![Status](https://img.shields.io/badge/status-active-brightgreen.svg)
  [![License](https://img.shields.io/github/license/spectrum-health-systems/avatoolwebservice)](https://www.apache.org/licenses/LICENSE-2.0)
  ![GitHub release](https://img.shields.io/github/release/spectrum-health-systems/avatoolwebservice?label=latest%20release)

</div>


<!-- TABLE OF CONTENTS [Optional] -------------------------------------------------------------------------------------
A Table of Contents allows users to quickly find exactly what they are looking for.
----------------------------------------------------------------------------- (Remove this comment block when done) -->
<h5 align="left">

  ### CONTENTS
  [ABOUT THIS REPOSITORY](#about-this-repository)<br>
  [FEATURES](#features)<br>
  [REQUIREMENTS](#requirements)<br>
  [BEFORE YOU BEGIN](#before-you-begin)<br>
  [GETTING STARTED](#getting-started)<br>
  [INSTALLING](#installing)<br>
  [USAGE](#usage)<br>
  [UPDATING](#updating)<br>
  [UNINSTALLING](#uninstalling)<br>
  [DEVELOPMENT](#development)<br>

</h5>

# ABOUT THIS REPOSITORY
[myAvatar™](https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar) is a behavioral health EHR, developed by [Netsmart](https://www.ntst.com/), that offers a recovery-focused suite of solutions that leverage real-time analytics and clinical decision support to drive value-based care.

While myAvatar™ is a robust platform, like most things in life (except [Heroes of Might and Magic III](https://www.gog.com/game/heroes_of_might_and_magic_3_complete_edition)), it isn't perfect.

The good news is that myAvatar™ functionality can be extended via Netsmart's myAvatar™ Web Services, and/or custom web services that are written by myAvatar™ users.

The Avatool Web Service is one such custom web service which includes various tools and utilities for myAvatar™ that aren't included in the official release, and provides a solid foundation for building additional functionality quickly and efficiently.

# FEATURES
* Several built-in tools and utilities for use with myAvatar™
* A solid foundation to build additional custom tools and utilities

# REQUIREMENTS
* A location to host the Avatool Web Service
* Access to your myAvatar™ environments from the Avatool Web Service via HTTPS

# BEFORE YOU BEGIN
There are a few things you should know before using the Avatool Web Service in your myAvatar™ environments.

#### You will probably need to customize some stuff
Some components of the Avatool Web Service will need to be customized before they can be used at your organization.

These components, and the customization that they require, are detailed various documents in this repository. You'll know what needs to be changed, and what it needs to be changed to, as long as you follow the instructions.

#### You'll need a place to host the Avatool Web Service
You'll also need a location to host the Avatool Web Service. In our environment, the Avatool Web Service resides on a Microsoft Windows Server 2019 with IIS v10. I took some notes on [setting up IIS](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/doc/setting-up-iis.md) (YMMV!) for the Avatool Web Service, if you decide to go that route.

You can also have Netsmart host your custom web services (for a fee), but the Avatool Web Service has not been tested in a hosted environment.

#### Let's talk about ScriptLink
When working with custom web services and myAvatar™, it's inevitable that you will hear about ScriptLink. And depending on who/what is describing what ScriptLink is/does, you are going to get different answers.

Netsmart tends to use "ScriptLink" as another way to say "custom web services", but that's not really the case. I mean, a "custom web service" is just that - a web service. ScriptLink isn't a web service.

As far as I can tell, ScriptLink is simply a *link* to a *script*. Or, more specifically, a *link* to a *custom web service*. Or, even more specifically, *something that calls a method in a custom web service when something is done with/on a form in myAvatar™*.

In closing, in my experience, ScriptLink is essentially a line of code in the form designer that kicks off the magical stuff you've written in a custom web service.

# GETTING STARTED
Before we continue, please verify you have met the [requirements](#requirements).

### PRE-REQUISITES
If you are self-hosting the Avatool Web Service, you will need a web server that:
* Serves data via HTTPS
* Includes the .NET 4.6 framework

# INSTALLING
The Avatool Web Service isn't *installed* so much as it is *published*.

The current method of publishing the web service is to just copy the entire project to where it is being hosted. Future versions of the Avatool Web Service will utilize the publishing functionality of Visual Studio.

# USAGE
To use the Avatool Web Service with myAvatar™, you will need to add a ScriptLink event to one of the following events on a form:
* when the form loads ("Form Load")
* after the submit button is clicked, but prior to filing the form ("Pre-File")
* after the submit button is clicked and the form has been filed ("Post-File")

You can also use custom web services with fields and controls, but that is beyond the scope of this documentation.

### ADDING A SCRIPT LINK EVENT TO A FORM
In order to have the Avatar Web Service do something, you need to have something *call* the web service. You'll do this by adding a ScriptLink event on the form you're working with. In order to do this:
1. Open the **Form Designer** form
2. Choose the myAvatar™ form you want to use from the **Forms** dropdown
3. Choose the form tab from the **Tabs** dropdown
4. Click the **Show Tab** button

You will now see the form tab in designer mode. In the upper left of myAvatar™ you will see a **Settings** button:

![Form Designer settings](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/image/readme/form-designer-settings-button.png)

Clicking the **Settings** button will bring you to the ScriptLink options page:

![Blank ScriptLink options](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/image/readme/scriptlink-blank.png)

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

### AVATOOL WEB SERVICE CALLS
Currently there is a single call in the Avatool Web Service:
* [**VerifyInpatientAdmissionDate**](https://github.com/spectrum-health-systems/AvatoolWebService/blob/development/doc/using-VerifyInpatientAdmissionDate.md): verifies that a client's Pre-Admission Date is the same as the current date.

# UPDATING
Currently, the process of updating the Avatool Web Service is to simply remove the old build, and copy the new build to your web server.

# UNINSTALLING
Once you have imported a WSDL into myAvatar™, it cannot be removed. There is no "uninstall".

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

# DEVELOPMENT
The project is currently being developed by A Pretty Cool Program. If your interested in what's coming in the next release, the development branch of the project can be found [development branch](https://github.com/spectrum-health-systems/AvatoolWebService/tree/development).

If you would rather start with a completely blank Avatool Web Service, or you want to create your own custom web service for myAvatar™, you can follow the instructions for [creating the Avatool Web Service](https://github.com/spectrum-health-systems/AvatoolWebService/blob/development/doc/creating-a-new-avatool-web-service-project.md). This will give you an empty Web Service that can be used with myAvatar™.

### CONTRIBUTING
If you are interested in contributing to this project, please see the [contributing guidelines](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/doc/contributing.md).

### ACKNOWLEDGEMENTS
* All icons are from [Icons8](https://icons8.com)

### PROJECT RESOURCES
* [Repository](https://github.com/spectrum-health-systems/avatoolwebservice)
* [Homepage](https://github.com/spectrum-health-systems/avatoolwebservice)
* [Changelog](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/CHANGELOG.md)
* [Issues](https://github.com/spectrum-health-systems/avatoolwebservice/issues)
* [Pull requests](https://github.com/spectrum-health-systems/avatoolwebservice/pulls)
* [Project board](https://github.com/spectrum-health-systems/avatoolwebservice/projects)
* [Wiki](https://github.com/spectrum-health-systems/avatoolwebservice/wiki)
* [Security alerts](https://github.com/spectrum-health-systems/avatoolwebservice/network/alerts)
* [Insights](https://github.com/spectrum-health-systems/avatoolwebservice/pulse)
* [Code of conduct](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/repo/doc/code-of-conduct.md)
* [License](https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/LICENSE.md)
* [Testing procedures](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/repo/doc/testing.md)
* [Development notes](https://github.com/spectrum-health-systems/AvatoolWebService/blob/master/dev/development-notes.md)

### RELATED PROJECTS
* [ScriptLinkStandard](https://github.com/rcskids/ScriptLinkStandard): A Class Library designed to assist developers in creating SOAP web services that can be consumed by Netsmart's myAvatar™ solution using ScriptLink.

<div align="center">

  [![Developed by](https://img.shields.io/badge/developed%20by-A%20Pretty%20Cool%20Program-17806D.svg)](https://aprettycoolprogram.com)&nbsp;
  [![GitHub](https://img.shields.io/github/followers/aprettycoolprogram.svg?label=GitHub&style=social)](https://github.com/aprettycoolprogram)&nbsp;
  [![Twitter](https://img.shields.io/twitter/follow/aprettycoolprog.svg?label=Twitter&style=social)](https://twitter.com/aprettycoolprog)&nbsp;
  [![Feedback](https://img.shields.io/badge/contact-info@aprettycoolprogram.com-17806D.svg)](mailto:feedback@aprettycoolprogram.com)&nbsp;
  [![Built using](https://img.shields.io/badge/built%20using-a--repository--template-17806D.svg)](https://github.com/aprettycoolprogram/gru-codebase-repository/)&nbsp;

</div>