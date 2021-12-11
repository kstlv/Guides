# Pocket Import Helper — Import URL list into Pocket

**Pocket Import Helper** will help you make a file ready for import into [Pocket](https://getpocket.com/) from your text file with links (URLs).

The reason for creating this tool: I have not found a solution to import a simple list of links into Pocket.

## How to Use

1. Download `.exe` (for Windows) from [Releases](https://github.com/kstlv/pocket_import_helper/releases).
2. Create a `links.txt` file next to the program executable file (program folder).
3. Fill in this file with the links (URLs) following the requirements. File requirements: URLs must start with `http://` or with `https://`, each line is a separate URL, blank lines will be ignored.
4. Run the executable file of the program and follow the instructions in the console.
5. Import the `links.html` (located in the program folder) into Pocket: https://getpocket.com/import/instapaper (make sure you are signed in to your Pocket account).

## How to Build

I have implemented this task in two programming languages (C++ and C#). They work the same way. Each project is independent of the other's code.

### C++

Path: `cpp/pocket_import_helper`

Build using `JetBrains CLion` with `CMake`. Or any other IDE if you want.

### C#

Path: `cs/pocket_import_helper`

Compile using `Visual Studio Code` ([guide](https://code.visualstudio.com/docs/languages/dotnet)) or `Visual Studio` ([guide](https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2022)) or `JetBrains Rider`.

## License

You can use this code in any conditions.
