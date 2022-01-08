using UnityEngine;

public class LightController : MonoBehaviour
{

    #region Public variables

    public ApplicationManager applicationManager;

    #endregion

    #region Private variables

    private bool mlc_on = false;
    private bool mlw_on = false;
    private bool slf_on = false;
    private bool sls_on = false;

    private bool light_white = false;
    private bool light_yellow = false;
    private bool light_red = false;
    private bool light_pink = false;
    private bool light_green = false;
    private bool light_orange = false;
    private bool light_purple = false;

    private bool isStageLoaded = false;

    #endregion

    #region Monobehaviour Callbacks (start / update)

    private void Start()
    {
        HideAllLights();
    }

    private void Update()
    {
        if (applicationManager.stage4.activeSelf)
        {
            if (!isStageLoaded)
            {
                AnimatePointLights();
                InvokeRepeating("AnimatePointLights", 4.0f, 4.0f);

                isStageLoaded = true;
            }
        }
    }

    #endregion

    #region Custom function (to play light animation)

    public void HideAllLights()
    {
        applicationManager.moving_lights_color.SetActive(false);
        applicationManager.moving_lights_white.SetActive(false);
        applicationManager.static_light_flud.SetActive(false);
        applicationManager.static_light_spot.SetActive(false);

        applicationManager.truss_light_white.SetActive(false);
        applicationManager.truss_light_yellow.SetActive(false);
        applicationManager.truss_light_red.SetActive(false);
        applicationManager.truss_light_pink.SetActive(false);
        applicationManager.truss_light_green.SetActive(false);
        applicationManager.truss_light_orange.SetActive(false);
        applicationManager.truss_light_purple.SetActive(false);
    }

    private void AnimatePointLights()
    {
        for (int i = 0; i < applicationManager.trussPointLights.Length; i++)
        {
            applicationManager.trussPointLights[i].SetActive(false);
        }

        int random = Random.Range(1, applicationManager.trussPointLights.Length);
        for (int i = 0; i < random; i++)
        {
            applicationManager.trussPointLights[i].SetActive(true);
        }
    }

    public void PlayLightAnimation(string type)
    {
        if (applicationManager.stageController.stageChangeKeyPressed == "")
        {
            if (!applicationManager.raybotSequence.hasEntrySequenceStarted || applicationManager.raybotSequence.hasEntrySequenceEnded || !applicationManager.raybotSequence.hasExitSequenceStarted || applicationManager.raybotSequence.hasExitSequenceEnded)
            {
                switch (type)
                {
                    case "Moving Lights Color":
                        mlc_on = !mlc_on;
                        applicationManager.moving_lights_color.SetActive(mlc_on);
                        break;

                    case "Moving Lights White":
                        mlw_on = !mlw_on;
                        applicationManager.moving_lights_white.SetActive(mlw_on);
                        break;

                    case "Static Lights Fluid":
                        slf_on = !slf_on;
                        applicationManager.static_light_flud.SetActive(slf_on);
                        break;

                    case "Static Lights Spot":
                        sls_on = !sls_on;
                        applicationManager.static_light_spot.SetActive(sls_on);
                        break;

                    case "Truss Light White":
                        light_white = !light_white;
                        applicationManager.truss_light_white.SetActive(light_white);
                        break;

                    case "Truss Light Yellow":
                        light_yellow = !light_yellow;
                        applicationManager.truss_light_yellow.SetActive(light_yellow);
                        break;

                    case "Truss Light Red":
                        light_red = !light_red;
                        applicationManager.truss_light_red.SetActive(light_red);
                        break;

                    case "Truss Light Pink":
                        light_pink = !light_pink;
                        applicationManager.truss_light_pink.SetActive(light_pink);
                        break;

                    case "Truss Light Green":
                        light_green = !light_green;
                        applicationManager.truss_light_green.SetActive(light_green);
                        break;

                    case "Truss Light Orange":
                        light_orange = !light_orange;
                        applicationManager.truss_light_orange.SetActive(light_orange);
                        break;

                    case "Truss Light Purple":
                        light_purple = !light_purple;
                        applicationManager.truss_light_purple.SetActive(light_purple);
                        break;
                }
            }
        }
    }

    #endregion

}
