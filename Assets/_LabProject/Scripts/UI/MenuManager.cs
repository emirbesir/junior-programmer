using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent _onPauseEvent;
    [SerializeField] private UnityEvent _onResumeEvent;

    private List<GameObject> _activeMenus = new List<GameObject>();
    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        if (_isPaused)
        {
            _isPaused = false;
            _onResumeEvent.Invoke();
        }
        else
        {
            _isPaused = true;
            _onPauseEvent.Invoke();
        }
    }

    public void ShowMenu(GameObject menu)
    {
        if (!menu.activeSelf)
        {
            _activeMenus.Add(menu);
            menu.SetActive(true);
        }
    }

    public void HideMenu(GameObject menu)
    {
        if (menu.activeSelf)
        {
            _activeMenus.Remove(menu);
            menu.SetActive(false);
        }
    }

    public void HideAllMenus()
    {
        foreach (var activeMenu in _activeMenus)
        {
            activeMenu.SetActive(false);
        }
        _activeMenus.Clear();
    }
}
