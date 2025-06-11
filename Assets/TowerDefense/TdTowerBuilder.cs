using UnityEngine;

public class TdTowerBuilder : MonoBehaviour
{
    // TODO: Pøidat možnost výbìru vìže, kterou chceme postavit
    // Rùzné typy vìží
    // Ne overlap circle, ale spíš TriggerEnter/Exit

    Camera cam;

    [SerializeField]
    private LayerMask tileLayerMask;

    TdTile lastTile = null;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        var col = Physics2D.OverlapPoint(worldPoint, tileLayerMask);

        if (col)
        {
            var tile = col.GetComponent<TdTile>();

            if (lastTile != tile && lastTile != null)
            {
                lastTile.Unhighlight();
                lastTile = null;
            }

            tile.Highlight();
            lastTile = tile;
        } else
        {
            if (lastTile != null)
            {
                lastTile.Unhighlight();
                lastTile = null;
            }
        }
        if(Input.GetMouseButtonDown(0) && lastTile != null)
        {
            lastTile.Build(GameObject.CreatePrimitive(PrimitiveType.Sphere)); // Pøedpokládáme, že tento skript je pøipojen k objektu vìže
        }
    }
}
