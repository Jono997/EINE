# EINE

EINE (EINE Is Not EVEC) is a plugin for UTAU that serve multiple different functions.
EINE has been around for a year or so prior as a closed source project, but I'm now going to make it open source, but I'm redoing the code from scratch to fit with what I want EINE to be able to do in the future.

# How EINE will be structured
EINE will be structured into three parts: EINE-Core, EINE-Skin and EINE-Entry. One may see that EINE Studio is not part of this structure. EINE Studio is a separate application from the plugin and not part of the structure.
EINE-Core is the executable containing the core classes and processes that EINE makes use of.
EINE-Skin is a colloquial term for the "Skins" that will be made for EINE. Skins are the frontend of the EINE plugin, displaying a UI for users to use.
EINE-Entry is the entry point of the EINE plugin, the executable that UTAU will actually run when running the plugin. This executable will handle loading the skin.

# Current funcitionality
- EINE-Core can read and write to UST files and UTAU is able to process them properly.

# To-do list
- Define the classes in EINE-Core
- Write the functions in EINE-Core
- Achieve feature parity with EINE 2.1.1
- Basically everything