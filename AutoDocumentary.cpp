// AutoDocumentary.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//


#include <iostream>
using namespace std;



/// <summary>
/// Рабочее место
/// </summary>
class WorkingPlace {
    private:
    /// <summary>
    /// Дни без проблем
    /// </summary>
    int days_without_problems = 0;

    public:
    /// <summary>
    /// Устанавливает количество дней без проблем и выводит их на экран
    /// </summary>
    /// <param name="Дни без проблем"></param>
    /// <permission cref="System::Security::PermissionSet">Everyone can access this method.</permission>
    void SetDaysWithoutProblems(int days) {
        days_without_problems = days;
    }
    /// <summary>
    /// <c>ComeToHospital</c> используется, когда происходит проблема
    /// </summary>
    /// <param name="Дни без проблем"></param>
    /// <returns>Значение дней без проблем становится равным нулю</returns>
    int SomeNewProblem() {       
        days_without_problems = 0;
        return days_without_problems;
    }
    /// <summary>
    /// Выводит на экран количество дней без проблем
    /// </summary>
    void PrintDaysWithoutProblems() {
        cout << days_without_problems << endl;
    }

};

int main()
{
    /// <summary>
    /// Офис
    /// </summary>
    WorkingPlace office;
    office.SetDaysWithoutProblems(5);
    office.PrintDaysWithoutProblems();
    office.SomeNewProblem();
    office.PrintDaysWithoutProblems();
}

