using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class RenderTextureUIInteraction : MonoBehaviour
{
    public Camera mainCamera;      // Cámara principal que observa el quad
    public Camera uiCamera;        // Cámara que renderiza el Canvas en la RenderTexture
    public Canvas uiCanvas;        // El Canvas del UI en la RenderTexture
    public RenderTexture renderTexture;

    private GameObject currentHoveredObject;
    private bool isDragging = false;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
        {
            // Convertir coordenadas del mouse a coordenadas del RenderTexture
            Vector2 textureCoord = hit.textureCoord;
            Vector2 renderTextureCoord = new Vector2(textureCoord.x * renderTexture.width, textureCoord.y * renderTexture.height);

            // Preparar PointerEventData
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = renderTextureCoord,
                button = PointerEventData.InputButton.Left
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0)
            {
                GameObject hoveredObject = results[0].gameObject;

                // Handle PointerEnter/Exit
                if (currentHoveredObject != hoveredObject)
                {
                    if (currentHoveredObject != null)
                        ExecuteEvents.Execute(currentHoveredObject, pointerData, ExecuteEvents.pointerExitHandler);

                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.pointerEnterHandler);
                    currentHoveredObject = hoveredObject;
                }

                // Handle Drag events
                if (Input.GetMouseButtonDown(0))
                {
                    isDragging = true;
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.beginDragHandler);
                }

                if (Input.GetMouseButton(0) && isDragging)
                {
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.dragHandler);
                }

                if (Input.GetMouseButtonUp(0) && isDragging)
                {
                    isDragging = false;
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.endDragHandler);
                }
            }
            else
            {
                if (currentHoveredObject != null)
                {
                    ExecuteEvents.Execute(currentHoveredObject, pointerData, ExecuteEvents.pointerExitHandler);
                    currentHoveredObject = null;
                }
            }
        }
        else
        {
            if (currentHoveredObject != null)
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(currentHoveredObject, pointerData, ExecuteEvents.pointerExitHandler);
                currentHoveredObject = null;
            }

            // Reset drag state if mouse is not on the RenderTexture
            if (isDragging && Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }
}