// Inputing.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
using namespace std;

struct YuliaException : public exception {
    const char* what() const throw () {
        return "C++ Exception";
    }
};
int main()
{
    setlocale(LC_ALL, "Russian");

    try
    {
        throw YuliaException();
        cout << "shit"<<endl;
    }
    catch (YuliaException& e)
    {
        cout << "пиймав исключеню"<<endl;
    }

    cout << "пака"<<endl;
        
 }