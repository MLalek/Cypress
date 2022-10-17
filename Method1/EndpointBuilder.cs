using System.Text;

namespace Design_Patterns.Method1
{

    public class EndpointBuilder
    {
        private readonly StringBuilder sbUrl = new(); //en alttaki EndpointBuilder a (value) olarak ekledik
        private readonly StringBuilder sbParams = new();
        private const char defaultDelimeter = '/';    //delemetry ayrac belirleyelim
        
       
       public string BaseUrl { get; set; } 
        public EndpointBuilder (string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public EndpointBuilder Append (string value) // url den gelenleri burada olusturuyoruz
        {   
            //bu olusuyor
            //localhost/api/v1/user (bunlar route parameters)
            sbUrl.Append(value); //ekle bunu ve geri gonder
            sbUrl.Append(defaultDelimeter);
            return this;
        }

        //query string parameters
        //parametreleri ayri ve route lari (hemen) ayri tutmak icin
        public EndpointBuilder AppendParam(string name, string value)
        {
            //localhost/api/v1/user dan sonra ?[id=5] gelmesini saglayacagiz
            sbParams.AppendFormat("{0}={1}", name, value); 
            return this;
             
        }

        //toString gibi verileri isleyip geriye verecegimiz bir metod
        public string Build()
        {
            //baseUrl'in dolu olup olmadigini kontrol ediyoruz

            //bunlari istemeyiz cift // && gibi
            //1. slash kontrol
            if(BaseUrl.EndsWith(defaultDelimeter)) //eger baseurl / slashla bitiyorsa
            sbUrl.Insert(0, BaseUrl); // oldugu gibi birak (slash koyma)
            else 
            sbUrl.Insert(0, BaseUrl+ defaultDelimeter); // yoksa slash koy
            //2. & varsa kaldir
            var url = sbUrl.ToString().TrimEnd('&'); // TrimEnd metoduyla '&' leri kaldiriyoruz
            //Bu satirla birlikte olusan: localhost/api/v1/user
             
             


        }

    }
    
}