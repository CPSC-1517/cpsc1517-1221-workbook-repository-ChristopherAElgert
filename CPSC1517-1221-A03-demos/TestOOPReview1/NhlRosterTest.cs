using OOPReview1;

namespace TestOOPReview1
{
    [TestClass]
    public class NhlRosterTest
    {
        [TestMethod]
        [DataRow(97, "Connor McDavid", PlayerPosition.C)]
        [DataRow(18, "Zach Hyman", PlayerPosition.LW)]
        [DataRow(25, "Darnell Nurse", PlayerPosition.D)]
       

        public void Constructor_ValidValues_SetsAllProperties(int playerNo, string playerName, PlayerPosition playerPosition)

        {
            //arragne
            var validPlayer1 = new NhlRoster(playerNo, playerName, playerPosition);

            //act (and assert in this case)
            Assert.AreEqual(playerNo, validPlayer1.PlayerNumber);
            Assert.AreEqual(playerName, validPlayer1.PlayerName);
            Assert.AreEqual(playerPosition, validPlayer1.Position);

            //assert
        }

        [TestMethod]
        [DataRow(100)]
        [DataRow(-1)]
        public void No_InvalidNo_ThrowsArgumentOutOfRangeException(int playerNo)
        {
           

            //act and assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>( () => //lambda operator
            {
                //arrange
                var invalidPlayer1 = new NhlRoster(playerNo, "Greg", PlayerPosition.G);
            }
            );
            Assert.AreEqual("Player Number must be between 0 and 98", exception.ParamName);
        }

        public void Name_InvalidName_ThrowsArgumentNullOrWhiteSpaceException(string playerName)
        {

        }
    }
}