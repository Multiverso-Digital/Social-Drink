using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;
using System.IO.IsolatedStorage;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using System.Windows.Media.Imaging;
using System.Collections;
using Microsoft.Phone.Info;

using Microsoft.Phone.Marketplace;
using Spring.Rest.Client;
using System.Threading;



namespace Social_Drink
{
    
    
    
    
    public partial class App : Application
    {

        public static byte[] byteArray0;

        private static LicenseInformation _licenseInfo = new LicenseInformation();


        public static string CatSel { get; set; }
        public static string CatCod { get; set; }
        public static string LocID { get; set; }
        public static string LocIDGoogle { get; set; }
        public static string LocName { get; set; }
        public static string LocAddress { get; set; }
        public static string LocCity { get; set; }
        public static string LocPais { get; set; }
        public static string LocLat { get; set; }
        public static string LocLon { get; set; }
        public static string LocUF { get; set; }
        public static string LocCEP { get; set; }
        public static string LocFone { get; set; }
        public static string LocRefe { get; set; }
        public static string LocIcon { get; set; }
        public static string LocImg { get; set; }
        public static string LocLatG { get; set; }
        public static string LocLonG { get; set; }
        public static string LocTipo { get; set; }
        public static string LocDist { get; set; }


        public static string LocFotoFileName0 { get; set; }
        public static string LocFotoFileName1 { get; set; }
        public static string LocFotoFileName2 { get; set; }
        public static string LocFotoFileName3 { get; set; }
        public static string LocFilme { get; set; }
        public static int    LocIDAlbum { get; set; }
        public static int quem { get; set; }


        public static string LocLatMap { get; set; }
        public static string LocLonMap { get; set; }
        public static string LocNomMap { get; set; }


        public static string Localoutro { get; set; }


        public static bool SaiEnvia { get; set; }
        public static bool achouNome { get; set; }

        
        
        
        
        public static bool Confirmou { get; set; }
        public static bool TrialCancel { get; set; }
        public static bool adicionou { get; set; }


        public static string Checkin { get; set; }

        
        /*
        public static string UserID { get; set; }
        public static string UserToken { get; set; }
        public static string UserEmail { get; set; }
        public static string UserName { get; set; }
        public static string UserPass { get; set; }
        public static string UserKeep { get; set; }
        */


        public static int UserTotCheckIn { get; set; }
        public static int UserTotDrinks { get; set; }
        public static string bebida { get; set; }
        public static string marca { get; set; }
        public static double sangue { get; set; }

        public static bool Passou { get; set; }
        public static string FBMens { get; set; }
        public static string FBUrl { get; set; }
        public static bool NaoSoma { get; set; }
        public static bool addUser { get; set; }
 
        public static string img { get; set; }
        public static string img_emp { get; set; }
        
        public static bool GravouUsu { get; set; }
        public static bool PassouMarca { get; set; }
        public static bool PassouBebidas { get; set; }
        public static bool PassouDoses { get; set; }
        public static bool PassouFotoPlace { get; set; }
        public static string LinkFoto { get; set; }
        public static string TWMens { get; set; }
        public static Stream SelImg { get; set; }
        public static int MostraGoogle { get; set; }
        public static double LatSat { get; set; }
        public static double LonSat { get; set; }
        public static bool Clicou { get; set; }
       
        public static Image ImgBebiClicada { get; set; }
        public static Image ImgTela { get; set; }


        public static int shots { get; set; }
        public static double dose { get; set; }
    
    
        public static double latitude = 0;
        public static double longitude = 0;
        public static int achouLoc = 0;

        public static string Filme_Title { get; set; }
        public static string Filme_VideoImageUrl { get; set; }
        public static string Filme_VideoId { get; set; }
        public static int Filme_Tipo { get; set; }
        public static string CameraAlbum { get; set; }
        public static string CameraAlbumPhoto { get; set; }

        public static string FBAlbum { get; set; }
        public static string FBAlbumPhoto { get; set; }
        public static int passa_param { get; set; }
        public static bool PegouFoto { get; set; }

        

        IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();

        public static string LatCel { get; set; }
        public static string LonCel { get; set; }
        public static int wHorizontal { get; set; }
        public static int wRadius { get; set; }
        public static int Aceito { get; set; }
        public static bool som { get; set; }
        public static bool aviso { get; set; }
        public static bool net { get; set; }


       
        public static GeoCoordinate LocCel { get; set; } //local do celular




        public class OMarcas
        {
            public string Bebida { get; set; }
            public string img { get; set; }
            public string Nome { get; set; }

        }

        public static List<OMarcas> LOutras = new List<OMarcas>();
        public static List<OMarcas> LDelete = new List<OMarcas>();

        public class Bebidas
        {
            public string Nome { get; set; }
            public string img { get; set; }
            public double dose_ml { get; set; }
            public string garrafa { get; set; }
            public ImageSource img_garrafa { get; set; }
            public ImageSource img_copo { get; set; }
            public double teor { get; set; }
            



        }


        public class Marcas
        {
            public string Nome { get; set; }
            public string img { get; set; }
        }

