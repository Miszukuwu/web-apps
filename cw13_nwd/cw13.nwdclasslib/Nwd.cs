namespace cw13.nwdclasslib;

public class Nwd
{
    public int Calculate(int a, int b)
    {
        if (a == 0 && b == 0)
            throw new ArgumentException("a and b cant be zeros");
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
