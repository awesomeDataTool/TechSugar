using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using NUnit.Framework;

namespace Unity_vs_MEF
{
    [TestFixture]
    public class MEFSamples
    {
        [Test]
        public void RegisterInstanceAndResolve()
        {
            ServiceAdd instanceOfService = new ServiceAdd();
            using (CompositionContainer mefContainer = new CompositionContainer())
            {
                mefContainer.ComposeExportedValue<IService>(instanceOfService);

                IService service = mefContainer.GetExportedValue<IService>();
                //IService service = mefContainer.GetExport<IService>().Value;
                Assert.That(service.Calc(1, 2), Is.EqualTo(3));
            }
        }
        [Test]
        public void RegisterTypeAndResolve()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new TypeCatalog(typeof(ServiceAdd)));
            using (CompositionContainer mefContainer = new CompositionContainer(catalog))
            {
                //IService service = mefContainer.GetExport<IService>().Value;
                IService service = mefContainer.GetExportedValue<IService>();
                Assert.That(service.Calc(1, 2), Is.EqualTo(3));
            }
        }
        [Test]
        public void RegisterInstancesAndResolveByName()
        {
            using (CompositionContainer mefContainer = new CompositionContainer())
            {
                mefContainer.ComposeExportedValue<IService>("add", new ServiceAdd());
                mefContainer.ComposeExportedValue<IService>("sub", new ServiceSub());

                IService serviceAdd = mefContainer.GetExportedValue<IService>("add");
                IService serviceSub = mefContainer.GetExportedValue<IService>("sub");
                Assert.That(serviceAdd.Calc(1, 2), Is.EqualTo(3));
                Assert.That(serviceSub.Calc(5, 2), Is.EqualTo(3));
            }
        }
        [Test]
        public void RegisterTypesAndResolveByName()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new TypeCatalog(typeof(ServiceAdd)));
            catalog.Catalogs.Add(new TypeCatalog(typeof(ServiceSub)));
            using (CompositionContainer mefContainer = new CompositionContainer(catalog))
            {
                //IService service = mefContainer.GetExport<IService>().Value;
                IService service = mefContainer.GetExportedValue<IService>("add");
                Assert.That(service.Calc(1, 2), Is.EqualTo(3));
            }
        }
        [Test]
        public void RegisterTypeAndResolveClassWithConstructor()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new TypeCatalog(typeof(ServiceAdd)));
            using (CompositionContainer mefContainer = new CompositionContainer(catalog))
            {
                Manager manager = mefContainer.GetExportedValue<Manager>();     // canbe created instance without registration?

                Assert.That(manager.Service.Calc(1, 2), Is.EqualTo(3));
                Assert.That(manager.Title, Is.EqualTo("title"));
            }
        }
    }
}