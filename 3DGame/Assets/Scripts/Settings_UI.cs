using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.NVIDIA;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Settings_UI : MonoBehaviour
{
    public Slider[] GameSliders;
    public Toggle[] GameToggles;
    public Toggle[] VideoToggles;
    public TMP_Dropdown[] VideoDropdowns;
    public GameObject Player;
    public GameObject Gun;
    public Volume Rayvol;
    public TextMeshProUGUI FPS;
    public int FPSSamples;
    int Counter = 0;
    float[] Samples = new float[30];
    float Average;
    private void Start()
    {
        Samples = new float[FPSSamples];
        VideoToggles[0].interactable = false; CheckForHDRSupport();
        if (!HDDynamicResolutionPlatformCapabilities.DLSSDetected)
        {
            VideoDropdowns[2].interactable = false;
        }
        Rayvol = GameObject.Find("RayVol").GetComponent<Volume>();
    }

    void Update()
    {
        Player.GetComponent<PlayerHealth>().maxHealth = GameSliders[0].value;
        if (GameToggles[0].isOn) {
            Player.GetComponent<PlayerHealth>().health = Player.GetComponent<PlayerHealth>().maxHealth;
        }
        Gun.GetComponent<PumpAction>().Damage = GameSliders[1].value;

        if (Counter >= FPSSamples)
        {
            Counter = 0;
            for (int i = 0; i < FPSSamples; i++)
            {
                Average += Samples[i];
            }
            Average /= FPSSamples;
            FPS.text = "FPS: " + Average.ToString("0");
        }
        Average = 0;
        Samples[Counter] = (1 / Time.deltaTime);
        Counter++;

        //FPS.text = "FPS: " + (1 / Time.deltaTime).ToString("0");
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
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

    public void SetVSync(bool Value)
    {
        QualitySettings.vSyncCount = Convert.ToInt32(Value);
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

    public void SetDlss(int Value)
    {
        HDAdditionalCameraData HDC = Camera.main.GetComponent<HDAdditionalCameraData>();
        switch (Value)
        {
            case 0:
                HDC.allowDeepLearningSuperSampling = false;
                break;
            case 1:
                HDC.allowDeepLearningSuperSampling = true;
                HDC.deepLearningSuperSamplingQuality = 2;
                break;
            case 2:
                HDC.allowDeepLearningSuperSampling = true;
                HDC.deepLearningSuperSamplingQuality = 1;
                break;
            case 3:
                HDC.allowDeepLearningSuperSampling = true;
                HDC.deepLearningSuperSamplingQuality = 0;
                break;
            case 4:
                HDC.allowDeepLearningSuperSampling = true;
                HDC.deepLearningSuperSamplingQuality = 3;
                break;
        }
    }

    public void SetRayTracing(bool Value)
    {
        Rayvol.weight = Convert.ToInt32(Value);
        HDAdditionalCameraData HDC = Camera.main.GetComponent<HDAdditionalCameraData>();
        HDC.renderingPathCustomFrameSettingsOverrideMask.mask[(int)FrameSettingsField.RayTracing] = Value;
        HDC.renderingPathCustomFrameSettings.SetEnabled(FrameSettingsField.RayTracing, Value);
    }

    public void SetDynamicResolution(bool Value)
    {
        HDAdditionalCameraData HDC = Camera.main.GetComponent<HDAdditionalCameraData>();
        HDC.allowDynamicResolution = Value;
        VideoDropdowns[2].interactable = Value && HDDynamicResolutionPlatformCapabilities.DLSSDetected;
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
