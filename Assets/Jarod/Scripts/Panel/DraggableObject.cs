using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private Vector2 _offset;
    private RectTransform _rectTransform;

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        transform.SetAsLastSibling();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _rectTransform, eventData.position, eventData.pressEventCamera, out _offset);
    }

    public void OnDrag(PointerEventData eventData) {
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPointerPosition
            )) {
            _rectTransform.anchoredPosition = localPointerPosition - _offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
    }
}