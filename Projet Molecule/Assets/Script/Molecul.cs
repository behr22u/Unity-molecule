using System.Collections.Generic;
using UnityEngine;
public class Molecul
{
    public string Name { get; }
    public string Formule { get; }
    public string Structure { get; }
    public string Nodes { get; }
    public string Edges { get; }

    public static List<KeyValuePair<string, Atome>> atomes = new List<KeyValuePair<string, Atome>> {
        new KeyValuePair<string, Atome>("C", new Atome( "C","Carbone",Color.black,70 )),
        new KeyValuePair<string, Atome>("H", new Atome( "H","hydrogène",Color.white,25 )),
        new KeyValuePair<string, Atome>("CI", new Atome( "CI","chlore",Color.green,100 )),
        new KeyValuePair<string, Atome>("O", new Atome( "O","Oxygène",Color.red,60 )),
        new KeyValuePair<string, Atome>("N", new Atome( "N","Azote",Color.cyan,65 )),
	};
    
    public Molecul(string name, string formule, string structure)
    {
        Name = name;
        Formule = formule;
        Structure = structure;
    }
}
