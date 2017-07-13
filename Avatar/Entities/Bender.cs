using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    protected int Power { get { return this.power; } }

    public override string ToString()
    {
        string benderType = this.GetType().Name;
        int typeEnd = benderType.IndexOf("Bender");
        benderType = benderType.Insert(typeEnd, " ");

        return $"{benderType}: {this.name}, Power: {this.Power}";
    }

    public abstract double GetPower();
}
