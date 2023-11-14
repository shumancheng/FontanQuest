using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BuildCityWalls : MonoBehaviour
{
    GameObject mainCanvas;
    CastleMainUI castleMainUIScript;
    GameObject messageWindowObject;
    MessageWindow messageWindow;

    void OpenBuildWindow()
    {
        // Find the MessageWindow instance in the current scene
        mainCanvas = GameObject.Find("MainCanvas");
        castleMainUIScript = mainCanvas.GetComponent<CastleMainUI>();
        messageWindowObject = castleMainUIScript.GetMessageWindow();
        messageWindow = messageWindowObject.GetComponent<MessageWindow>();

        if (messageWindow != null)
        {
            // Prepare the callback actions
            UnityEngine.Events.UnityAction leftAction = messageWindow.DeactivateMessageWindow;
            UnityEngine.Events.UnityAction rightAction = RightButtonClicked;

            // Call the SetupMessageWindow function
            messageWindow.SetupMessageWindow(
                "Mauer",
                "Sollen wir eine Stadtmauer bauen? Das kostet " + BuildingCosts.CityWallCost + " Gold.",
                "Abrechen",
                leftAction,
                "Bauen",
                rightAction,
                null, // If you want a middle button, provide the text
                null
            );
        }
        else
        {
            Debug.LogError("MessageWindow instance was not found in the scene.");
        }
    }

    private void RightButtonClicked()
    {
        if (StaticResources.reduceNumOfCoins(BuildingCosts.CityWallCost) != 1)
        {
            // loading in the existing BuiltBuildings-Block
            SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.BuiltBuildings(false, false, false, false), "builtBuildings", 1);
            if (builtBuildings == null) { builtBuildings = new SaveGameObjects.BuiltBuildings(false, false, false, false);}
            builtBuildings.CityWalls = true;
            GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().ActivateCityWalls();
            SaveGameMechanic.saveSaveGameObject(builtBuildings, "builtBuildings", 1);
            castleMainUIScript.DeactivateMessageWindow();
        } else {
            Debug.Log("Not enough coins");
        }
    }
}
