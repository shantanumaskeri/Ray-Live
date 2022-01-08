using UnityEngine;

public class ObsDisplay : MonoBehaviour
{

    #region Public variables

    public GameObject stage_input1;
    public GameObject stage_input2;
    public GameObject stage_input3;
    public GameObject stage_input4;

    #endregion

    #region Private variables

    private WebCamDevice[] devices;
    private WebCamTexture webcamTexture;

    #endregion

    #region Monobehaviour Callbacks (start)

    private void Start()
    {
        ActivateVideoFeed();
    }

    #endregion

    #region Custom function (to activate video feed via OBS)

    private void ActivateVideoFeed()
    {
        devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture();

        for (int i = 0; i < devices.Length; i++)
        {
            print(devices[i].name);
            if (devices[i].name == "OBS-Camera")// || devices[i].name == "HD User Facing")
            {
                webcamTexture.deviceName = devices[i].name;

                stage_input1.GetComponent<Renderer>().material.mainTexture = webcamTexture;
                stage_input2.GetComponent<Renderer>().material.mainTexture = webcamTexture;
                stage_input3.GetComponent<Renderer>().material.mainTexture = webcamTexture;
                stage_input4.GetComponent<Renderer>().material.mainTexture = webcamTexture;

                webcamTexture.Play();
            }
        }
    }

    #endregion

}