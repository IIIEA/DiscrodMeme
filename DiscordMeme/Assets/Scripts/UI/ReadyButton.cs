using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReadyButton : MonoBehaviour
{
    [SerializeField] private GameGrid _gameGrid;
    [SerializeField] private InputField _inputWeight;
    [SerializeField] private InputField _inputHeight;
    [SerializeField] private InputField _botToken;
    [SerializeField] private DiscordManager _discrodManager;
    [SerializeField] private Canvas _canvas;

    private int _weight;
    private int _height;

    public void OnButtonClick()
    {
        if (_inputWeight.text != "" && _inputHeight.text != "" && _botToken.text != "")
        {
            if (int.TryParse(_inputWeight.text, out _weight) && int.TryParse(_inputHeight.text, out _height))
            {
                _gameGrid.SetSize(_weight, _height);
                _gameGrid.Create(_height, _weight);
                _discrodManager.botToken = _botToken.text;
                Debug.Log(_weight + _height);
                _canvas.gameObject.SetActive(false);
            }
        }
    }
}
