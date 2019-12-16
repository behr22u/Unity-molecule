
using UnityEngine;
public class Atome 
{
    public string Symbole { get; }
    public string Name { get; }
    public Color Color { get; }
    public int Scale { get; }

    public Atome(string symbole, string name, Color color, int scale)
    {
        Symbole = symbole;
        Name = name;
        Color = color;
        Scale = scale;
    }

}
