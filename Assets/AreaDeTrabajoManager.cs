using UnityEngine;

public class DrawGrid : MonoBehaviour
{
    public GameObject linePrefab;  // Prefab con LineRenderer
    public GameObject Camera; // Cámara principal
    public float cellSize = 1.0f;
    public int gridSize = 10;

    void Start()
    {
        //Pocisionar la cámara en el centro del grid
        Camera.transform.position = new Vector3(gridSize / 2, gridSize / 2, -10);
        
        for (float y = 0; y <= gridSize; y += cellSize)
        {
            DrawLine(new Vector3(0, y, 0), new Vector3(gridSize, y, 0));
        }

        for (float x = 0.75f; x <= gridSize; x += cellSize)
        {
            DrawLine(new Vector3(x, 0, 0), new Vector3(x, gridSize, 0));
        }
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineGO = Instantiate(linePrefab);
        LineRenderer lineRenderer = lineGO.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}