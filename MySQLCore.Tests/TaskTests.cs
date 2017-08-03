using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MySQLCore.Models;

namespace MySQLCore.Tests
{

    [TestClass]
    public class TaskTests : IDisposable
    {
        public void Dispose()
        {
            Task.DeleteAll();
        }
        public TaskTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=mysqlcore_test;";
        }
        [TestMethod]
        public void VerifyName_True()
        {
            //Arrange
            Task newTask = new Task("Walk the dog");
            //Assert
            Assert.AreEqual("Walk the dog", newTask.GetName());
        }
        [TestMethod]
        public void VerifyName_False()
        {
            //Arrange
            Task newTask = new Task("Mow the lawn");
            //Assert
            Assert.AreNotEqual("Walk the dog", newTask.GetName());
        }
        [TestMethod]
        public void SaveToDatabase_True()
        {
            // Arrange
            Task newTask = new Task("Make DB Connection Work");
            newTask.Save();
            List<Task> arrangedList = new List<Task> {};
            arrangedList.Add(newTask);
            // Act
            List<Task> allTasks = Task.GetAll();
            // Assert
            CollectionAssert.AreEqual(arrangedList, allTasks);
        }
    }
}
