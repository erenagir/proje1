namespace Proje1.UI.Models
{
    public enum OfferStatus
    {
        pending = 1,//bekleme
        approved,//onaylandı
        refuse,//ret 

    }
    public enum Status
    {
        pending = 1,//bekleme
        approved,//onaylandı
        refuse,//ret
        ordered,
        Completed//tamamlandı
    }
    public enum Roles
    {
        admin = 1,
        request,
        recive,
        accounting,
        management


    }

}
