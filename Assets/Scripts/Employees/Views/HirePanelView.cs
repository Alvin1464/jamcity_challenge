using System;
using Employees.Model;
using Employees.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HirePanelView : MonoBehaviour
{
    [SerializeField]
    InputField fullNameField;
    
    [SerializeField]
    TMP_Dropdown roleSelector;
    
    [SerializeField]
    TMP_Dropdown senioritySelector;

    [SerializeField]
    Button confirm;
    
    public event Action<string, Role, Seniority> OnHire;
    

    void Start()
    {
        confirm.onClick.AddListener(CheckHire);
    }

    void CheckHire()
    {
        if (fullNameField.text == string.Empty ||
            roleSelector.value < 0 ||
            senioritySelector.value < 0) 
            return;
        
        var role = Enum.Parse<Role>(roleSelector.options[roleSelector.value].text);
        var seniority = Enum.Parse<Seniority>(senioritySelector.options[senioritySelector.value].text);
        OnHire?.Invoke(fullNameField.text, role, seniority);
        HidePanel();
    }

    void HidePanel() => gameObject.SetActive(false);
}
