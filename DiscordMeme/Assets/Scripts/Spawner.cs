using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private DiscordManager _discordManager;
    [SerializeField] private GameGrid _gameGrid;
    [SerializeField] private Player _playerTemplate;

    private void OnEnable()
    {
        _discordManager.PlayerAdded += OnPlayerAdded;
    }

    private void OnDisable()
    {
        _discordManager.PlayerAdded -= OnPlayerAdded;
    }

    public void OnPlayerAdded(string index, string nickName)
    {
        var player = Instantiate(_playerTemplate, _gameGrid.GetRandomSpawnPoint(), Quaternion.identity, transform);
        player.Init(index, nickName);
    }
}