        public static List<Marcas> ListaMarcas = new List<Marcas>();
        public static List<Marcas> ListaDelete = new List<Marcas>();

        public class LocaisShots
        {
            public string Nome { get; set; }
            public string ID { get; set; }
            public List<Shot> LShot { get; set; }
        }

     public static List<LocaisShots> ListaShotsLoc = new List<LocaisShots>();

        public static List<Bebidas> ListaBebidas = new List<Bebidas>();


        public class configuracao
        {
            public int GoogleRadius { get; set; }
            public int HorizontalAjuste { get; set; }
            public string EmailUsu { get; set; }
            public int Aceito { get; set; }
            public string NomeUsu { get; set; }
            public string NumCel { get; set; }
            public string Destino { get; set; }
            public bool NET { get; set; }
            public bool SOM { get; set; }
            public bool AVISO { get; set; }
            public string DeviceNome { get; set; }
            public string DeviceID { get; set; }
            public string Senha { get; set; }
            public string UserToken { get; set; }
            public string Idioma { get; set; }
            public bool Gravou_no_Server { get; set; }
            public string UserID { get; set; }
            public string FB_UserID { get; set; }
            public string FB_Token { get; set; }
            public string FB_Picture { get; set; }
            public int conta_trial { get; set; }



        }

        public static List<configuracao> Conf = new List<configuracao>();

        public class locais
        {
            public string name { get; set; }
            public string address { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string idlocal { get; set; }
            public string reference { get; set; }
            public string icon { get; set; }
            public string tipo { get; set; }
            public string img { get; set; }
            public string pais { get; set; }
            public string cida { get; set; }
            public double distancia { get; set; }
            public string distStr { get; set; }
            public int quem { get; set; } //1=FS    2=Google,  3=Nokia
            public string imgrat { get; set; }
            public double rating { get; set; }
            
            
        }

        public static List<locais> LocaisGoogle   = new List<locais>();
        public static List<locais> LocaisUsu = new List<locais>();
     //   public static List<locais> LocaisTaxi = new List<locais>();





      


        public class Shot
        {
            public string idlocal { get; set; }
            public string datahoje { get; set; }
            public string bebida { get; set; }
            public string marca { get; set; }
            public string local { get; set; }
            public string horahoje { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public int shots { get; set; }
            public double ml { get; set; }
            public int tag { get; set; }
            public string pais { get; set; }
            public string cida { get; set; }
            public int gravou { get; set; }
         



        }



        public static List<Shot> ListaShot = new List<Shot>();







        public class checkin
        {
            public string idlocal { get; set; }
            public string name { get; set; }
            public string data { get; set; }
            public string hora { get; set; }
            public string img { get; set; }
            public string share { get; set; }
            
        }
        public static List<checkin> CheckinUsu = new List<checkin>();

        public class medalhas
        {
            
            public string tipo { get; set; }  //QRCODE
            public string cod { get; set; }   //Codigo
            public string locname { get; set; }
            public string data { get; set; }
            public int spin { get; set; }
            public int pontos { get; set; }
            public string email { get; set; }           
            public string promoname { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string img { get; set; }
            public string pais { get; set; }
            public string cida { get; set; }
            
        }
        public static List<medalhas> ListaMedalhas = new List<medalhas>();



        public class qrpromocao
        {
            public string datahoje { get; set; }
            public string horahoje { get; set; }
            public string local { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string qr_linha01 { get; set; }//Nome promoção
            public string qr_linha02 { get; set; }//Extensão promoção
            public string qr_linha03 { get; set; }//codigo secreto
            public string qr_linha04 { get; set; } //premio
            public int ganhou { get; set; } //premio

        }
        public static List<qrpromocao> QRPromocao = new List<qrpromocao>();



        public class Filmes
        {
            public int codigo { get; set; }
            public string datini { get; set; }
            public string datfim { get; set; }
            public string idioma { get; set; }
            public string lati { get; set; }
            public string longi { get; set; }
            public string raio { get; set; }
            public string URI { get; set; }
            public int ativo { get; set; }
        }

        public static List<Filmes> ListaFilmes = new List<Filmes>();






        public class Frases
        {
            public int codigo { get; set; }
            public string datini { get; set; }
            public string datfim { get; set; }
            public string idioma { get; set; }
            public double valini { get; set; }
            public double valfim { get; set; }
            public string bebida { get; set; }
            public string marca { get; set; }
            public string texto { get; set; }
            public int ativo { get; set; }
        }

        public static List<Frases> ListaFrases = new List<Frases>();






       // public static List<MyGeoObject> pins = new List<MyGeoObject>();



        public class RssLandMark
        {
            public string name { get; set; }
            public string address { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string icon { get; set; }
            public string reference { get; set; }
            public string id { get; set; }

        }

        public static Array LandMarkPositionArray = Array.CreateInstance(typeof(RssLandMark), 200);
        public static Array LandMarkPositionArraySalva = Array.CreateInstance(typeof(RssLandMark), 200);





























        public static RootObject ResultFS { get; set; }
        public static RootObjectGoogle ResultGoogle { get; set; }
        public static RootObjectNokia ResultNokia { get; set; }
        public static RootObjectFSSug ResultFsSug { get; set; }



