using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Library.Models.Playeur;
using System.Threading;

namespace WebApp.Hubs
{
    public class PartieHub : Hub
    {
        private static List<Joueur> _ListDeJoueur = new List<Joueur>();
        private static string GroupName = "Test";
        private static int turn = 0;

        private static Thread Game;
        private static readonly object Locker = new object();


        public async void Main()
        {
            await Clients.All.SendAsync("Start", "true");
            lock (Locker)
            {

            }
        }

        

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message+" "+Context.ConnectionId);
        }

        public async Task InitJoueur(int agi, int str, int vit, int intel, int perce, string name, string surname)
        {
            if ((agi + str + vit + intel + perce) != Joueur.MaxPointStat)
            {
                _ListDeJoueur.Add(new Joueur(agi, str, vit, intel, perce, name, surname, Context.ConnectionId));
                await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
            }
            else
                await Clients.Caller.SendAsync("error", "Les stat transmise ne sont pas bonne");

            if (_ListDeJoueur.Count > 15&&Game==null)
            {

            }
        }
        public async Task GetMaxPointstat() => await Clients.Caller.SendAsync("MaxPointStat", Joueur.MaxPointStat);
        public async Task GetMaxPerStat() => await Clients.Caller.SendAsync("MaxPerStat", Joueur.MaxPerStat);

        public override Task OnConnectedAsync()
        {
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("A user is disconnedcted"+Context.ConnectionId);
            if (_ListDeJoueur.Contains(new Joueur(Context.ConnectionId)))
                Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName);
                _ListDeJoueur.Find(e => e.ConnectionID == Context.ConnectionId).die();
            return Task.CompletedTask;
        }
    }   
}
