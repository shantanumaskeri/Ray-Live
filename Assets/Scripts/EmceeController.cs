using Klak.Hap;
using UnityEngine;

public class EmceeController : MonoBehaviour
{

    #region Public variables

    [HideInInspector]
    public bool isEmceeOnScreen = false;

    public ApplicationManager applicationManager;

    #endregion

    #region Custom function (to control emcee on / off stage)

    public void ControlEmcee()
    {
        if (!applicationManager.raybotSequence.hasEntrySequenceStarted)
        {
            if (applicationManager.stageController.stageChangeKeyPressed == "")
            {
                applicationManager.sun.SetActive(true);

                applicationManager.objectLightAnimator.Play("object_light_2");
                applicationManager.objectLightAnimator.gameObject.SetActive(false);

                applicationManager.laptopController.isLaptopOnScreen = false;
                applicationManager.laptop.SetActive(applicationManager.laptopController.isLaptopOnScreen);

                applicationManager.carController.isCarOnScreen = false;

                for (int i = 0; i < applicationManager.raceCarParts.Length; i++)
                {
                    applicationManager.raceCarParts[i].enabled = applicationManager.carController.isCarOnScreen;
                }

                applicationManager.carController.ResetConfiguration();

                isEmceeOnScreen = !isEmceeOnScreen;
                applicationManager.emcee.SetActive(isEmceeOnScreen);
                applicationManager.emcee.GetComponent<HapPlayer>().time = 0.0f;

                if (isEmceeOnScreen)
                {
                    if (applicationManager.stage1.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_in");
                    }
                    else if (applicationManager.stage2.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_in_2");
                    }
                    else if (applicationManager.stage3.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_in_3");
                    }
                    else if (applicationManager.stage4.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_in_4");
                    }
                }
                else
                {
                    if (applicationManager.stage1.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_out");
                    }
                    else if (applicationManager.stage2.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_out_2");
                    }
                    else if (applicationManager.stage3.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_out_3");
                    }
                    else if (applicationManager.stage4.activeSelf)
                    {
                        applicationManager.cameraAnimator.Play("camera_emcee_out_4");
                    }
                }

                PositionEmcee();
            }
        }
    }

    private void PositionEmcee()
    {
        if (applicationManager.stage1.activeSelf)
        {
            applicationManager.emcee.transform.position = new Vector3(applicationManager.emcee.transform.position.x, 1.3f, applicationManager.emcee.transform.position.z);
        }
        else if (applicationManager.stage2.activeSelf)
        {
            applicationManager.emcee.transform.position = new Vector3(applicationManager.emcee.transform.position.x, 0.98f, applicationManager.emcee.transform.position.z);
        }
        else if (applicationManager.stage3.activeSelf)
        {
            applicationManager.emcee.transform.position = new Vector3(applicationManager.emcee.transform.position.x, 1.3f, applicationManager.emcee.transform.position.z);
        }
        else if (applicationManager.stage3.activeSelf)
        {
            applicationManager.emcee.transform.position = new Vector3(applicationManager.emcee.transform.position.x, 1.14f, applicationManager.emcee.transform.position.z);
        }
    }

    #endregion

}
