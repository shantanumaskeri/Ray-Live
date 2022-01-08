using UnityEngine;

public class CameraEvents : MonoBehaviour
{

    #region Public variables

    public ApplicationManager applicationManager;

    #endregion

    #region Custom function (to check camera in / out position animation completion)

    public void CameraInPositionComplete()
    {
        applicationManager.sun.SetActive(false);

        applicationManager.botLightAnimator.gameObject.SetActive(true);
        applicationManager.botLightAnimator.enabled = true;
        applicationManager.botLightAnimator.Play("bot_light");
    }

    public void CameraOutPositionComplete()
    {
        applicationManager.raybotSequence.hasExitSequenceEnded = true;
        applicationManager.raybotSequence.hasEntrySequenceStarted = false;
        applicationManager.raybotSequence.hasExitSequenceStarted = false;
        applicationManager.raybotSequence.hasEntrySequenceEnded = false;
    }

    #endregion

}
