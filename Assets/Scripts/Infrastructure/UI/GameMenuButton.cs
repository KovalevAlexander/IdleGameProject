using System;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameMenuButton : MonoBehaviour
{
    [SerializeField] private Canvas canvasToToggle;

    private Button m_Button;

    public Action<Canvas> onClicked;

    private void Awake()
    {
        m_Button = GetComponent<Button>();

#if UNITY_EDITOR
        if (m_Button == null)
            Debug.LogError("Please ensure that this script is put on the gameObject with a Button", this);

        if (canvasToToggle == null)
            Debug.LogError("Please set a reference to a Canvas you want to toggle with a Button", this);
#endif
    }

    private void Start()
    {

        GameMenuManager.Instance.Register(this);

    }

    private void OnEnable()
    {
        if (GameMenuManager.IsAlive)
        {
            GameMenuManager.Instance.Register(this);
        }

        m_Button.onClick.AddListener(OnClick);
    }

#if !UNITY_EDITOR
    private void OnDisable()
    {
        GameMenuManager.Instance.Remove(this);
        m_Button.onClick.RemoveListener(OnClick);
    }
#endif

    private void OnClick()
    {
        if (onClicked == null)
            Debug.Log("No one is subscribed");

        onClicked?.Invoke(canvasToToggle);
    }
}
