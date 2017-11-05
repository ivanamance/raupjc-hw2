using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2;

namespace Zad2Test
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);

            Assert.AreEqual(zadaca.Text, rep.Get(zadaca.Id).Text);

            rep.Add(zadaca);
            Assert.IsTrue(rep.GetAll().Count == 1);
        }

        [TestMethod]
        public void GettingTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);

            TodoItem prviDodaniItem = rep.Get(zadaca.Id);

            Assert.AreEqual(zadaca.Text, prviDodaniItem.Text);

            Assert.IsNull(rep.Get(Guid.NewGuid()));

        }

        [TestMethod]
        public void RemovingTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);
            TodoItem labos = new TodoItem("Napisati labos iz OS-a");
            rep.Add(labos);
            TodoItem elektronika = new TodoItem("Pročitati poglavlje 'Poluvodičke diode'");
            rep.Add(elektronika);

            rep.Remove(labos.Id);

            Assert.IsNull(rep.Get(labos.Id));

        }

        [TestMethod]
        public void UpdatingTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);
            TodoItem labos = new TodoItem("Napisati labos iz OS-a");
            rep.Add(labos);
            TodoItem elektronika = new TodoItem("Pročitati poglavlje 'Poluvodičke diode'");
            rep.Add(elektronika);

            elektronika.Text = "Pročitati poglavlje 'Poluvodiči'";
            rep.Update(elektronika);

            Assert.AreNotEqual(elektronika.Text, "Pročitati poglavlje 'Poluvodičke diode'");

            TodoItem matematika = new TodoItem("Proučiti Laplaceove transformacije");
            rep.Update(matematika);

            Assert.AreEqual(matematika.Text, rep.Get(matematika.Id).Text);
            
        }

        [TestMethod]
        public void CopletingTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);

            rep.MarkAsCompleted(zadaca.Id);

            Assert.IsTrue(rep.Get(zadaca.Id).DateCompleted.HasValue);

        }

        [TestMethod]
        public void GettingAllTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);
            TodoItem labos = new TodoItem("Napisati labos iz OS-a");
            rep.Add(labos);
            TodoItem elektronika = new TodoItem("Pročitati poglavlje 'Poluvodičke diode'");
            rep.Add(elektronika);

            List<TodoItem> lista = rep.GetAll();

            Assert.IsTrue(lista.Contains(zadaca));

        }

        [TestMethod]
        public void GettingCompletedTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);
            TodoItem labos = new TodoItem("Napisati labos iz OS-a");
            rep.Add(labos);
            TodoItem elektronika = new TodoItem("Pročitati poglavlje 'Poluvodičke diode'");
            rep.Add(elektronika);

            rep.MarkAsCompleted(labos.Id);
            rep.MarkAsCompleted(elektronika.Id);

            List<TodoItem> zavrseni = rep.GetCompleted();

            Assert.IsTrue(zavrseni.Contains(labos));
            Assert.IsFalse(zavrseni.Contains(zadaca));

        }

        [TestMethod]
        public void GettingActiveTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);
            TodoItem labos = new TodoItem("Napisati labos iz OS-a");
            rep.Add(labos);
            TodoItem elektronika = new TodoItem("Pročitati poglavlje 'Poluvodičke diode'");
            rep.Add(elektronika);

            rep.MarkAsCompleted(labos.Id);
            rep.MarkAsCompleted(elektronika.Id);

            List<TodoItem> aktivni = rep.GetActive();

            Assert.IsTrue(aktivni.Contains(zadaca));
            Assert.IsFalse(aktivni.Contains(labos));

        }

        [TestMethod]
        public void GettingFilteredTodoItems()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem zadaca = new TodoItem("Napisati zadaću iz RAUPJC-a");
            rep.Add(zadaca);
            TodoItem labos = new TodoItem("Napisati labos iz OS-a");
            rep.Add(labos);
            TodoItem elektronika = new TodoItem("Pročitati poglavlje 'Poluvodičke diode'");
            rep.Add(elektronika);

            Func<TodoItem, bool> napisati = i => i.Text.Contains("Napisati");
            
            List<TodoItem> filtrirani  = rep.GetFiltered(napisati);

            Assert.IsTrue(filtrirani.Contains(labos));
            Assert.IsFalse(filtrirani.Contains(elektronika));

        }
    }
}
