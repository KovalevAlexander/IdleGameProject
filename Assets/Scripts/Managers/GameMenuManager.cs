using System.Collections.Generic;

using UnityEngine;

public sealed class GameMenuManager : Singleton<GameMenuManager>
{
    [SerializeField] private Canvas defaultMenu;
    [SerializeField] private List<Canvas> menuList;

    private Canvas m_CurrentMenu;
    private Canvas m_PreviousMenu;

    private void Start()
    {
        EnableMenu(defaultMenu);
    }

    public void EnableMenu(Canvas menuCanvas)
    {
        if (menuCanvas == null)
            return;

        if (AlreadyEnabled(menuCanvas))
            EnableMenu(m_PreviousMenu);
        else
        {
            DisableAllMenus();
            m_PreviousMenu = m_CurrentMenu;
            m_CurrentMenu = menuCanvas;

            menuCanvas.enabled = true;
        }

    }

    private bool AlreadyEnabled(Canvas canvas) => canvas.enabled;

    private void DisableAllMenus()
    {
        if (menuList.Count == 0)
            return;

        foreach (var menu in menuList)
        {
            menu.enabled = false;
        }
    }

    public void Register(GameMenuButton button)
    {
        button.onClicked = HandleButtonPress;
    }

    public void Remove(GameMenuButton button)
    {
        button.onClicked = null;
    }

    private void HandleButtonPress(Canvas canvas)
    {
        if (!menuList.Contains(canvas))
            return;

        EnableMenu(canvas);
    }
}
