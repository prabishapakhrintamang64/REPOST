 using System;
    using System.Diagnostics;
    using System.Linq;
    using Models;
    namespace Application
    {
        class Data
        {
            public static void Main()
            {
                using var db = new EmployysContext();

                Console.WriteLine($"Database path : {db.Dbpath}");
                Console.WriteLine("Inserting All Employees");

                Employys employy = new Employys { EmployyId = 1, EmployyName = "momo nohara", DepartId = 10 };
                Employys employy1 = new Employys { EmployyId = 2, EmployyName = "rott wheiler", DepartId = 20 };
                Employys employy2 = new Employys { EmployyId = 3, EmployyName = "Ezaki Hikaru", DepartId = 30 };

                db.Add(employy);
                db.Add(employy1);
                db.Add(employy2);
                db.SaveChanges();

                List<Employys> allEmployy = db.Employys
                .OrderBy(E => E.EmployyName)
                .ToList();
                
                foreach (var Employee in allEmployy)
                {
                    Console.WriteLine($"EmployyId : {Employee.EmployyId},EmployyName : {Employee.EmployyName},DepartId : {Employee.DepartId}");
                }
              

                EmployysLeave employeeLeave = new EmployysLeave { LeaveId = 111, EmployyId = employy.EmployyId, NumOfDays = 2 };
                EmployysLeave employeeLeave1 = new EmployysLeave { LeaveId = 222, EmployyId = employy1.EmployyId, NumOfDays = 3 };
                EmployysLeave employeeLeave2 = new EmployysLeave { LeaveId = 333, EmployyId = employy2.EmployyId, NumOfDays = 1 };
 
                db.AddRange(employeeLeave, employeeLeave1, employeeLeave2);
                db.SaveChanges();

                Console.WriteLine($"Leave applied by {employy.EmployyName} for {employeeLeave.NumOfDays} days");
                Console.WriteLine($"Leave applied by {employy1.EmployyName} for {employeeLeave1.NumOfDays} days");
                Console.WriteLine($"Leave applied by {employy2.EmployyName} for {employeeLeave2.NumOfDays} days");

                EmployysLeave newleave= new EmployysLeave{LeaveId= 444,  EmployyId = employy1.EmployyId, NumOfDays=2};
                db.Add(newleave);
                db.SaveChanges();

                var TotalLeave= db.EmployysLeave
                .Where(l=>l.EmployyId ==employy1.EmployyId)
                .Sum(l=> l.NumOfDays);
                  
                Console.WriteLine($"TotalLeave applied by {employy1.EmployyName} is {TotalLeave} days");

               
                db.RemoveRange(employy, employy1, employy2);
                db.RemoveRange(employeeLeave, employeeLeave1, employeeLeave2, newleave);
                db.SaveChanges();
            }
        }
    }
