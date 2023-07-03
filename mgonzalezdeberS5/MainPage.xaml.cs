using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mgonzalezdeberS5
{
    public partial class MainPage : ContentPage
    {
        //Variables globales para el url, cliente y donde almacenamos temporalmente
        private string url = "http://192.168.100.62/ws_PanFrances/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Usuario> post;


        public MainPage()
        {
            InitializeComponent();
            cargarDatos();
        }


        public async void cargarDatos()
        {
            var contenido = await cliente.GetStringAsync(url);
            List<Usuario> listaPost = JsonConvert.DeserializeObject<List<Usuario>>(contenido);
            post = new ObservableCollection<Usuario>(listaPost);
            listaUsuarios.ItemsSource = post;
        }
    }
}
