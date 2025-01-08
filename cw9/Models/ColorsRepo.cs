namespace cw9.Models;

public class ColorsRepo {
    public static List<MyColor> GetColors() {
        return new List<MyColor>(){
            new MyColor(){ Value = "Biały", Key = "White" },
            new MyColor(){ Value = "Niebieski", Key = "Blue" },
            new MyColor(){ Value = "Zielony", Key = "Green" },
            new MyColor(){ Value = "Czerwony", Key = "Red" },
            new MyColor(){ Value = "Żółty", Key = "Yellow" },
            new MyColor(){ Value = "Pomarańczowy", Key = "Orange" },
        };
    }
}
