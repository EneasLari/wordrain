using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{

    public Material MainMenuSkyBox;

    public Material InGameSkyBox;

    public Material FalseSkyBox;

    void Start() {
        RenderSettings.skybox = MainMenuSkyBox;
    }

    public void setInGameSkyBox() {
        RenderSettings.skybox = InGameSkyBox;
    }

    public void setFalseSkyBox() {
        RenderSettings.skybox = FalseSkyBox;
    }

    public void setMainMenuSkyBox() {
        RenderSettings.skybox = MainMenuSkyBox;
    }

}
