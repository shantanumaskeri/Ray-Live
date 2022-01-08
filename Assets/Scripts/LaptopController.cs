using System;
using UnityEngine;

public class LaptopController : MonoBehaviour
{

    #region Public variables

    [HideInInspector]
    public bool isLaptopOnScreen = false;
    
    public ApplicationManager applicationManager;

    #endregion

    #region Private variables

    private float originalY;
    private float floatStrength = 0.2f;

    #endregion

    #region Monobehaviour Callbacks (awake / update)

    private void Awake()
    {
        originalY = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x,
           originalY + ((float)Math.Sin(Time.time) * floatStrength),
           transform.position.z);

        transform.Rotate(0, 20.0f * Time.deltaTime, 0);
    }

    #endregion

    #region Custom function (to control laptop on / off stage)

    public void ControlLaptop()
    {
        if (!applicationManager.raybotSequence.hasEntrySequenceStarted)
        {
            if (applicationManager.stageController.stageChangeKeyPressed == "")
            {
                applicationManager.emceeController.isEmceeOnScreen = false;

                isLaptopOnScreen = !isLaptopOnScreen;
                applicationManager.laptop.SetActive(isLaptopOnScreen);

                applicationManager.emcee.SetActive(isLaptopOnScreen);
                applicationManager.sun.SetActive(!isLaptopOnScreen);

                applicationManager.carController.isCarOnScreen = false;

                for (int i = 0; i < applicationManager.raceCarParts.Length; i++)
                {
                    applicationManager.raceCarParts[i].enabled = applicationManager.carController.isCarOnScreen;
                }

                applicationManager.carController.ResetConfiguration();

                if (isLaptopOnScreen)
                {
                    applicationManager.objectLightAnimator.gameObject.SetActive(true);
                    applicationManager.objectLightAnimator.Play("object_light");
                    applicationManager.cameraAnimator.Play("camera_laptop_in");
                }
                else
                {
                    applicationManager.objectLightAnimator.Play("object_light_2");
                    applicationManager.cameraAnimator.Play("camera_laptop_out");
                }
            }
        }
    }

    #endregion

}
