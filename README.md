# Lime_interview
Project for LIME CRM interview


HI!

Well easy to run

********************************************************************************************************
there is a lock.txt in root folder of this projcet, if this is the first time you run this
just go delete that, if that file exists, your database will not be populated with record of employees
after you delted that, go ahead and continue below
********************************************************************************************************


first you need a database, open cmd, dont be admin, you dont need admin where we are going!

run this :

sqllocaldb create lime -s

you will get this: 

LocalDB instance "lime" created with version 13.1.4001.0.
LocalDB instance "lime" started.


DONE? good.


ok, now open "Program.cs" and run the program, the API now initializes, connects to database, 
populates it, and launches 2 things. First thing a cmd window which sais this :

"Migrating to DataBase, This can take a long time. Please wait."

If you are seeing this, good, wait 6 minutes no joke, it is a lot of data. When its done you will see a few more texts
saying which port and URL to use. 

it will look like this:

Hosting environment: Development
Content root path: D:\Projects\Lime_interview\src\Supermarket.API
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.

From there open a browser and use this URL to test everything works (it will automatically do this also, in case it didnt, use this URL):

http://localhost:5000/api/schedule?user=57646786307395936680161735716561753784&length=30&earliest=3-13-2015 10:00 am&latest=3-13-2015 06:00 pm&officehour=08-18

You will get a response like this:

[
    "2015-03-13T14:30:00",
    "2015-03-13T15:00:00",
    "2015-03-13T15:30:00",
    "2015-03-13T16:00:00",
    "2015-03-13T16:30:00",
    "2015-03-13T17:00:00",
    "2015-03-13T17:30:00"
]

These are the available times in your time zone, your current pc time. If you see all these, congrats. If not, you missed a step.

Have fun!
