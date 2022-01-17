using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjectKomik
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Login(string username, string password);
        [OperationContract]
        string Register(string username, string password, string kategori);
        [OperationContract]
        string UpdateRegister(string username, string password, string kategori, int id);
        [OperationContract]
        string DeleteRegister(string username);
        [OperationContract]
        List<DataRegister> DataRegist();

        [OperationContract]
        string peminjaman(string IDPeminjaman, string TanggalPeminjaman, int Harga, string IDKomik); //method //proses input data 
        [OperationContract]
        string editPeminjaman(string IDPeminjaman, string TanggalPeminjaman, int Harga, string IDKomik);
        [OperationContract]
        string deletePeminjaman(string IDPeminjaman);
        [OperationContract]
        List<Peminjaman> Peminjaman();

        [OperationContract]
        string Komik(string IDKomik, string JudulKomik, string Pengarang, string Tahun);
        [OperationContract]
        string editKomik(string IDKomik, string JudulKomik, string Pengarang, string Tahun);
        [OperationContract]
        string hapusKomik(string IDKomik);
        List<Komik> Komik();


        // TODO: Add your service operations here
    }

    [DataContract]
    public class Komik
    {
        [DataMember]
        public string IDKomik { get; set; }
        [DataMember]
        public string JudulKomik { get; set; }
        [DataMember]
        public string Pengarang { get; set; }
        [DataMember]
        public string Tahun { get; set; }
    }

    [DataContract]
    public class Peminjaman
    {
        [DataMember]
        public string IDPeminjaman { get; set; }
        [DataMember]
        public string TanggalPeminjaman { get; set; }
        [DataMember]
        public int Harga { get; set; }
        [DataMember]
        public string JudulKomik { get; set; }
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }

    // TODO: Add your service operations here
}

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ProjectKomik.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


