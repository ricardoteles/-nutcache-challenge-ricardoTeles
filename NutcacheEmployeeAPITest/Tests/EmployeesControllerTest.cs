using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NutcacheEmployeeAPI.Controllers;
using NutcacheEmployeeAPI.Models;
using NutcacheEmployeeAPI.Services.Interface;
using NutcacheEmployeeAPITest.Mock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutcacheEmployeeAPITest
{
    [TestFixture]
    public class EmployeesControllerTest
    {
        private Mock<IEmployeeService> _service;
        private EmployeesController _controller;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IEmployeeService>();
            _controller = new EmployeesController(_service.Object);
        }

        [Test]
        public void EmployeesController_GetEmployee_ShouldReturnNull_WhenThereIsNoEmployee()
        {
            // Arrange
            List<Employee> employees = null;
            _service.Setup(_ => _.GetAll()).Returns(Task.FromResult(employees));

            // Act
            var result = _controller.GetEmployee();

            // Assert
            Assert.AreEqual(null, result.Result.Value);
        }

        [Test]
        public void EmployeesController_GetEmployee_ShouldReturnEmployeeList_WhenThereIsEmployee()
        {
            // Arrange
            List<Employee> employees = EmployeeMock.getEmployeeList();
            _service.Setup(_ => _.GetAll()).Returns(Task.FromResult(employees));

            // Act
            var result = _controller.GetEmployee();

            // Assert
            Assert.AreEqual(employees, result.Result.Value);
        }

        [Test]
        public void EmployeesController_GetEmployee_ShouldReturnNotFoundStatus_WhenDontFindEmployee()
        {
            // Arrange
            Employee employee = null;
            _service.Setup(_ => _.Get(1)).Returns(Task.FromResult(employee));

            // Act
            var result = _controller.GetEmployee(1);

            // Assert
            Assert.AreEqual(StatusCodes.Status404NotFound, (result.Result.Result as StatusCodeResult).StatusCode);
        }

        [Test]
        public void EmployeesController_GetEmployee_ShouldReturnEmployee_WhenFindEmployee()
        {
            // Arrange
            Employee employee = EmployeeMock.getEmployee();

            _service.Setup(_ => _.Get(1)).Returns(Task.FromResult(employee));

            // Act
            var result = _controller.GetEmployee(1);

            // Assert
            Assert.AreEqual(employee, result.Result.Value);
        }

        [Test]
        public void EmployeesController_PostEmployee_ShouldReturnCreatedStatus_WhenAddedEmployee()
        {
            // Arrange
            Employee employee = EmployeeMock.getEmployee();

            _service.Setup(_ => _.Add(employee)).Returns(Task.FromResult(employee));

            // Act
            var result = _controller.PostEmployee(employee);

            // Assert
            Assert.AreEqual(StatusCodes.Status201Created, (result.Result.Result as ObjectResult).StatusCode);
        }

        [Test]
        public void EmployeesController_PutEmployee_ShouldReturnBadRequestStatus_WhenEmployeeIsWrong()
        {
            // Arrange
            Employee employee = EmployeeMock.getEmployee();

            // Act
            var result = _controller.PutEmployee(2, employee);

            // Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (result.Result as StatusCodeResult).StatusCode);
        }

        [Test]
        public void EmployeesController_PutEmployee_ShouldReturnNoContentStatus_WhenEmployeeIsUpdated()
        {
            // Arrange
            Employee employee = EmployeeMock.getEmployee();
            _service.Setup(_ => _.Update(employee)).Returns(Task.FromResult(employee));

            // Act
            var result = _controller.PutEmployee(1, employee);

            // Assert
            Assert.AreEqual(StatusCodes.Status204NoContent, (result.Result as StatusCodeResult).StatusCode);
        }

        [Test]
        public void EmployeesController_DeleteEmployee_ShouldReturnNotFoundStatus_WhenEmployeeIsNotFound()
        {
            // Arrange
            Employee employee = null;
            _service.Setup(_ => _.Delete(1)).Returns(Task.FromResult(employee));

            // Act
            var result = _controller.DeleteEmployee(4);

            // Assert
            Assert.AreEqual(StatusCodes.Status404NotFound, (result.Result.Result as StatusCodeResult).StatusCode);
        }

        [Test]
        public void EmployeesController_DeleteEmployee_ShouldReturnEmployee_WhenEmployeeIsDeleted()
        {
            // Arrange
            Employee employee = EmployeeMock.getEmployee();
            _service.Setup(_ => _.Delete(1)).Returns(Task.FromResult(employee));

            // Act
            var result = _controller.DeleteEmployee(1);

            // Assert
            Assert.AreEqual(employee, result.Result.Value);
        }
    }
}
