# C# Payroll Console App

**Contents**
- [Project Overview](#project-overview)
- [Principles Implemented and not Implemented](#principles)
- [Install the App](#install)

<a name="project-overview"/>
<h2>Project Overview</h2>
This Payroll console app was written to consolidate as many of the basic principles of programming in C# in the simplest way possible. I tried to incorporate as many of the basic principles as I could. In the section Below I will explain and point out these principles to demonstrate my understanding and show where they have been used in the code. There are also a couple that weren't included, that I realize are also important to C#, and as such I will also give an overview these to demonstrate my understanding of them.

As C# is an object orientated langauge. The application is split into 6 classes (Program, Staff, Manager, Admin, PaySlip and FileReader). These classes are essentially templates that are used to create objects that interact with each other in a typical object orientated fashion.

The application runs in the console and accepts input from the user to gather the year and month that the payslips are being generated for. It then reads througn a text file of users and there roles to gather the required staffing information and requests that we input the hours worked for each employee. It then prints a brief summary and moves on to the next staff on the list from the file. It has now generated a payslip for the staff memeber and printed these to a file which can be found in the Debug directory where the staff input file is also found.

<a name="principles"/>
<h2>Principles</h2>

Demonstrated Principles

**Implemented*
- Object Orientated Approach
- Directives
- Namespaces
- Data types and casting
- Variable declaration  (value vs reference) and assignment
- Enums
- Fields
- Properties
- Methods
- Iteration
- Exception Handling
- LINQ (Language-Integrated Query)
- File Handling
- Classes
- Access Modifiers
- Overriding / Overloading
- Inheritence
- Polymorphism

**studied not implemented*
- Interfaces
- Abstract Classes
- structs
- Switches

<h3> Object Orientated Programming </h3>

Object orientated programming is basically just a bunch of objects, that hold different methods and data, Interacting with each other. C# is an object orientated Language (Along with many other modern high level languages). It uses Classes, which are basically just templates for objects, to create objects from. In this Application I have created  6 classes (Program, Staff, Manager, Admin, PaySlip and FileReader). In C# the Program class is the default class which holds the Main() method. The Main method is the programs entry point. This is where we will generally make instances of classses and uses these instances to perform tasks, interact with each other, complete the program. 

This can be seen from lines 8 - 77

<h3> Directives </h3>

Directives for this program can be seen on lines 1-4. Directives tell the compiler that we want to use certain namespaces in our program. This allows us to use these Namespaces and the code contained within them in our application. C# comes with a lot of pre defined namespaces that we can use. Speaking of which...Namespaces here we come =>

<h3> Namespaces </h3>

Namespaces are just a grouping of related code elements. This could include classes, interfaces, methods etc.  C# has a heap (no pun intended) of Namespaces already defined for us that we can use. For example the infamous and commonly used System Namespace as seen on line 1 gives us methods that we can use to interact with users. For example on line 18 the WriteLine method allows us to print messages to the screen. On line line 23 we use ReadLine to accept user input. These methods are defined within the System Namespace. The reason our program knows about them and how to use them is because we have used the Directuve on line 1 to tell the compiler about the system namespace.

<h3> Data types & Casting. </h3>

C# has Several datatypes that we can use including all the usual culprits. Integers, Floats, Doubles, Decimals, Booleans ... the list Goes on. In C# we must declare the data type of a variable when we declare it. C# is very strict on datatypes and it generally wont implicitly type cast your varibales or make assumptions about what you mean. This is said to help avoid unwanted errors down the track. The compiler will want to know what you mean specifically. 

For example if we look at line 23 of my code. We can see that I am using a type casting method:

```C#
year = Convert.ToInt32(Console.ReadLine());
```

The reason for this is because year is declared as an Integer(line 14) and user input is always accepted as a string. If we do not Explicitly cast this type to an integer. Then the compiler will throw an error with unwieldly borkage. How dare we try and implicitly type cast!

<h3> Variable Declaration & Assignment ( value vs reference types) </h3>

Varibales can be declared and assigned at the same time but they can also be declared and assigned on another line. A datatype myst be declared when declaring a varibale and the assignment sign is the = sign as in most languages.

It is important to understand the difference between Reference and Value types in C#. This can have implications on memory allocation and on the way that we manipulate or pass a variable. A Value type will be allocated on the stack (the value is actually stored there.) where as a reference types will be declared on the stack and will have a pointer stored there that will point to an allocation on the heap.

When we make a copy of a reference type variable we are copying the pointer...this means that when we change the value of a reference type variable it will be effected wherever we access it from. i.e

```C#

string[] myStringArr = {"Howdy Partner!"};
myCopyArr = myStringArr

```

In the scenario above the pointer for myStringArr has been copied to myCopyArr **NOT** the actual value. This means if i change myStringArr's value then myCopyArr will also return the new value and not the old value that we originally assigned it.

most primitive datatypes except for string are value types. string along with most Advanced data types like arrays and lists are reference variable types. Value datatypes get assigned a fixed size (a certain amount of bytes). Reference varibales do not and garbage collection gets handled on the heap where they live.

<h3> Enums </h3>

<a name="install"/>
<h2>Install</h2>


