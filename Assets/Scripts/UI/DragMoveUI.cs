using UnityEngine;
using UnityEngine.EventSystems;

public class DragMoveUI : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private Transform target;
    private Vector2 beginPoint;
    private Vector2 moveBegin;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        beginPoint = target.position;
        moveBegin = eventData.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        target.position = beginPoint + (eventData.position - moveBegin);
    }
}
