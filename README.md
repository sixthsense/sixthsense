README
------

For more information on SixthSense software and hardware, see:

 http://code.google.com/p/sixthsense/wiki/Software
 http://code.google.com/p/sixthsense/wiki/Hardware

Detailed documentation is in progress.

64-bit users!
-------------

There are currently some problems plaguing 64 bit systems that we're trying to fix. 
Until then, follow these steps to debug the code under 64-bit systems (in Visual Studio):

From top menu select "Build", then "Configuration Manager".
After adding a new "x86" platform inherited from debug platform, we see a
new platform in the list and the old one is removed. 

From the new platform displayed we click on Platform column to see a dropdown
containing 3 options "or more", the first is "Any CPU", the second is
<New...>, and the third is <Edit...>, select <New...>, a window will
open to choose the platform.

Select x86 then hit OK.

Click debug, it runs as it should.

Mailing List
------------

This is where most of the discussion goes on.

http://groups.google.com/group/ss_dev

Technology
-----------
We use C# (tested on Windows, not Mono) with OpenCV (for .NET).

Developers
----------

To get started, there's all kinds of indentation issues in the codebase, fix those so you can get a feel for how all the code is laid out.

Standards
---------

We use tabs-as-spaces, with 4 spaces for identation. There's all kinds of identation issues, and we encourage people to fix those.

Ports
---------
The current code only runs on Windows, under the CLR virtual machine (i.e. C#). 
If you're working on a port to a different environment (*nix, Mac OS X, Android, etc.) please list it here, with some kind of link to code.

