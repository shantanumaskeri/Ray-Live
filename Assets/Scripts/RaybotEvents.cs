//using System.Collections;
using UnityEngine;

public class RaybotEvents : MonoBehaviour
{

    #region Public variables

    public ApplicationManager applicationManager;

    #endregion

    #region Custom function (to check bot entry / exit animation completion)

    public void BotEntryAnimationComplete()
    {
        //yield return new WaitForSeconds(4.6f);

        applicationManager.audioSource.clip = applicationManager.entrySpeech;
        applicationManager.audioSource.Play();

        applicationManager.cameraAnimator.Play("camera_bot");

        StartCoroutine(applicationManager.raybotSequence.EntrySequenceComplete());
    }

    public void BotExitAnimationComplete()
    {
        //yield return new WaitForSeconds(4.6f);

        applicationManager.raybotSequence.currentView = applicationManager.exitPoint;
        applicationManager.raybotSequence.isAnimating = true;

        applicationManager.audioSource.clip = applicationManager.motion;
        applicationManager.audioSource.Play();
    }

    #endregion

}