        public class Cat
        {
            public string categoria { get; set; }
        }

        public static List<Cat> ListaCat = new List<Cat>();






        public class objetoTipsToDo
        {
            public string count { get; set; }

        }



        public class objetoTipsGroups
        {
            public string type { get; set; }
            public int count { get; set; }
            public List<objetoUser> items { get; set; }
            public string summary { get; set; }

        }



        public class objetoTipsLikes
        {
            public string count { get; set; }
            public List<objetoTipsGroups> groups { get; set; }
            public string summary { get; set; }

        }



        public class objetoTipsDet
        {
            public string id { get; set; }
            public string createdAt { get; set; }
            public string text { get; set; }
            public objetoTipsLikes likes { get; set; }
            public bool like { get; set; }
            public objetoTipsToDo todo { get; set; }
            public objetoUser user { get; set; }
        }

        public class objetoTips
        {
            public string type { get; set; }
            public string name { get; set; }
            public int count { get; set; }
            public List<objetoTipsDet> items { get; set; }
        }

        public class PhotoItem
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }



        public class objetoUser
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public PhotoItem photo { get; set; }
        }


        public class Source
        {
            public string name { get; set; }
            public string url { get; set; }


        }




        public class objetoItems
        {
            public string id { get; set; }
            public string createdAt { get; set; }
            public Source source { get; set; }
            public string prefix { get; set; }
            public string suffix { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public objetoUser user { get; set; }
            public string visibility { get; set; }

        }





        public class objectPhotos
        {
            public string type { get; set; }
            public string name { get; set; }
            public int count { get; set; }
            public List<objetoItems> items { get; set; }
        }



        public class Meta
        {
            public int code { get; set; }
        }

        public class Contact
        {
            public string phone { get; set; }
            public string formattedPhone { get; set; }
            public string twitter { get; set; }
        }

        public class Location
        {
            public string address { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public int distance { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string cc { get; set; }
            public string postalCode { get; set; }
            public string crossStreet { get; set; }
        }

        public class Stats
        {
            public int checkinsCount { get; set; }
            public int usersCount { get; set; }
            public int tipCount { get; set; }
        }

        public class Prices
        {
            public int tier { get; set; }
            public string message { get; set; }
        }



        public class Likes
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
            //     public string summary { get; set; }
        }

        public class Menu
        {
            public string type { get; set; }
            public string url { get; set; }
            public string mobileUrl { get; set; }
        }

        public class Hours
        {
            public string status { get; set; }
            public bool isOpen { get; set; }
            public List<object> timeframes { get; set; }
        }


        public class objectEspecial
        {
            public string message { get; set; }
            public string description { get; set; }
            public string finePrint { get; set; }
            public string icon { get; set; }


        }



        public class Specials
        {
            public int count { get; set; }
            public List<objectEspecial> items { get; set; }
        }



        public class Photos
        {
            public int count { get; set; }
            public List<objectPhotos> groups { get; set; }
        }





        public class HereNow
        {
            public int count { get; set; }
            public string summary { get; set; }
            public List<object> groups { get; set; }
        }


        public class Reasons
        {
            public int count { get; set; }
            public List<object> items { get; set; }
        }





        public class Mayor
        {
            public int count { get; set; }
            public objetoUser user { get; set; }
        }

        public class Tips
        {
            public int count { get; set; }
            public List<objetoTips> groups { get; set; }
        }



        public class Venue
        {
            public string id { get; set; }
            public string name { get; set; }
            public Contact contact { get; set; }
            public Location location { get; set; }
            public List<Categories> categories { get; set; }
            public bool verified { get; set; }
            public Stats stats { get; set; }
            //   public string url { get; set; }
            //   public Prices price { get; set; }
            public Likes likes { get; set; }
            public bool like { get; set; }
            public bool dislike { get; set; }
            public double rating { get; set; }
            //    public Menu menu { get; set; }
            //    public Hours hours { get; set; }
            public Specials specials { get; set; }
            public Photos photos { get; set; }
            public HereNow hereNow { get; set; }
            public Reasons reasons { get; set; }
            public string createdAt { get; set; }
            public Mayor mayor { get; set; }
            public Tips tips { get; set; }
            //     public string referralId { get; set; }
        }



        public class RootObjectFS
        {
            public MetaFS meta { get; set; }
            public ResponseFS response { get; set; }
        }

        public class MetaFS
        {
            public int code { get; set; }
        }

        public class ResponseFS
        {
            public objectPhotosFS photos { get; set; }
        }
        public class objectPhotosFS
        {
            public int count { get; set; }
            public List<objetoItems> items { get; set; }
        }



        public class RootObjectFSTips
        {
            public MetaFSTips meta { get; set; }
            public ResponseFSTips response { get; set; }
        }

        public class MetaFSTips
        {
            public int code { get; set; }
        }

        public class ResponseFSTips
        {
            public objetoTipsFS tips { get; set; }
        }


        public class objetoTipsFS
        {
            public int count { get; set; }
            public List<objetoTipsDet> items { get; set; }
        }










