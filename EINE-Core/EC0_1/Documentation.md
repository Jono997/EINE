# Classes

## Note
The class representing an UTAU note

### Properties
Index (int): The position of the Note object in the parent UST object. If -1, this is the PREV note. If -1, this is the NEXT note.

RawHeader (string): The header of the note as written by UTAU

Misc (string string SerializableDictionary): All the unprocessed information in the note. This includes information that is used and processed by EINE, but in an unprocessed form.

### Constructors
No params: Creates a Note object with no information.

note_raw (string): Creates a Note object from the serialised note from UTAU.

### Methods
InterpretNotedProperties: Reads through Misc to set the other properties of the object. Currently an empty function.

InterpretMisc: Reads through this object's properties to set certain values of Misc. Currently an empty function.

## UST
The class representing a UST/information passed to a plugin.

### Properties
Notes (Note array): The notes in the UST.

Raw (string): The raw information passed to EINE from UTAU.

RawOrganised (string array): The raw information passed to EINE from UTAU organised into sections by headers.

### Constructors
No params: Creates a UST object with no information

raw (string): Creates a UST object from the information passed to EINE from UTAU

### Methods
InterpretNotedProperties: Reads through RawOrganised to set the other properties of this object.

InterpretRawOrganised: Reads through Raw to create RawOrganised.

InterpretRaw: Reads through RawOrganised to create Raw

SaveXML (string file): Saves this object to XML

LoadXML (string file): Loads this object from XML

SaveUST (string file): Saves this object in the format used by UTAU. Use the string constructor for UST to load from this format.

## Common
The class holding common information used by EINE-Core

### Properties
Newline (string): The newline format used in UST files

PREV (string): The header information used by UTAU to
label a note as before the selection

NEXT (string): The header information used by UTAU to
label a note as after the selection

### Methods
CanBeInt (string check): Checks to see if check can be converted into an int without issue.