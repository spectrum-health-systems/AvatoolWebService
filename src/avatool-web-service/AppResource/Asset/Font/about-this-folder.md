### AppResource/Asset/Font/
> This file is a placeholder to ensure that ***AppResource/Asset/Font/*** is included in the GitHub repository, and is also
created (if it doesn't exist already) at runtime.

#### Purpose
All project fonts belong here.

#### Structure
| Folder                             | Contents                                                    |
|-----------------------------------:|:------------------------------------------------------------|
| `AppResource/Asset/Font/`          | Files to be copied to `AppResource/Asset/Font/` at runtime. |
| `AppResource/Asset/Font/Embedded/` | Files built as a project resource.                          |

To copy files to `AppResource/Asset/Font/` at runtime, set the file properties as such:
```
Build Action: None
Copy to Output Directory: Copy always
```

To copy build files in `AppResource/Asset/Font/Embedded/` as project resources, set the file properties as such:
```
Build Action: Resource
```