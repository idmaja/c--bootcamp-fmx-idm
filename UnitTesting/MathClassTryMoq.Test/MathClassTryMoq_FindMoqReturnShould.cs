using Moq;
using NUnit.Framework;

public class MathClassTryMoq_FindMoqReturnShould
{
    [Test]
    public void Tambah_CallLogger()
    {
        var logger = new Mock<IMathLogger>();
        var mathClassTryMoq = new MathClassTryMoq(logger.Object);

        var result = mathClassTryMoq.Tambah(2, 3);
        var expectedResult = 5;

        Assert.That(result, Is.EqualTo(expectedResult));
        logger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }
}