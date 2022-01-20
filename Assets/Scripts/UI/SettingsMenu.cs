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
        mouseSensitivitySlider.value = _mouseSettingsData.mouseSensitivity;
        mouseSensitivityInfoLabel.text = (_mouseSettingsData.mouseSensitivity / 10f).ToString();
    }

    public void SetResolution( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); ;
    }
    public void SetMouseSensitivity()
    {
        _mouseSettingsData.mouseSensitivity = mouseSensitivitySlider.value;
        mouseSensitivityInfoLabel.text = (_mouseSettingsData.mouseSensitivity / 10f).ToString();
    }
    
    public void IsFullscreen( bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetSyncToogle( bool hasSync)
    {
        QualitySettings.vSyncCount = hasSync ? 1 : 0;
        Debug.Log(QualitySettings.vSyncCount.ToString());
        
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
