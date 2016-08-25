using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DomainModel;

namespace GenericWCFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Castle.Windsor.WindsorContainer Container { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeContainer();
        }

        private void InitializeContainer()
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:45688/MyService.svc");
            var myChannelFactory = new ChannelFactory<IEntityEditService<MyEntity>>(myBinding, myEndpoint);


            IEntityEditService<MyEntity> client = null;

            try
            {
                client = myChannelFactory.CreateChannel();
                MyEntity entity = new MyEntity();
                entity.Description = "Hello there";
                entity.Name = "Default";
                entity.Identifier = DateTime.Now.Ticks.ToString() ;
                client.Insert(entity);
                List<MyEntity> result = client.GetAll();
                if(result == null)
                {
                    throw new ArgumentNullException();
                }
                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort();
                }
            }

            var myBinding2 = new BasicHttpBinding();
            var myEndpoint2 = new EndpointAddress("http://localhost:45688/YourService.svc");
            var myChannelFactory2 = new ChannelFactory<IEntityEditService<YourEntity>>(myBinding2, myEndpoint2);
            IEntityEditService<YourEntity> client2 = null;

            try
            {
                client2 = myChannelFactory2.CreateChannel();
                List<YourEntity> result = client2.GetAll();
                if (result == null)
                {
                    throw new ArgumentNullException();
                }
                ((ICommunicationObject)client2).Close();
            }
            catch
            {
                if (client2 != null)
                {
                    ((ICommunicationObject)client2).Abort();
                }
            }


        }
    }
}
