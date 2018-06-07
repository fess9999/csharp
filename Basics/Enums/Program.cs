using System;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceExample();
            //FlagsExample();

            Console.ReadLine();
        }

        private static void FlagsExample()
        {
            var userRight = AccessRightType.Create | AccessRightType.Update;

            Console.WriteLine(userRight.HasFlag(AccessRightType.Update));
            Console.WriteLine(userRight.HasFlag(AccessRightType.Delete));

            Console.WriteLine((int) userRight);
        }

        private static void ServiceExample()
        {
            var serviceStatus = ServiceStatus.Stopped;
            HandleServiceStatus(serviceStatus);

            serviceStatus = ServiceStatus.Running;
            HandleServiceStatus(serviceStatus);
            Console.WriteLine($"{serviceStatus} {(int) serviceStatus}");

            var enumType = typeof(ServiceStatus);

            Console.WriteLine(Enum.GetUnderlyingType(enumType));
            PrintArray(Enum.GetValues(enumType));
            PrintArray(Enum.GetNames(enumType));
            Console.WriteLine(Enum.GetName(enumType, 3));
            Console.WriteLine(Enum.Parse(enumType, "Running"));

            Console.WriteLine(Enum.ToObject(enumType, 0));
            Console.WriteLine((ServiceStatus) 0);
        }

        private static void PrintArray(Array array)
        {
            foreach (var o in array)
                Console.Write($"{o} ");
            Console.WriteLine();
        }

        static void HandleServiceStatus(ServiceStatus status)
        {
            switch (status)
            {
                case ServiceStatus.Stopped:
                    Console.WriteLine("Service is now stopped");
                    break;
                case ServiceStatus.Running:
                    Console.WriteLine("Service is running now");
                    break;
                case ServiceStatus.Stopping:
                    Console.WriteLine("Service is being stopped now");
                    break;
                case ServiceStatus.Disabled:
                    Console.WriteLine("Service has been disabled. Please contact the support");
                    break;
            }
        }

        private enum ServiceStatus
        {
            Stopped,    //=0
            Running,    //=1
            Stopping,   //=2
            Disabled    //=3
        }

        [Flags]
        private enum AccessRightType : byte
        {
            None = 0,
            Read = 1,
            Create = 2,
            Update = 4,
            Delete = 8
        }
    }
}
