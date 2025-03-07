// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace EndConditions
{
    using System;
    using Exiled.API.Features;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <summary>
        /// Gets the only existing instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <summary>
        /// Gets an instance of the <see cref="EndConditions.Methods"/> class.
        /// </summary>
        public Methods Methods { get; private set; }

        /// <inheritdoc/>
        public override Version Version { get; } = new(3, 0, 1);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new(8, 4, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Instance = this;
            Methods = new Methods(this);
            eventHandlers = new EventHandlers(this);
            ServerHandlers.EndingRound += eventHandlers.OnEndingRound;
            ServerHandlers.WaitingForPlayers += eventHandlers.OnWaitingForPlayers;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            ServerHandlers.EndingRound -= eventHandlers.OnEndingRound;
            ServerHandlers.WaitingForPlayers -= eventHandlers.OnWaitingForPlayers;
            eventHandlers = null;
            Methods = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}
