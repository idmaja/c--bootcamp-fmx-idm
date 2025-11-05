// string nama = "Apa \"aku\" adalah"; // untuk menambahkan tanda petik di dalam string
// string nama = "Apa aku \n adalah";
// string nama = "Kamu harus pergi ke drive c:\\"; // untuk menghindari error pada backslash
// string nama = @"Kamu harus pergi ke drive c:\"; // cara lain untuk menghindari error pada backslash

// string nama = String.Format("{1} = {0}", "Satu", "Dua");

// string nama = String.Format("{0:C}", 1500000); // untuk menambahkan simbol mata uang

// string nama = String.Format("{0:N}", 123456); // untuk menambahkan koma setiap 3 digit

// string nama = String.Format("{0:P}", .12); // untuk menjadikan persen

// string nama = String.Format("Phone Number : {0 : (###) ####-####-####}", 62895380222584); // untuk format phone number dan # untuk digit angka

string nama = " hallooo teman-teman ";
// nama = nama.Substring(6);
// nama = nama.ToUpper();
// nama = nama.Replace("TEMAN-TEMAN", "SAHABAT");
// nama = nama.Remove(6, 8);
// nama = nama.Trim().Length.ToString();
nama = nama.Length.ToString();

Console.WriteLine(nama);