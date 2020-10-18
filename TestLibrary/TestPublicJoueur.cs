using System;
using Xunit;
using Library.Models.Playeur;

namespace TestLibrary
{
    public class TestPublicJoueur
    {
        [Fact]
        public void InstanciatePublicJoueur()
        {
            Joueur jojo = new Joueur(10, 10, 10, 10, 5, "max", "leriche", "je suis un connectionID",0);
            Assert.Equal(jojo.Name,new PublicJoueur(jojo).Name);
            Assert.Equal(jojo.Surname, new PublicJoueur(jojo).Surname);
            Assert.Equal(jojo.Email, new PublicJoueur(jojo).Email);
            Assert.Equal(jojo.MaxLife, new PublicJoueur(jojo).MaxLife);
            Assert.Equal(jojo.Life, new PublicJoueur(jojo).Life);
            Assert.Equal(jojo.Hapiness, new PublicJoueur(jojo).Hapiness);
            Assert.Equal(jojo.IsDead, new PublicJoueur(jojo).IsDead);
        }

        [Fact]
        public void InstanciatePublicJoueurError()
        {
            Assert.Throws<ArgumentNullException>(() => new PublicJoueur(null));
        }
    }
}
