### AppResource/Asset/Image/Icon/
> This file is a placeholder to ensure that ***AppResource/Asset/Image/Icon/*** is included in the GitHub repository, and is also
created (if it doesn't exist already) at runtime.

#### Purpose
All project icons belong here.

#### Structure
| Folder                                   | Contents                                                          |
|-----------------------------------------:|:------------------------------------------------------------------|
| `AppResource/Asset/Image/Icon/`          | Files to be copied to `AppResource/Asset/Image/Icon/` at runtime. |
| `AppResource/Asset/Image/Icon/Embedded/` | Files built as a project resource.                                |

To copy files to `AppResource/Asset/Image/Icon/` at runtime, set the file properties as such:
```
Build Action: None
Copy to Output Directory: Copy always
```

To copy build files in `AppResource/Asset/Image/Icon/` as project resources, set the file properties as such:
```
Build Action: Resource
```