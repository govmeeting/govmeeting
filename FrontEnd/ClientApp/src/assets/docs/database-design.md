# Overview

Currently these are two separate database instances, but these will eventually be merged into one.

1. Database for registered users.
This is used in the Server/WebApp project. It was created automatically by Microsoft Identity Service when "Authentication = Individual User Accounts" was checked when the project was first built.

2. Database for data extracted from processed transcripts.
This is used in the Database/LoadTranscriptIntoDb project. This was created by the "Code First" feature of Entity Framework. The C# classes in the "Database/Model" project library were first written. Then EF automatically generated the database schema and tables.

Since the projects were first created in Visual Studio, they were created as SQL Server LocalDb databases. If you have [SQL Server Data Tools](https://docs.microsoft.com/en-us/sql/ssdt/download-sql-server-data-tools-ssdt) installed, you can open and view the database contents by accssing them in this way:

* Open SQL Server Object Explorer
* Right-click on "SQL Server" and select "Add SQL Server".
* Enter "(localdb)\MSSQLLocalDB" as the server name.
* Click "Select". A new server will appear under "SQL Server".

You can now view and/or modify both databases. The registered user database is named "govmeeting". The transcript database is named "Govmeeting.Backend.DbAccess.MeetingContext". This was a name automatically generated from the project name at the time the DB was created.


# Transcript Database Schema

## "Government Entity" table

Field	| Meaning	| Example-1	| Example-2	| Example-3
------------- | ------------- | ------------- | ------------- | -----------
PrimaryKey | unique key | 1 | 2	| 3
Name | name of entity | Senate | Assembly | Planning Board |
Country | country location |U.S.A | U.S.A	| U.S.A |
State | state location | | Iowa	| New Jersey |
County | county or region location | | | Gloucester |
Municipal | city or town | | | Monroe Township |

*More examples for Government Entity table

Field | Example-4 | Example-5
--- | --- | ---
PrimaryKey | 4 | 5
Name |	Vidhan Sabha | Municipal Council
Country | India | India
State | Andhra Pradesh	| Andhra Pradesh
County	| | Kadapa district | 
Municipal | | Rayachoty | 

Note that if the government entity is at the national level, its state, county and municipal locations are null. If the entity is at the state level, its county & municipal locations are null, etc.

I need to expand these example for other countries. If you are reading this and have other examples, or reasons why this will not work for some countries, please add comments below.

## "Meeting" table

Field | Meaning | Example-1 | Example-2
--- | --- | --- | ---
PrimaryKey | unique key | 1 | 2
GovEntity | key to government entity | 2 (U.S Senate) | 4 (Vidhan Sabha)
Time | meeting time | Aug 3, '14 19:30 | May 2, '14 13:00
Text | transcription text | "The meeting will come to order. ..." | "The assembly will convene. ..."

The speakers at the meetings could be representatives of the governing entity or of the general public. In either case, there can be the same people attending meetings in more than one government entity. We will want to track  what the same representative says across each of the bodies of which he/she is a member. Therefore we need a unique identifier for each representative.

We will need to decide on what information is required for this identification. We obviously won't have a person's national identity number of something of that nature. We may need to use a combination of more than one field to identify someone. For example, address and name.

There will be a "Representative" table which contains a unique personal identifier for each representative.

## "Representative" table

Field | Meaning | Example-1 | Example-2
--- | --- | --- | ---
PrimaryKey | unique key | 1 | 2
FullName | full name | Rep. Steve Jones | Chairman Ravi Anand
Identifier | personal identifier | (to be decided | (to be decided)

There will also be a table, "RepresentativeToEntity", which links representatives and the government entities on which they serve. Note that the same representative can serve on multiple government entities.

## "RepresentativeToEntity" table

Field | Meaning | Example-1 | Example-2 | Example-3
--- | --- | --- | --- | ---
Representative | key to representative | 1 | 2 | 2
GovEntity | key to government entity |  5 |  7 |  9

There will be a "Citizen" table for members of the public. The Citizen table will contain a foreign-key pointing to the meeting at which this person spoke.

We do not want track what members of the public say across all the meetings that they attend. That is too Orwellian to consider. Therefore the name that the person gives when they speak at a meeting is all that we need to identify that person at that particular meeting. We do not need to correlate that name across meetings. We may even prefer to just store first name and last initial, so that we do not have the ability to track people even if we wanted to.

## "Citizen" table

Field | Meaning | Example-1 | Example-2
--- | --- | --- | ---
PrimaryKey | unique key | 1 | 2
Name | name | John J. | Rai S.
Meeting | key to meeting | 2 (U.S Senate meeting on Aug 3 '14) | 4 (Vidhan Sabha meeting on May 2 '14)

Each government entity (for example the U.S. senate or the Zoning Board in Monroe Township, NJ, USA) will have its own unique names for categories and topics discussed at their meetings. Therefore, the Tag Name table contains a foreign-key pointing to the government entity.

## "Topic" table

Field | Meaning | Example-1 | Example-2
--- | --- | --- | ---
PrimaryKey | unique key | 1 | 2
GovEntity | key to government entity | 2 (U.S Senate) | 2 (U.S Senate) | 4 (Vidhan Sabha)
Type | Category or Topic | Category | Topic | Category
Name | topic name | Health | Obamacare | education

The full transcript of the meeting is a string of text. The Speaker Location and Tag Location tables contain pointers into the text, namely the start and end points at which either the speaker or the tag changes. These will be character pointers into the text string.

## "Speaker Tags" table

Field | Meaning | Example-1 | Example-2
--- | --- | --- | ---
PimaryKey | unique key | 1 | 2
Speaker | key to speaker | 1 (Rep. Jones) | 2 (Chair. Anand)
Meeting | key to meeting | 1 (meeting #1) | 2 (meeting #2)
Start | point when speaker starts talking | 521 | 12045
End | point when speaker stops talking | 1050 | 14330

## "Topic Tags" table

Field | Meaning | Example-1 | Example-2
--- | --- | --- | ---
PrimaryKey | unique key | 1 | 2
Tag | key of tag | 1 (energy) | 2 (education)
Meeting | key to meeting | 1 (meeting #1) | 2 (meeting #2)
Start | point when topic starts | 750 | 14500
End | point when topic stops | 1345 | 17765

The size of the final meeting database is very small. Let's assume a transcript of 20,000 words and average word size of 6 characters (the average for English). An entire year of monthly town council meetings can fit into 1.5 meg of storage. This is a trivial amount of data for today's computers or smart phones. This will enable us to build applications where much of the data is be stored locally on a user's computer or smartphone -- for high performance and the ability to run the application off-line.
