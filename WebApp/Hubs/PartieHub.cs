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

        public async Task Test() => NewPartie.NewPlayeur(10, 10, 10, 10, 0, "maxime", "leriche", "connectionID",2);

        public async Task SchoolTalk(string GroupName, string message)
        {
            if (NewPartie.GroupName == GroupName)
            {
                await Clients.Group(GroupName).SendAsync("SchoolTalk",NewPartie.GetName(Context.ConnectionId),message);
            }
        }

        public async Task MessageTalk(string Email, string message)
        {
            if (NewPartie.MailExist(Email))
                await Clients.User(NewPartie.GetConnectIDfrommail(Email)).SendAsync("MessageTalk", NewPartie.GetEmailfromconnectID(Context.ConnectionId), message);
            else
                await Clients.Caller.SendAsync("MessageTalk", Email, "L'uttilisateur demander n'existe pas");
        }

        public async Task InitJoueur(int agi, int str, int vit, int intel, int perce, string name, string surname,int gender)
        {
            if (NewPartie.NewPlayeur(agi,str,vit,intel,perce,name,surname,Context.ConnectionId,gender))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, NewPartie.GroupName);
                await Clients.Caller.SendAsync("GroupName", NewPartie.GroupName);
            }
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
