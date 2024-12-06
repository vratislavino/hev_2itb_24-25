using UnityEngine;

public class RPSSymbol : MonoBehaviour
{
    private Symbol currentSymbol;
    public Symbol CurrentSymbol => currentSymbol;

    [SerializeField]
    private Material[] symbolMaterials;

    [SerializeField]
    private MeshRenderer symbolRenderer;

    void Start()
    {
        ChangeSymbol(GetRandomSymbol(false));
    }

    public void ChangeSymbol(Symbol newSymbol)
    {
        currentSymbol = newSymbol;
        // update the sprite
        symbolRenderer.material = symbolMaterials[(int)currentSymbol];
    }

    private Symbol GetRandomSymbol(bool baseOnCurrent = true)
    {
        if(baseOnCurrent)
        {
            Symbol newSymbol = (Symbol)Random.Range(0, 3);
            if(newSymbol == currentSymbol)
            {
                return GetRandomSymbol(baseOnCurrent);
            }
            return newSymbol;
        }

        return (Symbol)Random.Range(0, 3);
    }

    public void ChangeSymbolToRandom()
    {
        ChangeSymbol(GetRandomSymbol());
    }
}

public enum Symbol
{
    Rock,
    Paper,
    Scissors
}
