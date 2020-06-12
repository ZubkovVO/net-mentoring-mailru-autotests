To run this version of application you have to downloads selenium server .jar from :
https://selenium-release.storage.googleapis.com/3.141/selenium-server-standalone-3.141.59.jar

Create 2 bat files with the following content/names (StartNode, StartHub) and have them put in one folder with the downloaded .jar file

StartHub file contents:

java -jar selenium-server-standalone-3.141.59.jar -role hub

StartNode file contents:
java -Dwebdriver.chrome.driver="C:\pathToTheRepo\Automated Testing Mentoring Program [2020Q2 RU]\Epam.Automation.Mentoring.Mail.Autotests\bin\Debug\netcoreapp3.1\chromedriver.exe"  -Dwebdriver.gecko.driver="C:\pathToTheRepo\Automated Testing Mentoring Program [2020Q2 RU]\Epam.Automation.Mentoring.Mail.Autotests\bin\Debug\netcoreapp3.1\geckodriver.exe" -jar selenium-server-standalone-3.141.59.jar -role node -hub http://localhost:4444/grid/register

Then while running FolderAndFileActions test you should keep in mind that test preconditions are the following ->
There are no folders in the cloud, there is at least one file named "Чистая вода.jpg"