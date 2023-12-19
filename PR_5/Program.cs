class Program
{
    static int punkt = 0, podpunkt = 0;
    static List<List<string>> main_menu = new List<List<string>>()
    {
        new List<string>(){
            "Форма",
            "Размеер",
            "Вкус",
            "Количество коржей",
            "Глазурь",
            "Декор"
        },
        new List<string>(){
            "Сердце",
            "Круг",
            "Овал",
            "Ромб",
            "Параллелепипед"
        },
        new List<string>(){
            "Большой",
            "Никакой",
            "Мелкий",
            "Крысиный",
            "Фиолетовый"
        },
        new List<string>(){
            "Клубника",
            "Шоколад",
            "Яблоко",
            "Банан",
            "Брусочко бананчик"
        },
        new List<string>(){
            "Один",
            "Два",
            "Пидисят два",
            "Двадцать четыре",
            "Четыре"
        },
        new List<string>(){
            "Клубника",
            "Шоколад",
            "Яблоко",
            "Банан",
            "Брусочко бананчик"
        },
        new List<string>(){
            "Ничего",
            "Не понятно чего",
            "Дохрена непонятно чего",
            "Ахренеть - это что",
            "О серпантинки или как их там"
        }
    };
    static Tort tort = new Tort();
    static void Main() => menu();
    static void menu()
    {
        while (true)
        {
            print_menu("Выбрите пункт меню:");
            punkt = pointer(true) - 1;
            print_menu("Выберите подпункт", punkt);
            podpunkt = pointer() - 2;
            if (punkt == 1)
                tort.set_form(main_menu[punkt][podpunkt]);
            else if (punkt == 2)
                tort.set_size(main_menu[punkt][podpunkt]);
            else if (punkt == 3)
                tort.set_vkus(main_menu[punkt][podpunkt]);
            else if (punkt == 4)
                tort.set_count(main_menu[punkt][podpunkt]);
            else if (punkt == 5)
                tort.set_glazur(main_menu[punkt][podpunkt]);
            else if (punkt == 6)
                tort.set_dekor(main_menu[punkt][podpunkt]);
        }

    }
    static int pointer(bool menu_ = false)
    {
        ConsoleKeyInfo key;
        int point = 2;
        do
        {
            Console.SetCursorPosition(0, point);
            Console.WriteLine(">>");
            key = Console.ReadKey(true);
            Console.SetCursorPosition(0, point);
            Console.WriteLine("  ");
            if (key.Key == ConsoleKey.UpArrow)
            {
                point--;
                if (point < 2) point = 7;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                point++;
                if (point > 7) point = 2;
            }
        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.S);
        if (key.Key == ConsoleKey.Escape)
            menu();
        else if (key.Key == ConsoleKey.S && menu_)
        {
            save();
            menu();
        }
        return point;

    }
    static void print_menu(string title, int point = 0)
    {
        Console.Clear();
        Console.WriteLine(title);
        Console.WriteLine(string.Join("", Enumerable.Repeat("-", 50)));
        foreach (var a in main_menu[point])
            Console.WriteLine($"  {a}");
        if (point == 0)
            Console.WriteLine($"Ваш торт:\n{tort.get_tort().Replace("\t", null)}");
    }
    static void save()
    {
        File.AppendAllText("save.txt", $"Новый заказ:\n{DateTime.Now.ToShortDateString()}\n{tort.get_tort() }\n");
        tort = new Tort();
    }
}
class Tort
{
    private string Form;
    private string Size;
    private string Vkus;
    private string Count;
    private string Glazur;
    private string Dekor;

    public Tort() { }

    public void set_form(string form) => Form = form;
    public void set_size(string size) => Size = size;
    public void set_vkus(string vkus) => Vkus = vkus;
    public void set_count(string count) => Count = count;
    public void set_glazur(string glazur) => Glazur = glazur;
    public void set_dekor(string dekor) => Dekor = dekor;

    public string get_tort() => $"\tФорма: {Form}\n\tРазмер: {Size}\n\tВкус: {Vkus}\n\tКоличество коржей: {Count}\n\tГлазурь: {Glazur}\n\tДекор: {Dekor}\n";
}