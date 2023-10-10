namespace Proje1.UI.Models
{
    public enum Roles
    {
        Admin = 1,
        Request,
        Recive,
        Accounting,
        Management


    }
    public enum Status
    {
        pending = 1,//bekleme
        approved,//onaylandı
        refuse,//ret 
        Completed//tamamlandı
    }
}
