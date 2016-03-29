#ifndef LIST_INIT_SIZE
#define LIST_INIT_SIZE 10
#define LIST_INCREMENT 2
typedef int ElemType;
struct SqList
{
	ElemType *elem;
	int length;
	int listsize;
};
#endif