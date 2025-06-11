using UnityEngine;

public class TdTowerBuilder : MonoBehaviour
{
    // TODO: P�idat mo�nost v�b�ru v�e, kterou chceme postavit
    // R�zn� typy v��
    // Ne overlap circle, ale sp� TriggerEnter/Exit

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
            lastTile.Build(GameObject.CreatePrimitive(PrimitiveType.Sphere)); // P�edpokl�d�me, �e tento skript je p�ipojen k objektu v�e
        }
    }
}
