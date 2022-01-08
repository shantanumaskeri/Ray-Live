using System.Collections;
using UnityEngine;

public class StageController : MonoBehaviour
{

    #region Public variables

    public ApplicationManager applicationManager;

    [HideInInspector]
    public string stageChangeKeyPressed = "";

    #endregion

    #region Custom function (to check key press and change stage)

    public void ControlStage(GameObject stage, string key)
    {
        if (!applicationManager.raybotSequence.hasEntrySequenceStarted)
        {
            if (stageChangeKeyPressed == "")
            {
                if (!stage.activeSelf)
                {
                    applicationManager.cameraAnimator.Play("camera_stage_front");

                    applicationManager.objectLightAnimator.Play("object_light_2");
                    applicationManager.objectLightAnimator.gameObject.SetActive(false);

                    applicationManager.sun.SetActive(true);

                    applicationManager.carController.isCarOnScreen = false;
                    applicationManager.emceeController.isEmceeOnScreen = false;
                    applicationManager.laptopController.isLaptopOnScreen = false;

                    applicationManager.emcee.SetActive(false);
                    applicationManager.laptop.SetActive(false);

                    for (int i = 0; i < applicationManager.raceCarParts.Length; i++)
                    {
                        applicationManager.raceCarParts[i].enabled = applicationManager.carController.isCarOnScreen;
                    }

                    applicationManager.carController.ResetConfiguration();

                    stageChangeKeyPressed = key;
                    
                    StartCoroutine(CheckKeyPressed());
                }
            }
        }
    }

    private IEnumerator CheckKeyPressed()
    {
        yield return new WaitForSeconds(3.0f);

        applicationManager.levelLoader.FadeToLevel();
    }

    public void UpdateStage()
    {
        applicationManager.cameraAnimator.Play("base_movement");

        applicationManager.stage1.SetActive(false);
        applicationManager.stage2.SetActive(false);
        applicationManager.stage3.SetActive(false);
        applicationManager.stage4.SetActive(false);

        switch (stageChangeKeyPressed)
        {
            case "F1":
                applicationManager.stage1.SetActive(true);
                //applicationManager.postProcessingBehaviour.enabled = false;
                break;

            case "F2":
                applicationManager.stage2.SetActive(true);
                //applicationManager.postProcessingBehaviour.enabled = false;
                break;

            case "F3":
                applicationManager.stage3.SetActive(true);
                //applicationManager.postProcessingBehaviour.enabled = false;
                break;

            case "F4":
                applicationManager.stage4.SetActive(true);
                //applicationManager.postProcessingBehaviour.enabled = true;
                break;
        }

        stageChangeKeyPressed = "";
    }

    #endregion

    #region Custom function (to change tint of 3rd / 4th stage)

    public void ChangeStageTint(Color color)
    {
        Color tintColor = color;

        if (applicationManager.stage3.activeSelf)
        {
            applicationManager.sun.GetComponent<Light>().color = tintColor;
            applicationManager.ring.GetComponent<MeshRenderer>().material.color = tintColor;

            applicationManager.floor.color = tintColor;
            applicationManager.ceiling.color = tintColor;

            if (tintColor == Color.white)
            {
                Color originalColor = new Color(0.65882353f, 0.65882353f, 0.65882353f);

                applicationManager.floor.SetColor("_EmissionColor", originalColor);
                applicationManager.ceiling.SetColor("_EmissionColor", originalColor);
            }
            else
            {
                applicationManager.floor.SetColor("_EmissionColor", tintColor);
                applicationManager.ceiling.SetColor("_EmissionColor", tintColor);
            }

            applicationManager.lightRenderer.material.SetColor("_EmissionColor", tintColor);
        }
        else if (applicationManager.stage4.activeSelf)
        {
            for (int i = 0; i < applicationManager.trussPointLights.Length; i++)
            {
                applicationManager.trussPointLights[i].GetComponent<Light>().color = tintColor;
            }

            if (tintColor == Color.white)
            {
                applicationManager.stepSurfBottom.color = new Color(0.8156862f, 0.8392156f, 0.905882f);
                applicationManager.stepSurfTop.color = new Color(0.8156862f, 0.8392156f, 0.905882f);

                Color vertOriginalColor = new Color(0.3294117f, 0.396078f, 0.749019f);
                vertOriginalColor *= applicationManager.colorIntensityVertical;

                Color horizOriginalColor = new Color(0.3294117f, 0.396078f, 0.749019f);
                horizOriginalColor *= applicationManager.colorIntensityHorizontal;

                applicationManager.vertLedStrips.SetColor("_EmissionColor", vertOriginalColor);
                applicationManager.horizLedStrips.SetColor("_EmissionColor", horizOriginalColor);
            }
            else
            {
                applicationManager.stepSurfBottom.color = tintColor;
                applicationManager.stepSurfTop.color = tintColor;

                Color vertTintColor = tintColor;
                Color horizTintColor = tintColor;

                vertTintColor *= applicationManager.colorIntensityVertical * 0.75f;
                horizTintColor *= applicationManager.colorIntensityHorizontal * 0.75f;

                applicationManager.vertLedStrips.SetColor("_EmissionColor", vertTintColor);
                applicationManager.horizLedStrips.SetColor("_EmissionColor", horizTintColor);
            }
        }
    }

    #endregion

}
