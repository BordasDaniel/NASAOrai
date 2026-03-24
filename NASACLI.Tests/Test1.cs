namespace NASACLI.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        [DataRow("Magas", 15, 2000000000)]
        [DataRow("Közepes", 5, 2000000000)]
        [DataRow("Közepes", 15, 500000000)]
        [DataRow("Alacsony", 5, 500000000)]
        public void KockazatSzintTest(string szint, int tomeg, int osszeg)
        {
            Kuldetes k = new($"Test;2024;Mars;5;Igen;Teszt küldetés;{osszeg};{tomeg}");
            Assert.AreEqual(szint, k.KockazatiSzint());
        }
    }
}
