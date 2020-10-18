using System;
using Xunit;
using Library.Models.Playeur;

namespace TestLibrary
{
    public class TestJoueur
    {

        [Fact]
        public void TestInstanciationJoueur()
        {
            Assert.Equal("max", new Joueur(10, 10, 10, 10, 5, "max", "leriche", "je suis un connectionID", 0).Name);
            Assert.Equal("leriche", new Joueur(10, 10, 10, 10, 5, "max", "leriche", "je suis un connectionID", 0).Surname);
            Assert.Equal("ConnectionID", new Joueur(10, 10, 10, 10, 5, "max", "leriche", "ConnectionID", 0).ConnectionID);

            Assert.Throws<Exception>(() => new Joueur(20, 20, 0, 0, 0, "max", "", "je suis un connectionID", 0)); // Surname X
            Assert.Throws<Exception>(() => new Joueur(20, 20, 0, 0, 0, "", "Y", "je suis un connectionID", 0)); // name X
            Assert.Throws<Exception>(() => new Joueur(20, 20, 0, 0, 0, "", "Y", "je suis un connectionID", -1)); // gender go brrr

            Assert.Equal(Genre.Unknow, new Joueur(20, 20, 0, 0, 5, "X", "Y", "je suis un connectionID", 0).Gender);
            Assert.Equal("@max.leriche", new Joueur(10, 10, 10, 10, 5, "max", "leriche", "je suis un connectionID", 0).Email);
        }

        [Fact]
        public void TestStatsJoueur()
        {
            //Test if Stats Ok
            Assert.Equal(10, new Joueur(10, 10, 10, 10, 5, "max", "leriche", "je suis un connectionID", 0).AGI);
            Assert.Equal(10, new Joueur(5, 10, 10, 10, 10, "max", "leriche", "je suis un connectionID", 0).STR);
            Assert.Equal(10, new Joueur(10, 5, 10, 10, 10, "max", "leriche", "je suis un connectionID", 0).VIT);
            Assert.Equal(10, new Joueur(10, 10, 5, 10, 10, "max", "leriche", "je suis un connectionID", 0).INT);
            Assert.Equal(10, new Joueur(10, 10, 10, 5, 10, "max", "leriche", "je suis un connectionID", 0).PER);
            //Test Not Okay Init
            Assert.Throws<Exception>(() => new Joueur(0, 0, 0, 0, 0, "max", "leriche", "je suis un connectionID", 0)); //Stat != 40
            Assert.Throws<Exception>(() => new Joueur(21, 9, 10, 0, 0, "max", "leriche", "je suis un connectionID", 0)); //Stat > 20
            Assert.Throws<Exception>(() => new Joueur(20, 20, 5, -5, 0, "max", "leriche", "je suis un connectionID", 0)); //Stat < 0
        }

        [Fact]
        public void StatutJoueur()
        {
            //TODO Change die function and IsKing logic

            Joueur testPlayer = new Joueur(10, 10, 10, 10, 5, "max", "leriche", "je suis un connectionID", 0);

            //Check Mental Stat
            Assert.False(testPlayer.IsStressed);
            Assert.False(testPlayer.IsDepressed);
            Assert.False(testPlayer.IsHappy);
            Assert.True(testPlayer.CanBeInLove); //CanBeInLove
            Assert.False(testPlayer.IsTired);
            //Assert.False(testPlayer.WhereHeIs); //TODO

            //Check Other Data
            Assert.False(testPlayer.IsKing);
            Assert.False(testPlayer.IsDead);
            Assert.False(testPlayer.HaveEnoughToBuy(100000));

            testPlayer.IsKing = true;
            testPlayer.KillThePlayer();

            Assert.True(testPlayer.IsDead);
            Assert.True(testPlayer.IsKing);
        }


    }
}
