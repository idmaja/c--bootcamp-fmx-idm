
using Moq;

public class MathClass_FindMoqReturnShould
{
    [Test]
    public void Tambah_CallLogger()
    {
        var logger = new Mock<IMathLogger>();
        var mathClass = new MathClass(logger.Object);

        var result = mathClass.Tambah(2, 3);
        var expectedResult = 5;

        Assert.That(result, Is.EqualTo(expectedResult));
        logger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }
}