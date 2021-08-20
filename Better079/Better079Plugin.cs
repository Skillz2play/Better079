using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API;
using Exiled.API.Features;
using Exiled.Events;
using Exiled;
using Exiled.Events.EventArgs;

namespace Better079
{
    public class Better079Plugin : Plugin<Config>
    {
        public static Better079Plugin instance;

        public override string Name => "Better079";
        public override string Author => "Skillz2play";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(2, 13, 0);
        public PluginEvents PLEV;

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= PLEV.RoundStart;
            Exiled.Events.Handlers.Player.Spawning -= PLEV.PlayerSpawn;
            Exiled.Events.Handlers.Scp079.GainingExperience -= PLEV.ExpGain;
            PLEV = null;
            instance = null;
        }

        public override void OnEnabled()
        {
            instance = this;
            PLEV = new PluginEvents(this);
            Exiled.Events.Handlers.Server.RoundStarted += PLEV.RoundStart;
            Exiled.Events.Handlers.Player.Spawning += PLEV.PlayerSpawn;
            Exiled.Events.Handlers.Scp079.GainingExperience += PLEV.ExpGain;
        }
    }
}
