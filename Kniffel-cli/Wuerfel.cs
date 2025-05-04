namespace Kniffel_cli;

public class Wuerfel
{
    private int augenzahl;
    private int minAugenzahl;
    private int maxAugenzahl;
    private bool ausgewaehlt;
    
    public int Augenzahl { get => augenzahl; set => augenzahl = value; }
    public int MinAugenzahl { get => minAugenzahl; }
    public int MaxAugenzahl { get => maxAugenzahl; }
    public bool Ausgewaehlt { get => ausgewaehlt; set => ausgewaehlt = value; }

    public Wuerfel(int minAugenzahl, int maxAugenzahl)
    {
        this.minAugenzahl = minAugenzahl;
        this.maxAugenzahl = maxAugenzahl;
    }

    public void Wuerfeln()
    {
        if(ausgewaehlt)
        {
            return;
        }
        
        Random rnd = new Random();
        augenzahl = rnd.Next(minAugenzahl, maxAugenzahl + 1);
    }

    public void ResetWuerfel()
    {
        augenzahl = 0;
        ausgewaehlt = false;
    }
}