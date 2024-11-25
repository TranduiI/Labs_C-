#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main()
{
	setlocale(LC_ALL, "rus");

	ifstream file("54.txt");
	if (!file.is_open())
	{
		cout << "Файл не открыт!\n\n" << endl;
		return -1;
	}
	string str;
	getline(file, str);
	cout << str << endl;

	char lit[26] = { 'a','b','c','d','e',
					'f','g','h','i','j','k',
					'l','m','n','o','p',
					'q','r','s','t','u',
					'v','w','x','y','z' };
	string code[26] = { "11 ","12 ","13 ","14 ","15 ",
						"21 ","22 ","23 ","24 ","24 ","25 ",
						"31 ","32 ","33 ","34 ","35 ",
						"41 ","42 ","43 ","44 ","45 ",
						"51 ","52 ","53 ","54 ","55 " };

	for (string::size_type i = 0; i < str.length(); ++i)
	{
		for (int j = 0; j < 26; j++)
		{
			if (str[i] == lit[j])
			{
				str.erase(i, 1);
				str.insert(i, code[j]);
				i = i + 1;
			}
		}
	}
	ofstream out;          // поток для записи
	out.open("55.txt"); // окрываем файл для записи
	if (out.is_open()) {
		out << str << endl;
	}
	cout << str << endl;

	ifstream filein("55.txt");

	if (!file.is_open())
	{
		cout << "Файл не открыт!" << endl;
		return -1;
	}
	string strin;
	getline(filein, strin);
	cout << strin << endl;
	string strout(str.length(), ' ');
	for (string::size_type i = 0; i < str.length(); ++i) {
		for (int j = 0; j < 26; j++) {
			if (strin.substr(i, 3) == code[j]) {
				strout[i] = lit[j];
			}
		}
	}
	cout << strout << endl;
}