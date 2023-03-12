using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform panelRectTransform;
    private Vector2 pointerOffset;

    private void Awake()
    {
        panelRectTransform = transform.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPointerPosition = ClampToCanvas(eventData);
        Vector2 newPanelPosition = localPointerPosition - pointerOffset;
        panelRectTransform.localPosition = new Vector3(newPanelPosition.x, newPanelPosition.y, panelRectTransform.localPosition.z);
    }

    private Vector2 ClampToCanvas(PointerEventData eventData)
    {
        Vector2 localPointerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPointerPosition);
        float halfWidth = panelRectTransform.rect.width * 0.5f;
        float halfHeight = panelRectTransform.rect.height * 0.5f;
        float maxX = panelRectTransform.parent.GetComponent<RectTransform>().rect.width - halfWidth;
        float maxY = panelRectTransform.parent.GetComponent<RectTransform>().rect.height - halfHeight;
        float x = Mathf.Clamp(localPointerPosition.x, -maxX, maxX);
        float y = Mathf.Clamp(localPointerPosition.y, -maxY, maxY);
        return new Vector2(x, y);
    }
}