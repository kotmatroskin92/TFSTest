# TFSTest support Firefox and Chrome browser
To start project use MSTest.
testData.Json and config.json must located to {project}\Configuration dir.
# config.json required fields:
* "StartPageUrl": "https://",
* "browser.name": "Chrome",
* "browser.MaximizeWindow": false,
* "browser.WindowHeight": 1080,
* "browser.WindowWidth": 1920
# config.json not required fields:
* "DefaultWaitTimeout": "00:01:00",
* "DefaultDownloadTimeout": "00:01:00",
* "browser.headless": false,
* "ScreenshotFolder": "{currentDir}\\screenshots",
* "DownloadsFolder": "C:\\Autotest\\downloads",
* "WebDriverFolder": "{projectDir}",
## we can change path using this rule:
* {currentDir} - project runs dir;
* {projectDir} - current project base dir;
* use full path
