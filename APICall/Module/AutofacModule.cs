using Autofac;
using APICall.Services; // Replace "APICall" with the actual namespace of your project where MyService is located
using APICall.Interfaces; // Replace "APICall" with the actual namespace of your project where IMyService is located

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register your services and dependencies here
        builder.RegisterType<MyService>().As<IMyService>();
    }
}
