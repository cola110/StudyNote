#include "c2-1.h"
#include <malloc.h>
#include <iostream>


void InitList(SqList &L)
{
	L.elem = (ElemType*)malloc(LIST_INCREMENT*sizeof(ElemType));
	if (!L.elem)
	{
		exit(OVERFLOW);
	}
	L.length = 0;
	L.listsize = LIST_INIT_SIZE;
}

void DestroyList(SqList &L)
{
	free(L.elem);
	L.elem = NULL;
	L.listsize = 0;
	L.length = 0;
}

void ClearList(SqList &L)
{
	L.length = 0;
}

// Status