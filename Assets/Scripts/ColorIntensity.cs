using UnityEngine;

public class ColorIntensity : MonoBehaviour
{

    #region Public variables

    public float _endRange = 0.0f;
    public float _startRange = 2.0f;

    #endregion

    #region Private variables

    private float intensity;
    private float _oscillateRange;
    private float _oscillateOffset;
    private float _tempValue;

    #endregion

    #region Monobehaviour Callbacks (start / update)

    private void Start()
    {
        _oscillateRange = (_endRange - _startRange) / 2;
        _oscillateOffset = _oscillateRange + _startRange;
    }

    private void Update()
    {
        _tempValue = _oscillateOffset + Mathf.Sin(Time.time * 2.0f) * _oscillateRange;
        intensity = _tempValue;

        SetCustomMaterialEmissionIntensity();
    }

    #endregion

    #region Custom function (to ping pong color intensity)

    private void SetCustomMaterialEmissionIntensity()
    {
        float s = Mathf.PingPong(3.0f, 6.0f) - 3.0f;
        
        Material[] materials = GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].name == "darkBlue (Instance)" || materials[i].name == "lightBlue (Instance)" || materials[i].name == "purpleframe (Instance)" || materials[i].name == "pink (Instance)" || materials[i].name == "blue (Instance)" || materials[i].name == "lines4 (Instance)" || materials[i].name == "light (Instance)")
            {
                Color color = materials[i].GetColor("_Color");

                float adjustedIntensity = intensity - (0.4169F);

                color *= Mathf.Pow(2.0F, adjustedIntensity);
                materials[i].SetColor("_EmissionColor", color);
            }
        }  
    }

    #endregion

}