        public class Response
        {
            public Venue venue { get; set; }
        }

        public class RootObject
        {
            public Meta meta { get; set; }
            public Response response { get; set; }
        }


        public class PhotosG
        {
            public string photo_reference { get; set; }
        }



        public class AspectsG
        {
            public string rating { get; set; }
            public string type { get; set; }

        }



        public class ReviewsG
        {
            public List<AspectsG> aspects { get; set; }
            public string author_name { get; set; }
            public string author_url { get; set; }
            public string text { get; set; }
            public string time { get; set; }
        }



        public class ResultG
        {
            public string formatted_address { get; set; }
            public string formatted_phone_number { get; set; }
            public List<PhotosG> photos { get; set; }
            public List<ReviewsG> reviews { get; set; }
        }





        public class RootObjectGoogle
        {
            public ResultG result { get; set; }
        }

        public class RootObjectNokia
        {
            public string name { get; set; }
            public string placeId { get; set; }
            public string view { get; set; }
            public List<object> alternativeNames { get; set; }
            //  public LocationN location { get; set; }
            public ContactsN contacts { get; set; }
            public MediaN media { get; set; }
        }



        public class LocationN
        {
            public Array position { get; set; }
            public Address address { get; set; }
        }









        public class ContactsN
        {
            public List<PhoneN> phone { get; set; }

        }
        public class PhoneN
        {
            public string value { get; set; }
            public string label { get; set; }
        }

        public class MediaN
        {
            public ImagesN images { get; set; }
            public ReviewN reviews { get; set; }
        }

        public class ImagesN
        {
            public List<ItemsN> items { get; set; }
        }

        public class ReviewN
        {
            public List<ItemsRN> items { get; set; }
        }





        public class ItemsN
        {
            public string src { get; set; }
            public SupplierN supplier { get; set; }

        }

        public class ItemsRN
        {
            public string date { get; set; }
            public string title { get; set; }
            public string rating { get; set; }
            public string description { get; set; }
            public UserN user { get; set; }
            public SupplierN supplier { get; set; }
        }

        public class UserN
        {
            public string name { get; set; }
        }


        public class SupplierN
        {
            public string title { get; set; }
            public string icon { get; set; }

        }
        public class Categories
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
        }


        public class Icon
        {
            public string prefix { get; set; }
            public string mapPrefix { get; set; }
            public string suffix { get; set; }
        }




        public class ResponseFSSug
        {
            // public string headerMessage { get; set; }
            public List<GroupFSSug> groups { get; set; }
        }

        public class GroupFSSug
        {
            public List<GroupItemsFSSug> items { get; set; }

        }

        public class GroupItemsFSSug
        {
            //   public ReasonsFSSug reasons { get; set; }
            public VenueFSSug venue { get; set; }
            public List<TipsFSSug> tips { get; set; }
            //   public List<PhrasesFSSug> phrases { get; set; }

        }

        public class ReasonsFSSug
        {
            public List<ReasonItemsFSSug> items { get; set; }
        }

        public class ReasonItemsFSSug
        {
            public string summary { get; set; }
        }



        public class PhrasesFSSug
        {
            public string phrase { get; set; }
            public SampleFSSug sample { get; set; }
        }

        public class SampleFSSug
        {
            public string text { get; set; }

        }


        public class TipsFSSug
        {
            public string id { get; set; }
            public string createdAt { get; set; }
            public string text { get; set; }
            //  public objetoTipsLikes likes { get; set; }
            //  public bool like { get; set; }
            //  public objetoTipsToDo todo { get; set; }
            // public objetoUserFSSug user { get; set; }
        }




        public class objetoUserFSSug
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string photo { get; set; }
        }






        public class VenueFSSug
        {
            public string id { get; set; }
            public string name { get; set; }
            public Contact contact { get; set; }
            public LocationFSSug location { get; set; }
            public List<CategoriesFSSug> categories { get; set; }
            public bool verified { get; set; }
            public StatsFSSug stats { get; set; }
            public LikesFSSug likes { get; set; }
            //   public double rating { get; set; }
            //   public bool like { get; set; }
            //   public bool dislike { get; set; }
            public double rating { get; set; }
            public SpecialsFSSug specials { get; set; }
            public PhotosFSSug photos { get; set; }

        }








        public class objetoItemsFSSug
        {
            public string id { get; set; }
            public string createdAt { get; set; }
            public string url { get; set; }

            /*
            public string prefix { get; set; }
            public string suffix { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public objetoUser user { get; set; }
            public string visibility { get; set; }
             */

        }




        public class objectPhotosFSSug
        {
            public string type { get; set; }
            public string name { get; set; }
            public int count { get; set; }
            public List<objetoItemsFSSug> items { get; set; }
        }



        public class PhotosFSSug
        {
            public int count { get; set; }
            public List<objectPhotosFSSug> groups { get; set; }
        }



        public class SpecialsFSSug
        {
            public int count { get; set; }
            public List<Object> items { get; set; }
        }



        public class LikesFSSug
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
            //     public string summary { get; set; }
        }



