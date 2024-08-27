
using Patikafly;

List<People> people = new List<People>();// verilen isimleri listeye ekliyoruz 
people.Add(new People { Name= "Ajda Pekkan",Genre="Pop" , Year=1968 , Sale=20});
people.Add(new People { Name = "Sezen Aksu", Genre = "Pop", Year = 1971, Sale = 10 });
people.Add(new People { Name = "Funda Arar", Genre = "Pop", Year = 1999, Sale = 3 });
people.Add(new People { Name = "Sertap Erener", Genre = "Pop", Year = 1994, Sale = 5 });
people.Add(new People { Name = "Sıla", Genre = "Pop", Year = 2009, Sale = 3 });
people.Add(new People { Name = "Serdar Ortaç", Genre = "Pop", Year = 1994, Sale = 10 });
people.Add(new People { Name = "Tarkan", Genre = "Pop", Year = 1992, Sale = 40 });
people.Add(new People { Name = "Hande Yener", Genre = "Pop", Year = 1999, Sale = 7 });
people.Add(new People { Name = "Hadise", Genre = "Pop", Year = 2005, Sale = 5 });
people.Add(new People { Name = "Gülben Ergen", Genre = "Pop", Year = 1997, Sale = 10 });
people.Add(new People { Name = "Neşat Ertaş", Genre = "Türk Halk Müziği", Year = 1960, Sale = 2 });


var quaestion1 = people.Where(x => x.Name.StartsWith("S"));// isimi s ile başlayanalrı buluyoruz

foreach (var person in quaestion1)
{
    Console.WriteLine("İlk harfi S olan santçılar:" + string.Join(",",person.Name));
}


var quastion2 = people.Where(x => x.Sale > 10);// 10 miyondan fazla satış yapanları buluyoruz 

foreach (var person in quastion2)
{
    Console.WriteLine("Satışları 10 milyondan fazla olan  sanatçılar: " + string.Join(",",person.Name));
}

var quastion3 = people
    .Where(x => x.Year < 2000 && x.Genre.ToLower() == "pop")// 2000 den önce çıkış yapmış ve pop müzik yapan kişileri buluyoruz 
    .GroupBy(s => s.Year)//bulduğumuz kişileri gruplandırıyoruz
    .OrderBy(g => g.Key)//grupladıklarımızı sıralamak için order by kullanıyoruz
    .Select(g => new
    { 
        year= g.Key,    
        name=g.OrderBy(s=>s.Name).ToList()
    });

foreach (var group in quastion3)
{
    Console.WriteLine($"Çıkış yılı: {group.year}");//grupladığımız yılları yazdırıyoruz

    foreach (var person in group.name) 
    {
        Console.WriteLine(person.Name);// gruplanan yıların içindeki kişileri yazıyoruz 
  
    }
}

var max = people.Max(x => x.Sale);// oluşturduğumuz listede max değerini buluyoruz 
    var maxsales = people.Where(x => x.Sale == max);// bulduğumuz max değerinin kime eşit olduğunu buluyorum 

    foreach (var person in maxsales)
    {
        Console.WriteLine("En fazla satış yapan : " + person.Name);
    }

    var oldyear=people.Min(x => x.Year);// oluşturduğumuz listede min değerini buluyoruz 
var  oldexit = people.Where(x=>x.Year== oldyear);//bulduğumuz min değerinin kime eşit olduğunu buluyoruz

foreach(var person in oldexit)
{
    Console.WriteLine("En yeni çıkış yapan: " +person.Name);
}

var newyear =people.Max(x => x.Year);
var newexit=people.Where(x=>  x.Year== newyear);

foreach (var person in newexit)
{
    Console.WriteLine("En eski çıkış yapan: "+ person.Name);
}


    