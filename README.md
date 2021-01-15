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
- Inheritence
- Polymorphism

**studied not implemented*
- Interfaces
- Abstract Classes
- structs
- Switches
- Multithreading and Async
- All the other things

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

Enums are a special data type in C# that allow us to create a set list of constants that represent an underlying numerical type. The numerical type will be integer by default and will increment in 1's. You can see an example of an enum on line 219 of my code. I have an enum named Months of the year and have listed all months. Enums are of immutable value type. On line 236 the enums values are accessed based on the month supplied by the user.

<h3> Fields </h3>

Fields are generally declared at the top of our classes. Fields are Simply put just a variable that belong to a class or struct. You can see examples of this at the top of all of my declared classes. Have a look at lines 12-14 in the program class. I have declared 4 fields. myStaff of type List containing Staff, fr a FileReader object, month and year both integers.

<h3> Properties </h3>

Properties come in 2 forms. Manual and auto-implemented. If no further logic is required we can use an auto implemented property. If we need more fine grained control over the logic. Then we can use manual properties. Properties essentially define our getter and setter for fields within a class. We can set access control on our properties getters and setters aswell. If you look at line 85-102 you can see an example of a manual Property called HoursWorked which has a backer field called hWorked just above it. This was made manual so we could add some additional logic to the setter. An example of an auto implemented property is on line 104.

<h3> Methods </h3>

Methods in C# aren't disimilar to other laguages. You must have a method name followed by (). If there are paramters they are defined inside these brackets. If there isnt they are still required. We then use curly Boi's {} To define the scope that holds the logic. Methods are declared with an access modifier and a return value type or void. Line 114 in the code holds the start of the CalculatePay method. you will also notice the word virtual between the access modifier and the return type (in this case void). This allows the method to be overriden in child classes. 

The static keyword can also be used to make member accessable on the class itself and not just the object created from it. For example => If the CalculatePay method was declared as below. Then we could use Staff.CalculatePay(); from anywnere in the code without creating an instance of the class.

```C#
public static void CalculatePay(){};
```

parameters should have there types declared aswell. i.e CalculatePay(int someNum, string expectedString){};.

<h3> Iteration </h3>

Iteration is not dissimilar to other languages in C# you cna view some examples of this in my code at lines 231(foreach), 189(while). Not much more to say here. It has the features you would expect. There are some keywords including break to stop iterating and continue to jump to the next iteration. C# also contains the stanard for loop. These features can be used for flow control etc.

<h3> Exception Handling </h3>

C# Gives us the try, catch, finally block to help with error handling. You can see an example of this in my code at lines 20-29. The catch block can set a variable to refer to the exception which can then be used to access its message. Although i didnt in my code. You can also create your own exceptions and catch particular exceptions. You can also have more than one catch block defines to perform differnt scenarios based on the exception type. The finally block will ececute regardless of if the catch was used or not.

<h3> LINQ </h3>

LINQ stands for Language-Integrated Query. It is a syntax provided that allows us to query data in our program. I have provided an example of this in my code... simple as it may be... on line 263. It has an SQL...ish like syntax for ease of querying and arranging data. In my code you can see that it can be assigned to a variable and formatted in a certain way. We can then manipulate this data to our liking i.e line 272-276.

<h3> File Handling </h3>

C# Provides a number of classes to work with files. The systemIO Namespace is where you will find them. As you cna see on line 3 we have used a Directive to include the System.io namespace in our application. This allows us to use the classes within it. The 2 classes that have been used in my code are StreamReader, for reading files i.e line 176 defines the FileReader class on line 187 we create an instance of the StreanReader class, and StreamWriter in the GeneratePaySlip function at line 235.

<h3> Classes </h3>

Classes in C# are not unlike classes from any other object orientated language. But essentially, as we may or may not know, classes are templates for creating objects. Classes contain members including fields, properties constructors and methods that all have differnt levels of access control to define where and how they can be used. They are essentially the blueprint for all object created in C# (and other object oriented languages). They are one of if not the most important concepts in object orientated programming.

see examples on lines 8, 79, 128, 150, 176 and 214.

<h3> Access Modifiers </h3>

Although I have already touched on access modifiers. Lets do it again...YAY!

Access modifiers are used in c# programming to define the access level of members. What is meant by members is any contained field, method or property of a containing class. There are 3 main access modifiers used (although not only 3) in C#. Public, private and protected. These are prepended to a statment. You can see examples of this in the code all over the place. Here are what each level implies.

Public: Accessable from anywhere. No restrictions. Take me!
Private: Only accessable from within the containing class. This is the default if nothing is specified.
Protected: Accessable only from within the containing class and any child classes.

<h3> Inheritance </h3>

Inheritance in C# and infact all object orientated programming is simply put:

Creating a new class from an existing class so that we can reuse code. The created class... or the child class... Is the inheriting class. The original class or the Parent or Base class... is the inherited class.....sigh...breath.

In C# we can implement class inheritance using a colon : symbol. See examples of this in the code at line 128 and 150. The child class will have access to any members of the parent class that are not private. Generally the parent constructor will be called first. We have to pass the parent its required parameters using the following syntax in the constructor declaration. See this in action on line 132.

```c#
public Manager(string name) : base(name, managerHourlyRate) { }
```
All this is doing is allowing the constructor of the child class to accept a paramter of its own. Then a colon is used followed by the base keyword. We use parantheses to pass up the required params. Also worth noting is that the parameter that the child class accepted is passed through the base keyword. This isnt required but possible. This particular constructor did not contain any additinal logic, The logic contained in the parent construtor is sufficient. But it was required so that the parameters could be passed.

<h3> Polymorphism </h3>

Polymorphism is defined as the ability to take on many forms. In programming and indeed in C# this concept is important to understand for instances demonstrated on lines 245 andn 249 of my code.

Basically we need to Explicitly dictate to the runtime environment that we want to "morph" into the correct class. You see that on line 227 this method accepts a List. The List contains type Staff. These being instances of the staff class. Becuase we have used inheritance it actually contains Manager and Admin instances which are children of the Staff class. C# allows us to simply declare the List as Staff. However it does not implicitly know at runtime that the list actually contains Manager and Admin instances.

This is why its important to know. If we do not Explictly notify the compiler and subsequently the runtime environment of this then an error will occur.

Thats what this weird syntax on lines 245 and 249 are doing.

Polymorphism...like animorphs for code but we its explicit! ... cough ... rough crowd.

**Disclaimer** The following Sections are being included to demonstrate my knowledge. But there are no examples in my code.

<h3> Interfaces </h3>
<h3> Abstract Classes </h3>
<h3> Structs </h3>
<h3> Switches </h3>
<h3> Multithreading and Async </h3>
<h3> All the other things </h3>

<a name="install"/>
<h2>Install</h2>