        public class StatsFSSug
        {
            public int checkinsCount { get; set; }
            public int usersCount { get; set; }
            public int tipCount { get; set; }
        }


        public class LocationFSSug
        {
            public string address { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public int distance { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string cc { get; set; }

        }




        public class CategoriesFSSug
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public IconFSSug icon { get; set; }
            public bool primary { get; set; }
        }

        public class IconFSSug
        {
            public string prefix { get; set; }
            //  public string mapPrefix { get; set; }
            public string name { get; set; }
        }



        public class RootObjectFSSug
        {
            public Meta meta { get; set; }
            public ResponseFSSug response { get; set; }
        }


















        private static bool _isTrial = true;
        public bool IsTrial
        {
            get
            {
                return _isTrial;
            }
        }

        /// <summary>
        /// Check the current license information for this application
        /// </summary>
        private void CheckLicense()
        {
            // When debugging, we want to simulate a trial mode experience. The following conditional allows us to set the _isTrial 
            // property to simulate trial mode being on or off. 
#if DEBUG
            string message = "This sample demonstrates the implementation of a trial mode in an application." +
                               "Press 'OK' to simulate trial mode. Press 'Cancel' to run the application in normal mode.";
            if (MessageBox.Show(message, "Debug Trial",
                 MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                _isTrial = true;
            }
            else
            {
                _isTrial = false;
            }
#else
            _isTrial = _licenseInfo.IsTrial();
#endif
        }


        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();
                                    
            // Phone-specific initialization
            InitializePhoneApplication();
            this.OverrideColorsViaCode();



            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;



            if (originalCulture.Name.Substring(0, 2) == "es")
            {


                try
                {
                    CultureInfo newCulture = new CultureInfo("es-ES");
                    Thread.CurrentThread.CurrentCulture = newCulture;
                    Thread.CurrentThread.CurrentUICulture = newCulture;

                }
                catch
                {
                    //Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
                }
                finally
                {
                    //Thread.CurrentThread.CurrentCulture = originalCulture;
                    //Thread.CurrentThread.CurrentUICulture = originalCulture;
                }


            }




            if (originalCulture.Name.Substring(0, 2) == "en")
            {


                try
                {
                    CultureInfo newCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentCulture = newCulture;
                    Thread.CurrentThread.CurrentUICulture = newCulture;

                }
                catch
                {
                    //Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
                }
                finally
                {
                    //Thread.CurrentThread.CurrentCulture = originalCulture;
                    //Thread.CurrentThread.CurrentUICulture = originalCulture;
                }


            }







            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }


