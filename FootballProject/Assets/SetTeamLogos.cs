using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetTeamLogos : MonoBehaviour
{
    public RawImage team1;
    public RawImage team2;

    public bool isSelected;

    public float selectedTeams;

    public Button pressedButtonSeahawks;
    public Button pressedButtonPatriots;
    public Button pressedButtonEagles;
    public Button pressedButtonBrowns;
    public Button pressedButtonFalcons;
    public Button pressedButtonRavens;

    // Use this for initialization
    void Start()
    {
        StoreSprite spriteStorage = FindObjectOfType<StoreSprite>();
        team1.texture = spriteStorage.team1;
        team2.texture = spriteStorage.team2;

        selectedTeams = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedTeams > 2)
        {
            selectedTeams = 2;
        }
    }

    public void buttonSelectSeahawks()
    {
        isSelected = true;
        ++selectedTeams;

        var initialColors = pressedButtonSeahawks.colors;
        initialColors.normalColor = initialColors.pressedColor;
        initialColors.highlightedColor = initialColors.pressedColor;
        pressedButtonSeahawks.colors = initialColors;

        //team1 = SeahawksLogo;

        if (selectedTeams >= 2)
        {
            initialColors.pressedColor = initialColors.disabledColor;
            initialColors.normalColor = initialColors.disabledColor;
            initialColors.highlightedColor = initialColors.disabledColor;
            pressedButtonSeahawks.colors = initialColors;
        }
    }

    public void buttonSelectPatriots()
    {
        isSelected = true;
        ++selectedTeams;

        var initialColors = pressedButtonPatriots.colors;
        initialColors.normalColor = initialColors.pressedColor;
        initialColors.highlightedColor = initialColors.pressedColor;
        pressedButtonPatriots.colors = initialColors;
    }

    public void buttonSelectEagles()
    {
        isSelected = true;
        ++selectedTeams;

        var initialColors = pressedButtonEagles.colors;
        initialColors.normalColor = initialColors.pressedColor;
        initialColors.highlightedColor = initialColors.pressedColor;
        pressedButtonEagles.colors = initialColors;
    }

    public void buttonSelectBrowns()
    {
        isSelected = true;
        ++selectedTeams;

        var initialColors = pressedButtonBrowns.colors;
        initialColors.normalColor = initialColors.pressedColor;
        initialColors.highlightedColor = initialColors.pressedColor;
        pressedButtonBrowns.colors = initialColors;
    }

    public void buttonSelectFalcons()
    {
        isSelected = true;
        ++selectedTeams;

        var initialColors = pressedButtonFalcons.colors;
        initialColors.normalColor = initialColors.pressedColor;
        initialColors.highlightedColor = initialColors.pressedColor;
        pressedButtonFalcons.colors = initialColors;
    }

    public void buttonSelectRavens()
    {
        isSelected = true;
        ++selectedTeams;

        var initialColors = pressedButtonRavens.colors;
        initialColors.normalColor = initialColors.pressedColor;
        initialColors.highlightedColor = initialColors.pressedColor;
        pressedButtonRavens.colors = initialColors;
    }
}