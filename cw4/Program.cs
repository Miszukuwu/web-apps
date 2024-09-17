int[] tab =  new int[10];
for (int i = 0; i < tab.Length; i++) {
    tab[i] = i * i;
}
string[] tab2 = new string[] {"ala","ma","Kota","i","plot","ale","jaja","rety","Kotlety"};
int[] tab3 = GenerTab(10);
Person[] tab4 = new Person[] { new Person("Jan", "Kowalski", 20), new Person(), new Person("Kacper", "Nowak") };
showTable(tab);
showTable(tab2);
showTable(tab3);
showTable(tab4);
Console.WriteLine("Max = " + GetMax(tab3));
Console.WriteLine("Min = " + GetMin(tab3));
Console.WriteLine("Amplitude = " + (GetMax(tab3) + GetMin(tab3)));
Console.WriteLine("Avg = " + GetAvg(tab3));
showTable(GenerDivBy(10,5));

void showTable<T>(T[] tab){
    foreach (T element in tab) {
        Console.Write(element+" ");
    }
    Console.WriteLine();

}
int[] GenerTab(int size){
    Random rnd = new Random();
    int[] tab = new int[size];
    for (int i = 0; i < tab.Length; i++) {
        tab[i] = rnd.Next(100);
    }
    return tab;
}
int GetMax(int[] arr){
    int max = arr[0];
    for (int i = 1; i < arr.Length; i++) {
        if (arr[i] > max) {
            max = arr[i];
        }
    }
    return max;
}
int GetMin(int[] arr){
    int min = arr[0];
    for (int i = 1; i < arr.Length; i++) {
        if (arr[i] < min) {
            min = arr[i];
        }
    }

    return min;
}
double GetAvg(int[] arr){
    return (double)GetSum(arr) / arr.Length;
}
int GetSum(int[] arr){
    int sum = 0;
    for (int i = 0; i < arr.Length; i++) {
        sum += arr[i];
    }
    return sum;
}
int[] GenerDivBy(int size, int div){
    Random rnd = new Random();
    int[] tab = new int[size];
    for (int i = 0; i < tab.Length; i++) {
        tab[i] = rnd.Next(100/div)*div;
    }
    return tab;
}