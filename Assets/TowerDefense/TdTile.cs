using UnityEngine;
using UnityEngine.EventSystems;

public class TdTile : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer tileRenderer;

    private Color originalColor;

    private void Start()
    {
        originalColor = tileRenderer.color;
    }

    public void Highlight()
    {
        tileRenderer.color = Color.yellow;
    }

    public void Unhighlight()
    {
        tileRenderer.color = originalColor;
    }

    public void Build(GameObject towerToBuild)
    {
        var newTower = Instantiate(towerToBuild, transform);
        // dál nìjaké nastavení vìže
    }
}
