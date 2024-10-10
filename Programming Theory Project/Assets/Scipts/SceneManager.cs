using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SceneManager : MonoBehaviour
{
    public enum CharacterRace
    {
        Human,
        Elf,
        Goblin,
        Undead
    }

    public CharacterRace CurrentRace { get; private set; }

    [SerializeField] private TMP_Dropdown raceDropdown;
    [SerializeField] private GameObject humanObject;
    [SerializeField] private GameObject elfObject;
    [SerializeField] private GameObject goblinObject;
    [SerializeField] private GameObject undeadObject;

    // Start is called before the first frame update
    void Start()
    {
        // Populate the dropdown
        raceDropdown.ClearOptions();
        raceDropdown.AddOptions(new List<string>(Enum.GetNames(typeof(CharacterRace))));

        // Set default value to Human
        raceDropdown.value = (int)CharacterRace.Human;
        CurrentRace = CharacterRace.Human;

        // Add listener for when the selected option changes
        raceDropdown.onValueChanged.AddListener(OnRaceChanged);
    }

    private void OnRaceChanged(int index)
    {
        CurrentRace = (CharacterRace)index;
        Debug.Log($"Selected race: {CurrentRace}");
        UpdateRaceObjectPositions();
    }

    private void UpdateRaceObjectPositions()
    {
        SetObjectYPosition(humanObject, CurrentRace == CharacterRace.Human);
        SetObjectYPosition(elfObject, CurrentRace == CharacterRace.Elf);
        SetObjectYPosition(goblinObject, CurrentRace == CharacterRace.Goblin);
        SetObjectYPosition(undeadObject, CurrentRace == CharacterRace.Undead);
    }

    private void SetObjectYPosition(GameObject obj, bool isSelected)
    {
        if (obj != null)
        {
            Vector3 position = obj.transform.position;
            position.y = isSelected ? 1f : 0f;
            obj.transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
