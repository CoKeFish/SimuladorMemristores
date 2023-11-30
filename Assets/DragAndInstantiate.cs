using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndInstantiate : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject prefabToInstantiate; // Asigna el prefab que deseas instanciar aquí
    private GameObject instance; // La instancia del objeto que se está arrastrando
    public float gridSize = 1.0f; // Tamaño de la celda de la cuadrícula

    public void OnPointerDown(PointerEventData eventData)
    {
        // Puedes añadir lógica aquí si necesitas hacer algo cuando el usuario hace clic en el objeto
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Instancia el objeto en el mundo del juego en la posición inicial del arrastre
        Vector3 worldPosition = SnapToGrid(Camera.main.ScreenToWorldPoint(eventData.position));
        instance = Instantiate(prefabToInstantiate, worldPosition, Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Actualiza la posición del objeto instanciado
        Vector3 screenPoint = eventData.position;
        screenPoint.z = 10.0f; // Asegúrate de que el objeto esté visible en la cámara
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPoint);
        instance.transform.position = SnapToGrid(worldPosition);

        // Rotar el objeto si se presiona la tecla 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            instance.transform.Rotate(0, 0, 90);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Finaliza el arrastre, puedes añadir lógica adicional aquí si es necesario
    }

    private Vector3 SnapToGrid(Vector3 position)
    {
        // Redondea las coordenadas para que se ajusten a la cuadrícula
        float x = Mathf.Round(position.x / gridSize) * gridSize;
        float y = Mathf.Round(position.y / gridSize) * gridSize;
        return new Vector3(x, y, position.z);
    }
}