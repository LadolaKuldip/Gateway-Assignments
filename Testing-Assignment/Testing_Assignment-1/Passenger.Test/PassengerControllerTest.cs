using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Testing_Assignment_1.Controllers;
using Testing_Assignment_1.Repository;
using Xunit;

namespace Passenger.Test
{
    public class PassengerControllerTest
    {
        private readonly Mock<IDataRepository> mockDataRepository = new Mock<IDataRepository>();
        private readonly PassengerController _passengerController;

        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mockDataRepository.Object);
        }

        /// <summary>
        /// Test Method to retrive list of Passengers
        /// </summary>
        [Fact]
        public void Test_GetPassenger()
        {
            // Arrange
            var resultObj = mockDataRepository.Setup(x => x.getPassengersList()).Returns(GetPassengers());

            // Act
            var response = _passengerController.Get();

            // Asert
            Assert.Equal(3, response.Count);

        }

        /// <summary>
        /// Test Method to delete Passenger
        /// </summary>
        [Fact]
        public void Test_DeletePassenger()
        {
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            // Arrange
            var resultObj = mockDataRepository.Setup(x => x.Delete(passenger.Id)).Returns(true);

            // Act
            var response = _passengerController.Delete(passenger.Id);

            //Assert
            Assert.True(response);

        }

        /// <summary>
        /// Test Method to get Passenger details
        /// </summary>
        [Fact]
        public void Test_GetPassengerById()
        {
            // Arrange
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Kuldip";
            passenger.LastName = "Ladola";
            passenger.PhoneNumber = "9876543210";

            // Act
            var responseObj = mockDataRepository.Setup(x => x.GetById(passenger.Id)).Returns(passenger);
            var result = _passengerController.Get(passenger.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<Testing_Assignment_1.Models.Passenger>>(result);
            // Assert
            Assert.NotNull(isNull);
        }

        /// <summary>
        /// Test Method to add new Passenger
        /// </summary>
        [Fact]
        public void Test_AddPassenger()
        {
            // Arrange
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Kuldip";
            passenger.LastName = "Ladola";
            passenger.PhoneNumber = "9876543210";
            // Act
            var response = mockDataRepository.Setup(x => x.AddPassenger(passenger)).Returns(AddPassenger());
            var result = _passengerController.Post(passenger);

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Test Method to update Passenger data
        /// </summary>
        [Fact]
        public void Test_UpdatePassenger()
        {
            // Arrange
            var model = new Testing_Assignment_1.Models.Passenger();
            model.Id = new Guid();
            model.FirstName = "Kuldip";
            model.LastName = "Ladola";
            model.PhoneNumber = "9876543210";
            // Act
            var resultObj = mockDataRepository.Setup(x => x.Update(model)).Returns(model);
            var response = _passengerController.Put(model);
            // Assert
            Assert.Equal(model, response);
        }

        /// <summary>
        /// returns list of Passengers
        /// </summary>
        private static IList<Testing_Assignment_1.Models.Passenger> GetPassengers()
        {
            Guid id1 = new Guid();
            Guid id2 = new Guid();
            Guid id3 = new Guid();
            IList<Testing_Assignment_1.Models.Passenger> passengers = new List<Testing_Assignment_1.Models.Passenger>()
            {                
                new Testing_Assignment_1.Models.Passenger() {Id = id1, FirstName = "Kuldip", LastName = "Ladola" ,PhoneNumber = "9876543210"},
                new Testing_Assignment_1.Models.Passenger() { Id = id2, FirstName = "Parth", LastName = "Patel", PhoneNumber = "9876543210" },
                new Testing_Assignment_1.Models.Passenger() { Id = id3, FirstName = "Rushi", LastName = "Nariya", PhoneNumber = "9876543210" },

            };
            return passengers;
        }

        /// <summary>
        /// creates Passenger
        /// </summary>
        private static Testing_Assignment_1.Models.Passenger AddPassenger()
        {
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Kuldip";
            passenger.LastName = "Ladola";
            passenger.PhoneNumber = "9876543210";
            return passenger;
        }
    }
}
