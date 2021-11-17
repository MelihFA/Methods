// See https://aka.ms/new-console-template for more information
class Personel
{
    public long TC { get; private set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public Personel(long tc,string name,string address,string phone)
    {
        this.TC = tc;
        this.Name = name;
        this.Address = address;
        this.Phone = phone;
    }

    public string ToString ()
    {
        return $"{TC},{Name},{Address},{Phone}";
    }
}
class Program
{
     List<Personel> PersonelList = new List<Personel>();

    private void PersonelEkle(long tc, string name, string address, string phone)
    {
        Personel p = new Personel(tc,name,address,phone);
        PersonelList.Add(p);
    }
    private bool PersonelSil(long tc)
    {
        for (int i = 0; i < PersonelList.Count; i++)
        {
            Personel p = PersonelList[i];
            if (p.TC == tc)
            {
                PersonelList.Remove(p);
                return true;
            }

        }
        return false;
    }
    private string PersonelGuncelle(long tc, string name="", string address="", string phone="")
    {
        for (int i = 0; i < PersonelList.Count; i++)
        {
            Personel p = PersonelList[i];
            if (p.TC == tc)
            {
                string personelinfo = p.ToString();
                if (name != "")
                {
                    p.Name = name;
                }
                if (address != "")
                {
                    p.Address = address;
                }
                if(!string.IsNullOrEmpty(phone))
                {
                    p.Phone = phone;
                }
                personelinfo += "\n"+p.ToString();
                return personelinfo;
            }

        }
        return "Güncelleme yok";
    }
    private string PersonelAra (long tc=0, string name = "", string address = "", string phone = "")
    {
        for (int i = 0; i < PersonelList.Count; i++)
        {
            Personel p = PersonelList[i];
            if (p.TC == tc || p.Name== name||p.Address==address||p.Phone==phone)
            {
                return p.ToString();
            }
        }
        return "Personel bulunamadı!";
    }
    static void Main(string[] args)
    {
        Program program = new Program();
        program.PersonelEkle(1, "ahmet", "istanbul", "123");
        program.PersonelEkle(2, "melih", "istanbul", "124");
        program.PersonelEkle(3, "sinem", "istanbul", "125");
        string personel = program.PersonelAra(tc : 1);
        Console.WriteLine(personel);
        program.PersonelSil(tc: 1);
        personel = program.PersonelAra(tc: 1);
        Console.WriteLine(personel);
        personel = program.PersonelGuncelle(tc: 2, name: "melih furkan");
        Console.WriteLine(personel);
    }
}
