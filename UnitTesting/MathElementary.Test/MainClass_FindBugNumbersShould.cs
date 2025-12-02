public class MainClass_FindBugNumbersShould
{

    private MainClass? _mainClass;

    [SetUp]
    public void Setup()
    {
        _mainClass = new MainClass();
    }

    // Test biasa.
    [Test]
    [Category("Penjumlahan")]
    public void Tambah_ReturnsCorrectValue()
    {
        var result = _mainClass?.Tambah(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }

    // Test dengan beberapa input.
    [TestCase(2, 3, 5)]
    [TestCase(10, 5, 15)]
    [TestCase(-2, 2, 0)]
    [Category("Penjumlahan")]
    public void Tambah_UsingTestCase(int a, int b, int expectedResult)
    {
        var result = _mainClass?.Tambah(a, b);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [Category("Pengurangan")]
    public void Kurang_ReturnsExpectedValue()
    {
        var inputOne = 10;
        var inputTwo = 0;
        var expectedResult = 10;

        var result = _mainClass?.Kurang(inputOne, inputTwo);

        Assert.That(result, Is.EqualTo(expectedResult)); // -> Model Constraint
        // Assert.AreEqual(); -> Model Klasik / Lama
    }

    // Sumber test eksternal.
    static object[] DataPerkalian =
    {
        new object[] {2, 3, 6},
        new object[] {5, 5, 25}
    };

    [TestCaseSource(nameof(DataPerkalian))]
    [Category("Perkalian")]
    public void Kali_UsingTestCaseSource(int a, int b, int expectedResult)
    {
        var result = _mainClass?.Kali(a, b);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    // Test diberi kategori.
    [Test]
    [Category("Pembagian")]
    public void Bagi_ReturnsCorrectValue()
    {
        var result = _mainClass?.Bagi(10, 2);
        Assert.That(result, Is.EqualTo(5));
    }

    // Test diabaikan sementara.
    // [Test]
    // [Ignore("On Debugging")]
    // public void TestYangDilewati() { }
}