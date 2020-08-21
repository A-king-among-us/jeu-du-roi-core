using System;
using Xunit;
using Library.Models.Playeur;

namespace TestLibrary
{
    public class TestJoueur
    {
        [Fact]
        public void TestInstanciationJoueurErreur()
        {
            Assert.Throws<Exception>(() => new Joueur(0, 0, 0, 0, 0, "max", "leriche", "Je suis un connectionID",0));
        }
        
        [Fact]
        public void TestInstanciationJoueur()
        {
            Assert.Equal(10, new Joueur(10, 10, 10, 10, 0, "max", "leriche", "je suis un connectionID",0).AGI);
            Assert.Equal(10, new Joueur(0, 10, 10, 10, 10, "max", "leriche", "je suis un connectionID",0).STR);
            Assert.Equal(10, new Joueur(10, 0, 10, 10, 10, "max", "leriche", "je suis un connectionID",0).VIT);
            Assert.Equal(10, new Joueur(10, 10, 0, 10, 10, "max", "leriche", "je suis un connectionID",0).INT);
            Assert.Equal(10, new Joueur(10, 10, 10, 0, 10, "max", "leriche", "je suis un connectionID",0).PER);
            Assert.Equal("max", new Joueur(10, 10, 10, 10, 0, "max", "leriche", "je suis un connectionID",0).Name);
            Assert.Equal("leriche", new Joueur(10, 10, 10, 10, 0, "max", "leriche", "je suis un connectionID",0).Surname);
            Assert.Equal("ConnectionID", new Joueur(10, 10, 10, 10, 0, "max", "leriche", "ConnectionID",0).ConnectionID);
        }
    }
}
