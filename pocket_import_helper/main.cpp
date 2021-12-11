#include <iostream>
#include <string>
#include <fstream>

using namespace std;

void create_export_file() {
    const string fileImport = "links.txt";
    const string fileExport = "links.html";

    const string htmlStart = "<!DOCTYPE html>\n<html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\n<title>Instapaper: Export</title>\n</head>\n<body>\n<h1>Unread</h1>\n<ol>\n";
    const string htmlEnd = "</ol>\n</body>\n</html>";

    const string tagStart = "<li><a href=\"";
    const string tagEnd = "\"></a>\n";

    const string http = "http://";
    const string https = "https://";

    int counterIncorrect = 0;
    int counterCorrect = 0;

    string links;
    links = "";

    cout << "Trying to open the file (" + fileImport + ")... ";

    ifstream file(fileImport);
    if (file.is_open()) {
        cout << "Success" << endl;

        string link;
        link = "";
        while (getline(file, link)) {
            if (!link.empty() && ((link.find(https) == 0) || (link.find(http) == 0))) {
                links.append(tagStart + link + tagEnd);
                counterCorrect++;
            } else {
                counterIncorrect++;
            }
        }

        cout << "\nLinks (URLs)" << endl;
        cout << string(12, '-') << endl;
        cout << "Correct:   " << counterCorrect << endl;
        cout << "Incorrect: " << counterIncorrect << "\n" << endl;

        if (counterCorrect != 0) {
            cout << "Creating a file ready for import into Pocket... ";
            ofstream fout;
            fout.open(fileExport);
            if (!fout.is_open()) {
                cout << "Error" << endl;
            } else {
                fout << htmlStart << links << htmlEnd;
                cout << "Success" << endl << endl << "File (" << fileExport << ") is ready to be imported into Pocket."
                     << endl << endl;
                cout << "Go to \"https://getpocket.com/import/instapaper\" and select (" << fileExport
                     << ") HTML-file.";
            }
            fout.close();
        } else {
            cout << "No correct links (URLs) found in (" + fileImport + ")." << endl;
        }
    } else {
        cout << "Error" << endl;
    }

    file.close();
}

bool menu() {
    system("cls");

    cout << "Hello! Thanks for using \"Pocket Import Helper\"!" << endl;
    cout << "Developed by Danil Kostylev." << endl << endl;
    cout << "This program will help you make a file ready for import into Pocket from your text file with links (URLs)."
         << endl;
    cout << R"(Please note that URLs must start with "http://" or with "https://". Each line is a separate URL.)"
         << endl << endl;

    cout << "0. Exit" << endl;
    cout << "1. I have prepared the file (links.txt), start!" << endl << endl;

    cout << "Select an option: ";

    char x;
    cin >> x;

    switch (x) {
        case '0':
            return false;
        case '1':
            system("cls");
            create_export_file();
            cout << "\nPress any key to return to the menu." << endl;
            system("pause");
            return true;
        default:
            return true;
    }
}

int main() {
    bool show_menu = true;
    while (show_menu) {
        show_menu = menu();
    }
    return 0;
}
