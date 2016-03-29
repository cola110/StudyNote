#include <stdio.h>
#include <sys/timeb.h>

int algo1_2_main()
{
	timeb t1, t2;
	long t;
	double x, sum = 1, sum1 = 1;
	int i, n;
	printf("x,n:");
	scanf("%lf%d", &x, &n);
	ftime(&t1);
	for (i = 1; i <= n; i++)
	{
		sum1 *= -(1.0) / x;
		sum += sum1;
	}
	ftime(&t2);
	t = (t2.time - t1.time) * 1000 + (t2.millitm - t1.millitm);
	printf("sum= %lf %ldms\n ", sum, t);
	return 0;
}
