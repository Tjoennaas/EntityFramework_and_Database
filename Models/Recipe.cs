


/*
Validering
Name (påkrevd, 3–100 tegn)
Ingredients (minst 1)
Steps (minst 1, maks 50)*/


namespace Models;

public class recipes{

     public int id { get; set; }

    public string Name { get; set; }

    public List<string> Ingredients { get; set; } = new();

    public List<string> Steps { get; set; }
    
}