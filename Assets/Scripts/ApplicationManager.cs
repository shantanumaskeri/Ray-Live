using UnityEngine;
using UnityEngine.PostProcessing;

public class ApplicationManager : MonoBehaviour
{

    #region Public variables

    public GameObject[] trussPointLights;
    public MeshRenderer[] raceCarParts;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject sun;
    public GameObject laptop;
    public GameObject car;
    public GameObject emcee;
    public GameObject ring;
    public GameObject moving_lights_color;
    public GameObject moving_lights_white;
    public GameObject static_light_flud;
    public GameObject static_light_spot;
    public GameObject truss_light_white;
    public GameObject truss_light_yellow;
    public GameObject truss_light_red;
    public GameObject truss_light_pink;
    public GameObject truss_light_green;
    public GameObject truss_light_orange;
    public GameObject truss_light_purple;
    public Material floor;
    public Material ceiling;
    public Material vertLedStrips;
    public Material horizLedStrips;
    public Material stepSurfBottom;
    public Material stepSurfTop;
    public MeshRenderer lightRenderer;
    public Animator botLightAnimator;
    public Animator objectLightAnimator;
    public Animator cameraAnimator;
    public Animator botAnimator;
    public Animator levelAnimator;
    public Transform entryPoint;
    public Transform exitPoint;
    public Transform carPoint;
    public AudioClip motion;
    public AudioClip entrySpeech;
    public AudioClip exitSpeech;
    public AudioSource audioSource;
    public float colorIntensityVertical = 3.4f;
    public float colorIntensityHorizontal = 2.4f;

    public PostProcessingBehaviour postProcessingBehaviour;
    public LevelLoader levelLoader;
    public RaybotSequence raybotSequence;
    public LightController lightController;
    public CameraController cameraController;
    public EmceeController emceeController;
    public CarController carController;
    public LaptopController laptopController;
    public StageController stageController;

    #endregion

    #region Monobehaviour Callbacks (on destroy)

    private void OnDestroy()
    {
        ResetMaterials();
    }

    #endregion

    #region Custom function (to reset color of materials)

    private void ResetMaterials()
    {
        floor.color = Color.white;
        floor.SetColor("_EmissionColor", new Color(0.65882353f, 0.65882353f, 0.65882353f));

        ceiling.color = Color.white;
        ceiling.SetColor("_EmissionColor", new Color(0.65882353f, 0.65882353f, 0.65882353f));

        Color vertOriginalColor = new Color(0.3294117f, 0.396078f, 0.749019f);
        vertOriginalColor *= colorIntensityVertical;

        Color horizOriginalColor = new Color(0.3294117f, 0.396078f, 0.749019f);
        horizOriginalColor *= colorIntensityHorizontal;

        vertLedStrips.SetColor("_EmissionColor", vertOriginalColor);
        horizLedStrips.SetColor("_EmissionColor", horizOriginalColor);

        stepSurfBottom.color = new Color(0.8156862f, 0.8392156f, 0.905882f);
        stepSurfTop.color = new Color(0.8156862f, 0.8392156f, 0.905882f);
    }

    #endregion

}
