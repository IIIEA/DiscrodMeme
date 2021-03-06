using UnityEngine;
using System;
using System.Linq;
using DiscordUnity;
using DiscordUnity.API;
using DiscordUnity.State;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.Events;

public class DiscordManager : MonoBehaviour, IDiscordServerEvents, IDiscordMessageEvents, IDiscordStatusEvents
{
    public string botToken;
    public DiscordLogLevel logLevel = DiscordLogLevel.None;

    public void SetBotToken(string token)
    {
        botToken = token;
    }

    public event UnityAction<string, string> PlayerAdded;

    [SerializeField] private List<string> _users = new List<string>();
    [SerializeField] private PlayerData[] _players;

    #region Singleton
    public static DiscordManager Singleton { get; private set; }

    protected virtual void Awake()
    {
        if (Singleton != null)
        {
            Destroy(gameObject);
            return;
        }

        Singleton = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (Singleton == this)
        {
            DiscordAPI.UnregisterEventsHandler(this);
            DiscordAPI.Stop();
            Singleton = null;
        }
    }
    #endregion

    protected virtual async void Start()
    {
        Debug.Log("Starting DiscordUnity ...");
        DiscordAPI.Logger = new DiscordLogger(logLevel);
        DiscordAPI.RegisterEventsHandler(this);
        await DiscordAPI.StartWithBot(botToken);
        Debug.Log("DiscordUnity started.");
    }

    private void Update()
    {
        DiscordAPI.Update();
    }

    public async void OnServerJoined(DiscordServer server)
    {
        //server.Channels.Values.FirstOrDefault(x => x.Type == DiscordUnity.Models.ChannelType.GUILD_TEXT)?.CreateMessage("Hello World!", null, null, null, null, null, null);
        Debug.Log("hello world");
        await DiscordAPI.CreateMessage("772015084633325580", "Hello World", null, false, null, null, null, null);
    }

    public void OnServerUpdated(DiscordServer server)
    {

    }

    public void OnServerLeft(DiscordServer server)
    {

    }

    public void OnServerBan(DiscordServer server, DiscordUser user)
    {

    }

    public void OnServerUnban(DiscordServer server, DiscordUser user)
    {

    }

    public void OnServerEmojisUpdated(DiscordServer server, DiscordEmoji[] emojis)
    {

    }

    public void OnServerMemberJoined(DiscordServer server, DiscordServerMember member)
    {

    }

    public void OnServerMemberUpdated(DiscordServer server, DiscordServerMember member)
    {

    }

    public void OnServerMemberLeft(DiscordServer server, DiscordServerMember member)
    {

    }

    public void OnServerMembersChunk(DiscordServer server, DiscordServerMember[] members, string[] notFound, DiscordPresence[] presences)
    {

    }

    public void OnServerRoleCreated(DiscordServer server, DiscordRole role)
    {
        Debug.Log("role added: " + role.Name);
    }

    public void OnServerRoleUpdated(DiscordServer server, DiscordRole role)
    {

    }

    public void OnServerRoleRemove(DiscordServer server, DiscordRole role)
    {

    }

    //message events
    public async void OnMessageCreated(DiscordMessage message)
    {
        if(message.Author.Bot == null || message.Author.Bot == false) // check if the author is not a bot
        {
            if (message.Content.Contains("!start"))
            {
                _players = GetComponentsInChildren<PlayerData>();

                await DiscordAPI.CreateMessage(message.ChannelId, "Started", null, false, null, null, null, null);
            }
        }
        if (message.Author.Bot == true && message.Content.Contains("Started"))
        {
            await AddEmoji(message.ChannelId, message.Id, "⬆️");

            await Task.Delay(100);

            await AddEmoji(message.ChannelId, message.Id, "⬅️");

            await Task.Delay(100);

            await AddEmoji(message.ChannelId, message.Id, "➡️");

            await Task.Delay(100);

            await AddEmoji(message.ChannelId, message.Id, "⬇️");

            await Task.Delay(100);

            await AddEmoji(message.ChannelId, message.Id, "🔫");
        }

        if (message.Author.Bot == null || message.Author.Bot == false)
        {
            if (message.Content.Contains("!join"))
            {
                await DiscordAPI.CreateMessage(message.ChannelId, "Choose player", null, false, null, null, null, null);
            }
        }
        if (message.Author.Bot == true && message.Content.Contains("Choose player"))
        {
            await AddEmoji(message.ChannelId, message.Id, "👨‍🦽");

            await Task.Delay(100);
        }


        /*
        if (message.Author.Bot == null )
        {
            Debug.Log("sender is not a bot, null");
            
        }

        if (message.Author.Bot == false)
        {
            Debug.Log("sender is not a bot, false");

        }

        if (message.Author.Bot == true)
        {
            Debug.Log("sender is a bot, true");

        }

        if (!message.Author.Bot == true)
        {
            Debug.Log("sender is not a bot, not true");

        }

        if (message.Author.Bot == null || message.Author.Bot == false)
        {
            Debug.Log("sender is not a bot, or");

        }
        */

    }

