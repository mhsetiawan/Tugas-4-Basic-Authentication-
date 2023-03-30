using System.Text;
using System.Timers;

namespace ConsoleApp1;

class Example01
{
    static void Main(string[] args)
    {
        int pilihMenu = 0, countUser = 1;
        SortedList<int,User> user = new SortedList<int, User>();
        string pesan;
        Console.WriteLine(DateTime.Now);
        do
        {
            Console.WriteLine("== BASIC AUTHENTICATION ==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");
            Console.Write("Input :");
            pilihMenu = Convert.ToInt32(Console.ReadLine());
            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("==CREATE USER==");
                    User newUser = new User();
                    newUser.InputNewUser(newUser);

                    //Cek Username Sama
                    if (user.Any(u => u.Value.Username.Contains(newUser.Username)))
                    {
                        newUser.Username = $"{newUser.FirstName[..2]}{newUser.LastName[..2]}{user.Count()}";
                    }
                    user.Add(countUser,newUser);
                    countUser++;

                    Console.WriteLine("Data User Berhasil Dibuat");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    int pilihan = 0;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("==SHOW USER==");
                        foreach (var item in user)
                        {
                            Console.WriteLine("=============================================");
                            Console.WriteLine("ID       :" + item.Key);
                            item.Value.PrintUser();
                            Console.WriteLine("=============================================");
                        }
                 
                        Console.WriteLine("Menu");
                        Console.WriteLine("1. Edit User");
                        Console.WriteLine("2. Delete User");
                        Console.WriteLine("3. Back");
                        Console.WriteLine("Input :");
                        pilihan = Convert.ToInt32(Console.ReadLine());
                        switch (pilihan)
                        {
                            case 1:
                                Console.Write("ID yang ingin diubah :");
                                int idUbah = Convert.ToInt32(Console.ReadLine());
                                //Ubah First Name
                                Console.Write("First Name :");
                                string newFname = Console.ReadLine();
                                user[idUbah].FirstName = newFname;
                                //Ubah Last Name
                                Console.Write("Last Name :");
                                string newLname = Console.ReadLine();
                                user[idUbah].LastName = newLname;
                                //Ubah Username
                                user[idUbah].Username = $"{user[idUbah].FirstName[..2]}{user[idUbah].LastName[..2]}";
                                //Ubah Password
                                Console.Write("Password :");
                                string newPass = Console.ReadLine();
                                user[idUbah].Pass = newPass;                             

                                Console.WriteLine($"User dengan id {idUbah} berhasil di edit");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Write("ID yang ingin dihapus :");
                                int idHapus = Convert.ToInt32(Console.ReadLine());
                                user.Remove(idHapus);
                                Console.WriteLine("Akun Berhasil dihapus");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                break;
                            default:
                                pesan = "Input Tidak Valid, Silahkan Pilih Ulang";
                                Console.WriteLine(pesan);
                                break;
                        }
                    } while (pilihan != 3);

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("==CARI AKUN==");
                    string namaCari;
                    Console.Write("Masukkan Nama :");
                    namaCari = Console.ReadLine();
                    var search = (from u in user where u.Value.FirstName.ToLower().Contains(namaCari.ToLower())
                                  || u.Value.LastName.ToLower().Contains(namaCari.ToLower()) select u).ToList();

                    if (search.Any())
                    {
                        foreach (var item in search)
                        {
                            Console.WriteLine("=============================================");
                            Console.WriteLine("ID       :" + item.Key);
                            item.Value.PrintUser();
                            Console.WriteLine("=============================================");
                        }
                       
                    }
                    else {
                        Console.WriteLine("==Akun Tidak Ditemukan==");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("==LOGIN==");
                    Console.Write("USERNAME :");
                    string username;
                    username = Console.ReadLine();

                    Console.Write("Password :");
                    string pass;
                    pass = Console.ReadLine();

                    var login = (from u in user where u.Value.Username.Equals(username) && u.Value.Pass.Equals(pass) select u);

                    if (login.Any())
                    {
                        Console.Write("Login Berhasil");
                    }
                    else
                    {
                        Console.WriteLine("Login Gagal");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    break;
                default:
                    pesan = "Input Tidak Valid, Silahkan Pilih Ulang";
                    Console.WriteLine(pesan);
                    break;
            }
        } while (pilihMenu != 5);


    }
}