<!--
===============================================================================
FILENAME: README.md
 PROJECT: code-repo-template
          https://github.com/aprettycoolprogram/code-repo-template
 VERSION: Version 5.1.200512.1241
 AUTHORS: development@aprettycoolprogram.com

Copyright 2019-2020 A Pretty Cool Program

Licensed under the Apache License, Version 2.0 (the "License"); you may not use
this file except in compliance with the License. You may obtain a copy of the
License at http://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed
under the License is distributed onan "AS IS" BASIS, WITHOUT WARRANTIES OR
CONDITIONS OF ANY KIND, either express or implied. See the License for the
specific language governing permissions and limitations under the License.
===============================================================================
-->

<h2 align="center">
  Codebase Repository Template
  <br>
  <br>
  <img src="https://github.com/spectrum-health-systems/avatoolwebservice/blob/master/src/avatool-web-service/AppResource/Asset/Image/Logo/avatool-webservice-logo-100x100.png" alt="Avatool Web Service" width="200">
  <br>
  <br>
  A custom Web service for Netsmart's myAvatar™ EHR
  <br>
</h2>

<div align="center">

  ![Status](https://img.shields.io/badge/status-active-brightgreen.svg)
  [![License](https://img.shields.io/github/license/spectrum-health-systems/avatool-web-service)](https://www.apache.org/licenses/LICENSE-2.0)
  ![GitHub release](https://img.shields.io/github/release/spectrum-health-systems/avatool-web-service?label=latest%20release)

</div>

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
[myAvatar™](https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar) is a behavioral health EHR developed by [Netsmart](https://www.ntst.com/) which offers a recovery-focused suite of solutions that leverage real-time analytics and clinical decision support to drive value-based care.

Like most things in life (except [Heroes of Might and Magic III](https://www.gog.com/game/heroes_of_might_and_magic_3_complete_edition)), myAvatar™ isn't perfect. The good news is that myAvatar™ functionality can be extended via [Netsmart's myAvatar™ Web Services](https://wikihelp.ntst.com/myAvatar%E2%84%A2/Avatar_Web_Services), and/or custom web services that are written by myAvatar™ users just like you!

The **Avatool Web Service** is one such custom web service that includes various tools and utilities for myAvatar™ that aren't included in the official release, and provides a solid foundation for building additional functionality quickly and efficiently.

# FEATURES
* Several built-in tools and utilities for use with myAvatar™
* A solid foundation to build additional custom tools and utilities

# REQUIREMENTS
* A location to host the Avatool Web Service (with .NET 4.6 framework installed)
* Access to your myAvatar™ environments from the Avatool Web Service via HTTPS

# BEFORE YOU BEGIN
There are a few things you should know before implementing the Avatool Web Service in your myAvatar™ environments.

### Read the manual!
Ther is a [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md), and you should read it.

### You will need to make modifications for your organization/environments
In order for the Avatool Web Service to work at your organization, in your environments, you will need to make some modifications to the sourcecode. These modifications are detailed in the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md).

### You'll need a place to host the Avatool Web Service
Netsmart will do this for you (for a price), or you can host it yourself. There are some (very basic!) instructions for self-hosting the Avatool Web Service using IIS in the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md).

### Let's talk about ScriptLink
When working with custom web services and myAvatar™, it's inevitable that you will hear about ScriptLink - and depending on who you are talking with, you are going to get different answers as to what ScriptLink is/does.

Netsmart tends to use "ScriptLink" as another way to say "custom web services", but that's not really the case. ScriptLink isn't a web service, it's essentially a *link* inside myAvatar™ that points to a *script* (or, more specifically, a *link* to a *method call in a custom web service*).

# GETTING STARTED
Before we continue, please verify you have met the [requirements](#requirements).

Also, this documentation (as well as the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md) assumes that you are self-hosting the Avatool Web Service.

# INSTALLING
Currently the Avatool Web Service isn't *installed* so much as it is *published*. The current method of publishing the web service is to just copy the entire project to where it is being hosted. This is all covered in the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md).

# USAGE
To use the Avatool Web Service with myAvatar™, you will need to add a ScriptLink event to one of the following events on a form:
* When the form loads ("Form Load")
* After the submit button is clicked, but prior to filing the form ("Pre-File")
* After the submit button is clicked and the form has been filed ("Post-File")

The [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md) explains this process in detail.

# UPDATING
Currently the Avatool Web Service isn't *updated* so much as it is *replaced*. The current method of updating the web service is to simply remove the old build, and copy the new build to your web server. This is all covered in the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md).

# UNINSTALLING
### Uninstalling the Avatool Web Service
Currently the Avatool Web Service isn't *uninstalled* so much as it is *removed*. The current method of uninstalling the web service is to simply remove the web service files from your web server. This is all covered in the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md).

### Disabling scripts in myAvatar™
Once you have imported a WSDL into myAvatar™, it cannot be removed or uninstalled, only disabled. Please see the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md) for more information about disabling scripts in myAvatar™

# DEVELOPMENT
The project is currently being developed by A Pretty Cool Program. If your interested in what's coming in the next release, the development branch of the project can be found [development branch](https://github.com/spectrum-health-systems/avatool-web-service/tree/development).

### Developing your own version of the Avatool Web Service
If you would rather start with a completely blank Avatool Web Service, or you want to create your own custom web service for myAvatar™, the [Avatool Web Service Manual](AppResource/Doc/Man/avatool-web-service-manual.md) outlines the steps to take to create an empty Web Service that can be used with myAvatar™.

### Contributors
* Chris Banwarth (https://github.com/APrettyCoolProgram)

If you are interested in contributing to this project, please see the [contributing guidelines](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/AppResource/Doc/Proj/contributing.md).

### Project resources
* [Repository](https://github.com/spectrum-health-systems/avatool-web-service)
* [Homepage](https://github.com/spectrum-health-systems/avatool-web-service)
* [Changelog](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/CHANGELOG.md)
* [Issues](https://github.com/spectrum-health-systems/avatool-web-service/issues)
* [Pull requests](https://github.com/spectrum-health-systems/avatool-web-service/pulls)
* [Project board](https://github.com/spectrum-health-systems/avatool-web-service/projects)
* [Wiki](https://github.com/spectrum-health-systems/avatool-web-service/wiki)
* [Security alerts](https://github.com/spectrum-health-systems/avatool-web-service/network/alerts)
* [Insights](https://github.com/spectrum-health-systems/avatool-web-service/pulse)
* [Code of conduct](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/repo/doc/code-of-conduct.md)
* [License](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/LICENSE.md)
* [Testing procedures](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/repo/doc/testing.md)
* [Development notes](https://github.com/spectrum-health-systems/avatool-web-service/blob/master/dev/development-notes.md)

# ACKNOWLEDGEMENTS
* [Netsmart](https://www.ntst.com/)<br>
  Developers of [myAvatar�](https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar), the behavioral health EHR that Avatool Web Service serves as an interface to.
* The [Developer's Resource Group](https://netsmartcares.force.com/s/group/0F970000000XeyJCAS/developers-resource-group) at the [Netsmart Cares Community](https://netsmartcares.force.com/)<br>
  An information resource of other developers to bounce ideas off of.
* [ScriptLinkStandard](https://github.com/rcskids/ScriptLinkStandard)<br>
  A Class Library designed to assist developers in creating SOAP web services that can be consumed by myAvatar� solution using ScriptLink. The Avatool Web Service doesn't use this project, but it's interesting to see what's being done.

# THIRD PARTY CONTENT
* [icons8.com](https://icons8.com/): Avatool Web Service logo
* [shields.io](https://shields.io/): GitHub repository badges

### RELATED PROJECTS
* [ScriptLinkStandard](https://github.com/rcskids/ScriptLinkStandard): A Class Library designed to assist developers in creating SOAP web services that can be consumed by Netsmart's myAvatar™ solution using ScriptLink.

<div align="center">

  [![Developed by](https://img.shields.io/badge/developed%20by-A%20Pretty%20Cool%20Program-17806D.svg)](https://aprettycoolprogram.com)&nbsp;
  [![GitHub](https://img.shields.io/github/followers/aprettycoolprogram.svg?label=GitHub&style=social)](https://github.com/aprettycoolprogram)&nbsp;
  [![Twitter](https://img.shields.io/twitter/follow/aprettycoolprog.svg?label=Twitter&style=social)](https://twitter.com/aprettycoolprog)&nbsp;
  [![Feedback](https://img.shields.io/badge/contact-info@aprettycoolprogram.com-17806D.svg)](mailto:feedback@aprettycoolprogram.com)&nbsp;
  [![Built using](https://img.shields.io/badge/built%20using-a--repository--template-17806D.svg)](https://github.com/aprettycoolprogram/gru-codebase-repository/)&nbsp;

</div>