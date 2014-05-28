# DecryptSQLite

This repository contains a simple utility, written in C#, which allows to remove the password from
an encrypted SQLite database (created with [System.Data.SQLite](https://system.data.sqlite.org)).

Note that you have to know the password in order to remove it (the goal of this utility is not to
help recovering a lost password).

## How to build

DecryptSQLite depends on [System.Data.SQLite](https://system.data.sqlite.org), but this dependency
is not included in this repository.

Before opening or building this project, please put `System.Data.SQLite.DLL` at the root of the
project (next to this `README.md` file).

You can then use [MonoDevelop](http://monodevelop.com/) to open and build this project.

Note that this project was built and tested with version 1.0.66.0 of `System.Data.SQLite.DLL`.
It might not be compatible with other versions.

## How to use

* Make sure `DecryptSQLite.exe` and the correct version of `System.Data.SQLite.DLL` are in the same folder.

* Execute `DecryptSQLite.exe` (e.g. by double-clicking on it).

* A dialog box to select the database file is displayed. Please select the SQLite encrypted
database file (.db3) and click on Open.

* Another dialog box then asks where to save the unencrypted database. You can change the default path
(if needed) and validate by clicking on Save.

* Another dialog box then asks for the password to decrypt the encrypted database. Type the password
and click OK.

* When the password removal operation completes successfully, a success message is displayed.
Otherwise, an error message can be displayed.

## Copyright

The content of this repository is in the [Public domain](http://en.wikipedia.org/wiki/Public_Domain).