    public void OnMessageUpdated(DiscordMessage message)
    {

    }

    public void OnMessageDeleted(DiscordMessage message)
    {
        Debug.Log("Message Deleted...");


    }

    public void OnMessageDeletedBulk(string[] messageIds)
    {

    }

    public async void OnMessageReactionAdded(DiscordMessageReaction messageReaction)
    {
        if (messageReaction.Member.User.Bot == null || messageReaction.Member.User.Bot == false) 
        {
            if(messageReaction.Emoji.Name == "👨‍🦽")
            {
                if (_users.Contains(messageReaction.UserId) == false)
                {
                    _users.Add(messageReaction.UserId);
                    PlayerAdded?.Invoke(messageReaction.UserId, messageReaction.Member.User.Username);

                    await Task.Delay(20);
                }
            }

            if (messageReaction.Emoji.Name == "⬆️")
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    if (_players[i].Index == messageReaction.UserId)
                    {
                        _players[i].Move("Up");
                    }
                }

                await Task.Delay(100);
            }
            if (messageReaction.Emoji.Name == "⬅️")
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    if (_players[i].Index == messageReaction.UserId)
                    {
                        Debug.Log(_players[i].Name);
                        _players[i].Move("Left");
                    }
                }

                await Task.Delay(100);
            }
            if (messageReaction.Emoji.Name == "➡️")
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    if (_players[i].Index == messageReaction.UserId)
                    {
                        _players[i].Move("Right");
                    }
                }

                await Task.Delay(100);
            }
            if (messageReaction.Emoji.Name == "⬇️")
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    if (_players[i].Index == messageReaction.UserId)
                    {
                        _players[i].Move("Down");
                    }
                }

                await Task.Delay(100);
            }

            if (messageReaction.Emoji.Name == "🔫")
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    if (_players[i].Index == messageReaction.UserId)
                    {
                        _players[i].Shoot();
                    }
                }

                await Task.Delay(100);
            }
        }
    }

    public void OnMessageReactionRemoved(DiscordMessageReaction messageReaction)
    {

    }

    public void OnMessageAllReactionsRemoved(DiscordMessageReaction messageReaction)
    {

    }

    public void OnMessageEmojiReactionRemoved(DiscordMessageReaction messageReaction)
    {
        Debug.Log("emoji removed");
    }


    // discord status events
    public void OnPresenceUpdated(DiscordPresence presence)
    {

    }

    public void OnTypingStarted(DiscordChannel channel, DiscordUser user, DateTime timestamp)
    {
        Debug.Log("started typing");
    }

    public void OnServerTypingStarted(DiscordChannel channel, DiscordServerMember member, DateTime timestamp)
    {
        Debug.Log("started typing");
    }

    public void OnUserUpdated(DiscordUser user)
    {

    }

    private async Task AddEmoji(string ChannelId,string messageId, string emoji)
    {
        await DiscordAPI.CreateReaction(ChannelId, messageId, emoji);
    }

    #region Logger
    public enum DiscordLogLevel
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Debug = 3
    }

    private class DiscordLogger : DiscordUnity.ILogger
    {
        private readonly DiscordLogLevel level;

        public DiscordLogger(DiscordLogLevel level)
        {
            this.level = level;
        }

        public void Log(string log)
        {
            if (level >= DiscordLogLevel.Debug)
                Debug.Log(log);
        }

        public void LogWarning(string log)
        {
            if (level >= DiscordLogLevel.Warning)
            {
                Debug.LogWarning(log);
            }
        }

        public void LogError(string log, Exception exception = null)
        {
            if (level >= DiscordLogLevel.Error)
            {
                Debug.LogError(log);
                Debug.LogError(exception);
            }
        }
    }
    #endregion
}
