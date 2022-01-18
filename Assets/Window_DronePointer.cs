using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Window_DronePointer : MonoBehaviour
{

    [SerializeField]private Camera uiCamera;
    public GameObject target;
    [SerializeField] private Image pointerImage;
    [SerializeField] private Sprite[] pointerPhases;

    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    private void Awake()
    {
        targetPosition = target.transform.position;
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    private void Update()
    {
        targetPosition = target.transform.position;
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - new Vector3(fromPosition.x,-101).normalized);
        float angle = -(UtilsClass.GetAngleFromVectorFloat(dir));
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
        
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= 0 || targetPositionScreenPoint.x >= Screen.width || targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y >= Screen.height;
        //Debug.Log(isOffScreen + " " + targetPositionScreenPoint);

        if (isOffScreen)
        {
            pointerImage.sprite = pointerPhases[1];
            pointerImage.color = Color.white;
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.x <= 0) cappedTargetScreenPosition.x = 0f;
            if (cappedTargetScreenPosition.y <= 0) cappedTargetScreenPosition.y = 0f;
            if (cappedTargetScreenPosition.x >= Screen.width) cappedTargetScreenPosition.x = Screen.width;
            if (cappedTargetScreenPosition.y >= Screen.height) cappedTargetScreenPosition.y = Screen.height;

            Vector3 pointerWorldPosition = cappedTargetScreenPosition;
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        
        }
        else
        {
            pointerImage.sprite = pointerPhases[0];
            pointerImage.color = Color.yellow;
            Vector3 droneWorldPosition = targetPositionScreenPoint;
            pointerRectTransform.position = droneWorldPosition;
        }
    }
}
