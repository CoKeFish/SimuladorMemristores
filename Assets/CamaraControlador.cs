using UnityEngine;

public class CamaraControlador : MonoBehaviour
{
    public float velocidadDeDesplazamiento = 0.5f;
    public float velocidadDeZoom = 10.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 20.0f;

    void Update()
    {
        // Desplazamiento
        float desplazamientoHorizontal = Input.GetAxis("Horizontal");
        float desplazamientoVertical = Input.GetAxis("Vertical");

        Vector3 desplazamiento = new Vector3(desplazamientoHorizontal, desplazamientoVertical, 0);
        transform.Translate(desplazamiento * velocidadDeDesplazamiento);

        // Zoom
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize -= zoom * velocidadDeZoom;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
    }
}