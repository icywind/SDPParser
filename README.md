# SDPParser
Session Description Parser in C#
# SDP Parser

Project Repo: [https://github.com/icywind/SDPParser](https://github.com/icywind/SDPParser)

### Prerequisite
-   Visual Studios  
-   Newtonsoft JSON (added NuGet dependency in Unit Test project “sdptest”)
    
### How to use:

1.  Import the package namespace:
    ```csharp
    using io.agora.sdp;
    ```
2.  Instantiate the Parser class; then use the Parse() method to create a SessionDescription object.

```csharp
Parser parser = new Parser();  
SessionDescription sessionDescription = parser.Parse(sdptext);
```


3.  Use Newtonsoft.JsonConvert.Serialize() to convert the sessionDescription into JSON string

Note the SDPParser library itself doesn’t have external dependency. The JSON dependency is required just for the Unit Tests target.




# Unity Application
## From the SDPParser project to a Unity Project:
**Copy the SDPParser folder to the Unity project's Assets folder.**

## Prerequisite:

-   Unity 2019.4
    
-   Newtonsoft JSON: search “newtonsoft json” in Asset Store and download the package:
    
-   ![](https://lh6.googleusercontent.com/5AATbnoPqTGM9aNdvNiUyOX2v4q8M-Ty9Uz1VvhXY5XIm75wAdOoB6uyRtuV3f8Co2WeJoh-cfLyZn-0mCeH_r9ffN4CZvq0v7tTssai5BDxXi568lpkkAcQm0BRNHEoEHN1cbjp=s0)
    

  
  

## Demo:

[https://apprtcio-my.sharepoint.com/:u:/g/personal/rick_agora_io/EdlPipjjXQhOkys3D8sN-5kBw4Penq4fqwu6gJfTaoXvQA?e=gpbtxU](https://apprtcio-my.sharepoint.com/:u:/g/personal/rick_agora_io/EdlPipjjXQhOkys3D8sN-5kBw4Penq4fqwu6gJfTaoXvQA?e=gpbtxU)

  

## Setup:

-   The SDPParser folder has been copied into the Assets folder for the Unity project.
    
-   NewtonSoft is included in the package
    

## Test

Run the project by hitting Play button

1.  Select AgoraObject from the scene Hierarchy
    
2.  Paste your SDP text into the “Sdptext” box
    
3.  Tap the “Parse” button
    
4.  See the console output for the converted JSON
    

-   ![](https://lh4.googleusercontent.com/qKNtEkmPUR8W3TaHHczMfKnOxplgwDGdaFo0S299xViPC-twW9x5I8XW9Cp6ViHHESfFaT40SFHgst_lCLmwMnuZIHZ9qtI6FkMKbmrWVLLsaVKJ06KmsmJtI3Q4eiX_LGj3lWJ7=s0)
