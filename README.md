# DecryptSQLite

This repository contains a simple utility, written in C#, which allows to change the password of
an encrypted SQLite database (created with [System.Data.SQLite](https://system.data.sqlite.org)).

Note that you have to know the old password in order to change it (the goal of this utility is
not to help recovering a lost password).

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

* A dialog box to select the database file is displayed. Please select the source SQLite database
file (.db3) and click on Open.

* Another dialog box then asks where to save the changed database. You can change the default path
(if needed) and validate by clicking on Save.

* Another dialog box then asks for the password of the source database to decrypt it. Type
the password and click on OK. If the source database is not encrypted, you can either click on Cancel
or empty the field and click on OK.

* Another dialog box then asks for the new password to encrypt the database. Type the new password
and click on OK. If you don't want to encrypt the changed database, you can either click on Cancel,
or make sure the field is empty and click on OK.

* When the password removal operation completes successfully, a success message is displayed.
Otherwise, an error message can be displayed.

## Copyright

The content of this repository is in the [Public domain](http://en.wikipedia.org/wiki/Public_Domain).
