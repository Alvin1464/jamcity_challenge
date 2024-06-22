using System;
using Employees.Model;
using Employees.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Employees.Views
{
    public class EmployeeItemListView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI fullName;
        [SerializeField] TextMeshProUGUI roleAndSeniority;
        [SerializeField] TextMeshProUGUI salary;
        [SerializeField] Button applySalaryButton;

        public event Action<string> OnApplySalaryIncrement = _ => { };

        public void Awake()
        {
            applySalaryButton.onClick.AddListener(() => OnApplySalaryIncrement(id));
        }


        public string id { get; private set; }
        public Role role { get; private set; }
        
        public void SetEmployee(string fullName, Role role, Seniority seniority, Salary salary, string id)
        {
            this.fullName.text = $"{fullName}";
            roleAndSeniority.text = $"{role}\n{seniority}";
            this.salary.text = $"{salary.Amount}\n{salary.SalaryCurrency}";
            this.id = id;
            this.role = role;
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}
