# AutoTagger
Find Instagram Tags by uploading a Photo

## Table & Formel
![](https://github.com/Vittel/AutoTagger/raw/master/doc/table_formel.jpg)

## Architecture
![](https://github.com/Vittel/AutoTagger/raw/master/doc/architecture.jpg)

## TaggingProvider
Rest API
localhost:80
- GET /find

## UserInterface
Rest API
localhost:5000
cd AutoTagger\AutoTagger.UserInterface\bin\Debug\netcoreapp2.0
dotnet AutoTagger.UserInterface.dll
- POST /image -> body: form-data -> param "link"
- POST /image/upload -> param "file" with image
