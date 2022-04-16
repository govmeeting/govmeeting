<style>
  table {
  font-size: 100%;
}

table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
  font-weight: normal;
}
th, td {
  padding: 3px;
}
th {
  text-align: left;
}
th {
  text-align: center;
  font-weight: bold;
}
</style>

The tables in the database consist of:

1. Authentication tables.

These were created automatically by Microsoft Identity Service when "Authentication = Individual User Accounts" was checked when the project was first built.

2. Govmeeting tables.

These are created by the "Code First" feature of Entity Framework. EF reads the C# classes in the "Database/Model" project library and automatically generates the database schema and tables.

See the "Setup" document page for creating and working with the database.

# Schema

## "Government Entity" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th><th>Example 3</th></tr>
<tr><td>PrimaryKey</td><td>unique key</td><td>1</td><td>2</td><td>3</td></tr>
<tr><td>Name</td><td>name of entity</td><td>Senate</td><td>Assembly</td><td>Planning Board</td></tr>
<tr><td>Country</td><td>country location</td><td>U.S.A</td><td>U.S.A</td><td>U.S.A</td></tr>
<tr><td>State</td><td>state location</td><td></td><td>Iowa</td><td>New Jersey</td></tr>
<tr><td>County</td><td>county or region location</td><td></td><td></td><td>Gloucester</td></tr>
<tr><td>Municipal</td><td>city or town</td><td></td><td></td><td>Monroe Township</td></tr>
</table>

\*More examples for Government Entity table

<table>
<tr><th>Field</th><th>Example 4</th><th>Example 5</th></tr>
<tr><td>PrimaryKey</td><td>4</td><td>5</td></tr> 
<tr><td>Name</td><td>Vidhan Sabha</td><td>Municipal Council</td></tr>
<tr><td>Country</td><td>India</td><td>India</td></tr>
<tr><td>State</td><td>Andhra Pradesh</td><td>Andhra Pradesh</td></tr>
<tr><td>County</td><td></td><td>Kadapa district</td></tr>
<tr><td>Municipal</td><td></td><td>Rayachoty</td></tr>
</table>

Note that if the government entity is at the national level, its state, county and municipal locations are null. If the entity is at the state level, its county & municipal locations are null, etc.

Examples for other countries are needed. If you have other examples, please edit this document and issue a Pull Request in Github. If there are reasons why this will not work for some countries, please submit an issue an Github.

---

## "Meeting" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th></tr>
<tr><td>PrimaryKey</td><td>unique key</td><td>1</td><td>2</td></tr>
<tr><td>GovEntity</td><td>key to government entity</td><td>2 (U.S Senate)</td><td>4 (Vidhan Sabha)</td></tr>
<tr><td>Time</td><td>meeting time</td><td>Aug 3, '14 19:30</td><td>May 2, '14 13:00</td></tr>
<tr><td>Text</td><td>transcription text</td><td>"The meeting will come to order. ..."</td><td>"The assembly will convene. ..."</td></tr>
</table>

---

