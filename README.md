I've created this repo to help anyone that wants to create Selenium UI automation tests for Window Applications. This repo is intended to be used as a good example of how to setup a test automation project.

The project uses:
1. Selenium
2. WinAppDriver
3. Specflow

I have tried to use as many best practices as possible, however, if I have missed some, could improve in areas etc let me know!

I have been following the page object model pattern (https://www.selenium.dev/documentation/test_practices/encouraged/page_object_models/) to keep all the elements in one location. As this is a Windows application I have used 'Application Model' within my tests rather than 'Page Model'.

Prerequisite:
- Windows calculator (should be pre-installed on all windows computers)
- Visual Studio 2022 with SpecFlow for Visual Studio 2022 extension
- WinAppDriver (https://github.com/microsoft/WinAppDriver/releases/tag/v1.2.99). Once downloaded and installed, run WinAppDriver.exe (default location: C:\Program Files (x86)\Windows Application Driver)
- Locate/Install Inspect.exe
- Enable Developer mode - https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development

To do:
1. Showcase different Locators
2. Show different uses of xpath

Information/Guides:
Encouraged behaviours (best practices):
https://www.selenium.dev/documentation/test_practices/encouraged/

Page object model:
https://www.selenium.dev/documentation/test_practices/encouraged/page_object_models/
