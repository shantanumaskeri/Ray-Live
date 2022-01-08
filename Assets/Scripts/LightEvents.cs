using UnityEngine;

public class LightEvents : MonoBehaviour
{

    #region Public variables

    public ApplicationManager applicationManager;

    #endregion

    #region Custom function (to check bot light fade in / out animation completion)

    public void BotLightFadeInComplete()
    {
        applicationManager.audioSource.clip = applicationManager.motion;
        applicationManager.audioSource.Play();

        applicationManager.raybotSequence.isAnimating = true;
    }

    public void BotLightFadeOutComplete()
    {
        applicationManager.botLightAnimator.gameObject.SetActive(false);
        applicationManager.sun.SetActive(true);

        applicationManager.cameraAnimator.Play("out_position");
    }

    #endregion

}
