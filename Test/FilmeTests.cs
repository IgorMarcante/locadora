using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Models;
using System;

namespace Test
{
    [TestClass]
    public class FilmeTests
    {
        private Filme filme;

        [TestInitialize]
        public void Init()
        {
            this.filme = new Filme("Shrek",Convert.ToDateTime("2021-07-01"),true,1);
        }

        [TestMethod]
        public void DataFilmeMaiorQueDataAtual()
        {
            Assert.IsFalse(filme.DataCriacao > DateTime.Now);  
        }

        [TestMethod]
        public void RecebendoIdIndevido()
        {
            Assert.IsFalse(filme.Id != 0);  
        }

        [TestMethod]
        public void NomeMaiorQuePermitido()
        {
            Assert.IsFalse(filme.Nome.Length > 200);  
        }

        [TestMethod]
        public void GeneroVazio()
        {
            Assert.IsFalse(filme.GeneroId == 0);  
        }


    }
}