using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum DragType {Joystick, VerticleGear, HorizontalGear}

namespace Alok
{
	public class JoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{

		[SerializeField]
		DragType eDragType;

		private Image BgImag, JoystickButtonImg, HoriZontalBgImage, HorizontalBarButton, VerticleBgImage, VerticleBarButton;
		private Vector2 InputVector;


		void Start()
		{
			BgImag = GetComponent<Image>();
			JoystickButtonImg = transform.GetChild(0).GetComponent<Image>();
		}
		public void OnPointerDown(PointerEventData eventData)
		{
			OnDrag(eventData);
		}
		public void OnPointerUp(PointerEventData eventData)
		{
			InputVector = Vector2.zero;
			JoystickButtonImg.rectTransform.anchoredPosition = Vector2.zero;

		}
		public void OnDrag(PointerEventData eventData)
		{
			if (eDragType == DragType.Joystick)
				JoyStickCalculation(eventData);
			else if (eDragType == DragType.HorizontalGear)
				HorizontalGearCalculation(eventData);
			else if (eDragType == DragType.VerticleGear)
				VerticalGearCalculation(eventData);
		}

		void VerticalGearCalculation(PointerEventData eventData)
		{
			Vector2 Pos;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImag.rectTransform, eventData.position, eventData.enterEventCamera, out Pos))
				Pos.y = Pos.y / BgImag.rectTransform.sizeDelta.y;
			Pos.x = 0;
			InputVector = Pos * 2;
			InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;
			JoystickButtonImg.rectTransform.anchoredPosition = new Vector2(0, InputVector.y * BgImag.rectTransform.sizeDelta.y / 2);
		}
		void HorizontalGearCalculation(PointerEventData eventData)
		{
			Vector2 Pos;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImag.rectTransform, eventData.position, eventData.enterEventCamera, out Pos))
				Pos.x = Pos.x / BgImag.rectTransform.sizeDelta.x;
			Pos.y = 0;

			InputVector = Pos * 2;
			InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;
			JoystickButtonImg.rectTransform.anchoredPosition = new Vector2(InputVector.x * BgImag.rectTransform.sizeDelta.x / 2, 0);
		}
		void JoyStickCalculation(PointerEventData eventData)
		{
			Vector2 Pos;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImag.rectTransform, eventData.position, eventData.enterEventCamera, out Pos))
				Pos.x = Pos.x / BgImag.rectTransform.sizeDelta.x;
			Pos.y = Pos.y / BgImag.rectTransform.sizeDelta.y;
			InputVector = Pos * 2;
			InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;
			JoystickButtonImg.rectTransform.anchoredPosition = new Vector2(InputVector.x * BgImag.rectTransform.sizeDelta.x / 2, InputVector.y * BgImag.rectTransform.sizeDelta.y / 2);
		}
		public Vector2 DraggedValues()
		{
			return new Vector2(InputVector.x, InputVector.y);
		}
	}
}
