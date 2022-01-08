using UnityEngine;

public class CarController : MonoBehaviour
{

    #region Public variables

    [HideInInspector]
    public bool canRotate = false;
    [HideInInspector]
    public bool isCarOnScreen = false;

    public ApplicationManager applicationManager;

    #endregion

    #region Private variables

    private float timeCount = 0.0f;
    private float transitionSpeed = 0.5f;
    private Vector3 localPosition;
    private Vector3 localAngle;

    #endregion

    #region Monobehaviour Callbacks (awake / update)

    private void Awake()
    {
        localPosition = transform.localPosition;
        localAngle = transform.localEulerAngles;
    }

    private void Update()
    {
        if (isCarOnScreen)
        {
            if (!canRotate)
            {
                timeCount += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, applicationManager.carPoint.position, Time.deltaTime * transitionSpeed);
            }
            else
            {
                transform.Rotate(0, 20.0f * Time.deltaTime, 0);
            }

            if (timeCount > 6.0f)
            {
                canRotate = true;
                timeCount = 0.0f;
            }
        }   
    }

    #endregion

    #region Custom function (to control car on / off stage)

    public void ControlCar()
    {
        if (!applicationManager.raybotSequence.hasEntrySequenceStarted)
        {
            if (applicationManager.stageController.stageChangeKeyPressed == "")
            {
                applicationManager.emceeController.isEmceeOnScreen = false;

                isCarOnScreen = !isCarOnScreen;
                
                for (int i = 0; i < applicationManager.raceCarParts.Length; i++)
                {
                    applicationManager.raceCarParts[i].enabled = isCarOnScreen;
                }
                
                applicationManager.emcee.SetActive(isCarOnScreen);
                applicationManager.sun.SetActive(!isCarOnScreen);

                applicationManager.laptopController.isLaptopOnScreen = false;
                applicationManager.laptop.SetActive(applicationManager.laptopController.isLaptopOnScreen);

                if (isCarOnScreen)
                {
                    applicationManager.objectLightAnimator.gameObject.SetActive(true);
                    applicationManager.objectLightAnimator.Play("object_light");
                    applicationManager.cameraAnimator.Play("camera_car_in");
                }
                else
                {
                    applicationManager.objectLightAnimator.Play("object_light_2");
                    applicationManager.cameraAnimator.Play("camera_car_out");

                    ResetConfiguration();
                }
            }
        }
    }

    public void ResetConfiguration()
    {
        canRotate = false;
        timeCount = 0.0f;

        transform.localPosition = localPosition;
        transform.localEulerAngles = localAngle;
    }

    #endregion

}
