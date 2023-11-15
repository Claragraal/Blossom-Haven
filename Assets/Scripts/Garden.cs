using UnityEngine;

public class Garden : MonoBehaviour
{
    public GameObject tilePrefab;  // Drag your "Tile" prefab here in the Unity Editor
    public int xSize = 5;  // Number of tiles along the x-axis
    public int ySize = 5;  // Number of tiles along the y-axis
    public float tileSize = 1.0f; // Size of each tile
    public Vector3 startPosition = Vector3.zero; // Starting position of the grid

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                // Calculate position for each tile based on grid size, tile size, and starting position
                Vector3 tilePosition = startPosition + new Vector3(x * tileSize, y * tileSize, 0);

                // Instantiate a new tile at the calculated position
                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);

                // Set the newly created tile as a child of the Garden object
                tile.transform.parent = transform;

                // Add Rigidbody2D to ensure proper spacing and prevent overlapping
                Rigidbody2D rigidbody2D = tile.AddComponent<Rigidbody2D>();
                rigidbody2D.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
