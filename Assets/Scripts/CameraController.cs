using UnityEngine;

public class CameraController : MonoBehaviour
{

    #region Public variables

    public Animator anim;

    public ApplicationManager applicationManager;

    #endregion

    #region Custom function (to play camera animation)

    public void PlayCameraAnimations(string animationName)
    {
        if (applicationManager.stageController.stageChangeKeyPressed == "")
        {
            if (!applicationManager.raybotSequence.hasEntrySequenceStarted || applicationManager.raybotSequence.hasEntrySequenceEnded || !applicationManager.raybotSequence.hasExitSequenceStarted || applicationManager.raybotSequence.hasExitSequenceEnded)
            {
                anim.Play(animationName);
            }
        }
    }

    #endregion

}
