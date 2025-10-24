int s1 = 15;
int s2 = 16;
int s3 = -4968;
int s4 = 15;
int s5 = 15;

double m = (s1 + s2 + s3 + s4 + s5) / 5.0;

int c = (s1 < 0.9 * m || s1 > 1.1 * m ? 1 : 0) +
        (s2 < 0.9 * m || s2 > 1.1 * m ? 1 : 0) +
        (s3 < 0.9 * m || s3 > 1.1 * m ? 1 : 0) +
        (s4 < 0.9 * m || s4 > 1.1 * m ? 1 : 0) +    
        (s5 < 0.9 * m || s5 > 1.1 * m ? 1 : 0);

bool alarm = 2 <= c;
Console.WriteLine(alarm);