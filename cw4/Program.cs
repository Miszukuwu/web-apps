int[] tab =  new int[10];
for (int i = 0; i < tab.Length; i++) {
    tab[i] = i * i;
}
string[] tab2 = new string[] {"ala","ma","Kota","i","plot","ale","jaja","rety","Kotlety"};
int[] tab3 = generTab(10);

showTable(tab);
showTable(tab2);
showTable(tab3);
void showTable<T>(T[] tab){
    foreach (T element in tab) {
        Console.Write(element+" ");
    }
    Console.WriteLine();

}
int[] generTab(int size){
    Random rnd = new Random();
    int[] tab = new int[size];
    for (int i = 0; i < tab.Length; i++) {
        tab[i] = rnd.Next(100);
    }

    return tab;
}