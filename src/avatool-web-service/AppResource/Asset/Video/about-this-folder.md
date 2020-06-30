### AppResource/Asset/Video/
> This file is a placeholder to ensure that ***AppResource/Asset/Video/*** is included in the GitHub repository, and is also
created (if it doesn't exist already) at runtime.

#### Purpose
All project videos belong here.

#### Structure
| Folder                              | Contents                                                     |
|------------------------------------:|:-------------------------------------------------------------|
| `AppResource/Asset/Video/`          | Files to be copied to `AppResource/Asset/Video/` at runtime. |
| `AppResource/Asset/Video/Embedded/` | Files built as a project resource.                           |

To copy files to `AppResource/Asset/Video/` at runtime, set the file properties as such:
```
Build Action: None
Copy to Output Directory: Copy always
```

To copy build files in `AppResource/Asset/Video/Embedded/` as project resources, set the file properties as such:
```
Build Action: Resource
```