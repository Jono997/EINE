# EINE-Core

EINE-Core is the executable containing the core functions of the EINE plugin tha the skins will make use of.

# Usage
EINE-Core will be usable by skins in one of two ways:
- EXE: Run as an executable with the targeted EINE-Core version as the first parameter, followed by an XML file, the function and then the function's parameters.
- DLL: Reference EINE-Core.exe as a library and call the functions directly. Using this method also avoid the need to implement the EINE classes in the skin itself, but the skin must need to use .NET Framework 4.7 or higher (and may need to be written in C#? I don't know).

These two ways of using EINE-Core also call EINE-Core's functions in different ways.

# Version usage
Each version of EINE-Core is given its own namespace within the EINE-Core namespace (eg. EINE_Core.EC0.1).
This is to ensure compatability with older skins.