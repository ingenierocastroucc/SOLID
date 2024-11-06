using Xunit;
using Moq;
using DependencyInversion;
using DependencyInversion.Controllers;
using System.Collections.Generic;

namespace Api.Tests
{
    public class StudentTest
    {
        [Fact]
        public void GetStudent_ReturnsListOfStudents()
        {
            // Arrange: Crear mocks de las dependencias
            var mockStudentRepository = new Mock<IStudentRepository>();
            var mockLogbook = new Mock<ILogbook>();

            // Configurar el mock de IStudentRepository para que devuelva una lista simulada de estudiantes
            mockStudentRepository.Setup(repo => repo.GetAll())
                                 .Returns(new List<Student>
                                 {
                                     new Student(1, "Pepito Pérez", new List<double>{3, 4.5}),
                                     new Student(2, "Mariana Lopera", new List<double>{4, 5}),
                                     new Student(3, "José Molina", new List<double>{2, 3})
                                 });

            // Crear el controlador con las dependencias mockeadas
            var studentController = new StudentController(mockStudentRepository.Object, mockLogbook.Object);

            // Act: Llamar al método Get() del controlador
            var resultGetStudents = studentController.Get();

            // Assert: Verificar que el resultado no es nulo y contiene 3 estudiantes
            Assert.NotNull(resultGetStudents);
            Assert.Equal(3, resultGetStudents.Count());
        }
    }
}