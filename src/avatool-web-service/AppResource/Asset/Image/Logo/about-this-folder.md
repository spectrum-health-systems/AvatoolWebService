### AppResource/Asset/Image/Logo/
> This file is a placeholder to ensure that ***AppResource/Asset/Image/Logo/*** is included in the GitHub repository, and is also
created (if it doesn't exist already) at runtime.

#### Purpose
All project icons belong here.

#### Structure
| Folder                                   | Contents                                                          |
|-----------------------------------------:|:------------------------------------------------------------------|
| `AppResource/Asset/Image/Logo/`          | Files to be copied to `AppResource/Asset/Image/Logo/` at runtime. |
| `AppResource/Asset/Image/Logo/Embedded/` | Files built as a project resource.                                |

To copy files to `AppResource/Asset/Image/Logo/` at runtime, set the file properties as such:
```
Build Action: None
Copy to Output Directory: Copy always
```

To copy build files in `AppResource/Asset/Image/Logo//` as project resources, set the file properties as such:
```
Build Action: Resource
```