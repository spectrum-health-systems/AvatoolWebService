### AppResource/Data/*
> This file is a placeholder to ensure that the ***AppResource/Data/**** folders are included in the GitHub repository, and are also
created (if they don't exist already) at runtime.

#### Purpose
Any static data that an application needs to function should be stored here

Examples of project resources are:
* Data needed for development
* Data needed at runtime.

Please note that the any data in `AppResource/Data/*` should be static, and not modified. All dynamic/modifiable data should be stored in `AppData/*`

#### Structure
Each of the following locations may have its own folder structure.

| Folder                     | Contents                         |
|---------------------------:|:---------------------------------|
| `AppResource/Data/Config`  | Configuration data               |
| `AppResource/Data/DevMode` | Data needed for Development Mode |
| `AppResource/Data/Runtime` | Data needed at runtime           |