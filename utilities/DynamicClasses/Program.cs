using System;
using System.Reflection;

namespace DynamicCreateInstanceofclass
{
    class Program
    {
        static void Main(string[] args)
        {
            string spaceName = "DynamicCreateInstanceofclass";
            string exeName = "DynamicClasses.dll";
            string className = "UserDetails";

            User UR = CreateInstance<IUserDetails>(exeName, spaceName, className).GetUserDetails();

            Console.WriteLine("User ID:" + UR.ID);
            Console.WriteLine("User Name:" + UR.Name);

            Console.WriteLine("Press Key to exit");
            Console.ReadLine();
        }
        public static I CreateInstance<I>(string exeName, string spaceName, string className) where I : class
        {
            string assemblyPath = Environment.CurrentDirectory + "\\" + exeName;

            Assembly assembly;

            assembly = Assembly.LoadFrom(assemblyPath);
            Type type = assembly.GetType(spaceName + "." + className);
            return Activator.CreateInstance(type) as I;
        }
    }
    public class UserDetails : IUserDetails
    {
        public User GetUserDetails()
        {
            User UR = new User();
            UR.ID = 1;
            UR.Name = "Kailash";
            return UR;
        }
    }
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    interface IUserDetails
    {
        User GetUserDetails();
    }
}