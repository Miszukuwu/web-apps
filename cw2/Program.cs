void cw1(){
    Console.Write("Podaj a: ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Liczba {a} do potęgi wynosi {a * a}");
}

void cw2(){
    try {
        int a, b;
        Console.WriteLine("Podaj a: ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Podaj b: ");
        b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * {b} = {a * b}");
        if (b != 0)
            Console.WriteLine($"{a} / {b} = {(float)a / b}");
        else
            Console.WriteLine($"{a} / {b} = BRAK WYNIKU");
    }
    catch (Exception e) {
        Console.WriteLine("Fatal Error:");
        Console.WriteLine(e);
    }
}

void cw3(){
    int a;
    Console.WriteLine("Podaj a:");
    a = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine((a < 0)
        ? "Nie można pierwiastkować liczby mniejszej niż 0"
        : $"Pierwiastek liczby {a} wynosi {Math.Sqrt(a)}");
}
void cw4(){
    // Oblicz pierwiastki funkcji kwadratowej
    try {
        double a, b, c;
        Console.WriteLine("Podaj a:");
        a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Podaj b:");
        b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Podaj c:");
        c = Convert.ToDouble(Console.ReadLine());
        double delta = Math.Pow(b, 2) - 4 * a * c;
        if (delta > 0) {
            double x1, x2;
            x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"Istnieją dwa pierwiastki tej funkcji kwadratowej: {x1} i {x2}");
        }
        else if (delta == 0) {
            double x1 = -b / (2 * a);
            Console.WriteLine($"Istnieje jeden pierwiastek tej funckji kwadratowej: {x1}");
        }
        else {
            Console.WriteLine("Nie istnieje żadnych pierwiastków tej funkcji kwadratowej");
        }
    }
    catch (Exception e) {
        Console.WriteLine("Fatal Error:");
        Console.WriteLine(e);
    }
}
// cw1();
// cw2();
// cw3();
cw4();