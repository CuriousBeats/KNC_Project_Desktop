This file will contain information on how to run and compile the KNC Desktop App Project.

THERE ARE SETUP STEPS YOU MUST TAKE BEFORE LAUNCHING THIS PROGRAM

Firstly, You should use Visual Studio Code and open this Repo from there. The project information and dependencies should be prompted
to you for download

Secondly, before running the desktop app, you must:

- have python installed on your computer, preferrably a default install with pip
- you must run python as an administrator and run this command:
  
pip install --upgrade google-api-python-client google-auth-httplib2 google-auth-oauthlib

this will download the required python scripts for use in the app

next, it is imperitive that python and this package are added to PATH variables on Windows. For information on this please visit this link

https://dev.to/bsoyka/adding-files-to-the-path-on-windows-10-39jo

this setup should also work for Windows 11

you will know that it is done correctly, when launching the desktop app, you should see a command prompt window before the app launches which will list all the files being downloaded. 
