#include "c1.h"
typedef int ElemType;
#include "c2-1.h"
#include "bo2-1.h"
#include "func2-3.h"

void Union(SqList &La, SqList Lb)
{
	ElemType e;
	int La_len, Lb_len;
	int i;
	La_len = ListLength(La);
	Lb_len = ListLength(Lb);
	for (i = 0; i <= Lb_len; i++)
	{
		GetElem(Lb, i, e);
		if (!LocateElem(La, e, equal))
		{
			ListInsert(La, ++La_len, e);
		}
	}
}

int algo2_1_main()
{
	SqList La, Lb;
	int j;
	InitList(La);
	for (j = 1; j <= 5; j++)
	{
		ListInsert(La, j, j);
	}
	printf("La=");
	ListTraverse(La, print1);
	InitList(Lb);
	for (j = 1; j <= 5; j++)
	{
		ListInsert(Lb, j, 2 * j);
	}
	printf("Lb= ");
	ListTraverse(Lb, print1);
	Union(La, Lb);
	printf("new la= ");
	ListTraverse(La, print1);
	return 0;
}

