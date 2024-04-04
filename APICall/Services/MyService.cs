using APICall.Interfaces; // Assuming your interface is in a namespace called APICall.Interfaces

namespace APICall.Services
{
    public class MyService : IMyService
    {
        public string GetMessage()
        {
            return "Hello from MyService!";
        }
    }
}
