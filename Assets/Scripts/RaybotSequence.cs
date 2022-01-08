using System.Collections;
using UnityEngine;

public class RaybotSequence : MonoBehaviour
{

    #region Public variables

    [HideInInspector]
    public bool hasEntrySequenceStarted;
    [HideInInspector]
    public bool hasExitSequenceEnded;
    [HideInInspector]
    public bool hasExitSequenceStarted;
    [HideInInspector]
    public bool hasEntrySequenceEnded;
    [HideInInspector]
    public bool isAnimating;
    [HideInInspector]
    public Transform currentView;

    public ApplicationManager applicationManager;

    #endregion

    #region Private variables

    private float timeCount = 0.0f;
    private float transitionSpeed = 2.0f;

    #endregion

    #region Monobehaviour Callbacks (start / update)

    private void Start()
    {
        isAnimating = false;
        hasEntrySequenceStarted = false;
        hasExitSequenceStarted = false;
        hasEntrySequenceEnded = false;
        hasExitSequenceEnded = true;

        applicationManager.botLightAnimator.enabled = false;
    }

    private void Update()
    {
        SetRobotLocomotion();
    }

    #endregion

    #region Custom function (to control raybot on / off stage)

    public void ControlRaybotEntry()
    {
        if (applicationManager.stageController.stageChangeKeyPressed == "")
        {
            if (!hasEntrySequenceStarted)
            {
                currentView = applicationManager.entryPoint;

                applicationManager.objectLightAnimator.Play("bot_light_2");
                applicationManager.objectLightAnimator.gameObject.SetActive(false);

                applicationManager.carController.isCarOnScreen = false;
                applicationManager.emceeController.isEmceeOnScreen = false;
                applicationManager.laptopController.isLaptopOnScreen = false;

                applicationManager.laptop.SetActive(false);
                applicationManager.emcee.SetActive(false);

                for (int i = 0; i < applicationManager.raceCarParts.Length; i++)
                {
                    applicationManager.raceCarParts[i].enabled = false;
                }

                applicationManager.carController.ResetConfiguration();

                applicationManager.cameraAnimator.Play("in_position");

                hasEntrySequenceStarted = true;

                applicationManager.lightController.HideAllLights();
            }
        }
    }

    public void ControlRaybotExit()
    {
        if (applicationManager.stageController.stageChangeKeyPressed == "")
        {
            if (hasEntrySequenceEnded)
            {
                if (!hasExitSequenceStarted)
                {
                    applicationManager.audioSource.clip = applicationManager.exitSpeech;
                    applicationManager.audioSource.Play();

                    applicationManager.botAnimator.Play("ReverseAnimation");

                    hasExitSequenceStarted = true;
                }
            }
        }
    }

    private void SetRobotLocomotion()
    {
        if (isAnimating)
        {
            timeCount += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

            if (timeCount > transitionSpeed)
            {
                if (!hasExitSequenceStarted)
                {
                    ResetVariables();
                    AnimateRobot();
                }
                else
                {
                    ResetVariables();
                    AnimateLight();
                }
            }
        }
    }

    private void AnimateRobot()
    {
        applicationManager.botAnimator.enabled = true;
        applicationManager.botAnimator.Play("ForwardAnimation");
    }

    private void AnimateLight()
    {
        applicationManager.botLightAnimator.Play("bot_light_2");
        applicationManager.botAnimator.enabled = false;
    }

    private void ResetVariables()
    {
        isAnimating = false;
        timeCount = 0.0f;
    }

    public IEnumerator EntrySequenceComplete()
    {
        yield return new WaitForSeconds(applicationManager.entrySpeech.length);

        hasEntrySequenceEnded = true;
    }

    #endregion

}
