Purpose
This is an attempt to get rid of the cryptic .evt format to a more human readable form. We are currently supporting csv.

Credit to?
We have used the decryption code from CodeProject.
Need to find out the original author for the decrypting script and give the credits here.

What we have done

1. Made the application generic so that we can use a folder full of evt files or a single evt file.
2. Fixed the bug in reading evt files. It will not crash now.
3. Fixed the bug regarding the count of evt files.
4. Fixed the bug in loading evt files, ie now it reads only evt files and ignores the rest.
5. Refactored the code so that it is more readable. 
6. Introduced chaining of delegates.
7. Added right click functionality.
8. Added functionality where in, if you click on a row, the description opens up in a new window.

