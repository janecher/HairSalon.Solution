# Eau Claire's Hair Salon

#### C# .Net Core MVC Application, 07/31/2020

#### By **Evgeniya Chernaya**

## Description

This web application creates and manipulate with list of stylists, clients and appointments for hair salon, using MySQL database.

## Setup/Installation Requirements

* Click the green "Clone or download" button at the right of the screen.
* Select "Download ZIP."
* Use a file extractor or unzip program (such as PeaZip, Unzipper, WinZip, Zipware, or 7-ZIP) to extract the ZIP files onto your computer.
* In your browser, navigate to https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.106-macos-x64-installer for Mac or https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.203-windows-x64-installer for Windows and click the link "click here to download manually" if the download for .NET Core 2.2 SDK does not start automatically.
* Double-click the downloaded .NET Core 2.2 SDK file and run the installer.
* Open your computer's terminal and navigate to the directory bearing the name of the program and containing the top level subdirectories and files.
* Enter the command "dotnet restore" in the terminal.
* Enter the command "dotnet build" in the terminal.
* Enter the command "dotnet run" in the terminal. The program should begin to run in the browser.

### MySQL Setup

* Install MySQL Workbench on your computer (https://dev.mysql.com/downloads/file/?id=484391)

* Open MySQL Workbench and select the Local instance 3306 server.

* Open your MySQL Workbench. In the Navigator > Administration window, select Data Import/Restore.

* In Import Options select Import from Self-Contained File and navigate to 'evgeniya_chernaya' database.

* The following is the query information for access this database on MySQL Workbench.

DROP DATABASE IF EXISTS `evgeniya_chernaya`;
CREATE DATABASE `evgeniya_chernaya`;

DROP TABLE IF EXISTS `stylists`;
CREATE TABLE `stylists` (
  `StylistId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `Speciality` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`StylistId`)
)

DROP TABLE IF EXISTS `clients`;
CREATE TABLE `clients` (
  `ClientId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `StylistId` int(11) DEFAULT '0',
  PRIMARY KEY (`ClientId`)
) 

DROP TABLE IF EXISTS `appointments`;
CREATE TABLE `appointments` (
  `AppointmentId` int(11) NOT NULL AUTO_INCREMENT,
  `ClientId` int(11) DEFAULT '0',
  `Date` datetime DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Time` int(11) DEFAULT NULL,
  PRIMARY KEY (`AppointmentId`)
) 

## Known Bugs

_No known bugs_

## Technologies Used

  * C# .Net Core MVC
  * Entity Framework
  * Visual Studio Code
  * MySQL Workbench

### License

_This software is licensed under the MIT license_

Copyright (c) 2020 **Evgeniya Chernaya**.