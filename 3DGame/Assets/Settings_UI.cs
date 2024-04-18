using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
public class Settings_UI : MonoBehaviour
{
    public Slider[] GameSliders;
    public Toggle[] GameToggles;
    public Toggle[] VideoToggles;
    public TMP_Dropdown[] VideoDropdowns;
    public GameObject Player;
    public GameObject Gun;

    private void Start()
    {
        VideoToggles[0].interactable = false; CheckForHDRSupport();
        if (!HDDynamicResolutionPlatformCapabilities.DLSSDetected)
        {
            VideoToggles[3].interactable = false;
        }
    }

    void Update()
    {
        Player.GetComponent<PlayerHealth>().maxHealth = GameSliders[0].value;
        if (GameToggles[0].isOn) {
            Player.GetComponent<PlayerHealth>().health = Player.GetComponent<PlayerHealth>().maxHealth;
        }
        Gun.GetComponent<PumpAction>().Damage = GameSliders[1].value;
    }

    public void SetGunInvisible(bool Value)
    {
        Gun.transform.GetChild(0).GetComponent<Renderer>().enabled = Value;
        Gun.transform.GetChild(1).GetComponent<Renderer>().enabled = Value;
        Gun.GetComponent<Renderer>().enabled = Value;
    }

    public void SetCamTilt(float Value)
    {
        GetComponent<CamTilt>()._tiltAmount = Value;
    }

    public void SetSensitivity(float Value)
    {
        Camera.main.GetComponent<MouseLook>().sensitivityX = Value;
        Camera.main.GetComponent<MouseLook>().sensitivityY = Value;
    }

    public void SetShadowQuality(int Value)
    {
        HDAdditionalLightData HAL = GameObject.Find("Directional Light").GetComponent<HDAdditionalLightData>();
        switch (Value)
        {
            case 0:
                HAL.SetShadowResolutionLevel(0);
                break;
            case 1:
                HAL.SetShadowResolutionLevel(1);
                break;
            case 2:
                HAL.SetShadowResolutionLevel(2);
                break;
            case 3:
                HAL.SetShadowResolutionLevel(3);
                break;
        }
    }

    public void SetDlss(bool Value)
    {

        HDAdditionalCameraData HDC = Camera.main.GetComponent<HDAdditionalCameraData>();
        HDC.allowDeepLearningSuperSampling = Value;
    }

    public void SetDynamicResolution(bool Value)
    {
        Camera.main.allowDynamicResolution = Value;
    }
    public void SetHDR(bool Value)
    {
        Camera.main.allowHDR = Value && CheckForHDRSupport();
        
    }

    public static bool CheckForHDRSupport()
    {
        if (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.DefaultHDR)) return false;
        var check = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBFloat)
                    || SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf);
        return check;
    }

    public void SetAA(int Value)
    {
        HDAdditionalCameraData HDC = Camera.main.GetComponent<HDAdditionalCameraData>();
        switch (Value)
        {
            case 0:
                HDC.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
                break;
            case 1:
                HDC.antialiasing = HDAdditionalCameraData.AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 2:
                HDC.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                HDC.SMAAQuality = HDAdditionalCameraData.SMAAQualityLevel.Low;
                break;
            case 3:
                HDC.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                HDC.SMAAQuality = HDAdditionalCameraData.SMAAQualityLevel.Medium;
                break;
            case 4:
                HDC.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                HDC.SMAAQuality = HDAdditionalCameraData.SMAAQualityLevel.High;
                break;

        }
    }

    public void SetResolution(int Value)
    {
        string[] Values = VideoDropdowns[0].options[Value].text.Split('x');
        Debug.Log(int.Parse(Values[0]) + "x" + int.Parse(Values[1]));
        Screen.SetResolution(int.Parse(Values[0]), int.Parse(Values[1]), Screen.fullScreenMode);
    }

    public void SetFullScreen(bool Value)
    {
        if (Value)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Debug.Log("Exclusive");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("Windowed");
        }
    }
}
