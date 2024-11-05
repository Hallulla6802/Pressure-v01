using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class RenderTextureUIInteraction : MonoBehaviour
{
    public Camera mainCamera;      // Cámara principal que observa el quad
    public Camera uiCamera;        // Cámara que renderiza el Canvas en la RenderTexture
    public Canvas uiCanvas;        // El Canvas del UI en la RenderTexture
    public RenderTexture renderTexture;

    private GameObject currentHoveredObject;
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            Vector2 textureCoord = hit.textureCoord;
            Vector2 renderTextureCoord = new Vector2(textureCoord.x * renderTexture.width, textureCoord.y * renderTexture.height);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(uiCanvas.GetComponent<RectTransform>(), renderTextureCoord, uiCamera, out Vector2 localPoint);

            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = renderTextureCoord,
                button = PointerEventData.InputButton.Left,
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            RaycastResult? validResult = null;
            foreach (var result in results)
            {
                if (result.gameObject.GetComponent<Graphic>() != null && result.gameObject.GetComponent<Graphic>().raycastTarget)
                {
                    validResult = result;
                    break;
                }
            }

            if (validResult.HasValue)
            {
                GameObject hoveredObject = validResult.Value.gameObject;

                if (currentHoveredObject != hoveredObject)
                {
                    if (currentHoveredObject != null)
                    {
                        ExecuteEvents.Execute(currentHoveredObject, pointerData, ExecuteEvents.pointerExitHandler);
                    }
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.pointerEnterHandler);
                    currentHoveredObject = hoveredObject;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.pointerDownHandler);
                }

                if (Input.GetMouseButton(0))
                {
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.dragHandler);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.pointerUpHandler);
                    ExecuteEvents.Execute(hoveredObject, pointerData, ExecuteEvents.pointerClickHandler);
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
        }
    }
}