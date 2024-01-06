using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using System;

public class AnimalManager : MonoBehaviour
{   
    private Pet_UI_Management pet_UI_Management;
    public SaveGameObjects.PetSystem petSystem;
    void Start()
    {   
        pet_UI_Management = GameObject.Find("MainCanvas").GetComponent <Pet_UI_Management>(); 
        DeactivateAllAnimals();
        GameObject pet = GameObject.Find("Pet");
        AnimalManager animalManager = pet.GetComponent<AnimalManager>();
        animalManager.ActivateAnimal("Bear_Cub_8");

    }

    void DeactivateAllAnimals()
    {
        DeactivateChildrenRecursively(transform);
    }

    void DeactivateChildrenRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false);
            DeactivateChildrenRecursively(child);
        }
    }

    public void ActivateAnimal(string animalName)
    {
        Debug.Log("Activating " + animalName);
        DeactivateAllAnimals(); // First, deactivate all animals

        if (ActivateAnimalRecursively(transform, animalName))
        {
            // If the animal is found and activated, activate its parent hierarchy
            ActivateParentHierarchy(transform, animalName);
        }
    }

    bool ActivateAnimalRecursively(Transform parent, string animalName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == animalName)
            {
                child.gameObject.SetActive(true);
                return true; // Animal found and activated
            }

            if (ActivateAnimalRecursively(child, animalName))
            {
                return true; // Animal found in sub-children
            }
        }
        return false; // Animal not found in this branch
    }

    void ActivateParentHierarchy(Transform parent, string animalName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == animalName)
            {
                // Activate all parents up to the root
                Transform currentParent = child.parent;
                while (currentParent != null)
                {
                    currentParent.gameObject.SetActive(true);
                    currentParent = currentParent.parent;
                }
                break;
            }
            ActivateParentHierarchy(child, animalName); // Check sub-children
        }
    }


    // -------------------- animal selection
    public enum DefaultCubsToSelect
    {
        Bear_Cub_1,
        Deer_stag_1,
        LowPoly_Boar_cub_1,
        Fox_cub_1,
        LowPoly_Hare_cub_1,
        Wolf_cub_01
    }
    DefaultCubsToSelect defaultCubsToSelect;
    int currentArrayPosition = 0;

    public void nextPet()
    {
        currentArrayPosition++;
        setCubByArray(currentArrayPosition);
    }

    public void previousPet()
    {
        currentArrayPosition--;
        setCubByArray(currentArrayPosition);
    }

    public void setPet()
    {   
        
        var enumValues = (DefaultCubsToSelect[])Enum.GetValues(typeof(DefaultCubsToSelect));
        Debug.Log(enumValues[currentArrayPosition]);
        pet_UI_Management.petSystem.animalSelected = true;
        pet_UI_Management.petSystem.selectedAnimal = enumValues[currentArrayPosition].ToString();
        Debug.Log(petSystem.selectedAnimal);
        pet_UI_Management.ToggleVisibiliyAnimalSelectionButtons(false);
       
    }

    public void reSelect()
    {   
        pet_UI_Management.ToggleVisibiliyGameSelectionButtons(false);
        pet_UI_Management.petSystem.animalSelected = false;
        pet_UI_Management.petSystem.selectedAnimal = null;
        pet_UI_Management.petSystem.selectionComplete = false;
        pet_UI_Management.petSystem.gameSelected = false;
        pet_UI_Management.savePetSystem();
        pet_UI_Management.loadPetSystem();
        pet_UI_Management.ToggleVisibiliyAnimalSelectionButtons(true);
    }

    public void selectGame()
    {   
        pet_UI_Management.petSystem.gameSelected = true;
        Debug.Log("selectGamePressed");                    
        pet_UI_Management.ToggleVisibiliyGameSelectionButtons(false);
        pet_UI_Management.pet_CameraIntro.ActivateCameraAnimation(true);
        pet_UI_Management.savePetSystem();
    }


    public void setCubByArray(int arrayPosition)
    {
        DeactivateAllAnimals();
        // Get all values of DefaultCubsToSelect as an array
        var enumValues = (DefaultCubsToSelect[])Enum.GetValues(typeof(DefaultCubsToSelect));

        // cycle through the array if top or min is reached
        if (arrayPosition >= enumValues.Length)
        {
            arrayPosition = 0;
            currentArrayPosition = 0;
        }
        if (arrayPosition < 0)
        {
            arrayPosition = enumValues.Length - 1;
            currentArrayPosition = enumValues.Length - 1;
        }
        // actually changing the array
        ActivateAnimal(enumValues[arrayPosition].ToString());
    }
}
