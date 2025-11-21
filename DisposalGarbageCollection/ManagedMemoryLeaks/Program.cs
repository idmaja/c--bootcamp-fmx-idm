/// <summary>
/// versi bocor atau memory leak
/// tidak ada code yang melakukan p.CLick -= handle;
/// Walaupun kamu sudah tidak menyimpan variabel Subscriber, 
/// GC masih melihatnya dipakai, karena masih ada di daftar event
/// Akibatnya, objek Subscriber tidak pernah dibuang.
/// </summary>

// class Publisher
// {
//     public event EventHandler Click;
// }

// class Subscriber
// {
//     public Subscriber(Publisher p)
//     {
//         p.Click += Handle;
//     }

//     void Handle(object sender, EventArgs e) { }
// }

// class Demo
// {
//     static Publisher p = new Publisher();

//     static void Main()
//     {
//         var s = new Subscriber(p);
//         // s keluar scope, tapi masih terhubung ke event
//         // GC tidak bisa membuang s
//     }
// }

/// <summary>
/// perbaikannya dibawah ini
/// Di sinilah leak berhenti. 
/// Sebelum Dispose, Publisher masih punya referensi ke Subscriber lewat event
/// Setelah Dispose, referensi itu hilang
/// Kalau tidak ada referensi lain ke Subscriber, GC boleh membuang objek itu
/// </summary>
class Publisher
{
    public event EventHandler Click;
}

class Subscriber : IDisposable
{
    private Publisher _p;

    public Subscriber(Publisher p)
    {
        _p = p;
        _p.Click += Handle;
    }

    void Handle(object sender, EventArgs e) { }

    public void Dispose()
    {
        _p.Click -= Handle;
    }
}

class Demo
{
    static Publisher p = new Publisher();

    static void Main()
    {
        var s = new Subscriber(p);
        s.Dispose();
    }
}



