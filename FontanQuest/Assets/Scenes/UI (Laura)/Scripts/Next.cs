﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Next : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public string text;
    public Button VideoLink;
   

    void Start()
    {
       textField = GameObject.Find("Fact (TMP)").GetComponent<TextMeshProUGUI>();
       VideoLink.gameObject.SetActive(false);

    }



public void PickRandomFromList()
    {
        string[] activities = new string[] { "football?",
                                               "dance sesion",
                                                "pirates", "act4", "act5", "sonic"};
        //     string randomActivity = activities[Random.Range(0, activities.Length)];
        string randomActivity = activities[Random.Range(0, activities.Length)];
        textField.text = randomActivity;
        if (randomActivity == "football?")
        {
            VideoLink.gameObject.SetActive(false);
            textField.text = "Wollen wir nicht im Park mal Fussbal spielen?";
      
        }
        else if (randomActivity == "dance sesion")
        {
            textField.text = "Warum tanzen wir nicht einbisschen mit Elsa, der Eiskonigin?";
            VideoLink.gameObject.SetActive(true);

        }
        else if (randomActivity == "pirates")
        {
            textField.text = "Lass uns ein Workout mit Piraten machen!";
            VideoLink.gameObject.SetActive(true);        

        }
        else if (randomActivity == "act4")
        {
            textField.text = "Wollen wir ins Schwimmbad gehen?";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "act5")
        {
            textField.text = "Wollen wir draussen Frisbee spielen?";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "sonic")
        {
            textField.text = "Lass uns einbisschen Yoga mit Sonic the Hedgehog machen!";
            VideoLink.gameObject.SetActive(false);

        }
        else
        {
            textField.text = "That is all the activities we have";
        }

    }


    public void PickFact()
    {
        string[] fact = new string[] { "Exercise training in Fontan patients is most likely safe and has positive effects on exercise capacity, cardiac function and quality of life. (Scheffers et al., 2021)",
                                                "Why don't we prepare a scavenger hunt?", "Why don't we have a dance seesion?" };
        string randomfact = fact[UnityEngine.Random.Range(0, fact.Length)];
        textField.text = randomfact;
    }



    public void changeText()
    {
        text = "hola";
        textField.text = text;
    }
}
