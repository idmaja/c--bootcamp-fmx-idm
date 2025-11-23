using System.Diagnostics;

string LogFileName = "application_trace.log";

Console.WriteLine("Memulai konfigurasi Trace Listeners...");
        
// opsional, tapi best practice
Trace.Listeners.Clear();

TextWriterTraceListener fileListener = new TextWriterTraceListener(LogFileName);

fileListener.TraceOutputOptions = TraceOptions.DateTime | TraceOptions.ProcessId;

Trace.Listeners.Add(fileListener);

// memastikan log segera ditulis ke file, bahkan jika aplikasi crash.
Trace.AutoFlush = true;

Console.WriteLine($"Listener file '{LogFileName}' sudah terpasang dengan AutoFlush: {Trace.AutoFlush}");

try
{
    Trace.TraceInformation("Aplikasi berjalan. Memeriksa koneksi database...");
    
    bool isDbConnected = false; // Simulasikan failure
    
    if (!isDbConnected)
    {
        Trace.TraceWarning("Gagal mendapatkan koneksi ke database. Mencoba lagi dalam 5 detik.");
        
        // Simulasikan Critical Error
        Trace.TraceError("Kesalahan Fatal: Gagal memuat file konfigurasi penting.");
        
        Debug.Fail("Ini adalah kegagalan debug: Flow kode tidak boleh mencapai titik ini!");
    }
    Trace.TraceInformation("Proses utama selesai.");
}
catch (Exception ex)
{
    Trace.TraceError($"Exception tidak terduga: {ex.Message}");
}
finally
{
    // Trace.Close() harus dipanggil untuk menutup handle file.
    Trace.Close();
    Console.WriteLine("Trace.Close() dipanggil. Handle file ditutup.");
}