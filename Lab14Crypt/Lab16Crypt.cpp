// Lab16Crypt.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include "UPerceptron.h"
#include "UTPM.h"
#include <ctime>

using namespace std;
int main()
{
	clock_t start, end;
	srand((int)time(0));


	TPM* tpm1 = new TPM();
	TPM* tpm2 = new TPM();
	Perceptron* pers = new Perceptron[K];
	for (int i = 0; i < K; i++) {
		pers[i] = *new Perceptron();
	}
	tpm1->SetPerceptrons(pers);
	pers = new Perceptron[K];
	for (int i = 0; i < K; i++) {
		pers[i] = *new Perceptron();
	}
	tpm2->SetPerceptrons(pers);

	tpm1->PrintWeighs();
	tpm2->PrintWeighs();

	start = clock();

	while (tpm1->Distance(*tpm2) != 0) {
		int** Inputs = new int*[K];
		for (int i = 0; i < K; i++) {
			Inputs[i] = new int[N];
			for (int j = 0; j < N; j++) {
				Inputs[i][j] = rand() % 3 - 1;

				cout << Inputs[i][j] << " ";
			}

			cout << endl;
		}

		int Output1 = tpm1->GetOutput(Inputs);
		int Output2 = tpm2->GetOutput(Inputs);
		
		if (Output1 == Output2) {

			tpm1->Synchronize();
			tpm2->Synchronize();
		}

		

		cout << "Weights: " << tpm2->Distance(*tpm1) << " && Output1 = " << Output1 << " : Output2 = " << Output2 << endl;
	}

	end = clock();


	tpm1->PrintWeighs();
	tpm2->PrintWeighs();

	double time_taken = double(end - start) / double(CLOCKS_PER_SEC);
	cout << "Time taken by program is : " << fixed
		<< time_taken;
	cout << " sec " << endl;

}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
