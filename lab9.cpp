#include <iostream>
#include <fstream>
#include <string>
#include <cstdlib>
using namespace std;

int main()
{
    setlocale(0, "");

    fstream fin("text.txt");
    if (!fin) cout << "Ошибка при открытии файла!" << endl;
    else
    {
        cout << "Введите количество слов в предложении: ";
        int n;
        cin >> n;

        string str; // строка для предложения
        int c = 0; // счётчик слов
        int m = 0; // счётчик предложений, с заданным количеством слов

        while (true)
        {
            string temp;
            fin >> temp; // читается слово

            if (fin.eof()) break;

            str.append(temp); // слово добавляется в строку
            ++c;

            // если считано в строку предложение
            if (*(str.end() - 1) == '.' ||
                *(str.end() - 1) == '!' ||
                *(str.end() - 1) == '?')
            {
                if (c == n)
                {
                    cout << str; // выводим предложение с заданным количеством слов 
                    str.clear(); // очищаем строку
                    c = 0; // обнуляем счётчик слов
                    ++m;
                }
                else
                {
                    str.clear();
                    c = 0;
                }
            }
            else str.push_back(' '); // если не конец предложения, то добавляем после слова пробел
        }
        if (m == 0) cout << "Педложений, с таким количеством слов, в файле нет" << endl;

    }

    system("pause");
    return 0;
}