        private void OverrideColorsViaCode() 
        {
            (App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color = Colors.White;  
            (App.Current.Resources["PhoneForegroundBrush"] as SolidColorBrush).Color = Colors.White;
            //(App.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush).Color = Colors.Transparent;
        }



        public static void pegaimg(string bebidax)
        {
            try
            {
                Bebidas agedTwenty = ListaBebidas.Where<Bebidas>(x => x.Nome == bebidax).Single<Bebidas>();
                App.img = agedTwenty.img;
            }
            catch
            {
                App.img = "images/outros01.png";
            }
        }

        
        /*
        
        public static void pegaimg_emp(string ID)
        {

            try
            {


                CatViewModel foto = Categorias.Where<CatViewModel>(x => x.ID == ID).Single<CatViewModel>();



                img_emp = foto.img;

            }
            catch
            {
                img_emp = "images/G_establishment.png";
            }
        }
        */


        public static void zeraMapa()
        {
            for (int i = 0; i <= LandMarkPositionArray.Length-1; i++)
            {


                LandMarkPositionArray.SetValue(new RssLandMark() { name = null, address = null, longitude = null, latitude = null, icon = null, reference = null, id = null }, i);

            }
        }

        public static void zeraMapaSalva()
        {
            for (int i = 0; i <= LandMarkPositionArraySalva.Length - 1; i++)
            {


                LandMarkPositionArraySalva.SetValue(new RssLandMark() { name = null, address = null, longitude = null, latitude = null, icon = null, reference = null, id = null }, i);

            }
        }


        public static void achaNome(string nome)
        {
            achouNome = false;

            for (int i = 0; i < App.LandMarkPositionArray.Length; i++)
            {


                App.RssLandMark st = App.LandMarkPositionArray.GetValue(i) as App.RssLandMark;

                if (st != null)
                {

                    if (st.name != null)
                    {

                        if (st.name == nome)
                        {

                            achouNome = true;
                        }



                    }
                }
            }

           

        }











        public static void Retira_da_Lista()
        {

            /*


            for (int i = 0; i <= App.ListaFrases.Count - 1; i++)
            {
                DateTime monta = Convert.ToDateTime(App.ListaFrases[i].datfim);
                float diferenca = DateTime.Compare(DateTime.Today, monta);

                if ((diferenca > 0) || (App.ListaFrases[i].ativo == 0))
                {
                    App.ListaFrases.RemoveAt(i);
                }
            }


            for (int i = 0; i <= App.ListaFilmes.Count - 1; i++)
            {
                DateTime monta = Convert.ToDateTime(App.ListaFilmes[i].datfim);
                float diferenca = DateTime.Compare(DateTime.Today, monta);

                if ((diferenca > 0) || (App.ListaFilmes[i].ativo == 0))
                {
                    App.ListaFilmes.RemoveAt(i);
                }
            }

            */


        }



         public static void SomaShots(string ID, string Local, string Bebida, string Marca, double mlx, int TAG)
        {

            string data = DateTime.Today.ToString("MM/dd/yyyy");
            string hora = DateTime.Now.ToString("HH:mm:ss"); 
             
             var record =
                (from x in ListaShot
                 where x.idlocal == ID && x.datahoje == data && x.bebida == Bebida && x.marca == Marca
                 select x).SingleOrDefault();

                if (record != null)
                {
                    record.ml = record.ml + mlx;
                    record.shots = record.shots + 1;
 
                }
                else
                {
                    ListaShot.Add(new Shot() { idlocal=ID, datahoje = data, horahoje = hora, bebida = Bebida, marca = Marca, latitude = App.LocLat, longitude = App.LocLon, local = Local, ml = mlx, shots = 1, tag = TAG, gravou = 0, pais = App.LocPais,  cida = App.LocCity});
                }
        }




        public static void AdicionaLocal()
         {
            

             string data = DateTime.Today.ToString("MM/dd/yyyy");
             string hora = DateTime.Now.ToString("HH:mm:ss");

             var record =
                (from x in LocaisUsu
                 where x.idlocal == App.LocID
                 select x).SingleOrDefault();

             if (record == null)
             {

                 LocaisUsu.Add(new locais() { idlocal = App.LocID, name = App.LocName, address = App.LocAddress, cida = App.LocCity, pais = App.LocPais, icon = App.LocIcon, img = App.LocImg, latitude = "0", longitude = "0", reference = App.LocRefe, tipo = App.LocTipo, distStr = App.LocDist });
             }    





         }


/*

        public static void ZeraShot()
        {
            ListaShot.Clear();

            for (int i = 0; i <= 21; i++)
            {
            }
        }



        public static void procura(string ID)
        {

            achouLoc = 0;

            foreach(LocaisShots x in ListaShotsLoc)
            {
                if (x.ID == ID) {
                    achouLoc = 1; 
                }
            }

        }






        public static void PoeShots(string ID, string Nome)
        {

            
            procura(ID);


            if (achouLoc == 1)
            {

 
                LocaisShots acha = ListaShotsLoc.Where<LocaisShots>(x => x.ID == ID).Single<LocaisShots>();
                ListaShot = acha.LShot.ToList();

            }
            else
            {
                ZeraShot();
            }






        }






        public static void PoeLocalShots(string ID, string Nome)
        {
          
            procura(ID);
            if (achouLoc == 0)
            {
                ListaShotsLoc.Add(new LocaisShots() { ID = ID, Nome = Nome, LShot = ListaShot.ToList() });
            }
            else
            {
                LocaisShots acha = ListaShotsLoc.Where<LocaisShots>(x => x.ID == ID).Single<LocaisShots>();
                acha.LShot = ListaShot.ToList();
            }


        }



        */










        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");


          
          














            
            Application.Current.Host.Settings.EnableFrameRateCounter = false;

            //CheckLicense();
            MyToolkit.Networking.NetworkStateTracker.Start();


/*



            if (store.FileExists("configuracao.xml"))
            {
                Conf = GravaIS.IsolatedStorageCacheManager<List<configuracao>>.Retrieve("configuracao.xml");
                wRadius = Conf[0].GoogleRadius;
                wHorizontal = Conf[0].HorizontalAjuste;
                Aceito = Conf[0].Aceito;
                som = Conf[0].SOM;
                aviso = Conf[0].AVISO;
                net = Conf[0].NET;
            }
            else
            {
                wRadius = 500;
                wHorizontal = 500;
                Conf.Add(new configuracao() { GoogleRadius = 500, HorizontalAjuste = 500, AVISO = false, SOM = true, NET = true, Aceito = 9, conta_trial = 0 });
                byte[] uniqueId = (byte[])DeviceExtendedProperties.GetValue("DeviceUniqueId");
                Conf[0].DeviceID = BitConverter.ToString(uniqueId);
                Conf[0].Gravou_no_Server = false;
            }




            Conf[0].Idioma = CultureInfo.CurrentCulture.Name;
            Conf[0].DeviceNome = Microsoft.Phone.Info.DeviceStatus.DeviceName.ToString();
            Conf[0].NET = true;



            Conf[0].NET = true;


           



            if (store.FileExists("medalhas.xml"))
            {
                ListaMedalhas = GravaIS.IsolatedStorageCacheManager<List<medalhas>>.Retrieve("medalhas.xml");
            }




            if (store.FileExists("omarcas.xml"))
            {
                LOutras = GravaIS.IsolatedStorageCacheManager<List<OMarcas>>.Retrieve("omarcas.xml");
            }

            if (store.FileExists("dmarcas.xml"))
            {
                LDelete = GravaIS.IsolatedStorageCacheManager<List<OMarcas>>.Retrieve("dmarcas.xml");
            }



            if (store.FileExists("shots.xml"))
            {
                ListaShot = GravaIS.IsolatedStorageCacheManager<List<Shot>>.Retrieve("shots.xml");
            }


            if (store.FileExists("qrcode.xml"))
            {
                QRPromocao = GravaIS.IsolatedStorageCacheManager<List<qrpromocao>>.Retrieve("qrcode.xml");
            }




            if (store.FileExists("locaisusu.xml"))
            {
                LocaisUsu = GravaIS.IsolatedStorageCacheManager<List<locais>>.Retrieve("locaisusu.xml");
            }


            */






            /*

            if (store.FileExists("frases.xml"))
            {
                ListaFrases = GravaIS.IsolatedStorageCacheManager<List<Frases>>.Retrieve("frases.xml");
            }
            else
            {
 
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 10, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.0, valfim = 0.019, texto = "Um pouco tonto" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 11, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.019, valfim = 0.04, texto = "Aconchegante e descontraído" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 12, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.04, valfim = 0.09, texto = "Falta de coordenação (legalmente bêbado)" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 13, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.09, valfim = 0.014, texto = "Possível apagão(perda de memória)" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 14, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.14, valfim = 0.19, texto = "Se sente confuso e atordoado" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 15, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.19, valfim = 0.24, texto = "Emocionalmente e fisicamente entorpecido" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 16, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.24, valfim = 0.29, texto = "Pode estar bêbado!" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 17, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.29, valfim = 0.34, texto = "Provavelmente entrará em coma" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 18, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", valini = 0.34, valfim = 9.99, texto = "Chame um Taxi!" });

                ListaFrases.Add(new Frases() { ativo = 1, codigo = 19, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.0, valfim = 0.019, texto = "Little lightheaded" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 20, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.019, valfim = 0.04, texto = "Warm and relaxed" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 21, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.04, valfim = 0.09, texto = "Lack of coordination and balance (legally drunk)" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 22, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.09, valfim = 0.014, texto = "Possible blackout (memory loss)" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 23, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.14, valfim = 0.19, texto = "Feel confused, dazed, or otherwise disoriented" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 24, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.19, valfim = 0.24, texto = "Emotionally and physically numb" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 25, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.24, valfim = 0.29, texto = "In a drunken stupor" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 26, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.29, valfim = 0.34, texto = "Probably in a coma" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 27, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", valini = 0.34, valfim = 9.99, texto = "Call a Taxi!" });         


                ListaFrases.Add(new Frases() { ativo = 1, codigo = 1, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.0, valfim = 0.019, texto = "Little lightheaded" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 2, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.019, valfim = 0.04, texto = "Warm and relaxed" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 3, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.04, valfim = 0.09, texto = "Lack of coordination and balance (legally drunk)" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 4, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.09, valfim = 0.014, texto = "Possible blackout (memory loss)" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 5, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.14, valfim = 0.19, texto = "Feel confused, dazed, or otherwise disoriented" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 6, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.19, valfim = 0.24, texto = "Emotionally and physically numb" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 7, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.24, valfim = 0.29, texto = "In a drunken stupor" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 8, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.29, valfim = 0.34, texto = "Probably in a coma" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 9, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", valini = 0.34, valfim = 9.99, texto = "Call a Taxi!" });         
                 
              
              
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 28, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.0, valfim = 0.019, texto = "Un poco mareado" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 29, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.019, valfim = 0.04, texto = "acogedor y relajado" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 30, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.04, valfim = 0.09, texto = "falta de coordinación (legalmente borracho)"});
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 31, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.09, valfim = 0.014, texto = "apagón posible (pérdida de memoria)" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 32, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.14, valfim = 0.19, texto = "Sientes confundido y aturdido" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 33, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.19, valfim = 0.24, texto = "emocional y físicamente adormecido" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 34, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.24, valfim = 0.29, texto = "Puede estár borracho!" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 35, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.29, valfim = 0.34, texto = "Es probable que entre en coma" });
                ListaFrases.Add(new Frases() { ativo = 1, codigo = 36, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", valini = 0.34, valfim = 9.99, texto = "Llamar a un taxi" });         


             
            }


           

            for (int i = 0; i <= ListaFrases.Count - 1; i++)
            {
                DateTime monta = Convert.ToDateTime(ListaFrases[i].datfim);
                float diferenca = DateTime.Compare(DateTime.Today, monta);

                if (diferenca > 0)
                {
                    ListaFrases[i].ativo=0;
                }

            }



            /*
            for (int i = 0; i <= 5; i++)
             {
                 ListaKaraka.Add(new Karaka() { seq=i, tipo = 0, foto = "", album = "",videologo="" });
             }
            

            





            if (store.FileExists("filmes.xml"))
            {
                ListaFilmes = GravaIS.IsolatedStorageCacheManager<List<Filmes>>.Retrieve("filmes.xml");
            }
            else
            {
                ListaFilmes.Add(new Filmes() { ativo = 1, codigo = 200, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-BR", lati = "1", longi = "1", raio = "40075000", URI = "x-LzUNuTZqA" });
                ListaFilmes.Add(new Filmes() { ativo = 1, codigo = 100, datini = "2012/09/27", datfim = "2012/11/01", idioma = "en-US", lati = "1", longi = "1", raio = "40075000", URI = "MZtDqpdvy7s" });
                ListaFilmes.Add(new Filmes() { ativo = 1, codigo = 1, datini = "2012/09/27", datfim = "2050/11/01", idioma = "default", lati = "1", longi = "1", raio = "40075000", URI = "xO53rQ9nqQs" });
                ListaFilmes.Add(new Filmes() { ativo = 1, codigo = 300, datini = "2012/09/27", datfim = "2012/11/01", idioma = "es-ES", lati = "1", longi = "1", raio = "40075000", URI = "DOpej1RPdAA" });
                ListaFilmes.Add(new Filmes() { ativo = 1, codigo = 400, datini = "2012/09/27", datfim = "2012/11/01", idioma = "pt-PT", lati = "1", longi = "1", raio = "40075000", URI = "LAIQKn3VKKk" });

            }




            for (int i = 0; i <= ListaFilmes.Count - 1; i++)
            {
                DateTime monta = Convert.ToDateTime(ListaFilmes[i].datfim);
                float diferenca = DateTime.Compare(DateTime.Today, monta);

                if (diferenca > 0)
                {
                    ListaFilmes[i].ativo = 0;
                }

            }



            */
            











            //    ZeraShot();

                //     for (int i = 0; i <= 6; i++)
                //     {
                //         ListaShot.Add(new Shot() { datahoje = DateTime.Today.ToString("MM/dd/yyyy"), bebida = "", imagem = new Image(), shots=0, ml=0,gravou=0, marca="",local="" });
                //     }











          /* 



            XDocument loadedDataBebi = XDocument.Load("SampleData/bebidas.xml");
            var dataBebi = from query in loadedDataBebi.Descendants("Bebida")
                           select new Bebidas
                           {
                               Nome = (string)query.Element("Nome"),
                               img = (string)query.Element("img"),
                               dose_ml = (double)query.Element("dose"),
                               garrafa = (string)query.Element("garrafa"),
                               teor = (double)query.Element("teor"),
                           };




            ListaBebidas = dataBebi.ToList();

            foreach (Bebidas x in ListaBebidas)
            {

                Uri uri = new Uri(x.garrafa, UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                x.img_garrafa = imgSource;

                string ima = x.img.Replace("_03.png", "_00.png");

                Uri uri1 = new Uri(ima, UriKind.Relative);
                ImageSource imgSource1 = new BitmapImage(uri1);
                x.img_copo = imgSource1;

                


            }

            */
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
           


        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            MyToolkit.Networking.NetworkStateTracker.Stop();
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {


            /*

            if ((Application.Current as App).IsTrial)
            {
                Conf[0].conta_trial = Conf[0].conta_trial + 1;
            }
            else
            {
                Conf[0].conta_trial = 0;
            }
            */


            MyToolkit.Networking.NetworkStateTracker.Stop();

            if (store.FileExists("configuracao.xml"))
            {
                store.DeleteFile("configuracao.xml");
            }
            Conf[0].GoogleRadius = wRadius;
            Conf[0].HorizontalAjuste = wHorizontal;
            GravaIS.IsolatedStorageCacheManager<List<configuracao>>.Store("configuracao.xml", Conf);


             if (store.FileExists("locaisusu.xml"))
            {
                store.DeleteFile("locaisusu.xml");
            }
             GravaIS.IsolatedStorageCacheManager<List<locais>>.Store("locaisusu.xml", LocaisUsu);




             if (store.FileExists("locaisgoogle.xml"))
             {
                 store.DeleteFile("locaisgoogle.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<locais>>.Store("locaisgoogle.xml", LocaisGoogle);





/*
             if (App.bebida != null)
             {

                 App.PoeLocalShots(App.LocID, App.LocName);


             }
            */


             if (store.FileExists("shots.xml"))
             {
                 store.DeleteFile("shots.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<Shot>>.Store("shots.xml",  ListaShot);





             if (store.FileExists("omarcas.xml"))
             {
                 store.DeleteFile("omarcas.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<OMarcas>>.Store("omarcas.xml", LOutras);


             if (store.FileExists("dmarcas.xml"))
             {
                 store.DeleteFile("dmarcas.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<OMarcas>>.Store("dmarcas.xml", LDelete);

             if (store.FileExists("qrcode.xml"))
             {
                 store.DeleteFile("qrcode.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<qrpromocao>>.Store("qrcode.xml", QRPromocao);

            
             if (store.FileExists("frases.xml"))
             {
                 store.DeleteFile("frases.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<Frases>>.Store("frases.xml", ListaFrases);



             if (store.FileExists("filmes.xml"))
             {
                 store.DeleteFile("filmes.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<Filmes>>.Store("filmes.xml", ListaFilmes);
            




             if (store.FileExists("medalhas.xml"))
             {
                 store.DeleteFile("medalhas.xml");
             }
             GravaIS.IsolatedStorageCacheManager<List<medalhas>>.Store("medalhas.xml", ListaMedalhas);



        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}