namespace Proje1.UI.Models
{
    public enum Roles
    {
        admin = 1,
        request,
        recive,
        accounting,
        management


    }
    public enum Status
    {
        pending = 1,//bekleme
        approved,//onaylandı
        refuse,//ret 
        Completed//tamamlandı
    }
}
