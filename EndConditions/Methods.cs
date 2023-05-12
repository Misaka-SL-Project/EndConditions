// -----------------------------------------------------------------------
// <copyright file="Methods.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace EndConditions
{
    using System.Collections.Generic;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Exiled.Events.EventArgs.Server;
    using PlayerRoles;

    /// <summary>
    /// Various required methods.
    /// </summary>
    public class Methods
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="Methods"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public Methods(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Gets all alive player role names.
        /// </summary>
        /// <returns>A collection of all player role names.</returns>
        public IEnumerable<string> GetRoles()
        {
            foreach (Player player in Player.List)
            {
                if (player.IsDead || API.BlacklistedPlayers.Contains(player))
                    continue;

                if (API.ModifiedRoles.TryGetValue(player, out string modifiedRole))
                {
                    yield return modifiedRole;
                    continue;
                }

                if (player.Role.Type == RoleTypeId.Tutorial && plugin.Config.IgnoreTutorials)
                    continue;

                yield return RoleName(player.Role.Type);
            }
        }

        /// <summary>
        /// Ends the round with the specified parameters.
        /// </summary>
        /// <param name="ev">An instance of <see cref="EndingRoundEventArgs"/>.</param>
        /// <param name="leadingTeam">The team that won.</param>
        public void EndGame(EndingRoundEventArgs ev, LeadingTeam leadingTeam)
        {
            ev.LeadingTeam = leadingTeam;
            ev.IsRoundEnded = true;

            API.BlacklistedPlayers.Clear();
            API.ModifiedRoles.Clear();

            if (plugin.Config.RoundEndFf)
                Server.FriendlyFire = true;
        }

        private static string RoleName(RoleTypeId roleTypeId)
        {
            return roleTypeId switch
            {
                RoleTypeId.None => nameof(RoleTypeId.None),
                RoleTypeId.Scp173 => nameof(RoleTypeId.Scp173),
                RoleTypeId.ClassD => nameof(RoleTypeId.ClassD),
                RoleTypeId.Spectator => nameof(RoleTypeId.Spectator),
                RoleTypeId.Scp106 => nameof(RoleTypeId.Scp106),
                RoleTypeId.NtfSpecialist => nameof(RoleTypeId.NtfSpecialist),
                RoleTypeId.Scp049 => nameof(RoleTypeId.Scp049),
                RoleTypeId.Scientist => nameof(RoleTypeId.Scientist),
                RoleTypeId.Scp079 => nameof(RoleTypeId.Scp079),
                RoleTypeId.ChaosConscript => nameof(RoleTypeId.ChaosConscript),
                RoleTypeId.Scp096 => nameof(RoleTypeId.Scp096),
                RoleTypeId.Scp0492 => nameof(RoleTypeId.Scp0492),
                RoleTypeId.NtfSergeant => nameof(RoleTypeId.NtfSergeant),
                RoleTypeId.NtfCaptain => nameof(RoleTypeId.NtfCaptain),
                RoleTypeId.NtfPrivate => nameof(RoleTypeId.NtfPrivate),
                RoleTypeId.Tutorial => nameof(RoleTypeId.Tutorial),
                RoleTypeId.FacilityGuard => nameof(RoleTypeId.FacilityGuard),
                RoleTypeId.Scp939 => nameof(RoleTypeId.Scp939),
                RoleTypeId.ChaosRifleman => nameof(RoleTypeId.ChaosRifleman),
                RoleTypeId.ChaosRepressor => nameof(RoleTypeId.ChaosRepressor),
                RoleTypeId.ChaosMarauder => nameof(RoleTypeId.ChaosMarauder),
                _ => nameof(RoleTypeId.None)
            };
        }
    }
}