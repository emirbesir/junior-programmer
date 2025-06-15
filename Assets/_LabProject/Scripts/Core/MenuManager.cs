using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameOverMenu;

    [Header("Events")]
    [SerializeField] private UnityEvent _onPauseEvent;
    [SerializeField] private UnityEvent _onResumeEvent;

    private List<GameObject> _activeMenus = new List<GameObject>();

    private void Start()
    {
        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void ShowGameOverMenu()
    {
        foreach (var menu in _activeMenus)
        {
            menu.SetActive(false);
        }
        _activeMenus.Clear();
        _gameOverMenu.SetActive(true);
    }

    public void TogglePauseMenu()
    {
        if (_pauseMenu.activeSelf)
        {
            _onResumeEvent.Invoke();
            _pauseMenu.SetActive(false);
            _activeMenus.Remove(_pauseMenu);
            Time.timeScale = 1f; // Resume the game
        }
        else
        {
            _onPauseEvent.Invoke();
            _pauseMenu.SetActive(true);
            _activeMenus.Add(_pauseMenu);
            Time.timeScale = 0f; // Pause the game
        }
    }
}
