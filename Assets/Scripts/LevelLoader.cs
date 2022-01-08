using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    #region Public variables

    public ApplicationManager applicationManager;

    #endregion

    #region Custom function (to control fade in / out and change stage)

    public void FadeToLevel()
    {
        applicationManager.levelAnimator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        applicationManager.levelAnimator.SetTrigger("FadeIn");

        applicationManager.stageController.UpdateStage();
    }

    #endregion

}
