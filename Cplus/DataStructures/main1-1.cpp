//#include "c1.h"
//typedef int ElemType;
//#include "c1-1.h"
//// #include "bo1-1.cpp"

#include "bo1-1.h"
using namespace std;

int main()
{
	Triplet T;
	ElemType m;
	Status i;

	i = InitTriplet(T, 5, 7, 9);

	printf("���ó�ʼ��������i=%d(1:�ɹ�) T��3��ֵΪ", i);
	cout << T[0] << "" << T[1] << "" << T[2] << endl;
	i = Get(T, 2, m);
	if (i == OK)
	{
		cout << "T�ĵڶ���ֵΪ��" << m << endl;
	}

	return 0;
}