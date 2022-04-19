using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    private Resolution[] resolutions;

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Slider mouseSensitivitySlider;
    [SerializeField] private Toggle vsyncToggle;
    [SerializeField] private TextMeshProUGUI mouseSensitivityInfoLabel;
    [SerializeField] private MouseSettings _mouseSettingsData;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for( int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if( resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {
            _mouseSettingsData.mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
        }
        else
        {
            _mouseSettingsData.mouseSensitivity = 0.5f;
            PlayerPrefs.SetFloat("MouseSensitivity", _mouseSettingsData.mouseSensitivity);
            PlayerPrefs.Save();
        }
        mouseSensitivitySlider.value = _mouseSettingsData.mouseSensitivity*10f;
        mouseSensitivityInfoLabel.text = _mouseSettingsData.mouseSensitivity.ToString();

        if (PlayerPrefs.HasKey("VSync"))
        {
            vsyncToggle.isOn = PlayerPrefs.GetInt("VSync") == 2;
        }
        else
        {
            PlayerPrefs.SetInt("VSync", 2);
            vsyncToggle.isOn = PlayerPrefs.GetInt("VSync") == 2;
            QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
            PlayerPrefs.Save();
        }
        
    }

    public void SetResolution( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); ;
    }
    public void SetMouseSensitivity()
    {
        _mouseSettingsData.mouseSensitivity = mouseSensitivitySlider.value/10f;
        mouseSensitivityInfoLabel.text = _mouseSettingsData.mouseSensitivity.ToString();
        PlayerPrefs.SetFloat("MouseSensitivity", _mouseSettingsData.mouseSensitivity);
        PlayerPrefs.Save();
    }
    
    public void IsFullscreen( bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetSyncToggle()
    {
        QualitySettings.vSyncCount = vsyncToggle.isOn ? 2 : 0;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
