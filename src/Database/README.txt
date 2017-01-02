PROJECTS

Model - class library project that defines the data model. The entities are defined
 as POCO's (plain ordinary C# objects). They do not contain references to Entity Framework, 
 though they are used by E.F. when it does its object relational mapping.

DbAcess - class library project to provide database access using Entity Framework.
 It uses the object model defined in the "Model" project.

DbAccessTests - unit test of DbAccess

ReadTranscript - class library project to provide methods for reading a transcript file.

ReadTranscriptTests - unit tests of ReadTranscript

ProcessTranscriptFile - console program project to read a transcript file, load it into the
 data model in memory and then write the data to the database.

GovmeetingServer.shfbproj - A Sandcastle project that was created with Sandcastle Help File Builder (SHFB).
 It produces a documentation website in the .\documentation\Help folder. View this by opening index.html.
 Re-create the documentation by opening this project file with the SHFB GUI and running "build".
 Eventually, this step will be added as part of an automatic build process.
 

