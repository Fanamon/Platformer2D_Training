using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VampiricButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    private Button _button;

    public event UnityAction Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Enable()
    {
        _button.interactable = true;
        _timerText.gameObject.SetActive(false);
    }

    public void Disable()
    {
        _button.interactable = false;
        _timerText.gameObject.SetActive(true);
    }

    public void SetTimerNumber(int number)
    {
        _timerText.text = number.ToString();
    }

    private void OnButtonClick()
    {
        Clicked?.Invoke();
    }
}
