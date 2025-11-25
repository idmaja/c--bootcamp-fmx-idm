using System.Threading.Tasks;

Task tugas = Task.Run(() => {
    Console.WriteLine("Sedang mencuci piring...");
    Thread.Sleep(2000);
    Console.WriteLine("Cuci piring selesai!");
});

Console.WriteLine("Apakah sudah selesai? " + tugas.IsCompleted);
tugas.Wait(); // Main thread menunggu di sini sampai tugas selesai (seperti Join)


/// ------ Task dengan Kembalian (Task<T>) ------
Task<int> hitungAngka = Task.Run(() => {
    Thread.Sleep(2000);
    return 5 + 5;
});

Console.WriteLine("Sedang menghitung...");

// Properti .Result akan MEMBLOKIR (menunggu) sampai hasil siap
int hasil = hitungAngka.Result; 
Console.WriteLine("Hasilnya adalah: " + hasil); // Output: 10


/// ----- Exception Handling ------
Task tugasError = Task.Run(() => {
    throw new Exception("Gas Habis!");
});

try 
{
    tugasError.Wait(); // Saat ditunggu, error akan meledak di sini
}
catch (AggregateException ae)
{
    Console.WriteLine("Gagal masak: " + ae.InnerException?.Message);
}



/// ----- Continuations ------
Task<int> tugasHitung = Task.Run(() => 10 * 10);

var pengamat = tugasHitung.GetAwaiter();

pengamat.OnCompleted(() => {
    Console.WriteLine("Yeay selesai! Hasilnya: " + pengamat.GetResult());
});

Console.WriteLine("Saya bisa lanjut main HP sambil nunggu...");
Console.ReadLine();


/// ----- Task Tanpa Thread (TaskCompletionSource) ----
/// <summary>
/// Kadang kita butuh Task (janji selesai), tapi tidak butuh Thread (pekerja). 
/// Ini untuk operasi I/O Bound (menunggu database/network).
/// Analogi: Anda memesan Pizza. Anda dapat struk (Task). Koki tidak perlu berdiri diam 
/// menatap oven selama 20 menit (Blocking Thread). Dia bisa kerjakan hal lain. 
/// Nanti Oven (Timer/Event Eksternal) yang akan bunyi "TING!", dan status struk 
/// Anda berubah jadi "Siap".
/// </summary>

var tcs = new TaskCompletionSource<string>();

// Simulasi timer (misal: menunggu download selesai)
var timer = new System.Timers.Timer(3000) { AutoReset = false };
timer.Elapsed += (start, end) => {
    tcs.SetResult("Pizza Matang!"); 
};
timer.Start();

Task<string> taskPizza = tcs.Task; // Ini Task yang bisa ditunggu, tapi tidak makan Thread CPU!
Console.WriteLine("Menunggu Pizzaa"); // Akan menunggu 3 detik lalu muncul "Pizza Matang!"
Console.WriteLine(taskPizza.Result); // Akan menunggu 3 detik lalu muncul "Pizza Matang!"


/// ----- Task Delay  ----
// Cara Modern (Non-blocking delay)
Task.Delay(2000).GetAwaiter().OnCompleted(() => {
    Console.WriteLine("2 Detik berlalu tanpa memblokir thread!");
});