using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshingCourseConsole
{
    /*internal interface IServiceA
    {
        void Execute();
    }

    public class TypeAService : IServiceA
    {
        public void Execute()
        {
            Console.WriteLine("TypeAService.Execute()");
        }
    }

    class ServiceAClient
    {
        IServiceA _service;
        public void Start()
        {
            Console.WriteLine("ServiceAClient.Start()");
            _service.Execute();
        }
    }

    static class GenericServiceInjector
    {
        static Dictionary<object, object> _serviceContainer = new Dictionary<object, object>();

        public static void Add<T,U>() where U : IServiceA, new()
        {
            if (!_serviceContainer.ContainsKey(implementingType))
            {
                _serviceContainer.Add(interfaceType, implementingType);
            }
        }

        public static TInterface GetService<TInterface>()
        {
            try
            {
                var t = (TInterface)_serviceContainer[typeof(TInterface)];
                var obj = Activator.CreateInstance<TInterface>();
                return obj;
            }
            catch(Exception ex)
            {
                throw new Exception("Exception");
            }
        }
    }

    internal class DIP
    {
        internal static void Test()
        {
            //IServiceA service = new TypeAService();
            GenericServiceInjector.Add(typeof(IServiceA), typeof(TypeAService));
            var service = GenericServiceInjector.GetService<IServiceA>();   

            ServiceAClient client = new ServiceAClient(service);
            client.Start();
        }
    }*/
    internal class DIP
    {

    }
}