## "Representative" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th></tr>
<tr><td>PrimaryKey</td><td>unique key</td><td>1</td><td>2</td></tr>
<tr><td>FullName</td><td>full name</td><td>Rep. Steve Jones</td><td>Chairman Ravi Anand</td></tr>
<tr><td>Identifier</td><td>personal identifier</td><td>(to be decided</td><td>(to be decided)</td></tr>
</table>

The speakers at the meetings could be representatives of the governing entity or of the general public. In either case, there can be the same people attending meetings in more than one government entity. We will want to track what the same representative says across each of the bodies of which he/she is a member. Therefore we need a unique identifier for each representative.

We will need to decide on what information is required for this identification. We obviously won't have a person's national identity number of something of that nature. We may need to use a combination of more than one field to identify someone. For example, address and name.

There will be a "Representative" table which contains a unique personal identifier for each representative.

---

## "RepresentativeToEntity" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th><th>Example 3</th></tr>
<tr><td>Representative</td><td>key to representative</td><td>1</td><td>2</td><td>2</td></tr>
<tr><td>GovEntity</td><td>key to government entity</td><td> 5</td><td> 7</td><td> 9</td></tr>
</table>

There will also be a table, "RepresentativeToEntity", which links representatives and the government entities on which they serve. Note that the same representative can serve on multiple government entities.

---

## "Citizen" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th></tr>
<tr><td>PrimaryKey</td><td>unique key</td><td>1</td><td>2</td></tr>
<tr><td>Name</td><td>name</td><td>John J.</td><td>Rai S.</td></tr>
<tr><td>Meeting</td><td>key to meeting</td><td>2 (U.S Senate meeting on Aug 3 '14)</td><td>4 (Vidhan Sabha meeting on May 2 '14)</td></tr>
</table>

There will be a "Citizen" table for members of the public. The Citizen table will contain a foreign-key pointing to the meeting at which this person spoke.

Should we try to track what members of the public say across all the meetings that they attend? Perhaps that is not appropriate.

If not, the need not try to uniquely identify public speakers. The name that the person gives when they speak at a meeting can be used to identify someone just for that meeting. We do not need to correlate that name across meetings. We may even prefer to just store first name and last initial.

---

## "Topic" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th><th>Example 3</th></tr>
<tr><td>PrimaryKey</td><td>unique key</td><td>1</td><td>2</td><td>3</td></tr>
<tr><td>GovEntity</td><td>key to government entity</td><td>2 (U.S Senate)</td><td>2 (U.S Senate)</td><td>4 (Vidhan Sabha)</td></tr>
<tr><td>Type</td><td>Category or Topic</td><td>Category</td><td>Topic</td><td>Category</td></tr>
<tr><td>Name</td><td>topic name</td><td>Health</td><td>Obamacare</td><td>education</td></tr>
</table>

Each government entity (for example the U.S. senate or the Zoning Board in Monroe Township, NJ, USA) will have its own unique names for categories and topics discussed at their meetings. Therefore, the Tag Name table contains a foreign-key pointing to the government entity.

---

The full transcript of the meeting is a string of text. The Speaker Location and Tag Location tables contain pointers into the text, namely the start and end points at which either the speaker or the tag changes. These will be character pointers into the text string.

## "Speaker Tags" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th></tr>
<tr><td>PimaryKey</td><td>unique key</td><td>1</td><td>2</td></tr>
<tr><td>Speaker</td><td>key to speaker</td><td>1 (Rep. Jones)</td><td>2 (Chair. Anand)</td></tr>
<tr><td>Meeting</td><td>key to meeting</td><td>1 (meeting 1)</td><td>2 (meeting 2)</td></tr>
<tr><td>Start</td><td>point when speaker starts talking</td><td>521</td><td>12045</td></tr>
<tr><td>End</td><td>point when speaker stops talking</td><td>1050</td><td>14330</td></tr>
</table>

---

## "Topic Tags" table

<table>
<tr><th>Field</th><th>Meaning</th><th>Example 1</th><th>Example 2</th></tr>
<tr><td>PrimaryKey</td><td>unique key</td><td>1</td><td>2</td></tr>
<tr><td>Tag</td><td>key of tag</td><td>1 (energy)</td><td>2 (education)</td></tr>
<tr><td>Meeting</td><td>key to meeting</td><td>1 (meeting 1)</td><td>2 (meeting 2)</td></tr>
<tr><td>Start</td><td>point when topic starts</td><td>750</td><td>14500</td></tr>
<tr><td>End</td><td>point when topic stops</td><td>1345</td><td>17765</td></tr>
</table>

---

## Size of Data

The size of the final meeting database is very small. This will enable us to build applications where much of the data is be stored locally on a user's computer or smartphone -- for high performance and the ability to run the application off-line.
