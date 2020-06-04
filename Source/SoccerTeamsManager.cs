using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private Dictionary<long, Team> teams = new Dictionary<long, Team>();
        private Dictionary<long, Player> players = new Dictionary<long, Player>();

        private Player GetPlayer(long id)
        {
            if (!players.TryGetValue(id, out var player))
            {
                throw new PlayerNotFoundException("Player not found.");
            }
            return player;
        }

        private Team GetTeam(long id)
        {
            if (!teams.TryGetValue(id, out var team))
            {
                throw new TeamNotFoundException("Team not Found");
            }
            return team;
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (teams.ContainsKey(id))
            {
                throw new UniqueIdentifierException("Team exists.");
            }
            var team = new Team(id, name, createDate, mainShirtColor, secondaryShirtColor);
            teams.Add(id, team);
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if (players.ContainsKey(id))
            {
                throw new UniqueIdentifierException("Player exists.");
            }
            Team team = GetTeam(teamId);
            var player = new Player(id, team.Id, name, birthDate, skillLevel, salary);
            players.Add(id, player);
        }

        public void SetCaptain(long playerId)
        {
            Player player = GetPlayer(playerId);
            teams[player.TeamId].PlayerId = player;
        }

        public long GetTeamCaptain(long teamId)
        {
            Team team = GetTeam(teamId);
            if (team.PlayerId == null)
            {
                throw new CaptainNotFoundException("Captain not found");
            }
            return team.PlayerId.Id;
        }

        public string GetPlayerName(long playerId)
        {
            Player player = GetPlayer(playerId);
            return player.Name;
        }

        public string GetTeamName(long teamId)
        {
            Team team = GetTeam(teamId);
            return team.Name;
        }
        private IEnumerable<Player> GetPlayersOnTeam(long idTeam)
        {
            return players.Values.Where(x => x.TeamId == idTeam);
        }
        public List<long> GetTeamPlayers(long teamId)
        {
            Team team = GetTeam(teamId);

            return GetPlayersOnTeam(teamId).OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }
        public long GetBestTeamPlayer(long teamId)
        {
            Team team = GetTeam(teamId);
            var playersOnTeam = GetPlayersOnTeam(teamId).OrderByDescending(x => x.SkillLevel).Select(x => x.Id);

            return playersOnTeam.First();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            Team team = GetTeam(teamId);
            var playerOnTeam = GetPlayersOnTeam(teamId).OrderBy(x => x.BirthDate).Select(x => x.Id);
            return playerOnTeam.First();
        }

        public List<long> GetTeams()
        {
            return teams.Values.OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            Team team = GetTeam(teamId);
            var playerOnTeam = GetPlayersOnTeam(teamId).OrderByDescending(x => x.Salary).Select(x => x.Id);
            return playerOnTeam.First();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            Player player = GetPlayer(playerId);
            return player.Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            if (players.Count == 0)
            {
                return new List<long>();
            }
            return players.Values.OrderByDescending(x => x.SkillLevel).Select(x => x.Id).Take(top).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            Team teamHome = GetTeam(teamId);
            Team teamVisitor = GetTeam(visitorTeamId);

            if (teamHome.MainShirtColor == teamVisitor.MainShirtColor)
            {
                return teamVisitor.SecondaryShirtColor;
            }
            return teamVisitor.MainShirtColor;
        }


    }
}
