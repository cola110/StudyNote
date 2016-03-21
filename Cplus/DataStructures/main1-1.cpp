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

	printf("调用初始化函数后，i=%d(1:成功) T的3个值为", i);
	cout << T[0] << "" << T[1] << "" << T[2] << endl;
	i = Get(T, 2, m);
	if (i == OK)
	{
		cout << "T的第二个值为：" << m << endl;
	}

	return 0;
}