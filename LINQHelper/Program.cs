using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQHelper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // WhereDemo();
            // OrderByDemo();
            // ThenByDemo();
            // ReverseDemo();
            // ExceptDemo();
            // UnionDemo();
            // ConcatDemo();
            // IntersectDemo();
            // DistinctDemo();
            // AllDemo();
            // AnyDemo();
            // ContainsDemo();
            // SelectDemo();
            // SelectManyDemo();
            // AggregateMethodsMath();
            // GroupByDemo();
            // JoinDemo();
            // FirstAndFirstOrDefaultDemo();
            // LastAndLastOrDefaultDemo();
            // SingleAndSingleOrDefaultDemo();
            // DefaultIfEmptyDemo();
            // SequenceEqualDemo();
            // TakeDemo();
            // TakeWhileDemo();
            // SkipDemo();
            // SkipWhileDemo();
            // PagingWithTakeAndSkipDemo();
            // RangeDemo();
        }

        private static void RangeDemo()
        {
            //aralık almaya yarar
            IEnumerable<int> value1 = Enumerable.Range(10, 30).Where(x => x % 2 == 0); //10 dan başlayıp 40 a kadar 2'ye tam bölünen sayılar
            foreach (int item in value1)
            {
                Console.WriteLine(item);
            }
            
            IEnumerable<int> value2 = Enumerable.Range(1,5).Select(x=>x*x); //1 ile 6 arasındaki sayıların karesi
            foreach (int item in value2)
            {
                Console.WriteLine(item);
            }
        }

        private static void PagingWithTakeAndSkipDemo()
        {
            int recordsPerPage = 4;
            int pageNumber = 0;
            
            do
            {
                Console.WriteLine("Enter a number between 1 and 4...");
                if (int.TryParse(Console.ReadLine(), out pageNumber))
                {
                    if (pageNumber > 0 && pageNumber < 5)
                    {
                        List<Student> result = GetStudentsData().Skip((pageNumber - 1) * recordsPerPage).Take(recordsPerPage).ToList();
                        Console.WriteLine($"Page number : {pageNumber}");
                        foreach (Student item in result)
                        {
                            Console.WriteLine($"{item.FirstName} {item.LastName} {item.PhoneNumber}");
                        }
                    }
                    else
                        Console.WriteLine("Page number isn't correct");
                }
                else
                    Console.WriteLine("Page number isn't correct");
            } while (true);
        }

        private static void SkipWhileDemo()
        {
            //verilen kondisyonu geçer ve sonrasındaki elemanları yazdırır
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> result = numbers.SkipWhile(x => x < 6);
            foreach (int item in result)
            {
                Console.WriteLine(item); // --> 6,7,8,9
            }
        }

        private static void SkipDemo()
        {
            // şu kadar elemanı atla şeklinde kullanılır
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> result = numbers.Skip(4);
            foreach (int item in result)
            {
                Console.WriteLine(item); // --> 5,6,7,8,9
            }
        }

        private static void TakeWhileDemo()
        {
            // metodun içine bir kondisyon atanır ve kondisyon doğru olduğu sürece devam eder
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> result = numbers.TakeWhile(number => number < 5); //5 ten küçük olana kadar devam eder
            foreach (int item in result)
            {
                Console.WriteLine(item); // --> 1,2,3,4 
            }
        }

        private static void TakeDemo()
        {
            //metodun içinde verilen sayı kadar elemanı alır. ilk 4 eleman
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> result1 = numbers.Take(4);
            foreach (int item in result1)
            {
                Console.WriteLine(item);
            }

            //listeyi tersine çevirip, verilen sayı kadar elemanı alırız. sondan 4 eleman
            IEnumerable<int> result2 = numbers.OrderByDescending(x => x).Take(4);
            foreach (int item in result2)
            {
                Console.WriteLine(item);
            }
        }

        private static void SequenceEqualDemo()
        {
            //iki listeyi karşılaştırır. eğer tüm elemanlar eşitse true, değilse false döner
            List<int> numbers1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> numbers2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            bool result = numbers1.SequenceEqual(numbers2);
            Console.WriteLine(result);

            string[] languages1 = { "C#", "Typescript", "Java", "Ruby", "Go", "Swift", "C++" };
            string[] languages2 = { "c#", "typescript", "java", "ruby", "go", "swift", "c++" };
            bool result2 = languages1.SequenceEqual(languages2, StringComparer.OrdinalIgnoreCase); //büyük-küçük harf duyarlılığını göz ardı eder
            Console.WriteLine(result2);
        }

        private static void DefaultIfEmptyDemo()
        {
            //listede eleman varsa onları yazdırır. yoksa default değer (0) döner
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> result = numbers.DefaultIfEmpty(5); //listede eleman yoksa default değer 5 döner
            foreach (int item in result)
            {
                Console.WriteLine($"{item}");
            }
        }

        private static void SingleAndSingleOrDefaultDemo()
        {
            //single : tek bir değer dönderir. liste boş ise hata verir. listede birden fazla eleman olursa da hata verir
            //singleOrDefault : sorgu yazılabilir. sorgu sonucunda eğer birden fazla eleman dönerse yine hata verir
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int single = numbers.Single(x => x == 5);
            int singleOrDefault = numbers.SingleOrDefault(x => x > 20);
            Console.WriteLine($"Single : {single}");
            Console.WriteLine($"SingleOrDefault : {singleOrDefault}");
            Console.ReadLine();
        }

        private static void LastAndLastOrDefaultDemo()
        {
            //last : listenin son değerini verir. lambda ile sorgu da yazabilirsin ama sorguda herhangi bir sonuç dönmezse hata verir
            //lastOrDefault : sonucunda sayı dönmezse bile default değer olan 0'ı döndürür
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int last = numbers.Last();
            int lastOrDefault = numbers.LastOrDefault(x => x > 80);
            Console.WriteLine($"Last Method's Result -> {last}");
            Console.WriteLine($"LastOrDefault Method's Result -> {lastOrDefault}");
        }

        private static void FirstAndFirstOrDefaultDemo()
        {
            //first : listenin ilk değerini verir. lambda ile sorgu da yazabilirsin ama sorguda herhangi bir sonuç dönmezse hata verir
            //firstOrDefault : sonucunda sayı dönmezse bile default değer olan 0'ı döndürür
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int first = numbers.First();
            int firstOrDefault = numbers.FirstOrDefault(x => x > 50);
            Console.WriteLine($"First Method's Result -> {first}");
            Console.WriteLine($"FirstOrDefault Method's Result -> {firstOrDefault}");
        }

        private static void JoinDemo()
        {
            //tablolardaki ortak alanları birleştirme
            List<Student> students = GetStudentsData();
            List<City> cities = GetCities();
            var result = students.Join(cities, stu => stu.CityId, addr => addr.Id, (stu, addr) => new
            {
                stu.Id,
                stu.FirstName,
                stu.LastName,
                addr.CityName
            }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id}-{item.FirstName} {item.LastName} ({item.CityName})");
            }

            Console.ReadLine();
        }

        private static void GroupByDemo()
        {
            //gruplama yapmak için kullanılır
            List<Student> students = GetStudentsData();
            IEnumerable<IGrouping<bool, Student>> result = students.GroupBy(c => c.IsMarried);
            foreach (IGrouping<bool, Student> item in result)
            {
                Console.WriteLine($"{item.Key} {item.Count()}");
                foreach (Student i in item)
                {
                    Console.WriteLine($"{i.FirstName} {i.LastName}  -->  {i.Department.DepartmentName}");
                }
            }

            Console.ReadLine();
        }

        private static void AggregateMethodsMath()
        {
            //matematik sorguları
            int[] array = new int[] { 10, 20, 30, 40, 50, 60, 80, 100, 150, 180 };
            int total = array.Sum();
            Console.WriteLine($"Total : {total}");
            int max = array.Max();
            Console.WriteLine($"Max : {max}");
            int min = array.Min();
            Console.WriteLine($"Min : {min}");
            double avg = array.Average();
            Console.WriteLine($"Average : {avg}");
            int count = array.Count();
            Console.WriteLine($"Count : {count}");
            string[] languages = { "C#", "Typescript", "Java", "Ruby", "Go", "Swift", "C++" };

            //birden çok string ifadeyi tek bir string haline getirir
            string aggregate = languages.Aggregate((x, y) => $"{x}, {y}");
            Console.WriteLine($"Aggregate : {aggregate}");
            Console.ReadLine();
        }

        private static void SelectManyDemo()
        {
            //Birden fazla tablo ya da veri kaynağını birleştirip tek bir liste içinde göstermek için bu ifade kullanılır
            //class içindeki class'a erişmek gibi
            List<Student> students = GetStudentsData();
            IEnumerable<Student> result = students.SelectMany(x => students);
            foreach (Student item in result)
            {
                Console.WriteLine(item.Department.DepartmentName);
            }

            Console.ReadLine();
        }

        private static void SelectDemo()
        {
            //Liste içerisinden sadece belirlediğimiz değerlerin listesini döndürmek için kullanılır.
            List<Student> students = GetStudentsData();
            IEnumerable<Student> result = students.Select(c => new Student
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Age = c.Age
            });
            foreach (Student item in result)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
            }

            Console.ReadLine();
        }

        private static void ContainsDemo()
        {
            //içeriyor mu?
            List<Student> students = GetStudentsData();
            foreach (Student student in students)
            {
                if (student.FirstName.Contains("Buğrahan"))
                    Console.WriteLine("Öğrenciler arasında Buğrahan vardır");
            }

            Console.ReadLine();
        }

        private static void AnyDemo()
        {
            //liste içinde var mı sorgusu
            List<Student> students = GetStudentsData();
            if (students.Any(c => c.IsMarried == false))
                Console.WriteLine("En az bir tane evli olmayan öğrenci vardır");
            else
                Console.WriteLine("Evli olan öğrenci yoktur");

            Console.ReadLine();
        }

        private static void AllDemo()
        {
            //listenin tüm elemanları eğer lambda ile verilen şartı sağlıyorsa true döner, yoksa false döner
            int[] numbers = { 5, 10, 15, 20, 51, 100 };
            bool control = numbers.All(x => x % 5 == 0);
            if (control)
                Console.WriteLine("Hepsi 5'e tam bölünüyor");
            else
                Console.WriteLine("Listede 5'e tam bölünmeyen sayı var");
            Console.ReadLine();
        }

        private static void DistinctDemo()
        {
            //duplicate olan(tekrar eden) elemanları tek seferde gösterir
            string[] employees = { "Ali", "Metin", "Can", "Nur", "Yusuf", "Kadir", "Eylül", "Ali", "Hatice", "Nur" };
            IEnumerable<string> distinctValues = employees.Distinct();
            foreach (string item in distinctValues)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void IntersectDemo()
        {
            //iki listenin sadece ortak(birleşim) elemanlarını alır
            string[] list = { "ben", "bugün", "linq", "çalışıyorum" };
            string[] list2 = { "linq", "bugün" };

            IEnumerable<string> result = list.Intersect(list2);
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void ConcatDemo()
        {
            //her iki dizindeki tüm elemanları alır. union'dan farkı; ortak elemanları da alır.
            string[] list = { "ben", "bugün", "linq", "çalışıyorum" };
            string[] list2 = { "linq", "bugün" };
            IEnumerable<string> result = list.Concat(list2);
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void UnionDemo()
        {
            // her iki dizinde de aynı olanları sadece tek seferde alır ve iki listeyi de birleştirir
            string[] list = { "ben", "bugün", "linq", "çalışıyorum" };
            string[] list2 = { "linq", "bugün" };
            IEnumerable<string> result = list.Union(list2);
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void ExceptDemo()
        {
            // birinci dizinin elemanlarından ikinci dizinin elemanlarının farkını verir
            string[] list = { "ben", "bugün", "linq", "çalışıyorum" };
            string[] list2 = { "linq", "bugün" };

            IEnumerable<string> differentItems = list.Except(list2);
            foreach (string item in differentItems)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void ReverseDemo()
        {
            //tersine çevirme
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Console.WriteLine("Reverse kullanmadan...");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

            IEnumerable<int> arrayListReverse = array.Reverse();
            Console.WriteLine("Reverse metodu ile...");
            foreach (int i in arrayListReverse)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }

        private static void ThenByDemo()
        {
            //order by dan sonra ikinci bir sıralama yapmak için
            List<Student> students = GetStudentsData();
            IOrderedEnumerable<Student> thenByStudents = students.OrderBy(x => x.Age).ThenBy(c => c.FirstName);
            foreach (Student value in thenByStudents)
            {
                Console.WriteLine($"{value.FirstName} {value.LastName}");
            }

            Console.ReadLine();
        }

        private static void OrderByDemo()
        {
            List<Student> students = GetStudentsData();
            IOrderedEnumerable<Student> orderByStudents = students.OrderByDescending(x => x.Age);
            foreach (Student value in orderByStudents)
            {
                Console.WriteLine($"{value.FirstName} {value.LastName}");
            }

            Console.ReadLine();
        }

        private static void WhereDemo()
        {
            List<Student> students = GetStudentsData();
            IEnumerable<Student> result = students.Where(x => x.Age < 30).ToList();
            foreach (Student value in result)
            {
                Console.WriteLine(value.FirstName);
            }

            Console.ReadLine();
        }

        private static List<City> GetCities()
        {
            List<City> cities = new List<City>();
            cities.Add(new City { Id = 1, CityName = "İzmir" });
            cities.Add(new City { Id = 2, CityName = "İstanbul" });
            cities.Add(new City { Id = 3, CityName = "Antalya" });
            cities.Add(new City { Id = 5, CityName = "Ankara" });
            cities.Add(new City { Id = 5, CityName = "Gaziantep" });
            return cities;
        }

        private static List<Student> GetStudentsData()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Bugrahan",
                    LastName = "Ceker",
                    Department = new Department
                    {
                        DepartmentName = "Management Information Systems",
                    },
                    IdentityNumber = "6548431",
                    Age = 23,
                    PhoneNumber = "+905555555555",
                    IsMarried = false,
                    CityId = 2
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Merih",
                    LastName = "Demiral",
                    Department = new Department
                    {
                        DepartmentName = "Footballer",
                    },
                    IdentityNumber = "9845161",
                    Age = 26,
                    PhoneNumber = "+905951261",
                    IsMarried = true,
                    CityId = 3
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Polat",
                    LastName = "Alemdar",
                    Department = new Department
                    {
                        DepartmentName = "Mafia",
                    },
                    IdentityNumber = "897149",
                    Age = 32,
                    PhoneNumber = "+905018446",
                    IsMarried = false,
                    CityId = 1
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Batuhan",
                    LastName = "Ceker",
                    Department = new Department
                    {
                        DepartmentName = "Artist",
                    },
                    IdentityNumber = "109497",
                    Age = 20,
                    PhoneNumber = "+905920499",
                    IsMarried = false,
                    CityId = 5
                },
                new Student
                {
                    Id = 6,
                    FirstName = "Büşra",
                    LastName = "Küçüktaş",
                    Department = new Department
                    {
                        DepartmentName = "Teacher",
                    },
                    IdentityNumber = "598418",
                    Age = 28,
                    PhoneNumber = "+90982601",
                    IsMarried = true,
                    CityId = 2
                },
                new Student
                {
                    Id = 7,
                    FirstName = "Ezel",
                    LastName = "Bayraktar",
                    Age = 46,
                    Department = new Department
                    {
                        DepartmentName = "Business Man",
                    },
                    IdentityNumber = "565626",
                    PhoneNumber = "+90184141",
                    IsMarried = false,
                    CityId = 1
                },
                new Student
                {
                    Id = 8,
                    FirstName = "Micheal",
                    LastName = "Scofield",
                    Age = 39,
                    Department = new Department
                    {
                        DepartmentName = "Engineer",
                    },
                    IdentityNumber = "9049890",
                    PhoneNumber = "+1085731",
                    IsMarried = false,
                    CityId = 4
                },
                new Student
                {
                    Id = 9,
                    FirstName = "Engin",
                    LastName = "Demiroğ",
                    Age = 32,
                    Department = new Department
                    {
                        DepartmentName = "Software Engineer",
                    },
                    IdentityNumber = "201448",
                    PhoneNumber = "+901950175",
                    IsMarried = true,
                    CityId = 3
                }
            };

            return students;
        }

        private class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string IdentityNumber { get; set; }
            public Department Department { get; set; }
            public string PhoneNumber { get; set; }
            public short Age { get; set; }
            public bool IsMarried { get; set; }
            public short CityId { get; set; }
        }

        private class Department
        {
            public int Id { get; set; }
            public string DepartmentName { get; set; }
        }

        private class City
        {
            public short Id { get; set; }
            public string CityName { get; set; }
        }
    }
}