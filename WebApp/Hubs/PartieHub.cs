using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Library.Models.Playeur;
using Library.Partie;
using System.Threading;
using System.Text.RegularExpressions;

namespace WebApp.Hubs
{
    public class PartieHub : Hub
    {
        private static Play NewPartie = new Play("Test");

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
            await Clients.All.SendAsync("ReceiveMessage", user, message + " " + Context.ConnectionId);
        }

        public async Task InitJoueur(int agi, int str, int vit, int intel, int perce, string name, string surname)
        {
            if (NewPartie.NewPlayeur(agi,str,vit,intel,perce,name,surname,Context.ConnectionId))
                await Groups.AddToGroupAsync(Context.ConnectionId, NewPartie.GroupName);
            else
                await Clients.Caller.SendAsync("error", "Les stat transmise ne sont pas bonne");
        }
        public async Task GetMaxPointstat() => await Clients.Caller.SendAsync("MaxPointStat", Joueur.MaxPointStat);
        public async Task GetMaxPerStat() => await Clients.Caller.SendAsync("MaxPerStat", Joueur.MaxPerStat);
        public async Task GetPlayeur(string surname) => await Clients.Caller.SendAsync("GetPlayeur", NewPartie.GetPlayeur(surname)); 
        public async Task GetMySelf() => await Clients.Caller.SendAsync("Iam", NewPartie.GetMyself(Context.ConnectionId));
        public async Task GetAllPlayeur() => await Clients.Caller.SendAsync("ListPlayeur", NewPartie.GetAllPlayeur());

        public override Task OnConnectedAsync()
        {
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string Result = NewPartie.DisconnectPlayeur(Context.ConnectionId);
            if (Result != "")
            {
                Groups.RemoveFromGroupAsync(Context.ConnectionId, NewPartie.GroupName);
                Clients.Group(NewPartie.GroupName).SendAsync("King", Result);
            }
           
            return Task.CompletedTask;
        }
    }   
}
